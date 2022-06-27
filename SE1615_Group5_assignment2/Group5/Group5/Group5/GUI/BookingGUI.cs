using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Group5.Models;

namespace Group5.GUI
{
    public partial class BookingGUI : Form
    {
        CinemaContext context;
        char[] mySeats = new char[1000];
        public BookingGUI(Show show, CinemaContext context)
        {
            InitializeComponent();
            this.context = context;
            txtShowId.Text = show.ShowId.ToString();
            txtRoomId.Text = show.RoomId.ToString();
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
                    chk.Checked = (seats[index] == '1') ? true : false;
                    chk.Enabled = false;
                    chk.Location = new Point((j + 1) * width, (i + 1) * height);
                    chk.Name = index.ToString();
                    pnlBook.Controls.Add(chk);
                }
            bindGridbooking();
        }



        public void bindGridbooking()
        {
            dataGridView1.Columns.Clear();
            pnlBook.Controls.Clear();
            Room room = context.Rooms.Where(r => r.RoomId == int.Parse(txtRoomId.Text)).FirstOrDefault();
            int nRows = (int)room.NumberRows;
            int nCols = (int)room.NumberCols;
            string seatStatus = new string('0', nRows * nCols);
            char[] seats = seatStatus.ToCharArray();

            var bookings = context.Bookings
                .Where(b => b.ShowId == int.Parse(txtShowId.Text))
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
                    chk.Checked = (seats[index] == '1') ? true : false;
                    chk.Enabled = false;
                    chk.Location = new Point((j + 1) * width, (i + 1) * height);
                    chk.Name = index.ToString();
                    pnlBook.Controls.Add(chk);
                }
            dataGridView1.DataSource = context.Bookings
                .Where(b => b.ShowId == int.Parse(txtShowId.Text))
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
            dataGridView1.Columns["showid"].Visible = false;
            dataGridView1.Columns["bookingid"].Visible = false;
        }
        
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblNo.Text = dataGridView1.Rows.Count.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int showId = int.Parse(txtShowId.Text);
            Room room = context.Rooms.Where(r => r.RoomId == int.Parse(txtShowId.Text)).FirstOrDefault();
            BookingAddGUI add = new BookingAddGUI(context, showId);
            DialogResult dr = add.ShowDialog();
            bindGridbooking();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Detail"].Index)
            {
                int bookingId = (int)dataGridView1.Rows[e.RowIndex].Cells["BookingId"].Value;
                int showId = (int)dataGridView1.Rows[e.RowIndex].Cells["showId"].Value;
                BookingDetailGUI book = new BookingDetailGUI(context, showId, bookingId);
                DialogResult dr = book.ShowDialog();
            }
            if (dataGridView1.Columns["Delete"] == null)
            {
                bindGridbooking();
            }
            else {
                if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
                {
                    int showId = (int)dataGridView1.Rows[e.RowIndex].Cells["showId"].Value;
                    int bookingId = (int)dataGridView1.Rows[e.RowIndex].Cells["bookingId"].Value;
                    Show show = context.Shows.Find(showId);
                    Booking book = context.Bookings.Find(bookingId);
                    if (MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            txtShowId.Text = show.ShowId.ToString();
                            Room room = context.Rooms.Where(r => r.RoomId == show.RoomId).FirstOrDefault();
                            int nRows = (int)room.NumberRows;
                            int nCols = (int)room.NumberCols;
                            string seatStatus = new string('0', nRows * nCols);
                            char[] seats = seatStatus.ToCharArray();
                            var bookings = context.Bookings
                                .Where(b => b.BookingId == bookingId)
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
                                    chk.Checked = (seats[index] == '1') ? true : false;
                                    chk.Enabled = false;
                                    chk.Location = new Point((j + 1) * width, (i + 1) * height);
                                    chk.Name = index.ToString();
                                    mySeats[int.Parse(chk.Name)] = chk.Checked ? '1' : '0';
                                    pnlBook.Controls.Add(chk);
                                }
                            context.Bookings.Remove(book);
                            context.SaveChanges();
                            MessageBox.Show("Delete successfully!");
                            BookingGUI bookGUI = new BookingGUI(show, context);
                            bindGridbooking();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
            }
            
        }

        private void BookingGUI_Load(object sender, EventArgs e)
        {

        }
    }
}

