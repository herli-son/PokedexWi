using Controles;
using Mvvm.Base.ViewModelBase;
using Pokedex.Models;
using Servicos.Servicos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Apresentacao.CardDePokemon
{
    public class CardDePokemonViewModel : ItemViewModel<Object>
    {
        public PokemonService PokemonService { get; set; }

        public CardDePokemonViewModel()
        {
            PokemonService = new PokemonService();
            Item = PokemonService.ObterDadosPokemon<Object>();
            NotifyPropertyChanged(nameof(Item));
        }
        public void MontarCard(int numero, string nome)
        {
            Item = new CardModel { Imagem = ObterImagem(numero), Nome = nome };
            NotifyPropertyChanged("Item");
        }
        private BitmapImage ObterImagem(int numero)
        {
            string caminho = numero.ToString();
            if (numero < 100) caminho = "0" + caminho;
            if (numero < 10) caminho = "0" + caminho;
            caminho = $"https://raw.githubusercontent.com/herli-son/PokeAPI/main/Pokemons/{caminho}.png";

            return new BitmapImage(new Uri(caminho));
        }

    }
}
