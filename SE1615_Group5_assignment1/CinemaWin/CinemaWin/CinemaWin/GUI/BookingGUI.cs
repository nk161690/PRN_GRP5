using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CinemaWin.Models;

namespace CinemaWin.GUI
{
    public partial class BookingGUI : Form
    {
        CinemaContext context;
        public BookingGUI()
        {
            InitializeComponent();
            context = new CinemaContext();

            bindGrid();
        }

        public void bindGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = context.Bookings.ToList<Booking>();
            int count = dataGridView1.Columns.Count;

            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn
            {
                Name = "Detail",
                Text = "Detail",
                UseColumnTextForButtonValue = true
            };
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count, btnDelete);
            dataGridView1.Columns.Insert(count, btnDetail);            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblNo.Text = dataGridView1.Rows.Count.ToString();
        }
    }
}
