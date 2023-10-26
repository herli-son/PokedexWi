using Mvvm.Base.ViewModelBase;
using Pokedex.Models;
using Servicos.Servicos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apresentacao.ViewModel
{
    public class PokemonViewModel : ListaViewModel<PokemonModel>
    {
        public PokemonService PokemonService { get; set; }
        public PokemonViewModel()
        {
            PokemonService = new PokemonService();
            Itens = PokemonService.ObterDadosPokemon<PokemonModel>();
            NotifyPropertyChanged(nameof(Itens));
        }
    }
}
