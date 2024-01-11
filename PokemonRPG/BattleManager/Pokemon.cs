using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRPG.BattleManager
{
    public class Pokemon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Level { get; set; }

        public List<string> caughtPokemons { get; set; } = new List<string>();


        public Pokemon(string name, int health, int attackpower, int level)
        {
            Name = name;
            Health = health;
            AttackPower = attackpower;
            Level = level;

        }

        public void Attack(Pokemon wildPokemon)
        {
            Console.WriteLine($"{Name} is attacking {wildPokemon.Name}!");

            int damage = AttackPower;
            wildPokemon.Health -= damage;

            Console.WriteLine($"{wildPokemon.Name} took {damage} damage.");
        }

        public void Heal(Pokemon selectedPokemon)
        {
            selectedPokemon.Health += 20;
            Console.WriteLine("You used Potion (+20 HP)");
        }

        public void Catch(Pokemon wildPokemon)
        {


            int catchAttempts = 3;
             
            if (wildPokemon.Health <= 10)
            {
                Random random = new Random();
                int catchChance = random.Next(1, 101);

                if (catchChance <= 70 && catchAttempts > 0)
                {
                    string caughtPokemon = wildPokemon.Name;
                    caughtPokemons.Add(caughtPokemon);
                    wildPokemon.Health = 0;
                    Console.WriteLine($"You successfully caught {wildPokemon.Name}");
                }
                else
                {
                    Console.WriteLine("Catch attempt failed.");
                    catchAttempts--;

                    if (catchAttempts == 0)
                    {
                        Console.WriteLine("You ran out of Pokeballs");
                    }

                }
            }
            else
            {
                Console.WriteLine($"{wildPokemon.Name}'s Health is too hight to catch");
            }



        }


    }
}
