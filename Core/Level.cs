using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace tower_defense.Core
{
    //La classe level va permettre de calculer et d'afficher le level sur la fenêtre de jeu

    class Level
    {
        //Numéro du level actuel (on commence avec 1 min.)
        public int levelNo { get; set; }

        //limite de level maximum
        public int levelMax { get; set; }

        //Prix pour payer le prochain level
        public int levelPrice { get; set; }

        //Constante de multiplication pour le calcul du prix du level
        private const int _levelPriceConst = 50;

        public Level()
        {
            this.levelNo = 2;
            this.levelMax = 10;
            this.levelPrice = 0;
        }

        public void LevelUp()
        {
            if(levelNo < levelMax)
            {
                levelNo++;
            }
        }

        public void LevelPrice()
        {
            levelPrice = (int)(_levelPriceConst * Math.Pow((int)levelNo, 2));
            Debug.WriteLine(levelPrice);
        }

    }
}
