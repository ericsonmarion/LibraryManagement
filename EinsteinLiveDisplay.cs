using System;
using System.Windows.Forms;

namespace LogIn
{
    public partial class EinsteinLiveDisplay : Form
    {
        private string _userType = string.Empty;
        public EinsteinLiveDisplay(string userType)
        {
            InitializeComponent();
            _userType = userType;
        }

        private void btnBookSeatEinstein_Click(object sender, EventArgs e)
        {
            Einstein_Reservation reservationForm = new Einstein_Reservation(this);

            // Show the Einstein_Reservation form
            reservationForm.Show();
            this.Hide(); // Hide the current form
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ChooseLibrary chooseLibrary = new ChooseLibrary(_userType);
            chooseLibrary.Show();
            this.Hide();
        }
    }
}