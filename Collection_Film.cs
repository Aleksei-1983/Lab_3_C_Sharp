using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        //• Метод печати информации о коллекции (количество объектов, ёмкость)
        public void Print_Arr_Films_TTX()
        {
            Console.Write(" Всего фильмов: "); // Выводит текст " Всего фильмов: " без перевода строки
            Console.WriteLine(Film.Count); // Выводит общее количество созданных фильмов (статическое поле Count) и переводит строку
            Console.WriteLine($" Кол-во объектов в коллекции arr_films: {arr_films.Count}"); // Выводит количество элементов в коллекции arr_films
            Console.WriteLine($" Кол-во ячеек в коллекции arr_films: {arr_films.Capacity}"); // Выводит ёмкость (внутренний размер) коллекции arr_films
            Console.WriteLine("---------------------------------------------------"); // Разделительная линия
        }

        //• Метод печати всех фильмов в коллекции
        public void Print_Arr_Films()
        {
            Console.Write(" Всего фильмов: " + Film.Count); // Выводит текст и общее количество фильмов без перевода строки
            Console.WriteLine(); // Переводит строку после предыдущего вывода
            foreach (var film in arr_films) // Цикл по каждому объекту film в коллекции arr_films
            {
                film.Print_One_Film(); // Вызывает метод вывода информации об одном фильме
            }
            Console.WriteLine("---------------------------------------------------"); // Разделительная линия после печати всех фильмов
        }

        //• Индексатор для доступа к элементам коллекции по индексу
        public Film this[int Index]
        {
            get // Блок чтения индексатора
            {
                if (Index >= 0 && Index < arr_films.Count) // Проверяет, что индекс находится в допустимых пределах
                    return arr_films[Index]; // Возвращает элемент коллекции по указанному индексу
                else
                    return null; // Если индекс неверен, возвращает null
            }
        }

        //• Метод добавления объектов в коллекцию "по умолчанию"
        public void Add_Film()
        {
            Console.WriteLine(" Метод добавления фильмов в коллекцию \"по умолчанию\""); // Вывод названия метода
            Console.WriteLine(" Какой тип фильма Вы хотите добавить ?"); // Спрашивает тип добавляемого фильма
            Console.Write(" Если широкоэкранный - 1, если сериал - 2 :"); // Подсказка для выбора

            int choice = Regex_Method(); // Получает от пользователя число 1 или 2 через метод Regex_Method

            switch (choice) // Выбор действия в зависимости от ввода
            {
                case 1: // Если выбрал широкоэкранный фильм
                    Add_WidescreenFilm(); // Вызов метода добавления широкоэкранного фильма
                    break; // Выход из switch
                case 2: // Если выбрал сериал
                    Add_Series(); // Вызов метода добавления сериала
                    break; // Выход из switch
                default: // Если введено не 1 и не 2
                    Console.WriteLine(" Неверный выбор, фильм не добавлен."); // Сообщение об ошибке
                    break; // Выход из switch
            }
        }

        //• Метод приема 1, 2 или 3 от пользователя (здесь только 1-2)
        public int Regex_Method()
        {
            string str = Console.ReadLine() ?? ""; // Считывает строку с консоли, если null – заменяет на пустую строку
            string pattern = @"^[1-2]$"; // Регулярное выражение: строка должна состоять из одной цифры 1 или 2
            Match match = Regex.Match(str, pattern); // Проверяет строку на соответствие шаблону

            try // Блок перехвата исключений
            {
                return Convert.ToInt32(match.ToString()); // Пытается преобразовать найденное совпадение в целое число и вернуть его
            }
            catch // Если преобразование не удалось (например, пустая строка)
            {
                Console.WriteLine(" Получено неверное управляющее значение"); // Сообщение об ошибке
                return 0; // Возвращает 0 как признак ошибки
            }
        }

        //• Метод добавления широкоэкранного фильма с пустыми/минимальными данными
        public void Add_WidescreenFilm()
        {
            Console.WriteLine(" Вы решили добавить широкоэкранный фильм"); // Подтверждение выбора
            // Для Widescreen_Film нужен конструктор по умолчанию (если его нет, создаём)
            // Создаём объект с минимальными/пустыми данными
            arr_films.Add(new Widescreen_Film(FilmGenre.Unknown, "Нет названия", 0, 0, new string[0])); // Добавляет в коллекцию новый объект Widescreen_Film с заглушками
            Console.WriteLine(" Широкоэкранный фильм добавлен."); // Сообщение об успешном добавлении
            Console.ReadLine(); // Ожидает нажатия Enter, чтобы пользователь увидел сообщение
        }

        //• Метод добавления сериала с пустыми/минимальными данными
        public void Add_Series()
        {
            Console.WriteLine(" Вы решили добавить сериал"); // Подтверждение выбора
            arr_films.Add(new Series(FilmGenre.Unknown, "Нет названия", 0, 0, 0, new string[0])); // Добавляет объект Series с заглушками
            Console.WriteLine(" Сериал добавлен."); // Сообщение об успешном добавлении
            Console.ReadLine(); // Ожидание нажатия Enter
        }

        //• Метод добавления объектов в коллекцию с параметрами (только для потомков)
        public void Add_Film_With_Parameters()
        {
            Console.WriteLine(" Метод добавления фильмов с параметрами"); // Заголовок метода
            Console.WriteLine(" Какой тип фильма Вы хотите добавить?"); // Спрашивает тип
            Console.Write(" Если широкоэкранный фильм 1, если сериал - 2 :"); // Подсказка

            int choice = Regex_Method(); // Получение выбора 1 или 2

            switch (choice) // Ветвление по выбору
            {
                case 1: // Широкоэкранный
                    Add_Full_Widescreen_Film(); // Вызов метода ввода всех параметров для широкоэкранного
                    break;
                case 2: // Сериал
                    Add_Full_Series(); // Вызов метода ввода всех параметров для сериала
                    break;
                default: // Ошибка выбора
                    Console.WriteLine(" Неверный выбор. Добавление отменено.");
                    break;
            }
        }

        //• Добавление широкоэкранного фильма с вводом всех параметров
        public void Add_Full_Widescreen_Film()
        {
            Console.WriteLine(" Введите данные для широкоэкранного фильма:"); // Приглашение к вводу

            Console.Write(" Название: "); // Запрос названия
            string title = Console.ReadLine() ?? "Без названия"; // Считывание названия, если null – подставляется строка "Без названия"

            int year = 0; // Инициализация переменной года
            while (true) // Бесконечный цикл для корректного ввода года
            {
                Console.Write(" Год выпуска: "); // Запрос года
                string input = Console.ReadLine() ?? ""; // Считывание строки
                if (int.TryParse(input, out year) && year > 1880 && year <= DateTime.Now.Year + 2) // Проверка: число и диапазон (от 1880 до текущий год+2)
                    break; // Выход из цикла, если год корректен
                Console.WriteLine(" Некорректный год, повторите ввод."); // Сообщение об ошибке
            }

            FilmGenre genre = FilmGenre.Unknown; // Переменная для жанра, начальное значение Unknown
            while (true) // Цикл выбора жанра
            {
                Console.WriteLine("Выберите жанр:"); // Заголовок списка жанров
                for (int i = 0; i < Enum.GetNames(typeof(FilmGenre)).Length; i++) // Цикл по всем элементам перечисления FilmGenre
                    Console.WriteLine($"{i} – {Film.GetGenreString((FilmGenre)i)}"); // Выводит номер и строковое представление жанра

                string input = Console.ReadLine() ?? ""; // Считывание выбора
                if (int.TryParse(input, out int g) && g >= 0 && g <= 6) // Проверка, что введено число от 0 до 6
                {
                    genre = (FilmGenre)g; // Присваиваем жанр
                    break; // Выход из цикла
                }
                Console.WriteLine(" Некорректный жанр, повторите ввод."); // Ошибка ввода
            }

            int money = 0; // Переменная для сборов
            while (true) // Цикл ввода сборов
            {
                Console.Write(" Сборы (в млн $): "); // Запрос сборов
                string input = Console.ReadLine() ?? ""; // Считывание
                if (int.TryParse(input, out money) && money >= 0) // Проверка, что целое неотрицательное
                    break; // Успех
                Console.WriteLine(" Некорректное значение сборов, повторите ввод."); // Ошибка
            }

            int count = 0; // Количество актёров
            while (true) // Цикл ввода количества актёров
            {
                Console.Write(" Количество актёров: "); // Запрос
                string input = Console.ReadLine() ?? ""; // Считывание
                if (int.TryParse(input, out count) && count >= 0) // Проверка на целое неотрицательное
                    break; // Успех
                Console.WriteLine(" Некорректное количество, повторите ввод."); // Ошибка
            }

            string[] actors = new string[count]; // Создаём массив строк размером count
            for (int i = 0; i < count; i++) // Цикл ввода имён актёров
            {
                Console.Write($" Актёр {i + 1}: "); // Запрос имени актёра с номером
                actors[i] = Console.ReadLine() ?? "Неизвестный актёр"; // Считывание, если null – подставляется заглушка
            }

            arr_films.Add(new Widescreen_Film(genre, title, year, money, actors)); // Добавляем созданный объект в коллекцию
            Console.WriteLine(" Широкоэкранный фильм добавлен."); // Подтверждение
        }

        //• Добавление сериала с вводом всех параметров
        public void Add_Full_Series()
        {
            Console.WriteLine(" Введите данные для сериала:"); // Приглашение

            Console.Write(" Название: "); // Запрос названия
            string title = Console.ReadLine() ?? "Без названия"; // Считывание

            int year = 0; // Год
            while (true) // Цикл ввода года (аналогично)
            {
                Console.Write(" Год выпуска: ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out year) && year > 1880 && year <= DateTime.Now.Year + 2)
                    break;
                Console.WriteLine(" Некорректный год, повторите ввод.");
            }

            FilmGenre genre = FilmGenre.Unknown; // Жанр
            while (true) // Цикл ввода жанра (упрощённый вариант — цифра от 0 до 6)
            {
                Console.Write(" Жанр (0-Action, 1-Comedy, 2-Drama, 3-Horror, 4-Romance, 5-Thriller, 6-Unknown): "); // Подсказка с вариантами
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out int g) && g >= 0 && g <= 6)
                {
                    genre = (FilmGenre)g;
                    break;
                }
                Console.WriteLine(" Некорректный жанр, повторите ввод.");
            }

            int series = 0; // Количество серий
            while (true) // Цикл ввода серий
            {
                Console.Write(" Количество серий: ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out series) && series > 0) // Положительное целое
                    break;
                Console.WriteLine(" Некорректное количество серий, повторите ввод.");
            }

            int season = 0; // Номер сезона
            while (true) // Цикл ввода сезона
            {
                Console.Write(" Номер сезона: ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out season) && season > 0) // Положительное целое
                    break;
                Console.WriteLine(" Некорректный номер сезона, повторите ввод.");
            }

            int count = 0; // Количество актёров
            while (true) // Цикл ввода количества актёров
            {
                Console.Write(" Количество актёров: ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out count) && count >= 0)
                    break;
                Console.WriteLine(" Некорректное количество, повторите ввод.");
            }

            string[] actors = new string[count]; // Массив актёров
            for (int i = 0; i < count; i++) // Заполнение массива
            {
                Console.Write($" Актёр {i + 1}: ");
                actors[i] = Console.ReadLine() ?? "Неизвестный актёр";
            }

            arr_films.Add(new Series(genre, title, year, series, season, actors)); // Добавление сериала в коллекцию
            Console.WriteLine(" Сериал добавлен."); // Подтверждение
        }

        //• Метод удаления объектов из коллекции
        public void Del_bird(int index) // Название с опечаткой (bird вместо film)
        {
            try // Блок попытки выполнения
            {
                arr_films.RemoveAt(index); // Удаляет элемент коллекции по указанному индексу
            }
            catch // Если возникло исключение (неверный индекс)
            {
                Console.WriteLine(" Удалить элемент из коллекции arr_films не удалось"); // Сообщение об ошибке
                Console.WriteLine(" Проверьте правильность индекса удаления"); // Рекомендация
            }
        }

        //• Метод изменения объекта в коллекции
        public void Change_Item(int index, Film film)
        {
            arr_films.RemoveAt(index); // Удаляем старый элемент по индексу
            Film.DecreaseCounter(); // Уменьшаем статический счетчик фильмов (так как объект удалён)
            arr_films.Insert(index, film); // Вставляем новый элемент на то же место
        }

        //• Метод полной очистки коллекции arr_films
        public void Clearing_Collection()
        {
            while (Film.Count > 0) // Пока общее количество фильмов больше нуля
                Film.DecreaseCounter(); // Уменьшаем статический счетчик (вызывается для каждого удаляемого фильма)
            arr_films.Clear(); // Очищает коллекцию arr_films
        }

        //• Метод поиска объекта по полю
        // Будем искать по полю Name (хотя можно сделать и по любому другому)
        public int Find_film(string str)
        {
            int Index = 0; // Начальный индекс
            foreach (var item in arr_films) // Перебираем все элементы коллекции
            {
                if (item.Title == str) // Сравниваем название фильма (Title) с искомой строкой
                    return Index; // Если совпало, возвращаем текущий индекс
                Index++; // Увеличиваем индекс для следующего элемента
            }
            return -1; // Если ничего не найдено, возвращаем -1
        }



        // Метод сериализации (сохранения) коллекции фильмов в XML-файл
        // ------------------------------------------------------------------------------------------------
        public void Serialize_Collection_Films()
        {
            string xmlFilePath = "save_Films.xml"; // Задаёт имя файла для сохранения данных

            // Проводим сериализацию коллекции в файл в формате XML
            SerializeToXml(arr_films, xmlFilePath); // Вызывает статический метод для записи списка arr_films в XML-файл
        }

        //• Метод десериализации (загрузки) коллекции фильмов из XML-файла
        public void DeSerialize_Collection_Films()
        {
            string xmlFilePath = "save_Films.xml"; // Имя файла, откуда будут загружаться данные

            // Проводим сериализацию коллекции в файл в формате XML (в комментарии опечатка: имеется в виду десериализация)
            arr_films = DeserializeFromXml(xmlFilePath); // Загружает список фильмов из XML-файла и присваивает его полю arr_films
        }

        //• Статический метод для записи списка фильмов в XML-файл
        public static void SerializeToXml(List<Film> birds, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Film>)); // Создаёт объект XmlSerializer для работы со списком фильмов

            using (FileStream fs = new FileStream(filePath, FileMode.Create)) // Открывает файловый поток для записи (создаёт или перезаписывает файл)
            {
                serializer.Serialize(fs, birds); // Выполняет сериализацию: записывает список birds в поток fs в формате XML
            } // Блок using автоматически закрывает и освобождает файловый поток
        }

        //• Статический метод для чтения списка фильмов из XML-файла
        public static List<Film> DeserializeFromXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Film>)); // Создаёт сериализатор для работы со списком фильмов

            using (FileStream fs = new FileStream(filePath, FileMode.Open)) // Открывает файловый поток для чтения (файл должен существовать)
            {
                return (List<Film>)serializer.Deserialize(fs); // Десериализует данные из потока в объект типа List<Film> и возвращает его
            } // Блок using автоматически закрывает поток
        }

    }
}

