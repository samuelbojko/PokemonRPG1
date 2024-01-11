using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonRPG.BattleManager;

namespace PokemonRPG.StarterPokemon
{
    public class Location
    {
        public string Name { get; set; }
        public List<Pokemon> EnemyPokemons { get; set; }

        public Location(string name, List<Pokemon> enemyPokemons)
        {
            Name = name;
            EnemyPokemons = enemyPokemons;
        }

        public Pokemon GetRandomEnemy()
        {
            Random random = new Random();
            return EnemyPokemons[random.Next(EnemyPokemons.Count)];
        }
    }
}
