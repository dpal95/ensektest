namespace ensektest.Models
{
    public class CustomerAccountModel
    {
        public CustomerAccountModel(int accountId, string firstName, string lastName) 
        { 
            AccountId = accountId;
            Firstname = firstName;
            LastName = lastName;
        }

        public int AccountId { get; set; }

        public string Firstname { get; set; }

        public string LastName { get; set; }

    }
}
