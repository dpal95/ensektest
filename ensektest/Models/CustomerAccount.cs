namespace ensektest.Models
{
    public class CustomerAccount
    {
        public CustomerAccount(string accountId, string firstName, string lastName) 
        { 
            AccountId = accountId;
            Firstname = firstName;
            LastName = lastName;
        }

        public string AccountId { get; set; }

        public string Firstname { get; set; }

        public string LastName { get; set; }

    }
}
