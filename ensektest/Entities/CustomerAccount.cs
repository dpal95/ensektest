using System.ComponentModel.DataAnnotations;

namespace ensektest.Entities
{
    public class CustomerAccount
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public int AccountId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }

    }
}
