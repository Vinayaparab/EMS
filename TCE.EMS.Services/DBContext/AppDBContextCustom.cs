using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TCE.EMS.Services.DBContext
{
    public partial class AppDBContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = new LoggerFactory().AddFile(Directory.GetCurrentDirectory() + "\\Temp\\Logs\\EFCoreLog\\Log.txt", LogLevel.Trace);
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot config = builder.Build();

                string mConnStr = config.GetConnectionString("AppDB");

                if (config.GetSection("AppSettings").GetSection("Debug_IsEnabled").Value == "Y")
                {
                    optionsBuilder.UseLoggerFactory(loggerFactory);
                    optionsBuilder.EnableSensitiveDataLogging();
                    optionsBuilder.EnableDetailedErrors(true);
                }

                optionsBuilder.UseSqlServer(mConnStr);
            }
        }
    }
}
