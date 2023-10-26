using Refit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Servicos.API
{
    public interface IObterDadosAPI
    {
        [Get("/herli-son/PokeAPI/main/Dados/Pokemons.json")]
        Task<ObservableCollection<T>> GetDadosPokemons<T>();
    }
}
