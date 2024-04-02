using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;

namespace Teste2.Models
{
    public class Pokedex
    {
        public List<Pokemon> PokemonRegistered { get; set; }

        public List<RegionalPokedex> RegionalPokedex { get; set; }

        public bool IsInTheGlobal(Pokemon pokemon)
        {

            bool isInTheGlobal = false;
            foreach (Pokemon registeredPokemon in PokemonRegistered)

            {
                if (registeredPokemon.Name.Contains(pokemon.Name))
                    isInTheGlobal = true;
            }
            if (isInTheGlobal)
            {
                Console.WriteLine("The pokemon is already in the global pokedex.");
                Console.ReadKey();
                Console.Clear();
            }
            else
                PokemonRegistered.Add(pokemon);
            return isInTheGlobal;
        }

        public void ShowGlobalPokedex()
        {
            int count = 0, count2 = 0, count3 = 0;
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
                    if (RegionalPokedex[count].RegionalAreas == null)
                    {
                        int count1 = 0, count2 = 0, count3 = 0;
                        Console.WriteLine($"===============\n{RegionalPokedex[count].RegionalPokedexName.ToUpper()} POKEDEX\n===============");
                        for (int countRegionalPokemons = 0; countRegionalPokemons < RegionalPokedex[count].RegionalPokemon.Count; countRegionalPokemons++)
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
                    else
                    {
                        string[] countAreasOptions = new string[RegionalPokedex[count].RegionalAreas.Length];
                        for (int countAreas = 0; countAreas < RegionalPokedex[count].RegionalAreas.Length; countAreas++)
                        {
                            Console.WriteLine($"{countAreas + 1}. {RegionalPokedex[count].RegionalAreas[countAreas]}");
                            countAreasOptions[countAreas] = Convert.ToString(countAreas + 1);
                        }
                        string readAreaResult = Console.ReadLine();
                        int count1 = 0, count2 = 0, count3 = 0;
                        for (int countAreas = 0; countAreas < RegionalPokedex[count].RegionalAreas.Length; countAreas++)
                            if (readAreaResult == countAreasOptions[countAreas])
                            {
                                Console.WriteLine($"===============\n{RegionalPokedex[count].RegionalPokedexName.ToUpper()} POKEDEX\n===============");
                                Console.WriteLine($"===============\n{RegionalPokedex[count].RegionalAreas[countAreas].ToUpper()} AREA\n===============");
                                for (int countPokemons = 0; countPokemons < PokemonRegistered.Count; countPokemons++)
                                {
                                    if (!(PokemonRegistered[countPokemons].RegionalAreas == null))
                                        if (PokemonRegistered[countPokemons].RegionalAreas.Contains(RegionalPokedex[count].RegionalAreas[countAreas]))
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

                                            Console.WriteLine($"No.{count1}{count2}{count3} {PokemonRegistered[countPokemons].Name}");
                                        }
                                }
                            }
                    }
            }
            Console.ReadKey();
            Console.Clear();
        }

        public string RegisterPokemonInRegionalArea(string readAreaResult, string[] countAreasOptions, string regionName)
        {
            for (int count1 = 0; count1 < RegionalPokedex.Count; count1++)
                if (regionName == RegionalPokedex[count1].RegionalPokedexName)
                    for (int count = 0; count < countAreasOptions.Length; count++)
                    {
                        if (readAreaResult == countAreasOptions[count])
                            return RegionalPokedex[count1].RegionalAreas[count];
                    }
            return "";
        }

        public void OrganizePokedex()
        {
            Console.WriteLine("1. Global");
            List <string> countRegionalPokedex = RegionalPokedexList();
            string readResult = Console.ReadLine();
            if (readResult == "1")
            {
                ShowGlobalPokedex();
                Console.WriteLine("Enter the pokemon pokedex number to change: ");
                readResult = Console.ReadLine();
                int validateInteger = 0;
                if (int.TryParse(readResult, out validateInteger))
                {
                    int count = 0, count2 = 0, count3 = 0;
                    int pokemonPlace = 0;
                    Pokemon temporaryPlace = null;
                    for (int i = 0; i < PokemonRegistered.Count; i++)
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
                        string pokedexNumber = count.ToString() + count2.ToString() + count3.ToString();
                        if (readResult == pokedexNumber)
                        {
                            temporaryPlace = PokemonRegistered[i];
                            pokemonPlace = i;
                        }
                    }
                    Console.WriteLine("\nEnter the pokedex number intended to put the pokemon choosen: ");
                    readResult = Console.ReadLine();
                    Console.Clear();
                    if (int.TryParse(readResult, out validateInteger))
                        count = 0; count2 = 0; count3 = 0;
                    for (int i = 0; i < PokemonRegistered.Count; i++)
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
                        string pokedexNumber = count.ToString() + count2.ToString() + count3.ToString();
                        if (readResult == pokedexNumber)
                        {
                            PokemonRegistered[pokemonPlace] = PokemonRegistered[i];
                            PokemonRegistered[i] = temporaryPlace;
                        }
                    }
                }
                else
                    Console.WriteLine("A number from the pokedex must be provided.");
            }
        }
        public List<string> RegionalPokedexList(bool pokedexListHasNoGlobal = false)
        {
            int countOptions = 2;
            List<string> countRegionalPokedex = new List<string>();
            if (pokedexListHasNoGlobal)
                countOptions = 1;
            foreach (RegionalPokedex regional in RegionalPokedex)
            {
                Console.WriteLine($"{countOptions}. {regional.RegionalPokedexName}");
                countRegionalPokedex.Add(Convert.ToString(countOptions));
                countOptions++;
            }
            return countRegionalPokedex;
        }
    }
}