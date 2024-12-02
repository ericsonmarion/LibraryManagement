using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Forms;

namespace LogIn
{
    public partial class RizalLiveDisplay : Form
    {
        private Dictionary<Button, bool> seatOccupancy = new Dictionary<Button, bool>();
        private Dictionary<string, Button> seatNameToButton;
        private Dictionary<string, bool> timeSlotOccupancy = new Dictionary<string, bool>(); // To store time slot availability
        private const string receipts = "C:\\Users\\EM\\Documents\\LogIn-master-20241202T102501Z-001\\LogIn-master\\bin\\Debug\\Rizal_receipts.txt";
        private string _userType = string.Empty;

        public RizalLiveDisplay(string userType)
        {
            InitializeComponent();
            lblLiveTimeRizal.Text = DateTime.Now.ToString("HH:mm:ss");  // Display the current time in 24-hour format
            lblLiveTimeRizal.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            InitializeSeatMapping();
            InitializeTimeSlotOccupancy();

            InitializeSeatsAvailable();
            _userType = userType;
        }

        private void InitializeSeatMapping()
        {
            seatNameToButton = new Dictionary<string, Button>
            {
                { "Sofa 1", btnSofa1 },
                { "Sofa 2", btnSofa2 },
                { "Sofa 3", btnSofa3 },
                { "Sofa 4", btnSofa4 },
                { "Sofa 5", btnSofa5 },
                { "Sofa 6", btnSofa6 },
                { "Bean Bag 1", btnBB1 },
                { "Bean Bag 2", btnBB2 },
                { "Bean Bag 3", btnBB3 },
                { "Bean Bag 4", btnBB4 },
                { "Bean Bag 5", btnBB5 },
                { "Bean Bag 6", btnBB6 },
                { "High Table 1", btnHT1 },
                { "High Table 2", btnHT2 },
                { "High Table 3", btnHT3 },
                { "High Table 4", btnHT4 },
                { "Laptop Table 1", btnLT1 },
                { "Laptop Table 2", btnLT2 },
                { "Laptop Table 3", btnLT3 },
                { "Laptop Table 4", btnLT4 },
                { "Laptop Table 5", btnLT5 },
                { "Discussion Room", btnDR1 }
            };
        }

        // Initializes time slots as available
        private void InitializeTimeSlotOccupancy()
        {
            var timeSlots = new string[]
            {
                "7:00 AM - 9:00 AM", "9:00 AM - 11:00 AM", "11:00 AM - 1:00 PM", "1:00 PM - 3:00 PM", "3:00 PM - 5:00 PM"
            };

            foreach (var slot in timeSlots)
            {
                timeSlotOccupancy[slot] = false; // Initially, all slots are unreserved
            }
        }
        
        //show available seats count
        private void InitializeSeatsAvailable()
        {
            if (File.Exists(receipts))
            {
                try
                {
                    string[] details = File.ReadAllLines(receipts);

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
                            string term =  _term[1].ToString().TrimStart();
                            string seat = _seat[1].ToString().TrimStart();
                            string status = _status[1].ToString().TrimStart();
                            string date_booked = _date[1].ToString().TrimStart();
                            if (status.Equals("Open"))
                            {
                                taken++;
                                avail--;

                                //mark available seats
                                //check time
                                string[] _duration = time.Split('-');

                                string startHour = _duration[0].ToString().TrimEnd();
                                DateTime _parsedStartHour = DateTime.ParseExact(startHour, "h:mm tt", CultureInfo.InvariantCulture);
                                int parsedStartHour = _parsedStartHour.Hour;

                                string endHour = _duration[1].ToString().TrimStart();
                                DateTime _parsedEndHour = DateTime.ParseExact(endHour, "h:mm tt", CultureInfo.InvariantCulture);
                                int parsedEndHour = _parsedEndHour.Hour;

                                int currentHour = DateTime.Now.Hour;
                                //currentHour = 7;

                                if (currentHour >= parsedStartHour && parsedEndHour > currentHour)
                                {
                                    seatNameToButton.TryGetValue(seat, out Button seatButton);
                                    seatOccupancy[seatButton] = true; // Mark the seat as occupied
                                    seatButton.BackColor = Color.Red;
                                }

                            }
                            //Dictionary.Add()
                        }
                    }

                    lblAvailableSlotsRizal.Text = "Available Slots: " + avail.ToString();
                    lblOccupiedSlotsRizal.Text = "Occupied Slots: " + taken.ToString();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("An error has occurred while reading receipts file " + ex.Message, "Time Slot Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("An error has occurred while reading receipts file ", "Time Slot Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Marks the seat as occupied
        public void MarkSeatAsOccupied(string seatName, string timeSlot)
        {
            if (timeSlotOccupancy.ContainsKey(timeSlot) && timeSlotOccupancy[timeSlot])
            {
                MessageBox.Show("This time slot is already reserved.", "Time Slot Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (seatNameToButton.TryGetValue(seatName, out Button seatButton))
            {
                seatOccupancy[seatButton] = true; // Mark the seat as occupied
                UpdateSeatButtonColor(seatButton, Color.Red); // Change the button's color to red
                timeSlotOccupancy[timeSlot] = true; // Mark this time slot as taken
            }
            else
            {
                MessageBox.Show($"The seat '{seatName}' does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void UpdateSeatButtonColor(Button seatButton, Color color)
        {
            seatButton.BackColor = color; // Change button color to indicate reservation status
        }

        // Method to reset seat visuals (if needed)
        private void UpdateSeatVisuals()
        {
            foreach (var entry in seatOccupancy)
            {
                var color = entry.Value ? Color.Red : Color.Green; // Red for occupied, Green for available
                UpdateSeatButtonColor(entry.Key, color);
            }
        }

        private void btnBookSeat_Click(object sender, EventArgs e)
        {
            Rizal_Reservation reservationForm = new Rizal_Reservation(this);
            reservationForm.Show(); // Use ShowDialog() for modal behavior
            this.Hide(); // Optionally hide the current form
        }

        private void RizalLiveDisplay_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ChooseLibrary chooseLibrary = new ChooseLibrary(_userType);
            chooseLibrary.Show();
            this.Hide();
        }
    }
}
