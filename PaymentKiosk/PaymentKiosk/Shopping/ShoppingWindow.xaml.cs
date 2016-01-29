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

        private bool pikachuClear = false;
        private bool eeveeClear = false;
        private bool bulbasaurClear = false;

        public ShoppingWindow()
        {
            InitializeComponent();
        }

        private void textBoxPikachuQuantity_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!pikachuClear)
            {
                textBoxPikachuQuantity.Clear();
            }

            pikachuClear = true;
        }

        private void textBoxEeveeQuantity_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!eeveeClear)
            {
                textBoxEeveeQuantity.Clear();
            }

            eeveeClear = true;
        }

        private void textBoxBulbasaurQuantity_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!bulbasaurClear)
            {
                textBoxBulbasaurQuantity.Clear();
            }

            bulbasaurClear = true;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            int numberOfPikachus = 0;
            int numberOfEevees = 0;
            int numberOfBulbasaurs = 0;

            try
            {
                numberOfPikachus = int.Parse(textBoxPikachuQuantity.Text);
                numberOfEevees = int.Parse(textBoxEeveeQuantity.Text);
                numberOfBulbasaurs = int.Parse(textBoxBulbasaurQuantity.Text);

                int addToCart = numberOfPikachus + numberOfEevees + numberOfBulbasaurs;

                MessageBox.Show("You've added " + textBoxPikachuQuantity.Text + " Pikachus, "
                                + textBoxEeveeQuantity.Text + " Eevees, "
                                + textBoxBulbasaurQuantity.Text + " Bulbasaurs!");

                pokemonTotalPrice = PokemonService.CalculatePrice(numberOfPikachus, numberOfEevees, numberOfBulbasaurs);

                MainWindow goToCart = new MainWindow();
                goToCart.ShowDialog();
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Please enter a valid number in each box.");
            }
        }

     }
}
