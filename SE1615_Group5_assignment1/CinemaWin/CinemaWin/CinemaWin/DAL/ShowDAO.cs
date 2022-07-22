using Microsoft.Data.SqlClient;
using CinemaWin.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWin.DAL
{
    public class ShowDAO : DAO
    {
        SqlCommand cmd = new SqlCommand();

        static ShowDAO Instance;
        ShowDAO() { }
        static ShowDAO() => Instance = new ShowDAO();
        public static ShowDAO GetInstance() => Instance;

        public DataTable GetDataTable() => GetDataTable("select * from shows");
        public DataTable GetDataTable2(int RoomID, int Film, string date) => GetDataTable("select * from shows where filmId= " + Film + " and ShowDate= '" + date + "' and roomId= " + RoomID);
        public Show GetById(int id)
        {
            DataTable dt = GetDataTable("select * from shows where showId = " + id);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            Show show = new Show
            {
                ShowId = (int)row["showId"],
                RoomId = (int)row["roomId"],
                FilmId = (int)row["filmId"],
                ShowDate = (DateTime)row["ShowDate"],
                //Status = (bool)row["status"],
                Slot = (int)row["slot"],
                Price = (decimal)row["price"]
            };
            return show;
        }
        public List<Show> Search(int RoomID,int Film,string date)
        {
            List<Show> s = new List<Show>();
            DataTable dt = GetDataTable("select *from shows where filmId= " + Film+" and ShowDate= '"+date+"' and roomId= " + RoomID);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            foreach (DataRow r in dt.Rows)
            {
                Show show = new Show
                {
                    ShowId = (int)row["showId"],
                    RoomId = (int)row["roomId"],
                    FilmId = (int)row["filmId"],
                    ShowDate = (DateTime)row["ShowDate"],
                    Status = (bool)row["status"],
                    Slot = (int)row["slot"],
                    Price = (decimal)row["price"]
                };
                s.Add(show);
            }
            return s;
        }

        public  void Insert(Int32 roomId, Int32 filmId, DateTime ShowDate ,Int32 slot, decimal price)
        {

            SqlCommand cmd = new SqlCommand("Insert into shows(RoomId, FilmId, ShowDate, Price, Slot) Values(" + roomId + ", " + filmId + ", '" + ShowDate + "', " + price + "," + slot +  ")" );


            Update(cmd);


        }
        public void Update(Show show, Int32 id)
        {

            SqlCommand cmd = new SqlCommand(@"Update shows set filmId = @filmId, slot = @slot, price = @price " +
                "where showId = " + id);

            cmd.Parameters.AddWithValue("@filmId", show.FilmId);
            cmd.Parameters.AddWithValue("@slot", show.Slot);
            cmd.Parameters.AddWithValue("@price", show.Price);
            //    cmd.Parameters.AddWithValue("@showId", show.ShowId);

            Update(cmd);


        }

        public void Delete(Int32 id)
        {
            SqlCommand cmd = new SqlCommand("Delete from shows where showId = " + id);

            Update(cmd);

        }


    }
}

