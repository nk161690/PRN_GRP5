using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWin.DTL
{
    public class Show
    {
       

        public int ShowId { get; set; }
        public int RoomId { get; set; }
        public int FilmId { get; set; }
        public DateTime ShowDate { get; set; }
        public bool Status { get; set; }
        public int Slot { get; set; }
        public decimal Price { get; set; }

        
    }
}
