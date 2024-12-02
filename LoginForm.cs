using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace LogIn
{
    public partial class LoginForm : Form
    {
        private const string UserFilePath = "C:\\Users\\EM\\Documents\\LogIn-master-20241202T102501Z-001\\LogIn-master\\bin\\Debug\\student.txt";
        private const string AdminFilePath = "C:\\Users\\EM\\Documents\\LogIn-master-20241202T102501Z-001\\LogIn-master\\bin\\Debug\\admin.txt";
        public LoginForm()
        {
            InitializeComponent();
            btnSubmit.Click += btnSubmit_Click;
            AdminLogin.LinkClicked += linkLabelAdminLogin_LinkClicked;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtBox1.Text.Trim();
            string password = txtBox2.Text.Trim();

            if (IsLoginValid(username, password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ChooseLibrary chooseLibraryForm = new ChooseLibrary("User");
                chooseLibraryForm.Show();
                // Optionally hide or close the current login form
                this.Hide(); // Hides the LoginForm
                             // this.Close(); // Alternatively, closes the LoginForm if you don't need it anymore
            }
            else if (isAdmin(username, password))
            {
                ChooseLibrary chooseLibraryForm = new ChooseLibrary("Admin");
                chooseLibraryForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsLoginValid(string username, string password)
        {
            if (!File.Exists(UserFilePath))
            {
                MessageBox.Show("User file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                string[] lines = File.ReadAllLines(UserFilePath);
                foreach (string line in lines)
                {
                    //Console.WriteLine($"Processing line: {line}");

                    string[] credentials = line.Split(',');

                    if (credentials.Length == 2)
                    {
                        string fileUsername = credentials[0].Trim();
                        string filePassword = credentials[1].Trim();

                        //Console.WriteLine($"Comparing: Input Username: {username}, File Username: {fileUsername}");
                        //Console.WriteLine($"Comparing: Input Password: {password}, File Password: {filePassword}");

                        if (fileUsername.Equals(username, StringComparison.OrdinalIgnoreCase) && filePassword == password)
                        {
                            return true;
                        }
                    }
                }
                return false;
                
            }
        }

        private bool isAdmin(string username, string password)
        {
            if (!File.Exists(UserFilePath))
            {
                MessageBox.Show("User file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                string[] lines = File.ReadAllLines(AdminFilePath);
                foreach (string line in lines)
                {
                    //Console.WriteLine($"Processing line: {line}");

                    string[] credentials = line.Split(',');

                    if (credentials.Length == 2)
                    {
                        string fileUsername = credentials[0].Trim();
                        string filePassword = credentials[1].Trim();

                        if (fileUsername.Equals(username, StringComparison.OrdinalIgnoreCase) && filePassword == password)
                        {
                            return true;
                        }
                    }
                }
                return false;

            }
        }

        private void linkLabelAdminLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminLoginForm adminLoginForm = new AdminLoginForm(this);
            adminLoginForm.Show(); // Show the admin login form
            this.Hide(); // Optionally hide the main login form
        }
    }
}
