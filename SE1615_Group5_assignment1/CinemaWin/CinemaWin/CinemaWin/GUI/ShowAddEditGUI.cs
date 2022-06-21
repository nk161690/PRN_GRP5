using CinemaWin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CinemaWin.GUI;
using System.Text.RegularExpressions;

namespace CinemaWin.GUI
{
    public partial class ShowAddEditGUI : Form
    {
        int showId;
        CinemaContext context;
        public ShowAddEditGUI(Show show)
        {
            InitializeComponent();
            context = new CinemaContext();
            if (show == null) showId = 0;
            else showId = show.ShowId;
            cboRoomId.DataSource = context.Rooms.ToList<Room>();
            cboRoomId.DisplayMember = "Name";
            cboRoomId.ValueMember = "RoomId"; 
            cboFilmId.DataSource = context.Films.ToList<Film>();
            cboFilmId.DisplayMember = "Title";
            cboFilmId.ValueMember = "FilmID";

            if(showId != 0)
            {
                cboRoomId.SelectedValue = show.RoomId;
                dtpShowDate.Value = (DateTime)show.ShowDate;
                txtPrice.Text = show.Price.ToString();
                cboFilmId.SelectedValue = show.FilmId;
                bool[] slots = new bool[9];
                List<Show> shows = context.Shows.
                    Where(s => s.RoomId == show.RoomId
                    && s.ShowDate == show.ShowDate
                    && s.ShowId == show.ShowId).ToList<Show>();
                foreach(Show s in shows)
                {
                    slots[(int)s.Slot - 1] = true;
                }
                List<int> ls = new List<int>();
                for (int i = 0; i < slots.Length; i++)
                {
                    if (slots[i] == false) ls.Add(i + 1);
                }
                cboSlot.DataSource = ls;
                cboSlot.Text = show.Slot.ToString();
            } else
            {
                cboRoomId.Enabled = true;
                dtpShowDate.Enabled = true;              
            }
        }

        private void cboRoomId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rId;
            Int32.TryParse(cboRoomId.SelectedValue.ToString(), out rId);
            DateTime date = dtpShowDate.Value;
            bool[] slots = new bool[9];
            List<Show> shows = context.Shows.
                Where(s => s.RoomId == rId
                && s.ShowDate == date).ToList<Show>();
            foreach (Show s in shows)
            {
                slots[(int)s.Slot - 1] = true;
            }
            List<int> ls = new List<int>();
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] == false) ls.Add(i + 1);
            }
            cboSlot.DataSource = ls;
        }

        private void dtpShowDate_ValueChanged(object sender, EventArgs e)
        {
            int rId = Convert.ToInt32(cboRoomId.SelectedValue.ToString().Trim());
            DateTime date = dtpShowDate.Value;
            bool[] slots = new bool[9];
            List<Show> shows = context.Shows.
                Where(s => s.RoomId == rId
                && s.ShowDate == date).ToList<Show>();
            foreach (Show s in shows)
            {
                slots[(int)s.Slot - 1] = true;
            }
            List<int> ls = new List<int>();
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] == false) ls.Add(i + 1);
            }
            cboSlot.DataSource = ls;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal prc;
            if (!Decimal.TryParse(txtPrice.Text.ToString(), out prc))
            {
                MessageBox.Show("Invalid Price!");
            }
            Show show = new Show
            {
                RoomId = (int)cboRoomId.SelectedValue,
                FilmId = (int)cboFilmId.SelectedValue,
                ShowDate = dtpShowDate.Value,
                Slot = (int?)cboSlot.SelectedValue,
                Price = prc
            };
            if (showId != 0)
            {
                show.ShowId = showId;
                context.Shows.Update(show);
            }
            else
            {
                context.Shows.Add(show);
            }
            context.SaveChanges();
        }
    }
}
