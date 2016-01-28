using PaymentKiosk.Core.Services;
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
using System.Windows.Shapes;

namespace PaymentKiosk.Shopping
{
    /// <summary>
    /// Interaction logic for ShoppingWindow.xaml
    /// </summary>
    public partial class ShoppingWindow : Window
    {
        public static int pokemonTotalPrice = 0;

        public ShoppingWindow()
        {
            InitializeComponent();
        }

        private void textBoxPikachuQuantity_MouseEnter(object sender, MouseEventArgs e)
        {
            textBoxPikachuQuantity.Clear();
        }

        private void textBoxEeveeQuantity_MouseEnter(object sender, MouseEventArgs e)
        {
            textBoxEeveeQuantity.Clear();
        }

        private void textBoxBulbasaurQuantity_MouseEnter(object sender, MouseEventArgs e)
        {
            textBoxBulbasaurQuantity.Clear();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            int addToCart = int.Parse(textBoxPikachuQuantity.Text) + int.Parse(textBoxEeveeQuantity.Text) + int.Parse(textBoxBulbasaurQuantity.Text);
            MessageBox.Show("You've added " + textBoxPikachuQuantity.Text + " Pikachus, "
                            + textBoxEeveeQuantity.Text + " Eevees, "
                            + textBoxBulbasaurQuantity.Text + " Bulbasaurs!");

            pokemonTotalPrice = PokemonService.CalculatePrice(int.Parse(textBoxPikachuQuantity.Text), int.Parse(textBoxEeveeQuantity.Text), int.Parse(textBoxBulbasaurQuantity.Text));


            MainWindow goToCart = new MainWindow();
            goToCart.ShowDialog();
        }

     }
}
