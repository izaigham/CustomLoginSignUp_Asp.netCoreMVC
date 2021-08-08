using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OCS_TEST_PHASE.Data;

[assembly: HostingStartup(typeof(OCS_TEST_PHASE.Areas.Identity.IdentityHostingStartup))]
namespace OCS_TEST_PHASE.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<OCSDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("OCSDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<OCSDbContext>();
            });
        }
    }
}