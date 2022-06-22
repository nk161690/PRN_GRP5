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
        public BookingGUI(Show show, CinemaContext context)
        {
            InitializeComponent();
            this.context = context;
            Room room = context.Rooms.Where(r => r.RoomId == show.RoomId).FirstOrDefault();
            int nRows = (int)room.NumberRows;
            int nCols = (int)room.NumberCols;
            string seatStatus = new string('0', nRows * nCols);
            char[] seats = seatStatus.ToCharArray();

            var bookings = context.Bookings
                .Where(b => b.ShowId == show.ShowId)
                .ToList<Booking>();
            foreach (Booking b in bookings)
            {
                for (int i = 0; i < b.SeatStatus.Length; i++)
                    if (b.SeatStatus[i] == '1') seats[i] = '1';
            }
            int width, height;
            width = pnlBook.Width / (nCols + 1);
            height = pnlBook.Height / (nRows + 1);

            for (int i = 0; i < nRows; i++)
                for (int j = 0; j < nCols; j++)
                {
                    CheckBox chk = new CheckBox();
                    chk.Size = new Size(width - 5, height - 5);
                    int index = i * nCols + j;
                    //chk.Checked = (seats[index] == '1') ? true : false;
                    //if (chk.Checked) chk.Enabled = false;
                    //else chk.Enabled = true;
                    chk.Location = new Point((j + 1) * width, (i + 1) * height);
                    chk.Name = index.ToString();
                    //chk.CheckedChanged += Chk_CheckChanged;
                    pnlBook.Controls.Add(chk);
                }

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = context.Bookings
                .Where(b => b.ShowId == show.ShowId)
                .ToList<Booking>();
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

        private void Chk_CheckChanged(object sender, EventArgs e)
        {
            //CheckBox chk = (CheckBox)sender;
            //if (chk.Checked) amount += price;
            //else amount -= price;
            //txtAmount.Text = amount.toString();
            //mySeats[int.Parse(chk.Name)] = chk.Checked ? '1' : '0';
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblNo.Text = dataGridView1.Rows.Count.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
