using Lotographia.Functions.Data;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Lotographia.Functions.Startup))]
namespace Lotographia.Functions
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<LotographiaContext>(options => 
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LotographiaContext;Trusted_Connection=True;MultipleActiveResultSets=true"));
        }
    }
}
