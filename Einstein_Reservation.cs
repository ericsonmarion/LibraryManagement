using System;
using System.IO;
using System.Windows.Forms;

namespace LogIn
{
    public partial class Einstein_Reservation : Form
    {
        private EinsteinLiveDisplay parentForm;

        public Einstein_Reservation(EinsteinLiveDisplay parent)
        {
            InitializeComponent();
            InitializeComboBoxes();
            parentForm = parent; // Store the reference to the parent form

            // Attach the FormClosing event
            this.FormClosing += Einstein_Reservation_FormClosing;
        }

        // Initialize all ComboBoxes
        private void InitializeComboBoxes()
        {
            InitializeTimeComboBox();
            InitializeYearLevelComboBox();
            InitializeTermComboBox();
            InitializePrefSeatComboBox();
        }

        private void InitializeTimeComboBox()
        {
            cb_TIME.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_TIME.Items.AddRange(new string[]
            {
                "7:00 AM - 9:00 AM",
                "9:00 AM - 11:00 AM",
                "11:00 AM - 1:00 PM",
                "1:00 PM - 3:00 PM",
                "3:00 PM - 5:00 PM"
            });
            cb_TIME.SelectedIndex = 0; // Default selection
        }

        private void InitializeYearLevelComboBox()
        {
            cb_YearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_YearLevel.Items.AddRange(new string[]
            {
                "1st year",
                "2nd year",
                "3rd year",
                "4th year",
                "5th year",
                "Grade 11",
                "Grade 12"
            });
            cb_YearLevel.SelectedIndex = 0; // Default selection
        }

        private void InitializeTermComboBox()
        {
            cb_Term.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Term.Items.AddRange(new string[]
            {
                "1st Term - College",
                "2nd Term - College",
                "3rd Term - College",
                "1st Term - SHS",
                "2nd Term - SHS"
            });
            cb_Term.SelectedIndex = 0; // Default selection
        }

        private void InitializePrefSeatComboBox()
        {
            cb_PrefSeat.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_PrefSeat.Items.AddRange(new string[]
            {
                "Seat 1", "Seat 2", "Seat 3", "Seat 4",
                "Drafting Table 1", "Drafting Table 2", "Drafting Table 3", "Drafting Table 4", "Drafting Table 5", "Drafting Table 6",
                "Group Table 1", "Group Table 2", "Group Table 3", "Group Table 4", "Group Table 5", "Group Table 6", "Group Table 7",
                "Laptop Table 1", "Laptop Table 2", "Laptop Table 3", "Laptop Table 4", "Laptop Table 5",
                "Study Table 1", "Study Table 2", "Study Table 3", "Study Table 4", "Study Table 5", "Study Table 6",
                "Study Table 7", "Study Table 8", "Study Table 9", "Study Table 10", "Study Table 11", "Study Table 12",
                "Study Table 13", "Study Table 14", "Study Table 15", "Study Table 16", "Study Table 17", "Study Table 18"
            });
            cb_PrefSeat.SelectedIndex = 0; // Default selection
        }

        // Event handler for SubBtn click to save reservation
        private void SubBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect user input
                string userName = textBoxName.Text.Trim();
                string studentNo = textBoxStuNo.Text.Trim();
                string timeSlot = cb_TIME.SelectedItem.ToString();
                string yearLevel = cb_YearLevel.SelectedItem.ToString();
                string term = cb_Term.SelectedItem.ToString();
                string preferredSeat = cb_PrefSeat.SelectedItem.ToString();

                // Validate name
                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("Please enter your name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Format the data to write into the file
                string receiptContent = $"Name: {userName}\n" +
                                        $"Student Number: {studentNo}\n" +
                                        $"Time Slot: {timeSlot}\n" +
                                        $"Year Level: {yearLevel}\n" +
                                        $"Term: {term}\n" +
                                        $"Preferred Seat: {preferredSeat}\n" +
                                        $"Date: {DateTime.Now}\n";

                // Define the file path
                string filePath = "Einstein_receipts.txt";

                // Append the data to the file
                File.AppendAllText(filePath, receiptContent + "\n-------------------\n");

                // Show confirmation message
                MessageBox.Show("Reservation made!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally, clear the TextBox for the next reservation
                textBoxName.Clear();

                // Navigate back to the parent form
                parentForm.Show();
                this.Close(); // Close the current form
            }
            catch (Exception ex)
            {
                // Handle errors
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for form closing
        private void Einstein_Reservation_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show(); // Show the parent form when this form is closed
        }

        private void Einstein_Reservation_Load(object sender, EventArgs e)
        {
            // Optional: Add any additional logic to execute when the form loads
        }
    }
}

