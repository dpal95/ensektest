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
    public interface IMeterReadingRepo
    {

        public bool SaveMeterReading(MeterReading meterReading);



        public CustomerAccount? GetCustomerAccount(int accountNum);



        public bool CheckForReading(decimal readValue, int accountNum);

        public void SaveSeedData(IEnumerable<CustomerAccount> customerAccounts);




    }

}
