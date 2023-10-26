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
    public class CardDePokemonViewModel : ItemViewModel<CardPokemonModel>
    {
        public PokemonService PokemonService { get; set; }
        public BitmapImage BitMapImage { get => ObterImagem(int.Parse(Item.Numero)); }
        public string titulo { get => Item.Nome + " - " + Item.Numero; }

        public CardDePokemonViewModel()
        {
            PokemonService = new PokemonService();
        }
        public BitmapImage ObterImagem(int numero)
        {
            string caminho = numero.ToString();
            if (numero < 100) caminho = "0" + caminho;
            if (numero < 10) caminho = "0" + caminho;
            caminho = $"https://raw.githubusercontent.com/herli-son/PokeAPI/main/Pokemons/{caminho}.png";

            return new BitmapImage(new Uri(caminho));
        }

    }
}
