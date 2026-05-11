using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_laba
{
    internal class Widescreen_Film : Film
    {
        private int _moneyCollected;

        // Конструкторы
        public Widescreen_Film()
        {
            _moneyCollected = 0;
        }

        public Widescreen_Film(FilmGenre genre, string title, int year, int moneyCollected) : base(genre, title, year)
        {
            _moneyCollected = moneyCollected;

        }

        public Widescreen_Film(FilmGenre genre, string title, int year, int moneyCollected, string[] actors) : base(genre, title, year, actors)
        {
            _moneyCollected = moneyCollected;

        }

        // Методы
        // возвощает строку с данными
        public override string ToString()
        {
            string str = $"Кассовые зборы: {_moneyCollected}\n";         
            return base.ToString() + str ;
        } 
    }
}
