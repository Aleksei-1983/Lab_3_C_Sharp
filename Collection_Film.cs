using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3_laba
{
    internal class Collection_Film
    {
        // Создать коллекцию на основе динамического массива.
        private List<Film> arr_films = new List<Film>();
        // Метод заполнения коллекции arr_fi
        public void Filling_Collection()
        {
            arr_films.Clear();
            arr_films.Add(new Widescreen_Film(FilmGenre.Action, "Тёмный рыцарь", 2008, 1004, new string[] { "Кристиан Бэйл", "Хит Леджер", "Аарон Экхарт" }));
            arr_films.Add(new Series(FilmGenre.Comedy, "Друзья", 1994, 236, 10, new string[] { "Дженнифер Энистон", "Кортни Кокс", "Лиза Кудроу" }));
            arr_films.Add(new Series(FilmGenre.Horror, "Очень странные дела", 2016, 34, 4, new string[] { "Милли Бобби Браун", "Финн Вулфхард", "Дэвид Харбор" }));
            arr_films.Add(new Widescreen_Film(FilmGenre.Romance, "Дневник памяти", 2004, 115, new string[] { "Райан Гослинг", "Рэйчел МакАдамс" }));
            arr_films.Add(new Series(FilmGenre.Thriller, "Во все тяжкие", 2008, 62, 5, new string[] { "Брайан Крэнстон", "Аарон Пол" }));
            arr_films.Add(new Widescreen_Film(FilmGenre.Action, "Интерстеллар", 2014, 701, new string[] { "Мэттью МакКонахи", "Энн Хэтэуэй" }));
            arr_films.Add(new Series(FilmGenre.Drama, "Корона", 2016, 40, 4, new string[] { "Клэр Фой", "Оливия Колман" }));
            arr_films.Add(new Widescreen_Film(FilmGenre.Comedy, "Мальчишник в Вегасе", 2009, 469, new string[] { "Брэдли Купер", "Эд Хелмс" }));
            arr_films.Add(new Series(FilmGenre.Drama, "Ведьмак", 2019, 24, 3, new string[] { "Генри Кавилл", "Аня Чалотра" }));
        }

        public void Print_Arr_Films_TTX()
        {
            Console.Write(" Всего фильмов: ");
            Console.WriteLine(Film.Count);
            Console.WriteLine($" Кол-во объектов в коллекции arr_films: {arr_films.Count}");
            Console.WriteLine($" Кол-во ячеек в коллекции arr_films: {arr_films.Capacity}");
            Console.WriteLine("---------------------------------------------------");
        }

        /// <summary>
        /// Вывод на консоль всех фильмов из массива и их общего количества.
        /// </summary>
        public void Print_Arr_Films()
        {
            Console.Write(" Всего фильмов: " + Film.Count);
            Console.WriteLine();
            foreach (var film in arr_films)
            {
                film.Print_One_Film();
            }
            Console.WriteLine("---------------------------------------------------");
        }

        /// <summary>
        /// Индексатор для доступа к элементам массива по индексу.
        /// </summary>
        /// <param name="Index">Индекс элемента.</param>
        /// <returns>Объект Film или null, если индекс вне диапазона.</returns>
        public Film this[int Index]
        {
            get
            {
                if (Index >= 0 && Index < arr_films.Count)
                    return arr_films[Index];
                else
                    return null;
            }
        }

        // Метод добавления объектов в коллекцию "по умолчанию"
        public void Add_Film()
        {
            Console.WriteLine(" Метод добавления фильмов в коллекцию \"по умолчанию\"");
            Console.WriteLine(" Какой тип фильма Вы хотите добавить ?");
            Console.Write(" Если широкоэкранный - 1, если сериал - 2 :");

            int choice = Regex_Method();

            switch (choice)
            {
                case 1:
                    Add_WidescreenFilm();
                    break;
                case 2:
                    Add_Series();
                    break;
                default:
                    Console.WriteLine(" Неверный выбор, фильм не добавлен.");
                    break;
            }
        }

        // Метод приема 1, 2 или 3 от пользователя
        public int Regex_Method()
        {
            string str = Console.ReadLine() ?? "";
            string pattern = @"^[1-2]$";
            Match match = Regex.Match(str, pattern);

            try
            {
                return Convert.ToInt32(match.ToString());
            }
            catch
            {
                Console.WriteLine(" Получено неверное управляющее значение");
                return 0;
            }
        }

        public void Add_WidescreenFilm()
        {
            Console.WriteLine(" Вы решили добавить широкоэкранный фильм");
            // Для Widescreen_Film нужен конструктор по умолчанию (если его нет, создаём)
            // Создаём объект с минимальными/пустыми данными
            arr_films.Add(new Widescreen_Film(FilmGenre.Unknown, "Нет названия", 0, 0, new string[0]));
            Console.WriteLine(" Широкоэкранный фильм добавлен.");
            Console.ReadLine();
        }

        public void Add_Series()
        {
            Console.WriteLine(" Вы решили добавить сериал");
            arr_films.Add(new Series(FilmGenre.Unknown, "Нет названия", 0, 0, 0, new string[0]));
            Console.WriteLine(" Сериал добавлен.");
            Console.ReadLine();
        }


        // Метод добавления объектов в коллекцию с параметрами (только для потомков)
        public void Add_Film_With_Parameters()
        {
            Console.WriteLine(" Метод добавления фильмов с параметрами");
            Console.WriteLine(" Какой тип фильма Вы хотите добавить?");
            Console.Write(" Если широкоэкранный фильм 1, если сериал - 2 :");

            int choice = Regex_Method();

            switch (choice)
            {
                case 1:
                    Add_Full_Widescreen_Film();
                    break;
                case 2:
                    Add_Full_Series();
                    break;
                default:
                    Console.WriteLine(" Неверный выбор. Добавление отменено.");
                    break;
            }
        }

        // Добавление широкоэкранного фильма с вводом всех параметров
        public void Add_Full_Widescreen_Film()
        {
            Console.WriteLine(" Введите данные для широкоэкранного фильма:");

            Console.Write(" Название: ");
            string title = Console.ReadLine() ?? "Без названия";

            int year = 0;
            while (true)
            {
                Console.Write(" Год выпуска: ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out year) && year > 1880 && year <= DateTime.Now.Year + 2)
                    break;
                Console.WriteLine(" Некорректный год, повторите ввод.");
            }

            FilmGenre genre = FilmGenre.Unknown;
            while (true)
            {
                Console.WriteLine("Выберите жанр:");
                for (int i = 0; i < Enum.GetNames(typeof(FilmGenre)).Length; i++)
                    Console.WriteLine($"{i} – {Film.GetGenreString((FilmGenre)i)}");

                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out int g) && g >= 0 && g <= 6)
                {
                    genre = (FilmGenre)g;
                    break;
                }
                Console.WriteLine(" Некорректный жанр, повторите ввод.");
            }

            int money = 0;
            while (true)
            {
                Console.Write(" Сборы (в млн $): ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out money) && money >= 0)
                    break;
                Console.WriteLine(" Некорректное значение сборов, повторите ввод.");
            }

            int count = 0;
            while (true)
            {
                Console.Write(" Количество актёров: ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out count) && count >= 0)
                    break;
                Console.WriteLine(" Некорректное количество, повторите ввод.");
            }

            string[] actors = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($" Актёр {i + 1}: ");
                actors[i] = Console.ReadLine() ?? "Неизвестный актёр";
            }

            arr_films.Add(new Widescreen_Film(genre, title, year, money, actors));
            Console.WriteLine(" Широкоэкранный фильм добавлен.");
        }

        // Добавление сериала с вводом всех параметров
        public void Add_Full_Series()
        {
            Console.WriteLine(" Введите данные для сериала:");

            Console.Write(" Название: ");
            string title = Console.ReadLine() ?? "Без названия";

            int year = 0;
            while (true)
            {
                Console.Write(" Год выпуска: ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out year) && year > 1880 && year <= DateTime.Now.Year + 2)
                    break;
                Console.WriteLine(" Некорректный год, повторите ввод.");
            }

            FilmGenre genre = FilmGenre.Unknown;
            while (true)
            {
                Console.Write(" Жанр (0-Action, 1-Comedy, 2-Drama, 3-Horror, 4-Romance, 5-Thriller, 6-Unknown): ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out int g) && g >= 0 && g <= 6)
                {
                    genre = (FilmGenre)g;
                    break;
                }
                Console.WriteLine(" Некорректный жанр, повторите ввод.");
            }

            int series = 0;
            while (true)
            {
                Console.Write(" Количество серий: ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out series) && series > 0)
                    break;
                Console.WriteLine(" Некорректное количество серий, повторите ввод.");
            }

            int season = 0;
            while (true)
            {
                Console.Write(" Номер сезона: ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out season) && season > 0)
                    break;
                Console.WriteLine(" Некорректный номер сезона, повторите ввод.");
            }

            int count = 0;
            while (true)
            {
                Console.Write(" Количество актёров: ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out count) && count >= 0)
                    break;
                Console.WriteLine(" Некорректное количество, повторите ввод.");
            }

            string[] actors = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($" Актёр {i + 1}: ");
                actors[i] = Console.ReadLine() ?? "Неизвестный актёр";
            }

            arr_films.Add(new Series(genre, title, year, series, season, actors));
            Console.WriteLine(" Сериал добавлен.");
        }

        //•	Метод удаления объектов из коллекции
        public void Del_bird(int index)
        {
            try
            {
                arr_films.RemoveAt(index);
            }
            catch
            {
                Console.WriteLine(" Удалить элемент из коллекции arr_films не удалось");
                Console.WriteLine(" Проверьте правильность индекса удаления");
            }
        }

        //• Метод изменения объекта в коллекции
        public void Change_Item(int index, Film film)
        {
            arr_films.RemoveAt(index); // Удаляем старый элемент
            Film.DecreaseCounter();
            arr_films.Insert(index, film);// Вставляем новый элемент взамен старого

        }

        // Метод полной очистки коллекции arr_films
        public void Clearing_Collection()
        {

            while (Film.Count > 0) 
                Film.DecreaseCounter();
            arr_films.Clear();

        }


        //• Метод поиска объекта по полю
        // Будем искать по полю Name (хотя можно сделать и по любому другому)
        public int Find_film(string str)
        {
            int Index = 0;
            foreach (var item in arr_films)
            {
                if (item.Title == str) return Index;
                Index++;
            }
            return -1;
        }
    }
}

