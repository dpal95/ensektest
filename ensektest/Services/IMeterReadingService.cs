using CsvHelper;
using CsvHelper.Configuration;
using ensektest.Entities;
using ensektest.Models;
using ensektest.Responces;
using System;
using System.Formats.Asn1;
using System.Globalization;

namespace ensektest.Services
{
    public interface IMeterReadingService
    {
        public CsvReadResponse ReadCsvFile(string filePath);
        public CsvReadResponse ReadAccountCsvFile(string filePath);

        public MeterReadingResponse SaveMeterReading(CsvReadResponse csvReadResponse);

    }


}
