using Apresentacao.CardDePokemon;
using Apresentacao.ViewModel;
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

namespace Apresentacao
{
    /// <summary>
    /// Interação lógica para CardDePokemonView.xam
    /// </summary>
    public partial class CardDePokemonView : UserControl
    {

        public CardDePokemonViewModel ViewModel { get => DataContext as CardDePokemonViewModel; }
        public CardDePokemonView()
        {
            InitializeComponent();
            DataContext = new CardDePokemonViewModel();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
