using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_laba
{
    // Перечисление жанров (как в оригинале)
    public enum FilmGenre
    {
        Action,
        Comedy,
        Drama,
        Horror,
        Romance,
        Thriller,
        Unknown
    }
    
    interface I_Film
    {
        // Свойства названия жанра
        public FilmGenre Genre { get; set;  }
        // Свойства название фильма
        public string Title { get; set; }
        // Свойство год
        public int Year { get; set; }   

        // Методы
        // Для добавления нового актера в список актеров используется метод AddActor
        public void AddActor(string actor);


    }
}
