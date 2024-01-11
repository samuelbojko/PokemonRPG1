using System;
using System.Security.Cryptography.X509Certificates;
using PokemonRPG.BattleManager;
using PokemonRPG.StarterPokemon;

namespace PokemonRPG.StarterPokemon { }

public class Program
{
    public static void Main(string[] args)
    {

        string title = "  _____      _                              _____  _____   _____ \r\n |  __ \\    | |                            |  __ \\|  __ \\ / ____|\r\n | |__) |__ | | _____ _ __ ___   ___  _ __ | |__) | |__) | |  __ \r\n |  ___/ _ \\| |/ / _ \\ '_ ` _ \\ / _ \\| '_ \\|  _  /|  ___/| | |_ |\r\n | |  | (_) |   <  __/ | | | | | (_) | | | | | \\ \\| |    | |__| |\r\n |_|   \\___/|_|\\_\\___|_| |_| |_|\\___/|_| |_|_|  \\_\\_|     \\_____|\r\n                                                                 \r\n                                                                 ";
        Console.WriteLine(title);
        Console.WriteLine("");
        Console.WriteLine("Pick your starting pokemon here");
        Console.WriteLine("1)   Bulbasaur");
        Console.WriteLine("2)   Charmander");
        Console.WriteLine("3)   Squirtle");


        ConsoleKeyInfo pokemonSelect = Console.ReadKey();

        bool pokemonSelected = false;
        Pokemon selectedPokemon = null;

        if (pokemonSelect.KeyChar == '1')
        {
            PickBulbasaur();
            
            selectedPokemon = new Pokemon("Bulbasaur", 120, 50, 1);

        }
        else if (pokemonSelect.KeyChar == '2')
        {
            PickCharmander();
            
            selectedPokemon = new Pokemon("Charmander", 100, 70, 1);


        }
        else if (pokemonSelect.KeyChar == '3')
        {
            PickSquirtle();
            
            selectedPokemon = new Pokemon("Squirtle", 110, 60, 1);

        }
        else
        {
            Console.WriteLine("Invalid choice");
            
        }


        static void PickBulbasaur()
        {

            Console.WriteLine("You picked Bulbasaur , grass type Pokemon, Great choice! Now go and search for new pokemon!");
            Console.WriteLine("Where would you like to go? In each locotions theres different pokemon");
        }

        static void PickCharmander()
        {
            Console.WriteLine("You picked Charmander , fire type Pokemon. Great choice! Now go and search for new pokemon!");
            Console.WriteLine("Where would you like to go? In each locotions theres different pokemon");
        }

        static void PickSquirtle()
        {
            Console.WriteLine("You picked Squirtle , water type Pokemon. Great choice! Now go and search for new pokemon!");
            Console.WriteLine("Where would you like to go? In each locotions theres different pokemon");
        }



        List<Location> locations = new List<Location>
        {
            new Location("Viridian forest", new List<Pokemon>
            {
                new Pokemon("Caterpie" , 50 , 10 , 1),
                new Pokemon("Pidgey" , 70 , 30 , 1),
                new Pokemon("Rattata" , 60 , 25 ,1)
            }),
            new Location("Mt.Moon", new List<Pokemon>
            {
                new Pokemon("Jigglypuff" , 40 , 20 ,1),
                new Pokemon("Vulpix" , 60 , 30 ,1),
                new Pokemon("Clefairy" , 60 , 30 ,1)
            }),
            new Location("Diglett's cave", new List<Pokemon>
            {
                new Pokemon("Diglett" , 45 , 15 ,1),
                new Pokemon("Dugtiro" , 50 , 20 ,1),
                new Pokemon("Zubat" , 30 , 20 ,1) ,
                
                 

            })

        };

        Console.WriteLine("Choose a location to explore. In each location there is different Pokemo");

        for (int i = 0; i < locations.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {locations[i].Name}");
        }

        ConsoleKeyInfo key = Console.ReadKey();
        int locationIndex = int.TryParse(key.KeyChar.ToString() , out var result) ? result : 0;

        if (locationIndex >= 0 && locationIndex <= locations.Count)
        {
            Location selectedLocation = locations[locationIndex - 1];
            Console.WriteLine($"Let's explore {selectedLocation.Name}");

            Pokemon wildPokemon = selectedLocation.GetRandomEnemy();
            Console.WriteLine($"a wild {wildPokemon.Name} appeared!");

            while(selectedPokemon.Health > 0 && wildPokemon.Health > 0)
            {
                Console.WriteLine("Choose action");
                Console.WriteLine("1)  Use Potion");
                Console.WriteLine("2)  Attack");
                Console.WriteLine($"3)  Catch {wildPokemon.Name}");

                ConsoleKeyInfo action = Console.ReadKey();

                switch (action.KeyChar)
                {
                    case '1' :
                        selectedPokemon.Heal(selectedPokemon);
                        break;

                    case '2':
                        selectedPokemon.Attack(wildPokemon);
                        break;

                    case '3':
                        selectedPokemon.Catch(wildPokemon);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                if (wildPokemon.Health > 0)
                {
                    wildPokemon.Attack(selectedPokemon);
                }

            }

        }

        


    }
}