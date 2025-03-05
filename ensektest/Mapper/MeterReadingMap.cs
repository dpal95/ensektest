using CsvHelper.Configuration;
using ensektest.Models;

namespace ensektest.Mapper
{
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

