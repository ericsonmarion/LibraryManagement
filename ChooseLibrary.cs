using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn
{
    public partial class ChooseLibrary : Form
    {
        private string _userType = "";
        private const string rizalReceipts = "C:\\Users\\EM\\Documents\\LogIn-master-20241202T102501Z-001\\LogIn-master\\bin\\Debug\\Rizal_receipts.txt";
        private const string einsteinReceipts = "C:\\Users\\EM\\Documents\\LogIn-master-20241202T102501Z-001\\LogIn-master\\bin\\Debug\\Einstein_receipts.txt";

        public ChooseLibrary(string userType)
        {
            InitializeComponent();
            _userType = userType;
            lblWelcomeUser.Text = "Welcome " + userType;
            ShowRAvailableSeatsCount(rizalReceipts, lblAvailableSeatsRizal);
            ShowRAvailableSeatsCount(einsteinReceipts, lblAvaialbleSeatsEinstein);
        }

        private void ShowRAvailableSeatsCount(string path, Label lblCount)
        {
            if (File.Exists(path))
            {
                try
                {
                    string[] details = File.ReadAllLines(path);

                    int singleSeatCount = 21;
                    int discussionRoomSeat = 6;
                    int tpzdTableConut = 4;
                    int tpzdTableSeatCount = 4;
                    int taken = 0;
                    int avail = singleSeatCount + discussionRoomSeat + (tpzdTableConut * tpzdTableSeatCount);

                    //Dictionary<string, string[]> booking_details = new Dictionary<string, string[]>();
                    foreach (string line in details)
                    {
                        if (!line.Equals("-------------------") && !line.Equals(""))
                        {
                            string[] _data = line.ToString().Split(',');
                            string[] _name = _data[0].ToString().Split(':');
                            string[] _id = _data[1].ToString().Split(':');
                            string[] _time = _data[2].ToString().Split(':');
                            string[] _yrLvl = _data[3].ToString().Split(':');
                            string[] _term = _data[4].ToString().Split(':');
                            string[] _seat = _data[5].ToString().Split(':');
                            string[] _status = _data[6].ToString().Split(':');
                            string[] _date = _data[7].ToString().Split(':');

                            string name = _name[1].ToString().TrimStart();
                            string id = _id[1].ToString().TrimStart();
                            string time = _time[1].ToString().TrimStart() + ":" + _time[2].ToString().TrimStart() + ":" + _time[3].ToString().TrimStart();
                            string yr_level = _yrLvl[1].ToString().TrimStart();
                            string term = _term[1].ToString().TrimStart();
                            string seat = _seat[1].ToString().TrimStart();
                            string status = _status[1].ToString().TrimStart();
                            string date_booked = _date[1].ToString().TrimStart();
                            if (status.Equals("Open"))
                            {
                                taken++;
                                avail--;
                            }
                            //Dictionary.Add()
                        }
                    }

                    lblCount.Text = "Available seats: " + avail.ToString();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("An error has occurred while reading receipts file " + ex.Message, "Time Slot Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                lblCount.Text = "Available seats: 0";
            }
        }

        private void EinLibBtn_Click(object sender, EventArgs e)
        {
            EinsteinLiveDisplay einsteinLiveDisplayForm = new EinsteinLiveDisplay(_userType);
            einsteinLiveDisplayForm.Show();  // Open the RizalLiveDisplay form
            this.Hide();
        }

        private void RizLibBtn_Click(object sender, EventArgs e)
        {
            RizalLiveDisplay rizalLiveDisplayForm = new RizalLiveDisplay(_userType);
            rizalLiveDisplayForm.Show();  // Open the RizalLiveDisplay form
            this.Hide();
        }

        private void ChooseLibrary_Load(object sender, EventArgs e)
        {
            
        }

        private void pb_white_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
