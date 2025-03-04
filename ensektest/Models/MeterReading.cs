namespace ensektest.Models
{
    public class MeterReading
    {
        public MeterReading(string accountId, DateTime meterReadingDateTime, decimal meterReadValue) 
        { 
            AccountId = accountId;
            MeterReadingDateTime = meterReadingDateTime;
            MeterReadValue = meterReadValue;
        }

        public string AccountId { get; set; }

        public DateTime MeterReadingDateTime { get; set; }

        public decimal MeterReadValue { get; set; }

    }
}
