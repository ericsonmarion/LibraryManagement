using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LogIn
{
    public partial class Rizal_Reservation : Form
    {
        private RizalLiveDisplay parentForm;
        private const string receipts = "C:\\Users\\EM\\Documents\\LogIn-master-20241202T102501Z-001\\LogIn-master\\bin\\Debug\\Rizal_receipts.txt";

        // Dictionary to store reserved seats for each time slot
        private Dictionary<string, HashSet<string>> reservedSeats = new Dictionary<string, HashSet<string>>()
        {
            { "7:00 AM - 9:00 AM", new HashSet<string>() },
            { "9:00 AM - 11:00 AM", new HashSet<string>() },
            { "11:00 AM - 1:00 PM", new HashSet<string>() },
            { "1:00 PM - 3:00 PM", new HashSet<string>() },
            { "3:00 PM - 5:00 PM", new HashSet<string>() }
        };

        public Rizal_Reservation(RizalLiveDisplay parent)
        {
            InitializeComponent();
            InitializeComboBoxes();
            parentForm = parent; // Store the reference to the parent form

            // Attach the FormClosing event
            this.FormClosing += Rizal_Reservation_FormClosing;
        }

        private void InitializeComboBoxes()
        {
            InitializeTimeComboBox();
            InitializeYearLevelComboBox();
            InitializeTermComboBox();
            InitializePrefSeatComboBox();
        }

        private void UpdateTimeSlotColors()
        {
            // Get the current time
            DateTime currentTime = DateTime.Now;

            // Define time slots
            var timeSlots = new Dictionary<string, (DateTime Start, DateTime End)>
            {
                { "7:00 AM - 9:00 AM", (DateTime.Today.AddHours(7), DateTime.Today.AddHours(9)) },
                { "9:00 AM - 11:00 AM", (DateTime.Today.AddHours(9), DateTime.Today.AddHours(11)) },
                { "11:00 AM - 1:00 PM", (DateTime.Today.AddHours(11), DateTime.Today.AddHours(13)) },
                { "1:00 PM - 3:00 PM", (DateTime.Today.AddHours(13), DateTime.Today.AddHours(15)) },
                { "3:00 PM - 5:00 PM", (DateTime.Today.AddHours(15), DateTime.Today.AddHours(17)) }
            };

            // Iterate over combo box items and set color for the selected item
            for (int i = 0; i < cbTIME.Items.Count; i++)
            {
                string timeSlot = cbTIME.Items[i].ToString();
                if (timeSlots.ContainsKey(timeSlot))
                {
                    var (start, end) = timeSlots[timeSlot];
                    if (currentTime >= start && currentTime <= end)
                    {
                        cbTIME.SelectedIndex = i; // Select the matching time slot
                        cbTIME.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void InitializeTimeComboBox()
        {
            cbTIME.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTIME.Items.AddRange(new string[]
            {
                "7:00 AM - 9:00 AM",
                "9:00 AM - 11:00 AM",
                "11:00 AM - 1:00 PM",
                "1:00 PM - 3:00 PM",
                "3:00 PM - 5:00 PM"
            });
            cbTIME.SelectedIndex = 0; // Default selection
        }

        private void InitializeYearLevelComboBox()
        {
            cbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbYearLevel.Items.AddRange(new string[]
            {
                "1st year",
                "2nd year",
                "3rd year",
                "4th year",
                "5th year",
                "Grade 11",
                "Grade 12"
            });
            cbYearLevel.SelectedIndex = 0; // Default selection
        }

        private void InitializeTermComboBox()
        {
            cbTerm.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTerm.Items.AddRange(new string[]
            {
                "1st Term - College",
                "2nd Term - College",
                "3rd Term - College",
                "1st Term - SHS",
                "2nd Term - SHS"
            });
            cbTerm.SelectedIndex = 0; // Default selection
        }

        private void InitializePrefSeatComboBox()
        {
            cbPrefSeat.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPrefSeat.Items.AddRange(new string[]
            {
                "Sofa 1", "Sofa 2", "Sofa 3", "Sofa 4", "Sofa 5", "Sofa 6",
                "Bean Bag 1", "Bean Bag 2", "Bean Bag 3", "Bean Bag 4", "Bean Bag 5", "Bean Bag 6",
                "High Table 1", "High Table 2", "High Table 3", "High Table 4",
                "Laptop Table 1", "Laptop Table 2", "Laptop Table 3", "Laptop Table 4", "Laptop Table 5",
                "Trapezoid Table 1", "Trapezoid Table 2", "Trapezoid Table 3", "Trapezoid Table 4",
                "Discussion Room"
            });
            cbPrefSeat.SelectedIndex = 0; // Default selection
        }

        // Event handler for SubBtn click to save reservation
        private void SubBtnR_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect user input
                string userName = textBox_Name.Text.Trim();
                string studentNo = textBox_StuNo.Text.Trim();
                string timeSlot = cbTIME.SelectedItem?.ToString();
                string yearLevel = cbYearLevel.SelectedItem?.ToString();
                string term = cbTerm.SelectedItem?.ToString();
                string preferredSeat = cbPrefSeat.SelectedItem?.ToString();

                // Validate inputs
                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("Please enter your name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (string.IsNullOrEmpty(timeSlot) || string.IsNullOrEmpty(preferredSeat))
                {
                    MessageBox.Show("Please select a time slot and seat.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }//new solution
                else if (!isSeatReserved(preferredSeat, timeSlot))
                {
                    MessageBox.Show("This seat is already reserved for the selected time slot. Please choose another seat.", "Reservation Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    // Write reservation details to file
                    string receiptContent = $"Name: {userName}," +
                                            $"Student Number: {studentNo}," +
                                            $"Time Slot: {timeSlot}," +
                                            $"Year Level: {yearLevel}," +
                                            $"Term: {term}," +
                                            $"Preferred Seat: {preferredSeat}," +
                                            $"Status: Open," +
                                            $"Date: {DateTime.Now}";

                    string filePath = "Rizal_receipts.txt";
                    File.AppendAllText(filePath, receiptContent + "\n-------------------\n");

                    // Mark seat as occupied in the parent form
                    //parentForm.MarkSeatAsOccupied(preferredSeat, timeSlot);

                    // Show success message only after successful reservation
                    MessageBox.Show("Reservation made!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset input fields
                    textBox_Name.Clear();
                    ResetComboBoxes();

                    // Navigate back to the parent form
                    parentForm.Show();
                    this.Close(); // Close the current form
                }

                //incorrect solution --start
                // Check if the seat is already reserved for the selected time slot
                //if (reservedSeats[timeSlot].Contains(preferredSeat))
                //{
                //    MessageBox.Show("This seat is already reserved for the selected time slot. Please choose another seat.", "Reservation Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return; // Exit immediately to prevent further execution
                //}

                // If not reserved, process the reservation
                //reservedSeats[timeSlot].Add(preferredSeat);
                //incorrect solution --end
            }
            catch (Exception ex)
            {
                // Handle errors
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isSeatReserved(string prefSeat, string prefTime)
        {
            try
            {
                string[] details = File.ReadAllLines(receipts);

                int singleSeatCount = 21;
                int discussionRoomSeat = 6;
                int tpzdTableConut = 4;
                int tpzdTableSeatCount = 4;
                bool available = true;
                int avail = singleSeatCount + discussionRoomSeat + (tpzdTableConut * tpzdTableSeatCount);

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
                        string time = _time[1].ToString().TrimStart()+":"+ _time[2].ToString().TrimStart()+":"+ _time[3].ToString().TrimStart();
                        string yr_level = _yrLvl[1].ToString().TrimStart();
                        string term = _term[1].ToString().TrimStart();
                        string seat = _seat[1].ToString().TrimStart();
                        string status = _status[1].ToString().TrimStart();
                        string date_booked = _date[1].ToString().TrimStart();
                        if (seat.Equals(prefSeat) && time.Equals(prefTime) && status.Equals("Open"))
                        {
                            available = false;
                        }
                    }
                }
                return available;
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reading receipts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        // Method to reset ComboBoxes to default selection
        private void ResetComboBoxes()
        {
            cbTIME.SelectedIndex = 0;
            cbYearLevel.SelectedIndex = 0;
            cbTerm.SelectedIndex = 0;
            cbPrefSeat.SelectedIndex = 0;
        }

        // Event handler for form closing
        private void Rizal_Reservation_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show(); // Show the parent form when this form is closed
        }
    }
}
