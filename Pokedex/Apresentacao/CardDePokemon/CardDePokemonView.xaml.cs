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
        public CardDePokemonView()
        {
            InitializeComponent();
            PokemonImage.Source = new BitmapImage(new Uri("https://th.bing.com/th/id/OIP.GfvcTMJ4-_xEdijPRP65WAHaFj?pid=ImgDet&rs=1"));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
