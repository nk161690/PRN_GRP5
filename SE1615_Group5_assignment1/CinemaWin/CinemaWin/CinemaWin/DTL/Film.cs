using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWin.DTL
{
    class Film
    {
        public int FilmId { get; set; }
        public int GenreID { get; set; }
        public string Title
        { get; set; }
        public int Year { get; set; }

        public String CodeCoutry { get; set; }

    }
}
