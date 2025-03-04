using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ensektest.Entities
{
    public class MeterReading
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public int AccountId { get; set; }
        [MaxLength(50)]
        public DateTime MeterReadingDateTime { get; set; }
        [MaxLength(50)]
        public decimal MeterReadValue { get; set; }

    }
}
