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
    public partial class BookingAddGUI : Form
    {
        CinemaContext context = new CinemaContext();
        char[] mySeats = new char[1000];
        decimal amount, price;
        public BookingAddGUI(CinemaContext context, int showId)
        {
            InitializeComponent();
            this.context = context;
            Show show = context.Shows.Find(showId);
            txtShowId.Text = showId.ToString();
            price = (decimal)show.Price;
            Room room = context.Rooms.Where(r => r.RoomId == show.RoomId).FirstOrDefault();
            int nRows = (int)room.NumberRows;
            int nCols = (int)room.NumberCols;
            string seatStatus = new string('0', nRows * nCols);
            char[] seats = seatStatus.ToCharArray();
            mySeats = seatStatus.ToCharArray();

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
                    if (chk.Checked) chk.Enabled = false;
                    else chk.Enabled = true;
                    chk.Location = new Point((j + 1) * width, (i + 1) * height);
                    chk.Name = index.ToString();
                    chk.CheckedChanged += Chk_CheckChanged;
                    pnlBook.Controls.Add(chk);
                }
        }

        private void Chk_CheckChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked) amount += price;
            else amount -= price;
            txtAmount.Text = amount.ToString();
            mySeats[int.Parse(chk.Name)] = chk.Checked ? '1' : '0';
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void pnlBook_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BookingAddGUI_Load(object sender, EventArgs e)
        {

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(new string(mySeats));
                Booking book = new Booking();
                book.ShowId = int.Parse(txtShowId.Text);
                book.Name = txtName.Text.ToString();
                book.SeatStatus = new string(mySeats);
                book.Amount = decimal.Parse(txtAmount.Text);
                if (book.Amount < 0) { MessageBox.Show("Amount must > 0!"); return; }

                context.Bookings.Add(book);
                context.SaveChanges();
                MessageBox.Show("Your booking is saved!");
                this.DialogResult = DialogResult.Cancel;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
