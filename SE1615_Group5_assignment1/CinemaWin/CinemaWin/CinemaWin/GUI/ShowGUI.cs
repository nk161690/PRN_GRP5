using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CinemaWin.Models;

namespace CinemaWin.GUI
{
    public partial class ShowGUI : Form
    {
        CinemaContext context;
        public ShowGUI()
        {
            InitializeComponent();
            context = new CinemaContext();
            
            cboFilmId.DataSource = context.Films.ToList<Film>();
            cboFilmId.DisplayMember = "Title";
            cboFilmId.ValueMember = "FilmID";
            cboFilmId.SelectedValue = 1;

            cboRoomId.DataSource = context.Rooms.ToList<Room>();
            cboRoomId.DisplayMember = "Name";
            cboRoomId.ValueMember = "RoomID";
            cboRoomId.SelectedValue = 1;

            bindGrid(false);
        }
        

      public void bindGrid(bool filter)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = context.Shows
                .Where(s => s.FilmId == (filter ? (int)cboFilmId.SelectedValue : s.FilmId)
                && s.ShowDate == (filter ? dtpShowDate.Value : s.ShowDate)
                && s.RoomId == (filter ? (int)cboRoomId.SelectedValue : s.RoomId))
                .OrderByDescending(s => s.ShowDate)
                .ToList<Show>();
            int count = dataGridView1.Columns.Count;

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn
            {
                Name = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            DataGridViewButtonColumn btnBooking = new DataGridViewButtonColumn
            {
                Name = "Booking",
                Text = "Booking",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count, btnDelete);
            dataGridView1.Columns.Insert(count, btnEdit);
            dataGridView1.Columns.Insert(count, btnBooking);
            if (Settings.UserName == "" || Settings.UserName == null)
            {
                dataGridView1.Columns.RemoveAt(count);
                dataGridView1.Columns.RemoveAt(count);
                dataGridView1.Columns.RemoveAt(count);
                btnAdd.Enabled = false;
            }
            dataGridView1.Columns["showid"].Visible = false;
            dataGridView1.Columns["status"].Visible = false;
            //dataGridView1.Columns["Film"].Visible = false;
            // dataGridView1.Columns["Room"].Visible = false;
            //dataGridView1.Columns["Bookings"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Booking"].Index)
            {
                int showId = (int)dataGridView1.Rows[e.RowIndex].Cells["showId"].Value;
                Show show = context.Shows.Find(showId);

                //ShowAddEditGUI f = new ShowAddEditGUI(show);
                //DialogResult dr = f.ShowDialog();
            }
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                int showId = (int) dataGridView1.Rows[e.RowIndex].Cells["showId"].Value;
                Show show = context.Shows.Find(showId);
                
                ShowAddEditGUI edit = new ShowAddEditGUI(0, showId, context);
                DialogResult dr = edit.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    bindGrid(true);
                }
            }                      
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                int showId = (int)dataGridView1.Rows[e.RowIndex].Cells["showId"].Value;
                Show show = context.Shows.Find(showId);

                if (MessageBox.Show("Do you want to delete?", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        context.Shows.Remove(show);
                        context.SaveChanges();
                        bindGrid(true);
                        MessageBox.Show("Deleted!");
                    } catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }               
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindGrid(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int roomId = (int)cboRoomId.SelectedValue;
            ShowAddEditGUI add = new ShowAddEditGUI(1, roomId, context);
            DialogResult dr = add.ShowDialog();
            bindGrid(false);
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblNo.Text = dataGridView1.Rows.Count.ToString();
        }
    }
}
