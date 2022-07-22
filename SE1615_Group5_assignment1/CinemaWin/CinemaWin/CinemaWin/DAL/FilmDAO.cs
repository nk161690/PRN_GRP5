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
    class FilmDAO : DAO
    {

        static FilmDAO Instance;
        FilmDAO() { }
        static FilmDAO()
        {
            Instance = new FilmDAO();
        }
        public static FilmDAO GetInstance() { return Instance; }

        public DataTable GetDataTable() {
            return GetDataTable("select * from Films");
        } 

        public string GetNameById(int id)
        {
            DataTable dt = GetDataTable("select Title from Films where FilmID = " + id);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];

            string a = (string)row["Title"];

            return a;
        }

    }
}


