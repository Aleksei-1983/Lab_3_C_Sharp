using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_laba
{
    internal class Series : Film
    {
        private int _series;
        private int _season;

        public int _Series
        {
            get { return _series; }
            set { _series = value; }
        }

        public int Season
        {
            get { return _season; }
            set { _season = value; }
        }

        // Конструкторы
        public Series()
        {
            _series = 0;
            _season = 0;

        }

        public Series(FilmGenre genre, string title, int year, int series, int season) : base(genre, title, year)
        {
            _series = series;
            _season = season;

        }

        public Series(FilmGenre genre, string title, int year, int series, int season, string[] actors) : base(genre, title, year, actors)
        {
            _series = series;
            _season = season;

        }

        // Методы

        // возвощает строку с данными
        public override string ToString()
        {
            string str = $"Сезон: {_season} Серия: {_series}\n";
            return base.ToString() + str;
        }
    }
}
