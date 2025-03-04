namespace ensektest.Context
{
    using ensektest.Entities;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MeterReading> MeterReadings { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }


    }
}
