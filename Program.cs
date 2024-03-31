using System;
using Teste2.Models;

Pokedex pokedex = new Pokedex();
pokedex.PokemonRegistered = new List<Pokemon>();
pokedex.RegionalPokedex = new List<RegionalPokedex>();
bool endTask = true;
/*The loop shows a menu with options that interact with the classes. the variable readResult is used to receive the input for the most part of the loop. The classes points everytime the loop iterate to a new reference address so the regional pokedexes, pokemons and regional areas that are created doesn't point to the same address and register the same pokemons.*/
while (endTask)
{
    int readAreas = 0;
    Pokemon pokemon = new Pokemon();
    RegionalPokedex regionalPokedex = new RegionalPokedex();
    regionalPokedex.RegionalPokemon = new List<Pokemon>();
    string menu = "1. Look at the pokedex.\n2. Add a pokemon to the global pokedex.\n3. create a regional pokedex.\n4. Add a pokemon to the regional pokedex.\n5. End the proccess.";
    if (pokedex.PokemonRegistered.Count > 1)
    {
        menu = menu.Replace("5. End the proccess.", "5. Organize the pokedex.");
        menu += "\n6. End the proccess.";
    }
    Console.WriteLine(menu);
    string readResult = Console.ReadLine();
    Console.Clear();
    /*Choose the correct case based in the input set in the variable readResult and according to the options presented in the menu.*/
    switch (readResult)
    {
        case "1":
            int countOptions = 2;
            List<string> countRegionalPokedex = new List<string>();
            Console.WriteLine("1. GLOBAL\n");
            foreach (RegionalPokedex regional in pokedex.RegionalPokedex)
            {
                Console.WriteLine($"{countOptions}. {regional.RegionalPokedexName}");
                countRegionalPokedex.Add(Convert.ToString(countOptions));
                countOptions++;
            }
            readResult = Console.ReadLine();
            if (readResult == "1")
                pokedex.ShowGlobalPokedex();
            else
                pokedex.ShowRegionalPokedex(readResult, countRegionalPokedex);

            Console.ReadKey();
            Console.Clear();
            break;
        case "2":
            pokemon.RegisterPokemon();
            if (!pokemon.Canceled)
            {
                pokedex.IsInTheGlobal(pokemon);
            }
            break;
        /*Set the name of the regional pokedex. This case will prompt another Switch-case to decide the numbers of areas the regional pokedex can has.*/
        case "3":
            Console.WriteLine("Enter the name of the pokedex: \n");
            regionalPokedex.RegionalPokedexName = Console.ReadLine();
            Console.Clear();
            bool endRegionalTask = true;
            while (endRegionalTask)
            {
                /*readAreas is set to represent the length of the Array regionalAreas. And regionalAreas is set to represent the numbers of areas that the region is divided into, up to four areas.*/
                Console.WriteLine("Add areas to your region: \n1. 2 areas.\n2. 3 areas.\n3. 4 areas\n4. none.");
                readResult = Console.ReadLine();
                switch (readResult)
                {
                    case "1":
                        readAreas = 2;
                        regionalPokedex.RegisterRegionalAreasNames(readAreas);
                        pokedex.RegionalPokedex.Add(regionalPokedex);
                        endRegionalTask = false;
                        break;
                    case "2":
                        readAreas = 3;
                        regionalPokedex.RegisterRegionalAreasNames(readAreas);
                        pokedex.RegionalPokedex.Add(regionalPokedex);
                        endRegionalTask = false;
                        break;
                    case "3":
                        readAreas = 4;
                        regionalPokedex.RegisterRegionalAreasNames(readAreas);
                        pokedex.RegionalPokedex.Add(regionalPokedex);
                        endRegionalTask = false;
                        break;
                    case "4":
                        endRegionalTask = false;
                        pokedex.RegionalPokedex.Add(regionalPokedex);
                        break;
                    default:
                        Console.WriteLine("Please, select a valid option.");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
            break;
        /*Add a pokemon to the regional pokedex.*/
        case "4":
            //Verify if there is at least one regional pokedex to be able to add pokemons to the regional pokedex.
            if (!(pokedex.RegionalPokedex.Capacity == 0))
            {
                int count = 0;
                List<string> regionNumber = new List<string>();
                /*This foreach write in the Console The names of the regional pokedexes based on the numbers of pokedexes names provided in the Switch-case 3. Right after the foreach, enter the name of the regional pokedex.*/
                foreach (RegionalPokedex regionalPokedexes in pokedex.RegionalPokedex)
                {
                    count++;
                    regionNumber.Add(Convert.ToString(count));
                    Console.WriteLine($"{count}. {regionalPokedexes.RegionalPokedexName}");
                }
                readResult = Console.ReadLine();
                Console.Clear();
                /*Iterates through each regional pokedex created. If the regional pokedex name matches the name provided by the value of variable readResult, then regionName receives the name of the pokedex.*/
                for (int count1 = 0; count1 < pokedex.RegionalPokedex.Count; count1++)
                {
                    string regionName = "";
                    if (readResult == regionNumber[count1])
                    {
                        regionName = pokedex.RegionalPokedex[count1].RegionalPokedexName;

                        if (pokedex.RegionalPokedex[count1].RegionalAreas == null)
                        {
                            Console.WriteLine("1. Add a new pokemon.\n2. Choose from the global pokedex.");
                            readResult = Console.ReadLine();
                            Console.Clear();
                            if (readResult == "1")
                            {
                                pokemon.RegisterPokemon();
                                regionalPokedex.AddingToPrivateRegionalPokemon = pokemon;
                                //If the global pokedex has no pokemons registered, then register the pokemon that will be registered in the regional pokedex as well.
                                if (!pokemon.Canceled)
                                    if (!(pokedex.PokemonRegistered.Capacity == 0))
                                    {
                                        //Verify if the pokemon the user is trying to register in the regional pokedex is already in the global pokedex.
                                        if (!pokedex.IsInTheGlobal(pokemon))
                                            pokedex.RegisterRegionalPokedex(pokemon, regionName);
                                    }
                                    else
                                    {
                                        pokedex.PokemonRegistered.Add(pokemon);
                                        pokedex.RegisterRegionalPokedex(pokemon, regionName);
                                    }
                            }
                            else
                            {
                                pokedex.ShowGlobalPokedex();
                                Console.WriteLine("Enter the pokemon's pokedex number: ");
                                readResult = Console.ReadLine();
                            }
                        }
                        else
                        {
                            //iterates trhough a list of areas added to a regional pokedex. the number option that matches the area is added to a list to be used later.
                            string[] countAreasOptions = new string[pokedex.RegionalPokedex[count1].RegionalAreas.Length];
                            for (int countAreas = 0; countAreas < pokedex.RegionalPokedex[count1].RegionalAreas.Length; countAreas++)
                            {
                                Console.WriteLine($"{countAreas + 1}. {pokedex.RegionalPokedex[count1].RegionalAreas[countAreas]}");
                                countAreasOptions[countAreas] = Convert.ToString(countAreas + 1);
                            }
                            string readAreaResult = Console.ReadLine();
                            Console.WriteLine("1. Add a new pokemon.\n2. Choose from the global pokedex.");
                            readResult = Console.ReadLine();
                            Console.Clear();
                            if (readResult == "1")
                            {
                                pokemon.RegisterPokemon();
                                if (!pokemon.Canceled)
                                {
                                    if (!(pokedex.PokemonRegistered.Capacity == 0))
                                    {
                                        //Verify if the pokemon the user is trying to register in the regional pokedex is already in the global pokedex. if it is not, add it directly.
                                        if (!pokedex.IsInTheGlobal(pokemon))
                                        {
                                            pokemon.RegionalAreas = new List<string>();
                                            pokemon.RegionalAreas.Add(pokedex.RegisterPokemonInRegionalArea(readAreaResult, countAreasOptions, regionName));
                                        }
                                    }
                                    else
                                    {
                                        pokedex.PokemonRegistered.Add(pokemon);
                                        pokemon.RegionalAreas = new List<string>();
                                        pokemon.RegionalAreas.Add(pokedex.RegisterPokemonInRegionalArea(readAreaResult, countAreasOptions, regionName));
                                    }

                                }
                            }
                            else
                            {
                                pokedex.ShowGlobalPokedex();
                                Console.WriteLine("Enter the pokemon's pokedex number: ");
                                readResult = Console.ReadLine();
                            }

                        }
                    }
                }
            }
            else
                Console.WriteLine("Please, create a regional pokedex to add pokemons.");

            Console.ReadKey();
            Console.Clear();
            break;
        case "5":
            if (menu.Contains("5. Organize the pokedex."))
                pokedex.OrganizePokedex();
            else
            {
                endTask = false;
                Console.WriteLine("The procces was finished.");
            }
            break;
        case "6":
            if (menu.Contains("6. End the proccess."))
            {
                endTask = false;
                Console.WriteLine("The procces was finished.");
            }
            break;
    }
    Console.Clear();
}