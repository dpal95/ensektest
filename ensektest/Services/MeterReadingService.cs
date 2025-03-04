﻿using CsvHelper;
using CsvHelper.Configuration;
using ensektest.Entities;
using ensektest.Models;
using ensektest.Responces;
using System;
using System.Formats.Asn1;
using System.Globalization;

namespace ensektest.Services
{
    public class MeterReadingService
    {
        private bool IsValidReading(decimal reading)
        {
            if (reading < 0)
            {
                return false;
            }
            if (reading > 100000)
            {
                return false;
            }

            return true;
        }

        public MeterReadingResponse ReadCsvFile(string filePath)
        {
            MeterReadingResponse response = new MeterReadingResponse();
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


        //public MeterReadingResponse SaveMeterReading()
        //{

        //}

    }

public class MeterReadingMap : ClassMap<MeterReadingModel>
    {
        public MeterReadingMap()
        {
            Map(m => m.AccountId).Name("AccountId");
            Map(m => m.MeterReadingDateTime)
                .Name("MeterReadingDateTime")
                .TypeConverterOption.Format("dd/MM/yyyy HH:mm"); // Use correct date format
            Map(m => m.MeterReadValue).Name("MeterReadValue");
        }
    }

}
