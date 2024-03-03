using System;
using System.Dynamic;

namespace Teste2.Models
{
    public class RegionalPokedex
    {
        private string regionalPokedexName;
        private List<Pokemon> regionalPokemon;
        public string[] RegionalAreas { get; set; }
        public string RegionalPokedexName 
        {
             get=>regionalPokedexName;
             set
             {
                if(!decimal.TryParse(value, out decimal validateValue) && !(value.Contains(" ")) && !(String.IsNullOrEmpty(value)))
                    regionalPokedexName = value;
             }

        }
        public List<Pokemon> RegionalPokemon { get; set; }

        public void RegisterRegionalAreasNames(int readAreas)
        {
            RegionalAreas = new string[readAreas];
            Console.WriteLine("Register the names of the regional areas: \n");
            for(int count = 0; count < RegionalAreas.Length; count++)
            {
                Console.Write($"AREA {count + 1}: ");
                RegionalAreas[count] = Console.ReadLine();
            }
        }

    }
}