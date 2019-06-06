using LoanManager.Core.DataInterface;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LoanManager.Data.EFCore
{
    public static class IServiceCollectionExtensions
    {


        public static void ConfigureSqlLiteDatabase(this IServiceCollection services, String connectionString)
        {
            // Configures the contest
            SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();

            services.AddDbContext<LoanCalculatorContext>(options =>
                options.UseSqlite(connection)
            );

            // Make sure the database exists
            DbContextOptionsBuilder<LoanCalculatorContext> builder = new DbContextOptionsBuilder<LoanCalculatorContext>();
            builder.UseSqlite(connection);

            using (LoanCalculatorContext context = new LoanCalculatorContext(builder.Options))
            {
                context.Database.EnsureCreated();
            }
        }


        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILoanRateRepository, LoanRateRepository>();
            services.AddScoped<ILoanApplicationResultRepository, LoanApplicationResultRepository>();
        }


    }
}
