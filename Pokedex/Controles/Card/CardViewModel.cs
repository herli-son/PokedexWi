using Mvvm.Base.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Controles
{
    public class CardViewModel : ItemViewModel<CardModel>
    {

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
