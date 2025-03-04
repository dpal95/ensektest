namespace ensektest.Models
{
    public class MeterReadingModel
    {
        public MeterReadingModel() { }   
        public MeterReadingModel(int accountId, DateTime meterReadingDateTime, decimal meterReadValue) 
        { 
            AccountId = accountId;
            MeterReadingDateTime = meterReadingDateTime;
            MeterReadValue = meterReadValue;
        }

        public int AccountId { get; set; }

        public DateTime MeterReadingDateTime { get; set; }

        public decimal MeterReadValue { get; set; }

    }
}
