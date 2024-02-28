
using Azure;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using Pokedex.Dto;
using Pokedex.Model;
using System.Data.SqlTypes;
using static Pokedex.Dto.showPokemonView;
using static Pokedex.Model.PokemonData;
using static System.Net.WebRequestMethods;

namespace Pokedex.Data
{
    public class PokemonsServices
    {
        public PokemonsServices()
        {
           
        }
        static HttpClient client = new HttpClient();

        HttpResponseMessage response = new HttpResponseMessage();
        private string URL = "";
        public async Task<List<showPokemonView>> GetPokemonsAsync(int inicio, int fim)
        {
            URL = $"https://pokeapi.co/api/v2/pokemon?offset={inicio}&limit={fim}";
            Result pokemons = new Result();
            Rootobject pokemon = new Rootobject();
            List<showPokemonView> ListPokemons = new List<showPokemonView>();

            response = await client.GetAsync(URL);

            if (response != null)
            {
                pokemons = JsonConvert.DeserializeObject<Result>(response.Content.ReadAsStringAsync().Result);
            }
            foreach (var pokemonResult in pokemons.Results)
            {
                var urlSplited = pokemonResult.Url.Split('/');
                var pokemonId = urlSplited[6];
                pokemon = await GetPokemon(Convert.ToInt32(pokemonId));

                 ListPokemons.Add(FeedPokeViewer(pokemon));
            }
            
            return ListPokemons;
        }
        public async Task<Rootobject> GetPokemon(int pokeNumber)
        {
            URL = $"https://pokeapi.co/api/v2/pokemon-form/{pokeNumber}/";

            Rootobject pokemon = new Rootobject();
            response = await client.GetAsync(URL);

            if (response != null)
            {
                pokemon = JsonConvert.DeserializeObject<Rootobject>(response.Content.ReadAsStringAsync().Result);
            }
            return pokemon;
        }

        public  showPokemonView FeedPokeViewer(Rootobject pokemonRoot)
        {
            showPokemonView pokemon = new showPokemonView();
            List<Tipos> tipos = new();

            pokemon.Order = pokemonRoot.Order;    
            pokemon.Name = pokemonRoot.Name;
            pokemon.Foto = pokemonRoot.Sprites.Front_default;
            foreach (var slot in pokemonRoot.Types)
            {
                Tipos tipo = new Tipos();
                tipo.Slot = slot.Slot;
                tipo.Name = slot.type.Name;

                tipos.Add(tipo);
            }
            pokemon.Tipo = tipos;

            return pokemon;
        }

    }
}
