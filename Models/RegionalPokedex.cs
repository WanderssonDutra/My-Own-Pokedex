using System;
using System.Dynamic;
using System.Formats.Asn1;
using System.Net;

namespace Teste2.Models
{
    public class RegionalPokedex
    {
        private string regionalPokedexName;
        private List<Pokemon> regionalPokemon = new List<Pokemon>();
        public string[] RegionalAreas { get; set; }
        public List<List<Pokemon>> PokemonsInAreas = new List<List<Pokemon>>();
        public string RegionalPokedexName
        {
            get => regionalPokedexName;
            set
            {
                if (!decimal.TryParse(value, out decimal validateValue) && !(value.Contains(" ")) && !(String.IsNullOrEmpty(value)))
                    regionalPokedexName = value;
            }

        }
        public Pokemon AddingToPrivateRegionalPokemon { get; set; }
        public List<Pokemon> RegionalPokemon
        {
            get => regionalPokemon;
            set
            {
                if (AddingToPrivateRegionalPokemon != null)
                    regionalPokemon.Add(AddingToPrivateRegionalPokemon);
            }
        }

        public void RegisterRegionalAreasNames(int readAreas)
        {
            RegionalAreas = new string[readAreas];
            Console.WriteLine("Register the names of the regional areas: \n");
            for (int count = 0; count < RegionalAreas.Length; count++)
            {
                Console.Write($"AREA {count + 1}: ");
                RegionalAreas[count] = Console.ReadLine();

                List<Pokemon> pokemonsInArea = new List<Pokemon>();
                PokemonsInAreas.Add(pokemonsInArea);
            }
        }
    }
}