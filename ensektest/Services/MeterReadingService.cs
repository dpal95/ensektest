using Azure;
using CsvHelper;
using CsvHelper.Configuration;
using ensektest.Entities;
using ensektest.Mapper;
using ensektest.Models;
using ensektest.Repositories;
using ensektest.Responces;
using System;
using System.Formats.Asn1;
using System.Globalization;
using System.Security.Cryptography.Xml;

namespace ensektest.Services
{
    public class MeterReadingService : IMeterReadingService
    {
        public readonly IMeterReadingRepo _meterReadingRepo;
        public MeterReadingService(IMeterReadingRepo meterReadingRepo)
        {
            _meterReadingRepo = meterReadingRepo;

        }
        private bool IsValidReading(decimal reading)
        {
            if (reading < 0 || reading > 10000)
            {
                return false;
            }      
            return true;
        }

        public CsvReadResponse ReadCsvFile(string filePath)
        {
            CsvReadResponse response = new CsvReadResponse();
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",", // Ensure it matches your CSV delimiter
                    HasHeaderRecord = true, // If your CSV has headers
                    MissingFieldFound = null, // Prevent errors for missing fields
                    HeaderValidated = null // Ignore incorrect headers
                };
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, config))
                {
                    while (csv.Read())
                    {
                        try
                        {

                            csv.Context.RegisterClassMap<MeterReadingMap>(); // Register the custom mapping

                            MeterReadingModel record = csv.GetRecord<MeterReadingModel>();
                            if (IsValidReading(record.MeterReadValue))
                                response.SuccessReadings.Add(record);
                            else
                            {
                                response.FailureReadings++;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                            response.FailureReadings++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return response;
        }

        public CsvReadResponse ReadAccountCsvFile(string filePath)
        {
            CsvReadResponse response = new CsvReadResponse();
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",", // Ensure it matches your CSV delimiter
                    HasHeaderRecord = true, // If your CSV has headers
                    MissingFieldFound = null, // Prevent errors for missing fields
                    HeaderValidated = null // Ignore incorrect headers
                };
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, config))
                {

                    try
                    {
                        var records = csv.GetRecords<CustomerAccount>();

                        _meterReadingRepo.SaveSeedData(records);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        response.FailureReadings++;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return response;
        }


        public MeterReadingResponse SaveMeterReading(CsvReadResponse csvReadResponse)
        {
            MeterReadingResponse response = new MeterReadingResponse() { FailureReadings = csvReadResponse.FailureReadings};

            foreach (var meterReading in csvReadResponse.SuccessReadings)
            {              

                var checkAccount = GetCustomerAccount(meterReading.AccountId);

                if (checkAccount != null)
                {
                    if (!CheckForReading(meterReading.MeterReadValue, meterReading.AccountId))
                    {
                        MeterReading meterWrite = new MeterReading()
                        {
                            AccountId = meterReading.AccountId,
                            MeterReadingDateTime = meterReading.MeterReadingDateTime,
                            MeterReadValue = meterReading.MeterReadValue,
                        };
                        _meterReadingRepo.SaveMeterReading(meterWrite);//save reading 

                        response.SuccessReadings++;
                        continue;
                    };

                }
                response.FailureReadings++;
            }

            return response;
        }

        private CustomerAccountModel? GetCustomerAccount(int accountNum)
        {
            var account = _meterReadingRepo.GetCustomerAccount(accountNum);

            if (account != null)
            {
                return new CustomerAccountModel(account.AccountId, account.FirstName, account.LastName);
            }
            else
                return null;
        }

        private bool CheckForReading(decimal readValue, int accountNum)
        {
            return _meterReadingRepo.CheckForReading(readValue, accountNum);
        }

    }

}
