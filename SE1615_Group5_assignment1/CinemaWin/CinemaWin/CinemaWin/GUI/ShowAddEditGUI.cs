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
        int add, id;
        CinemaContext context;
        ShowGUI s = new ShowGUI();
        //ADD: add = 1, id is roomId; EDIT: add = 0, id is showId
        public ShowAddEditGUI(int add, int id, CinemaContext context)
        {
            InitializeComponent();
            this.context = context;
            this.add = add;
            this.id = id;

            cboRoomId.DataSource = context.Rooms.ToList<Room>();
            cboRoomId.DisplayMember = "Name";
            cboRoomId.ValueMember = "RoomId";
            cboFilmId.DataSource = context.Films.ToList<Film>();
            cboFilmId.DisplayMember = "Title";
            cboFilmId.ValueMember = "FilmID";

            //EDIT
            if (add == 0)
            {
                Show show = context.Shows.Find(id);
                cboRoomId.SelectedValue = show.RoomId;
                dtpShowDate.Value = show.ShowDate??DateTime.Now;
                txtPrice.Text = show.Price.ToString();
                cboFilmId.SelectedValue = show.FilmId;
                bool[] slots = new bool[9];
                List<Show> shows = context.Shows.
                    Where(s => s.RoomId == show.RoomId
                    && s.ShowDate == show.ShowDate
                    && s.ShowId != show.ShowId).ToList<Show>();
                foreach (Show s in shows)
                    slots[(int)s.Slot - 1] = true;
                List<int> ls = new List<int>();
                for (int i = 0; i < slots.Length; i++)
                    if (slots[i] == false) ls.Add(i + 1);
                cboSlot.DataSource = ls;
                cboSlot.Text = show.Slot.ToString();
            }
            else
            {
                cboRoomId.Enabled = true;
                dtpShowDate.Enabled = true;
            }
        }

        private void cboRoomId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (add != 0)
            {
                int rId;
                Int32.TryParse(cboRoomId.SelectedValue.ToString(), out rId);
                DateTime date = dtpShowDate.Value;
                bool[] slots = new bool[9];
                List<Show> shows = context.Shows.
                    Where(s => s.RoomId == rId
                    && s.ShowDate == date).ToList<Show>();
                foreach (Show s in shows)
                    slots[(int)s.Slot - 1] = true;
                List<int> ls = new List<int>();
                for (int i = 0; i < slots.Length; i++)
                    if (slots[i] == false) ls.Add(i + 1);
                cboSlot.DataSource = ls;
                cboSlot.SelectedIndex = 0;
            }
        }

        private void dtpShowDate_ValueChanged(object sender, EventArgs e)
        {
            if (add != 0)
            {
                int rId = Convert.ToInt32(cboRoomId.SelectedValue.ToString().Trim());
                DateTime date = dtpShowDate.Value;
                bool[] slots = new bool[9];
                List<Show> shows = context.Shows.
                    Where(s => s.RoomId == rId
                    && s.ShowDate == date).ToList<Show>();
                foreach (Show s in shows)
                    slots[(int)s.Slot - 1] = true;
                List<int> ls = new List<int>();
                for (int i = 0; i < slots.Length; i++)
                    if (slots[i] == false) ls.Add(i + 1);
                cboSlot.DataSource = ls;
                cboSlot.SelectedIndex = 0;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            //EDIT
            if(add == 0)
            {
                try
                {
                    Show show = context.Shows.Find(id);
                    show.RoomId = (int)cboRoomId.SelectedValue;
                    show.ShowDate = dtpShowDate.Value;
                    show.Slot = int.Parse(cboSlot.Text);
                    show.FilmId = (int)cboFilmId.SelectedValue;
                    show.Price = Decimal.Parse(txtPrice.Text);

                    context.Shows.Update(show);
                    context.SaveChanges();
                    MessageBox.Show("That show is editted!");
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //ADD
            else
            {
                Show show = new Show();
                show.RoomId = (int)cboRoomId.SelectedValue;
                show.ShowDate = dtpShowDate.Value;
                show.Slot = int.Parse(cboSlot.Text);
                show.FilmId = (int)cboFilmId.SelectedValue;
                show.Price = Decimal.Parse(txtPrice.Text);

                context.Shows.Add(show);
                context.SaveChanges();
                MessageBox.Show("A new show is added!");
            }
        }
    }
}
