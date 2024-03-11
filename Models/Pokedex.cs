using System;
using System.Runtime.CompilerServices;

namespace Teste2.Models
{
    public class Pokedex
    {
        public List<Pokemon> PokemonRegistered { get; set; }

        public List<RegionalPokedex> RegionalPokedex { get; set; }

        public void ShowGlobalPokedex()
        {
            int count = 0;
            int count2 = 0;
            int count3 = 0;
            Console.WriteLine("===================\nGLOBAL POKEDEX\n===================");
            foreach (Pokemon pokemons in PokemonRegistered)
            {

                if (count3 < 9)
                    count3++;
                else if (count2 < 9)
                {
                    count2++;
                    count3 = 0;
                }
                else
                {
                    count++;
                    count3 = 0;
                    count2 = 0;
                }
                Console.WriteLine($"\n===============\nNo.{count}{count2}{count3} {pokemons.Name}\n===============");
            }
        }
        public void RegisterRegionalPokedex(Pokemon pokemon, string regionName)
        {
            /*for (int count = 0; count < PokemonRegistered.Count; count++)
                if (!PokemonRegistered[count].Name.Contains(pokemon.Name))
                    PokemonRegistered.Add(pokemon);
            */
            bool isAlreadyInTheRegional = false;
            for (int count = 0; count < RegionalPokedex.Count; count++)
            {
                if (RegionalPokedex[count].RegionalPokedexName == regionName)
                {
                    if (!(RegionalPokedex[count].RegionalPokemon.Capacity == 0))
                    {
                        foreach (Pokemon regionalPokemons in RegionalPokedex[count].RegionalPokemon)
                            if (regionalPokemons.Name.Contains(pokemon.Name))
                                isAlreadyInTheRegional = true;
                        if (isAlreadyInTheRegional)
                            Console.WriteLine("The pokemon is already in the regional pokedex.");
                        else
                            RegionalPokedex[count].RegionalPokemon.Add(pokemon);
                    }
                    else
                        RegionalPokedex[count].RegionalPokemon.Add(pokemon);
                }
            }
        }

        public void ShowRegionalPokedex(string readResult, List<string> countRegionalPokedex)
        {
            for (int count = 0; count < RegionalPokedex.Count; count++)
            {
                if (readResult == countRegionalPokedex[count])
                {
                    int count1 = 0, count2 = 0, count3 = 0;
                    Console.WriteLine($"===============\n{RegionalPokedex[count].RegionalPokedexName.ToUpper()} POKEDEX\n===============");
                    for(int countRegionalPokemons = 0; countRegionalPokemons < RegionalPokedex[count].RegionalPokemon.Count; countRegionalPokemons++)
                    {
                    if (count3 < 9)
                        count3++;
                    else if (count2 < 9)
                    {
                        count2++;
                        count3 = 0;
                    }
                    else
                    {
                        count1++;
                        count2 = 0;
                        count3 = 0;
                    }
                    
                        Console.WriteLine($"No.{count1}{count2}{count3} {RegionalPokedex[count].RegionalPokemon[countRegionalPokemons].Name}");
                    }
                    
                }
            }
        }
    }
}