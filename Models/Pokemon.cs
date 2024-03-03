using System;
using System.Collections;
using System.Diagnostics;

namespace Teste2.Models
{
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

                switch (value)
                {
                    case "NORMAL":
                        type1 = value;
                        break;
                    case "FIRE":
                        type1 = value;
                        break;
                    case "WATER":
                        type1 = value;
                        break;
                    case "GRASS":
                        type1 = value;
                        break;
                    case "FIGHTING":
                        type1 = value;
                        break;
                    case "PSYCHIC":
                        type1 = value;
                        break;
                    case "ELECTRIC":
                        type1 = value;
                        break;
                    case "POISON":
                        type1 = value;
                        break;
                    case "ICE":
                        type1 = value;
                        break;
                    case "GHOST":
                        type1 = value;
                        break;
                    case "FAIRY":
                        type1 = value;
                        break;
                    case "ROCK":
                        type1 = value;
                        break;
                    case "GROUND":
                        type1 = value;
                        break;
                    case "BUG":
                        type1 = value;
                        break;
                    case "FLYING":
                        type1 = value;
                        break;
                    case "STEEL":
                        type1 = value;
                        break;
                    case "DRAGON":
                        type1 = value;
                        break;
                    case "DARK":
                        type1 = value;
                        break;
                    default:
                        Console.WriteLine("The type doesn't exist. Please, give a valid type to the pokémon.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public string Type2
        {
            get => type2;
            set
            {
                if (type1 == value)
                   Console.WriteLine("The pokémon can't has the same type twice.");
                else if (String.IsNullOrEmpty(value))
                    type2 = value;
                else
                    switch (value)
                    {
                        case "NORMAL":
                            type2 = value;
                            break;
                        case "FIRE":
                            type2 = value;
                            break;
                        case "WATER":
                            type2 = value;
                            break;
                        case "GRASS":
                            type2 = value;
                            break;
                        case "FIGHTING":
                            type2 = value;
                            break;
                        case "PSYCHIC":
                            type2 = value;
                            break;
                        case "ELECTRIC":
                            type2 = value;
                            break;
                        case "POISON":
                            type2 = value;
                            break;
                        case "ICE":
                            type2 = value;
                            break;
                        case "GHOST":
                            type2 = value;
                            break;
                        case "FAIRY":
                            type2 = value;
                            break;
                        case "ROCK":
                            type2 = value;
                            break;
                        case "GROUND":
                            type2 = value;
                            break;
                        case "BUG":
                            type2 = value;
                            break;
                        case "FLYING":
                            type2 = value;
                            break;
                        case "STEEL":
                            type2 = value;
                            break;
                        case "DRAGON":
                            type2 = value;
                            break;
                        case "DARK":
                            type2 = value;
                            break;
                        default:
                            type1 = null;
                            Console.WriteLine("The type doesn't exist. Please, give a valid type to the pokémon.");
                            Console.ReadKey();
                            break;
                    }
            }
        }
        public bool Canceled { get; set; }
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
                        if(!String.IsNullOrEmpty(Type1))
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