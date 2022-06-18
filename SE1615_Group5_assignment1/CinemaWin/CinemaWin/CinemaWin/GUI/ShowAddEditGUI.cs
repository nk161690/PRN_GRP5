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
using System.Text.RegularExpressions;

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
            cboRoomId.DataSource = RoomDAO.GetInstance().GetDataTable();
            cboRoomId.DisplayMember = "Name";
            cboRoomId.ValueMember = "RoomId";
            cboFilmId.DataSource = FilmDAO.GetInstance().GetDataTable();
            cboFilmId.DisplayMember = "Title";
            cboFilmId.ValueMember = "FilmID";

            if (add == 1)
            {
                cboRoomId.Enabled = true;
                dtpShowDate.Enabled = true;
            }
            else if (add == 0)
            {
                cboRoomId.SelectedValue = show.RoomId;
                dtpShowDate.Value = show.ShowDate;
                cboFilmId.SelectedValue = show.FilmId;
                txtPrice.Text = show.Price.ToString();
                txtshowid.Text = show.ShowId.ToString();                            
                cboSlot.Items.Add(show.Slot);
                cboSlot.SelectedIndex = cboSlot.Items.Count-1;
                btnSave.Enabled = false;
            }
        }

        private void ShowAddEditGUI_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int roomid = (int)cboRoomId.SelectedValue;
            int slot = (int)cboSlot.SelectedValue;

            int filmid = (int)cboFilmId.SelectedValue;
            string price = txtPrice.Text.ToString();
            //Regex pattern = "^[0-9]$";
            //if(price.)
            decimal prc;
            DateTime showdate = dtpShowDate.Value;
            if (Decimal.TryParse(price, out prc))
            {
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
                    ShowDAO.GetInstance().Update(show);
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
                    ShowDAO.GetInstance().Insert(show);
                    MessageBox.Show("A new show is added!");
                }
            } else
            {
                MessageBox.Show("invalid price");
            }
        }

        public void dtpShowDate_ValueChanged(object sender, EventArgs e)
        {
            if (add == 1)
            {
                int rId = Convert.ToInt32(cboRoomId.SelectedValue.ToString().Trim());
                string date = dtpShowDate.Value.ToString("yyyy-MM-dd");
                DataTable dt = ShowDAO.GetInstance().GetDataTable3(rId, date);
                List<int> dataList = new List<int>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        int value = Convert.ToInt32(dt.Rows[i].ItemArray[j]);
                        dataList.Add(value);
                    }

                }
                List<int> slot = new List<int>();
                slot.Add(1);
                slot.Add(2);
                slot.Add(3);
                slot.Add(4);
                slot.Add(5);
                slot.Add(6);
                slot.Add(7);
                slot.Add(8);
                slot.Add(9);
                List<int> slotItem = slot.Except(dataList).ToList();
                cboSlot.DataSource = slotItem;
            }
        }

        public void cboRoomId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (add == 1)
            {
                int rId;
                if (Int32.TryParse(cboRoomId.SelectedValue.ToString(), out rId))
                {
                    rId = Int32.Parse(cboRoomId.SelectedValue.ToString());
                    string date = dtpShowDate.Value.ToString("yyyy-MM-dd");
                    DataTable dt = ShowDAO.GetInstance().GetDataTable3(rId, date);
                    List<int> dataList = new List<int>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            int value = Convert.ToInt32(dt.Rows[i].ItemArray[j]);
                            dataList.Add(value);
                        }

                    }
                    List<int> slot = new List<int>();
                    slot.Add(1);
                    slot.Add(2);
                    slot.Add(3);
                    slot.Add(4);
                    slot.Add(5);
                    slot.Add(6);
                    slot.Add(7);
                    slot.Add(8);
                    slot.Add(9);
                    List<int> slotItem = slot.Except(dataList).ToList();
                    cboSlot.DataSource = slotItem;
                }
            }
        }
       
        private void cboSlot_Click(object sender, EventArgs e)
        {
            int rId = Int32.Parse(cboRoomId.SelectedValue.ToString());
            string date = dtpShowDate.Value.ToString("yyyy-MM-dd");
            DataTable dt = ShowDAO.GetInstance().GetDataTable3(rId, date);
            List<int> dataList = new List<int>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    int value = Convert.ToInt32(dt.Rows[i].ItemArray[j]);
                    dataList.Add(value);
                }

            }
            List<int> slot = new List<int>();
            slot.Add(1);
            slot.Add(2);
            slot.Add(3);
            slot.Add(4);
            slot.Add(5);
            slot.Add(6);
            slot.Add(7);
            slot.Add(8);
            slot.Add(9);
            List<int> slotItem = slot.Except(dataList).ToList();
            cboSlot.DataSource = slotItem;
            btnSave.Enabled = true;
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
