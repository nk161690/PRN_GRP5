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

namespace CinemaWin.GUI
{
    public partial class BookingDetailGUI : Form
    {
        CinemaContext context = new CinemaContext();
        char[] mySeats = new char[1000];
        decimal amount, price;
        public BookingDetailGUI(CinemaContext context, int showId, int bookingId)
        {
            InitializeComponent();
            this.context = context;
            Show show = context.Shows.Find(showId);
            txtBookingId.Text = bookingId.ToString();
            price = (decimal)show.Price;
            Room room = context.Rooms.Where(r => r.RoomId == show.RoomId).FirstOrDefault();
            int nRows = (int)room.NumberRows;
            int nCols = (int)room.NumberCols;
            string seatStatus = new string('0', nRows * nCols);
            char[] seats = seatStatus.ToCharArray();
            mySeats = seatStatus.ToCharArray();

            var bookings = context.Bookings
                .Where(b => b.BookingId == bookingId)
                .ToList<Booking>();
            
            foreach (Booking b in bookings)
            {
                txtName.Text = b.Name;
                txtAmount.Text = b.Amount.ToString();
                for (int i = 0; i < b.SeatStatus.Length; i++)
                    if (b.SeatStatus[i] == '1') seats[i] = '1';
            }
            int width, height;
            width = pnlBookingDetail.Width / (nCols + 1);
            height = pnlBookingDetail.Height / (nRows + 1);

            for (int i = 0; i < nRows; i++)
                for (int j = 0; j < nCols; j++)
                {
                    CheckBox chk = new CheckBox();
                    chk.Size = new Size(width - 5, height - 5);
                    int index = i * nCols + j;
                    chk.Checked = (seats[index] == '1') ? true : false;
                    if (chk.Checked) chk.Enabled = false;
                    else chk.Enabled = true;
                    chk.Location = new Point((j + 1) * width, (i + 1) * height);
                    chk.Name = index.ToString();
                    //chk.CheckedChanged += Chk_CheckChanged;
                    pnlBookingDetail.Controls.Add(chk);
                }

        }

        private void Chk_CheckChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textShowId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
