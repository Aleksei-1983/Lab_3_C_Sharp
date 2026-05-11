using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _3_laba // Объявляет пространство имен _3_laba для организации кода
{
    [Serializable]
    public class Widescreen_Film : Film // Объявляет внутренний класс Widescreen_Film, который наследуется от базового класса Film
    {
        private int _moneyCollected; // Приватное поле класса для хранения суммы кассовых сборов (в условных единицах)
   
        public int MoneyCollected // Свойство для доступа к полю _moneyCollected
        {
            get { return _moneyCollected; } // Геттер возвращает значение поля _moneyCollected
            set { _moneyCollected = value; } // Сеттер присваивает полю _moneyCollected переданное значение
        }

        // Конструкторы
        public Widescreen_Film() // Конструктор без параметров (по умолчанию)
        {
            _moneyCollected = 0; // Устанавливает начальное значение кассовых сборов равным 0
        }
        // Конструктор с 4 параметрами: жанр, название, год выпуска, сборы; вызывает конструктор базового класса Film
        public Widescreen_Film(FilmGenre genre, string title, int year, int moneyCollected) : base(genre, title, year)
        {
            _moneyCollected = moneyCollected; // Присваивает полю _moneyCollected переданное значение moneyCollected
        }
        // Конструктор с массивом актеров: жанр, название, год, сборы, актеры; вызывает соответствующий конструктор Film
        public Widescreen_Film(FilmGenre genre, string title, int year, int moneyCollected, string[] actors) : base(genre, title, year, actors) 
        {
            _moneyCollected = moneyCollected; // Присваивает полю _moneyCollected переданное значение moneyCollected
        }

        // Методы
        // возвощает строку с данными (строчный комментарий к методу)
        public override string ToString() // Переопределяет виртуальный метод ToString() для получения строкового представления объекта
        {
            string str = $"Кассовые зборы: {MoneyCollected}\n"; // Создает строку с информацией о кассовых сборах (знак \n означает перевод строки)
            return base.ToString() + str; // Возвращает результат метода ToString() из базового класса Film, объединенный со строкой о сборах
        }
    }
}
