using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PokeWebApiApp.Models
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {
        }

        public DbSet<Pokemon> PokemonItems { get; set; }
    }
}
