using Apresentacao.ViewModel;
using Controles;
using Pokedex.Models;
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

namespace Apresentacao.View
{
    /// <summary>
    /// Interação lógica para PokemonView.xam
    /// </summary>
    public partial class PokemonView : UserControl
    {
        public PokemonViewModel ViewModel { get => DataContext as PokemonViewModel; }
        public Action<PokemonModel> CardAlterado { get; set; }
        public PokemonView()
        {
            InitializeComponent();
            DataContext = new PokemonViewModel();

            foreach (var item in ViewModel.Itens)
            {
                var card = new Card();
                card.ViewModel.MontarCard(int.Parse(item.Numero), item.Nome);
                card.MouseDoubleClick += Card_MouseDoubleClick;
                Poke.Children.Add(card);
            }
        }

        private void Card_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var card = (Card)sender;
            var pk = ViewModel.Itens.FirstOrDefault(x => int.Parse(x.Numero) == card.ViewModel.Item.Numero);
            CardAlterado?.Invoke(pk);
        }
    }
}
