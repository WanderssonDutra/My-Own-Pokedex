using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Teste2.Models
{
    //A class with all the properties of a pokemon such as type, description and name.
    public class Pokemon
    {
        private string name, description, type1, type2;
        public string Name
        {
            get => name;
            set
            {
                bool isValidName = true;

                foreach (char letter in value)
                {
                    if (decimal.TryParse(Convert.ToString(letter), out decimal validate))
                        isValidName = false;
                }

                if (isValidName && value.Length <= 15 && !String.IsNullOrEmpty(value) && !value.Contains(" "))
                    name = value;
                else
                {
                    Console.WriteLine("The name of the pokemon needs to follow the rules:\n1-Can't contain numbers\n2- can't contain more than 15 characters\n3-can't contain spaces.\n4-can't be empty.");
                    Console.ReadKey();
                }
                return;
            }
        }
        public string Description
        {
            get => description;
            set
            {
                if (!decimal.TryParse(value, out decimal validateNumer) && value.Length < 100 && !String.IsNullOrEmpty(value))
                    description = value;
                else
                    throw new FormatException("The description of the pokemon needs to follow the rules:\n1-Can't contain numbers(write them in character format)\n2- can't contain more than 100 characters\n3-can't be empty.");
            }
        }
        public string Type1
        {
            get => type1;
            set
            {
                string[] types = { "NORMAL", "FIRE", "WATER", "ELECTRIC", "GRASS", "ICE", "FIGHTING", "POISON", "GROUND", "FLYING", "PSYCHIC", "BUG", "ROCK", "GHOST", "DRAGON", "DARK", "STEEL", "FAIRY" };
                if (String.IsNullOrEmpty(value))
                {
                    Console.WriteLine("The pokemon must has a type.");
                    type1 = null; type2 = null;
                    Console.ReadKey();
                }
                else
                {
                    bool isValid = false;
                    foreach (string type in types)
                        if (value == type)
                            isValid = true;
                    if(isValid)
                        type1 = value;
                    else
                    {
                        type1 = null; type2 = null;
                        Console.WriteLine("The type doesn't exist.");
                        Console.ReadKey();
                    }
                }
            }
        }
    public string Type2
    {
        get => type2;
        set
        {
            string[] types = { "NORMAL", "FIRE", "WATER", "ELECTRIC", "GRASS", "ICE", "FIGHTING", "POISON", "GROUND", "FLYING", "PSYCHIC", "BUG", "ROCK", "GHOST", "DRAGON", "DARK", "STEEL", "FAIRY" };
                if(value == type1)
                {
                    type1 = null; type2 = null;
                    Console.WriteLine("The pokemon cannot has the same type twice.");
                    Console.ReadKey();
                }
                else if (String.IsNullOrEmpty(value))
                    type2 = value;
                else
                {
                    bool isValid = false;
                    foreach (string type in types)
                        if (value == type)
                            isValid = true;
                    if(isValid)
                        type2 = value;
                    else
                    {
                        type1 = null; type2 = null;
                        Console.WriteLine("The type doesn't exist.");
                        Console.ReadKey();
                    }
                }
        }
    }

    public bool Canceled { get; set; }
    /// <summary>
    /// Register a pokemon with a name, type and description in the Pokemon class.
    /// </summary>
    public void RegisterPokemon()
    {
        string readResult;
        bool endTask = true;
        while (endTask)
        {
            string menu = "1. Register the pokemon's name.\n2. Add a description.\n3. Add the types of the pokemon.\n4. Cancel the register.";
            Console.WriteLine("====================================\nRegistering a pokemon in the Pokedex\n====================================");

            if (!String.IsNullOrEmpty(name))
                menu = menu.Replace("1. Register the pokemon's name.", "1. Change the pokemon's name.");
            if (!String.IsNullOrEmpty(description))
                menu = menu.Replace("2. Add a description.", "2. Change the description");
            if (!String.IsNullOrEmpty(Type1))
                menu = menu.Replace("3. Add the types of the pokemon.", "3. Change the types of the pokemon.");
            if (!(String.IsNullOrEmpty(name)) && !(String.IsNullOrEmpty(description)) && !(String.IsNullOrEmpty(Type1)))
                menu += "\n5. Finish the registration.";
            Console.WriteLine(menu);
            readResult = Console.ReadLine();

            switch (readResult)
            {
                case "1":
                    Console.WriteLine("Enter the pokemon's name:\n");
                    Name = Console.ReadLine().ToUpper().Trim();
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine("Enter the pokemon description:\n");
                    Description = Console.ReadLine();
                    Console.Clear();
                    break;
                case "3":
                    Console.WriteLine("Enter the types of the pokemon: \nOBS: A pokemon can has one or two types.\n");
                    Console.Write("FIRST TYPE:");
                    Type1 = Console.ReadLine().ToUpper().Trim();
                    if (!String.IsNullOrEmpty(Type1))
                    {
                        Console.Write("SECOND TYPE:");
                        Type2 = Console.ReadLine().ToUpper().Trim();
                        Console.Clear();
                    }
                    Console.Clear();
                    break;
                case "4":
                    Console.WriteLine("Pokemon Registration canceled.");
                    Canceled = true;
                    endTask = false;
                    break;
                case "5":
                    if (menu.Contains("\n5. Finish the registration."))
                    {
                        Console.WriteLine($"Registering {Name}...");
                        Canceled = false;
                        endTask = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Command.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
}
}