using System.ComponentModel.DataAnnotations;

namespace ensektest.Entities
{
    public class CustomerAccount
    {
        [Key]
        [MaxLength(50)]
        public int AccountId { get; set; }
        [MaxLength(50)]
        public string Firstname { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }

        public IEnumerable<MeterReading> MeterReadings { get; set; }
    }
}
