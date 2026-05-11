using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_laba
{
    class Program
    {
        static void Main(string[] args)
        {
            Collection_Film collection_Birds = new Collection_Film();

            collection_Birds.Filling_Collection();

            collection_Birds.Print_Arr_Films();

            collection_Birds.Print_Arr_Films_TTX();

            collection_Birds[3].Print_One_Film();

            Console.WriteLine("---------------------------------------------------");

            //collection_Birds.Add_Film();
            //collection_Birds.Print_Arr_Films();

            //collection_Birds.Add_Film_With_Parameters();
            //collection_Birds.Print_Arr_Films();


            //collection_Birds.Change_Item(0, new Widescreen_Film(FilmGenre.Drama, "Зеленая книга", 2018, 321, new string[] { "Вигго Мортенсен", "Махершала Али" }));
            //collection_Birds.Print_Arr_Films();

            //int Index = collection_Birds.Find_film("Мальчишник в Вегасе");
            //Console.WriteLine(Index);
            Console.WriteLine("--------------Serialize_Collection_Films---------------------");
            collection_Birds.Serialize_Collection_Films();
            collection_Birds.Clearing_Collection();
            collection_Birds.Print_Arr_Films();
            Console.WriteLine("--------------DeSerialize_Collection_Films--------------------");
            collection_Birds.DeSerialize_Collection_Films();
            collection_Birds.Print_Arr_Films();
            Console.WriteLine("--------------------------------------------------------------");












        }
    }
}