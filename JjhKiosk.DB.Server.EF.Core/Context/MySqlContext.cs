using JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.DB.Server.EF.Core.Context
{
    public class MySqlContext : JjhKioskDbContext
    {
        public MySqlContext(IConfiguration configuration) : base(configuration)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string? connectionString = _configuration.GetConnectionString("JjhKioskDB");
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
    }
}
