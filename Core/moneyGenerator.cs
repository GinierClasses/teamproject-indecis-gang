using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace tower_defense.Core
{
    public class MoneyGenerator
    {
        //Money = argent du jeu
        //AddedMoney = argent ajouté après le délai écoulé
        //MaxMoney = argent que le joueur peut avoir au maximum
        public int Money { get; set; }
        public int AddedMoney { get; set; }
        public int MaxMoney { get; set; }

        //Délai dans la génération de l'argent (en milliseconde)
        public int GenerationTime { get; set; }

        //Initialisation des variables
        public MoneyGenerator()
        {
            this.Money = 0;
            this.AddedMoney = 1;
            this.MaxMoney = 10000;
            this.GenerationTime = 1000;
        }

        //Génération de l'argent
        public async void GenerateMoney(int delay)
        {
            while (true)
            {
                Money += AddedMoney;
                Debug.WriteLine("Argent : " + Money + " $");
                await Task.Delay(delay);
            }
        }

    }
}
