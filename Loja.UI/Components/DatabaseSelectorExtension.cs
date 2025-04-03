using Loja.Data.Context;
using Loja.UI.Configurations;
using Loja.UI.Data;
using Microsoft.EntityFrameworkCore;

namespace Loja.UI.Components
{
    public static class DatabaseSelectorExtension
    {
        public static void AddDatabaseSelector(this WebApplicationBuilder builder)
        {
            if (builder.Environment.IsDevelopment())
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionLite") ?? throw new InvalidOperationException("Connection string 'DefaultConnectionLite' not found.");
                builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlite(connectionString));
                builder.Services.AddDbContext<DataDbContext>(o => o.UseSqlite(connectionString));
            }
            else
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
                builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));
                builder.Services.AddDbContext<DataDbContext>(o => o.UseSqlServer(connectionString));
            }
        }
    }
}
