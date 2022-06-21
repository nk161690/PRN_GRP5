﻿using Microsoft.Data.SqlClient;
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
            dataGridView1.Columns.Insert(count, btnDelete);
            dataGridView1.Columns.Insert(count, btnEdit);    
            dataGridView1.Columns["showid"].Visible = false;
            dataGridView1.Columns["status"].Visible = false;
            //dataGridView1.Columns["Film"].Visible = false;
           // dataGridView1.Columns["Room"].Visible = false;
            //dataGridView1.Columns["Bookings"].Visible = false;
        }
        public void bindGrid3()
        {
            dataGridView1.DataSource = context.Shows.ToList<Show>();
        }
        void bindGrid2(int filmid, string showdate, int roomid)
        {            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                int showId = (int) dataGridView1.Rows[e.RowIndex].Cells["showId"].Value;
                Show show = context.Shows.Find(showId);
                
                ShowAddEditGUI f = new ShowAddEditGUI(show);
                DialogResult dr = f.ShowDialog(); 
            }
            //if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            //{
            //    //int showId = (int)dataGridView1.Rows[e.RowIndex].Cells["showId"].Value;
            //    //Show show = ShowDAO.GetInstance().GetById(showId);

            //    //if (MessageBox.Show("Do you want to delete?", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    //{
            //    //    ShowDAO.GetInstance().Delete(show.ShowId);
            //    //    MessageBox.Show("Deleted");
            //    //}

            //    //bindGrid3();

            //}
        }
     
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindGrid(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Show show2 = null;

            ShowAddEditGUI add = new ShowAddEditGUI(show2);
            DialogResult dr = add.ShowDialog();
            bindGrid3();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ShowGUI_Load(object sender, EventArgs e)
        {

        }

        private void cboFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void ComboxShowDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblNo.Text = dataGridView1.Rows.Count.ToString();
        }
    }
}
