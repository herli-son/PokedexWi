using Refit;
using Servicos.API;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Servicos.Servicos
{
    public class PokemonService
    {
        private const string CAMINHO = "https://raw.githubusercontent.com";
        public ObservableCollection<T> ObterDadosPokemon<T>()
        {
            var repositorio = RestService.For<IObterDadosAPI>(CAMINHO);
            return repositorio.GetDadosPokemons<T>().Result;
        }
    }
}
