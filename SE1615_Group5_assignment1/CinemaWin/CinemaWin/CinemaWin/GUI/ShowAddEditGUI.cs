using CinemaWin.DAL;
using CinemaWin.DTL;
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

namespace CinemaWin.GUI
{
    public partial class ShowAddEditGUI : Form
    {
        int add;
        public ShowAddEditGUI(Show show)
        {
            InitializeComponent();
            if (show == null) add = 1;
            else add = 0;



            if (add == 1)
            {
                cboRoomId.Enabled = true;
                dtpShowDate.Enabled = true;
                cboRoomId.DataSource = RoomDAO.GetInstance().GetDataTable();
                cboRoomId.DisplayMember = "Name";
                cboRoomId.ValueMember = "RoomId";
                //cboSlot.DataSource = ShowDAO.GetInstance().GetDataTable();
                int[] myArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                //  cboSlot.ValueMember = "Slot";

                //cboSlot.SelectedValue = show.Slot;
                cboFilmId.DataSource = FilmDAO.GetInstance().GetDataTable();
                cboFilmId.DisplayMember = "Title";
                cboFilmId.ValueMember = "FilmID";


            }
            else
            {

                dtpShowDate.Value = show.ShowDate;

                cboRoomId.DataSource = RoomDAO.GetInstance().GetDataTable();
                cboRoomId.DisplayMember = "Name";
                cboRoomId.ValueMember = "RoomId";

                cboRoomId.SelectedValue = show.RoomId;
                //cboSlot.DataSource = ShowDAO.GetInstance().GetDataTable();
                int[] myArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                //  cboSlot.ValueMember = "Slot";

                //cboSlot.SelectedValue = show.Slot;
                cboSlot.Text = show.Slot.ToString();
                cboFilmId.DataSource = FilmDAO.GetInstance().GetDataTable();
                cboFilmId.DisplayMember = "Title";
                cboFilmId.ValueMember = "FilmID";
                cboFilmId.SelectedValue = show.FilmId;
                txtPrice.Text = show.Price.ToString();
                txtshowid.Text = show.ShowId.ToString();
            }
        }

        private void ShowAddEditGUI_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int roomid = (int)cboRoomId.SelectedValue;
            int slot = (int)cboSlot.SelectedIndex + 1;
            if (slot == 10)
            {
                slot--;
            }
            int filmid = (int)cboFilmId.SelectedValue;
            string price = txtPrice.Text.ToString();

            DateTime showdate = dtpShowDate.Value;


            if (cboRoomId.Enabled == false) //Edit
            {
                int showid = Int32.Parse(txtshowid.Text.ToString());
                Show show = new Show
                {
                    ShowId = showid,
                    RoomId = roomid,
                    FilmId = filmid,
                    ShowDate = (DateTime)showdate,
                    Slot = slot,
                    Price = decimal.Parse(price)
                };
                ShowDAO.GetInstance().Update(show, showid);
                MessageBox.Show("That show is edited!");
            }
            else //add
            {
                Show show = new Show
                {
                    RoomId = roomid,
                    FilmId = filmid,
                    ShowDate = (DateTime)showdate,
                    Slot = slot,
                    Price = decimal.Parse(price)
                };
                ShowDAO.GetInstance().Insert(show.RoomId, show.FilmId, show.ShowDate, show.Slot, show.Price);
                MessageBox.Show("A new show is added!");
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtpShowDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboRoomId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboSlot_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboFilmId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
