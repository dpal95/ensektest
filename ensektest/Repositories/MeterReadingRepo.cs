using CsvHelper;
using CsvHelper.Configuration;
using ensektest.Context;
using ensektest.Entities;
using ensektest.Models;
using ensektest.Responces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;

namespace ensektest.Repositories
{
    public class MeterReadingRepo : IMeterReadingRepo
    {    
        private readonly DataContext _dbContext;
        public MeterReadingRepo(DataContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public bool SaveMeterReading(MeterReading meterReading)
        {
            try
            {
                _dbContext.MeterReadings.Add(meterReading);

                    return true;

                
            }
            catch
            {
                return false;
            }
        }

        public CustomerAccount? GetCustomerAccount(int accountNum)
        {
          
                return _dbContext.CustomerAccounts.FirstOrDefault(x => x.AccountId == accountNum);
           
        }

        public bool CheckForReading(decimal readValue, int accountNum)
        {
          
                return _dbContext.MeterReadings.Any(x => x.MeterReadValue == readValue && x.AccountId == accountNum);
            
        }

    }

}
