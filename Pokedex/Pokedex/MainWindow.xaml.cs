using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pokedex
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listaPokemon.CardAlterado = (l) =>
            {
                cardViewPokemon.ViewModel.Item = new Apresentacao.CardDePokemon.CardPokemonModel { Nome = l.Nome, Numero = l.Numero, TipoPrimario = l.TipoPrimario, TipoSecundario = l.TipoSecundario, Historia = l.Descricao };
                cardViewPokemon.ViewModel.NotifyPropertyChanged("Item");
                cardViewPokemon.ViewModel.NotifyPropertyChanged("BitMapImage");
                cardViewPokemon.ViewModel.NotifyPropertyChanged("titulo");
                cardViewPokemon.ViewModel.NotifyPropertyChanged("titulo");
            };
        }
    }
}
