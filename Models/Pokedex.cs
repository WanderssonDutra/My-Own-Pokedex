using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace Teste2.Models
{
    public class Pokedex
    {
        public List<Pokemon> PokemonRegistered { get; set; }

        public List<RegionalPokedex> RegionalPokedex { get; set; }
        /// <summary>
        /// Verify if the pokemon is already at the global pokedex. Add the pokemon to the global pokedex if it's not registered there.
        /// </summary>
        /// <param name="pokemon">Pokemon to be verified by the method.</param>
        /// <returns>A boolean. True if it's at the global, otherwise it is false.</returns>
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
        /// <summary>
        /// Register a regional pokedex from the RegionalPokedex class in the RegionalPokedex List from the Pokedex class.
        /// </summary>
        /// <param name="pokemon">Pokemon to be added</param>
        /// <param name="regionName">The name of the regional pokedex. Used to properly add the pokemon to the right regional pokedex.</param>
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
        /// <summary>
        /// Show all pokemons from the regional pokedex.
        /// </summary>
        /// <param name="readResult">The number that matches the regional pokedex.</param>
        /// <param name="countRegionalPokedex">The total number of regional pokedex.</param>
        public void ShowRegionalPokedex(string readResult, List<string> countRegionalPokedex)
        {
            for (int count = 0; count < RegionalPokedex.Count; count++)
            {
                if (readResult == countRegionalPokedex[count])
                    //if the regional pokedex has no regional areas, show all pokemons from the regional pokedex. If there is regional areas, an else condition will ask the user to choose between the areas, then the pokedex will show the pokedex with the pokemons from that area.
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

                            Console.WriteLine($"\n===============\nNo.{count1}{count2}{count3} {RegionalPokedex[count].RegionalPokemon[countRegionalPokemons].Name}\n===============");
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
                                for (int countPokemonsInArea = 0; countPokemonsInArea < RegionalPokedex[count].PokemonsInAreas[countAreas].Count; countPokemonsInArea++)
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
                                    Console.WriteLine($"===============\nNo.{count1}{count2}{count3} {RegionalPokedex[count].PokemonsInAreas[countAreas][countPokemonsInArea].Name}\n===============");
                                }
                            }
                    }
            }
        }
        /// <summary>
        /// Register the pokemon in the choosen area.
        /// </summary>
        /// <param name="readAreaResult">The specified area to add the pokemon.</param>
        /// <param name="countAreasOptions">The total areas from the specified regional pokedex.</param>
        /// <param name="regionName">The name of the regional pokedex. Used to find the regional pokedex that matches the area.</param>
        /// <param name="pokemon">The pokemon to be added.</param>
        public void RegisterPokemonInRegionalArea(string readAreaResult, string[] countAreasOptions, string regionName, Pokemon pokemon)
        {
            for (int count1 = 0; count1 < RegionalPokedex.Count; count1++)
                if (regionName == RegionalPokedex[count1].RegionalPokedexName)
                {

                    for (int count = 0; count < countAreasOptions.Length; count++)
                    {
                        if (readAreaResult == countAreasOptions[count])
                        {
                            RegionalPokedex[count1].PokemonsInAreas[count].Add(pokemon);
                        }
                    }
                }
        }
        /// <summary>
        /// Organize the pokedex in the specified order choosen by the user.
        /// </summary>
        public void OrganizePokedex()
        {
            int validateInteger = 0;
            int pokemonPlace = 0;
            Pokemon temporaryPlace = null;
            Console.WriteLine("1. Global");
            List<string> countRegionalPokedex = RegionalPokedexList();
            string readResult = Console.ReadLine();
            ///switch the positions of the pokemons inside the registeredPokemon list at the global pokedex. Creates temporaries variables to store the pokemons and their original places number in the list to make the trade possible.
            if (readResult == "1")
            {
                ShowGlobalPokedex();
                Console.WriteLine("Enter the pokemon pokedex number to change: ");
                readResult = Console.ReadLine();
                if (int.TryParse(readResult, out validateInteger))
                {
                    int count = 0, count2 = 0, count3 = 0;
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
            ///switch the positions of the pokemons inside the specified regional pokedex pokemon list at the regional pokedex. Creates temporaries variables to store the pokemons and their original places number in the list to make the trade possible.
            else
            {
                for (int countRegional = 0; countRegional < RegionalPokedex.Count; countRegional++)
                {
                    if (readResult == countRegionalPokedex[countRegional])
                    {
                        if (RegionalPokedex[countRegional].PokemonsInAreas.Capacity == 0)
                        {
                            if (RegionalPokedex[countRegional].RegionalPokemon.Count < 2)
                                Console.WriteLine("Insuficient pokemons to organize.");
                            else
                            {
                                ShowRegionalPokedex(readResult, countRegionalPokedex);
                                Console.WriteLine("Enter the pokemon pokedex number to change: ");
                                readResult = Console.ReadLine();
                                if (int.TryParse(readResult, out validateInteger))
                                {
                                    int count = 0, count2 = 0, count3 = 0;
                                    for (int countRegionalPokemons = 0; countRegionalPokemons < RegionalPokedex[countRegional].RegionalPokemon.Count; countRegionalPokemons++)
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
                                            count2 = 0;
                                            count3 = 0;
                                        }
                                        string pokedexNumber = count.ToString() + count2.ToString() + count3.ToString();
                                        if (readResult == pokedexNumber)
                                        {
                                            temporaryPlace = RegionalPokedex[countRegional].RegionalPokemon[countRegionalPokemons];
                                            pokemonPlace = countRegionalPokemons;
                                        }
                                    }
                                    Console.WriteLine("\nEnter the pokedex number intended to put the pokemon choosen: ");
                                    readResult = Console.ReadLine();
                                    Console.Clear();
                                    count = 0; count2 = 0; count3 = 0;
                                    for (int countRegionalPokemons = 0; countRegionalPokemons < RegionalPokedex[countRegional].RegionalPokemon.Count; countRegionalPokemons++)
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
                                            count2 = 0;
                                            count3 = 0;
                                        }
                                        string pokedexNumber = count.ToString() + count2.ToString() + count3.ToString();
                                        if (readResult == pokedexNumber)
                                        {
                                            RegionalPokedex[countRegional].RegionalPokemon[pokemonPlace] = RegionalPokedex[countRegional].RegionalPokemon[countRegionalPokemons];
                                            RegionalPokedex[countRegional].RegionalPokemon[countRegionalPokemons] = temporaryPlace;

                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            List<string> countAreaOptions = new List<string>();
                            for (int countRegionalArea = 0; countRegionalArea < RegionalPokedex[countRegional].PokemonsInAreas.Count; countRegionalArea++)
                            {
                                Console.WriteLine($"{countRegionalArea + 1}. {RegionalPokedex[countRegional].RegionalAreas[countRegionalArea]}");
                                int options = countRegionalArea + 1;
                                countAreaOptions.Add(Convert.ToString(options));
                            }
                            readResult = Console.ReadLine();
                            
                            for (int countRegionalArea = 0; countRegionalArea < RegionalPokedex[countRegional].PokemonsInAreas.Count; countRegionalArea++)
                                if (readResult == countAreaOptions[countRegionalArea])
                                {
                                    Console.WriteLine($"===============\n{RegionalPokedex[countRegional].RegionalPokedexName.ToUpper()} POKEDEX\n===============");
                                    Console.WriteLine($"===============\n{RegionalPokedex[countRegional].RegionalAreas[countRegionalArea].ToUpper()} AREA\n===============");
                                    int count = 0, count2 = 0, count3 = 0;
                                    for (int countPokemonInArea = 0; countPokemonInArea < RegionalPokedex[countRegional].PokemonsInAreas[countRegionalArea].Count; countPokemonInArea++)
                                    {
                                        if (count3 < 9)
                                        {
                                            count3++;
                                        }
                                        else if (count2 < 9)
                                        {
                                            count2++;
                                        }
                                        else
                                        {
                                            count3 = 0;
                                            count2 = 0;
                                            count++;
                                        }
                                        Console.WriteLine($"===============\nNo.{count}{count2}{count3} {RegionalPokedex[countRegional].PokemonsInAreas[countRegionalArea][countPokemonInArea].Name}\n===============");
                                    }
                                }
                            Console.WriteLine("Enter the pokemon pokedex number to change: ");
                            string readPokemonPosition = Console.ReadLine();
                            for (int countAreas = 0; countAreas < RegionalPokedex[countRegional].PokemonsInAreas.Count; countAreas++)
                            {
                                if (readResult == countAreaOptions[countAreas])
                                {
                                    int count = 0, count2 = 0, count3 = 0;
                                    for (int countPokemonInArea = 0; countPokemonInArea < RegionalPokedex[countRegional].PokemonsInAreas[countAreas].Count; countPokemonInArea++)
                                    {
                                        if (count3 < 9)
                                        {
                                            count3++;
                                        }
                                        else if (count2 < 9)
                                        {
                                            count2++;
                                        }
                                        else
                                        {
                                            count3 = 0;
                                            count2 = 0;
                                            count++;
                                        }
                                        string pokedexNumber = Convert.ToString(count) + Convert.ToString(count2) + Convert.ToString(count3);
                                        if (readPokemonPosition == pokedexNumber)
                                        {
                                            temporaryPlace = RegionalPokedex[countRegional].PokemonsInAreas[countAreas][countPokemonInArea];
                                            pokemonPlace = countPokemonInArea;
                                        }
                                    }

                                    Console.WriteLine("\nEnter the pokedex number intended to put the pokemon choosen: ");
                                    readPokemonPosition = Console.ReadLine();
                                    count = 0; count2 = 0; count3 = 0;
                                    for (int countPokemonInArea = 0; countPokemonInArea < RegionalPokedex[countRegional].PokemonsInAreas[countAreas].Count; countPokemonInArea++)
                                    {
                                        if (count3 < 9)
                                        {
                                            count3++;
                                        }
                                        else if (count2 < 9)
                                        {
                                            count2++;
                                        }
                                        else
                                        {
                                            count3 = 0;
                                            count2 = 0;
                                            count++;
                                        }
                                        string pokedexNumber = Convert.ToString(count) + Convert.ToString(count2) + Convert.ToString(count3);
                                        if (readPokemonPosition == pokedexNumber)
                                        {
                                            RegionalPokedex[countRegional].PokemonsInAreas[countAreas][pokemonPlace] = RegionalPokedex[countRegional].PokemonsInAreas[countAreas][countPokemonInArea];
                                            RegionalPokedex[countRegional].PokemonsInAreas[countAreas][countPokemonInArea] = temporaryPlace;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Display a list of regional pokedexes.
        /// </summary>
        /// <param name="pokedexListHasNoGlobal">set to define the countOptions value.</param>
        /// <returns>A list of strings with the number options to choose between the regional pokedexes.</returns>
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