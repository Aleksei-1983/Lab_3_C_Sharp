using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _3_laba
{

    // Класс описывает информацию о фильме, содержит поля, свойства, конструкторы и методы
    internal class Film : I_Film
    {
        // поле перичесление количество созданных объектов
        private static int _counter = 0;

        // Для хранения данных о фильме используются поля: _title - название, _year - год выпуска, _actors - список актеров
        // Статический массив с названиями жанров (общий для всех объектов)
        private static readonly string[] _genres_str = { "экшн", "комедия", "драма", "хоррор", "романтика", "триллер", "не задано" };
        private FilmGenre _genre;
        private string _title;
        private int _year;
        private string[] _actors;
        private int _numberActor;

        // Свойства
        // С помощью свойств можно получать доступ к приватным полям и изменять их значения
        public FilmGenre Genre
        {
            get => _genre;
            set
            {
                if ((value & (FilmGenre.Action | FilmGenre.Comedy | FilmGenre.Romance |
                              FilmGenre.Thriller | FilmGenre.Horror | FilmGenre.Drama)) != 0)
                {
                    _genre = value;
                }
                else
                {
                    _genre = FilmGenre.Unknown;
                }
            }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public string[] Actors
        {
            get { return _actors; }
            set { _actors = value; }
        }

        // Индексатор
        // Индексатор позволяет получать или изменять элементы массива _actors по индексу
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < _actors.Length)
                {
                    return _actors[index];
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (index >= 0 && index < _actors.Length)
                {
                    _actors[_numberActor++] = value;
                }
            }

        }

        // Конструкторы
        public Film()
        {
            _genre = FilmGenre.Unknown;
            _title = "";
            _year = 0;
            _actors = new string[10];
            _numberActor = 0;
            IncreaseCounter();
        }

        public Film(FilmGenre genre, string title, int year)
        {
            _genre = genre;
            _title = title;
            _year = year;
            _actors = new string[10];
            _numberActor = 0;
            IncreaseCounter();
        }

        public Film(FilmGenre genre, string title, int year, string[] actors)
        {
            _genre = genre;
            _title = title;
            _year = year;
            _numberActor = actors.Length;
            _actors = actors;
            IncreaseCounter();
        }

        ~Film()
        {

        }

        // Методы
        // Для добавления нового актера в список актеров используется метод AddActor
        public void AddActor(string actor)
        {
            string[] newActors = new string[_actors.Length + 1];
            _actors.CopyTo(newActors, 0);
            newActors[newActors.Length - 1] = actor;
            _actors = newActors;
        }

        // возвощает строку с данными
        public override string ToString()
        {
            string s = $"Жанр: {GetGenreString(_genre)}.\nНазвание фильма: {_title}.\n" +
                $"Год выпуска: {_year}.\n";
            StringBuilder stringBuilder = new StringBuilder(s, 1024);
            stringBuilder.Append("Актеры: ");

            if (_numberActor > 0)
            {
                for (int i = 0; i < _numberActor && (_actors[i] != null) && (_actors[i] != ""); i++)
                {
                    stringBuilder.Append(_actors[i]).Append(", ");
                }
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }

        public virtual void Print_One_Film()
        {
            Console.WriteLine(this?.ToString());
        }

        // Статические поля и методы
        // Класс также содержит статические поля и методы,
        // в данном случае count - количество созданных объектов класса Film и
        // метод IncreaseCount для увеличения счетчика.
        public static int Count
        {
            get { return _counter; }
        }

        public static void IncreaseCounter()
        {
            _counter++;
        }

        public static void DecreaseCounter()
        {
            _counter--;
        }

        // Статический метод, который принимает FilmGenre и возвращает строку
        public static string GetGenreString(FilmGenre genre)
        {
            return _genres_str[(int)genre];
        }
    }
}



