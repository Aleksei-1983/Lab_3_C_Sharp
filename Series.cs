using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _3_laba // Объявляет пространство имен _3_laba
{
    [Serializable]
    public class Series : Film // Объявляет внутренний класс Series, наследующий от класса Film
    {
        private int _serial_number; // Приватное поле для хранения номера серии
        private int _season_number; // Приватное поле для хранения номера сезона

        public int Series_number // Свойство для доступа к полю _series
        {
            get { return _serial_number; } // Геттер возвращает значение поля _series
            set { _serial_number = value; } // Сеттер присваивает полю _series переданное значение
        }

        public int Season_number // Свойство для доступа к полю _season
        {
            get { return _season_number; } // Геттер возвращает значение поля _season
            set { _season_number = value; } // Сеттер присваивает полю _season переданное значение
        }

        // Конструкторы
        public Series() // Конструктор без параметров (по умолчанию)
        {
            _serial_number = 0; // Инициализирует _series нулем
            _season_number = 0; // Инициализирует _season нулем

        }
        // Конструктор с параметрами: жанр, название, год, серия, сезон; вызывает базовый конструктор Film
        public Series(FilmGenre genre, string title, int year, int series, int season) : base(genre, title, year)
        {
            _serial_number = series; // Присваивает полю _series значение параметра series
            _season_number = season; // Присваивает полю _season значение параметра season

        }
        // Конструктор с дополнительным массивом актеров; вызывает базовый конструктор Film
        public Series(FilmGenre genre, string title, int year, int series, int season, string[] actors) : base(genre, title, year, actors) 
        {
            _serial_number = series; // Присваивает полю _series значение параметра series
            _season_number = season; // Присваивает полю _season значение параметра season

        }

        // Методы

        // возвощает строку с данными
        // Переопределяет виртуальный метод ToString для получения строкового представления объекта
        public override string ToString() 
        {
            string str = $"Сезон: {Season_number} Серия: {Series_number}\n"; // Создает строку с информацией о сезоне и серии
            return base.ToString() + str; // Возвращает строку от базового класса ToString, объединенную с дополнительной информацией
        }
    }
}