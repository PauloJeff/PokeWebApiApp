using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PokeWebApiApp.Models;

namespace PokeWebApiApp.Services
{
    public class DatabaseManagementService
    {
        public static void MigrationInitialization(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<PokemonContext>().Database.Migrate();
            }
        }
    }
}
