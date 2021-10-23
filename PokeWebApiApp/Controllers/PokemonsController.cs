using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeWebApiApp.Models;

namespace PokeWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        private readonly PokemonContext _context;

        public PokemonsController(PokemonContext context)
        {
            _context = context;
        }

        // GET: api/Pokemons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemonItems()
        {
            return await _context.PokemonItems.ToListAsync();
        }

        // GET: api/Pokemons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(int id)
        {
            var pokemon = await _context.PokemonItems.FindAsync(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return pokemon;
        }

        // PUT: api/Pokemons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPokemon(int id, Pokemon pokemon)
        {
            if (id != pokemon.ID)
            {
                return BadRequest();
            }

            _context.Entry(pokemon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pokemons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pokemon>> PostPokemon(Pokemon pokemon)
        {
            _context.PokemonItems.Add(pokemon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPokemon", new { id = pokemon.ID }, pokemon);
        }

        // DELETE: api/Pokemons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var pokemon = await _context.PokemonItems.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }

            _context.PokemonItems.Remove(pokemon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PokemonExists(int id)
        {
            return _context.PokemonItems.Any(e => e.ID == id);
        }
    }
}
