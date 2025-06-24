//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;

//namespace DAL
//{
//    public class EventDbContextFactory : IDesignTimeDbContextFactory<EventDbContext>
//    {
//        public EventDbContext CreateDbContext(string[] args)
//        {
//            var config = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json")
//                .Build();

//            var optionsBuilder = new DbContextOptionsBuilder<EventDbContext>();
//            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

//            return new EventDbContext(optionsBuilder.Options);
//        }
//    }
//} 
