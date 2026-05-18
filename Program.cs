using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_laba
{
    class Program
    {
        // Метод Main — точка входа в программу, принимает массив строковых аргументов командной строки
        static void Main(string[] args)
        {
            // Создаем экземпляр коллекции фильмов (типа Collection_Film) с именем collection_Birds
            Collection_Film collection_Birds = new Collection_Film();

            // Вызываем метод Filling_Collection для заполнения коллекции данными (например, из файла или вручную)
            collection_Birds.Filling_Collection();

            // Вызываем метод Print_Arr_Films для вывода списка всех фильмов на консоль
            collection_Birds.Print_Arr_Films();

            // Вызываем метод Print_Arr_Films_TTX для вывода дополнительных характеристик фильмов (возможно, технических)
            collection_Birds.Print_Arr_Films_TTX();

            // Обращаемся к элементу коллекции с индексом 3 (четвертый фильм) и вызываем его метод Print_One_Film для вывода информации об одном фильме
            collection_Birds[3].Print_One_Film();

            //Console.WriteLine("------------------------Add and Change Film---------------------------");

            ////  вызов метода Add_Film (добавление нового фильма через ввод с клавиатуры)
            //collection_Birds.Add_Film();
            ////  вызов метода Print_Arr_Films для повторного вывода списка после добавления
            //collection_Birds.Print_Arr_Films();

            ////  вызов метода Add_Film_With_Parameters (добавление фильма с жестко заданными параметрами)
            //collection_Birds.Add_Film_With_Parameters();
            ////  вызов метода Print_Arr_Films для вывода обновленного списка
            //collection_Birds.Print_Arr_Films();

            ////  замена элемента с индексом 0 на новый объект Widescreen_Film (широкоэкранный фильм) с указанными параметрами
            //collection_Birds.Change_Item(0, new Widescreen_Film(FilmGenre.Drama, "Зеленая книга", 2018, 321, new string[] { "Вигго Мортенсен", "Махершала Али" }));
            ////  вывод списка после замены
            //collection_Birds.Print_Arr_Films();

            ////  поиск фильма по названию "Мальчишник в Вегасе" и сохранение его индекса в переменную Index
            //int Index = collection_Birds.Find_film("Мальчишник в Вегасе");
            ////  вывод найденного индекса на консоль
            //Console.WriteLine(Index);

            Console.WriteLine("--------------Serialize_Collection_Films---------------------");

            // Вызов метода Serialize_Collection_Films для сохранения коллекции в файл (сериализация)
            collection_Birds.Serialize_Collection_Films();

            // Вызов метода Clearing_Collection для очистки текущей коллекции в памяти
            collection_Birds.Clearing_Collection();

            // Вывод списка фильмов после очистки (ожидаем пустой список или сообщение об отсутствии элементов)
            collection_Birds.Print_Arr_Films();

            Console.WriteLine("--------------DeSerialize_Collection_Films--------------------");

            // Вызов метода DeSerialize_Collection_Films для загрузки коллекции из ранее сохраненного файла (десериализация)
            collection_Birds.DeSerialize_Collection_Films();

            // Вывод восстановленного списка фильмов на консоль
            collection_Birds.Print_Arr_Films();

            Console.WriteLine("--------------------------------------------------------------");
        }
    }
}