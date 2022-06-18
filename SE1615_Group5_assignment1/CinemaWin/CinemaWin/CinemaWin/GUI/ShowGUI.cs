using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using CinemaWin.DAL;
using CinemaWin.DTL;
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

namespace CinemaWin.GUI
{
    public partial class ShowGUI : Form
    {   
        public ShowGUI()
        {
            InitializeComponent();
            bindGrid();
            cboFilm.DataSource = FilmDAO.GetInstance().GetDataTable();
            cboFilm.DisplayMember = "Title";
            cboFilm.ValueMember = "FilmID";
            cboFilm.SelectedValue = 1;

            comboBoxRoom.DataSource = RoomDAO.GetInstance().GetDataTable();
            comboBoxRoom.DisplayMember = "Name";
            comboBoxRoom.ValueMember = "RoomID";
            comboBoxRoom.SelectedValue = 1;
        }
        

      public void bindGrid()
        {
            DataTable dt = ShowDAO.GetInstance().GetDataTable();
            dataGridView1.DataSource = dt;
            int count = dt.Columns.Count;

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
          if (Settings.UserName == "" || Settings.UserName == null)
            {
              dataGridView1.Columns.RemoveAt(count);
              dataGridView1.Columns.RemoveAt(count);
              btnAdd.Enabled = false;
           }
            dataGridView1.Columns["showid"].Visible = false;
            dataGridView1.Columns["status"].Visible = false;
        }
        public void bindGrid3()
        {
            DataTable dt = ShowDAO.GetInstance().GetDataTable();
            dataGridView1.DataSource = dt;
            
        }
        void bindGrid2(int filmid, string showdate, int roomid)
        {
            DataTable dt = ShowDAO.GetInstance().GetDataTable2(roomid, filmid, showdate);
            dataGridView1.DataSource = dt;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                int showId = (int) dataGridView1.Rows[e.RowIndex].Cells["showId"].Value;
                Show show = ShowDAO.GetInstance().GetById(showId);
                
                ShowAddEditGUI f = new ShowAddEditGUI(show);
                DialogResult dr = f.ShowDialog();
                bindGrid3();
               
               

            }
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                int showId = (int)dataGridView1.Rows[e.RowIndex].Cells["showId"].Value;
                Show show = ShowDAO.GetInstance().GetById(showId);

                if (MessageBox.Show("Do you want to delete?", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ShowDAO.GetInstance().Delete(show.ShowId);
                    MessageBox.Show("Deleted");
                }

                bindGrid3();

            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            int filmid = (int)cboFilm.SelectedValue;
            string showdate = ComboxShowDate.Value.ToString("yyyy-MM-dd");
          
            int roomid = (int)comboBoxRoom.SelectedValue;
            bindGrid2(filmid, showdate, roomid);

             //  MessageBox.Show(d.ToString());
             MainGUI m = new MainGUI();
            m.showToolStripMenuItem_Click();
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
    }
}
