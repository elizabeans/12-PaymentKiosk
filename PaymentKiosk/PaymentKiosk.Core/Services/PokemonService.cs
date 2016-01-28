using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentKiosk.Core.Services
{
    public class PokemonService
    {
        private const int pikachuPrice = 5000;
        private const int eeveePrice = 1000;
        private const int bulbasaurPrice = 2500;

        public static int CalculatePrice (int numberOfPikachu, int numberOfEevee, int numberOfBulbasaur)
        {
            // multiplies number of Pokemon * price of Pokemon
            int finalCostPikachu = numberOfPikachu * pikachuPrice;
            int finalCostEevee = numberOfEevee * eeveePrice;
            int finalCostBulbasaur = numberOfBulbasaur * bulbasaurPrice;

            return finalCostPikachu + finalCostEevee + finalCostBulbasaur;
        }
    }
}
