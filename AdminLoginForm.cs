using System;
using System.IO;
using System.Windows.Forms;

namespace LogIn
{
    public partial class AdminLoginForm : Form
    {
        private const string AdminUserFilePath = "\"C:\\Users\\EM\\Documents\\LogIn-master-20241202T102501Z-001\\LogIn-master\\bin\\Debug\\admin.txt\"";
        private LoginForm mainLoginForm;

        public AdminLoginForm(LoginForm loginForm)
        {
            InitializeComponent();
            mainLoginForm = loginForm;
            btnSubmit.Click += btnAdminSubmit_Click;
            btnBack.Click += btnBack_Click;
        }

        private void btnAdminSubmit_Click(object sender, EventArgs e)
        {
            string username = txtBox1.Text.Trim();
            string password = txtBox2.Text.Trim();

            if (IsAdminLoginValid(username, password))
            {
                MessageBox.Show("Admin login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open the ChooseLibraryAdmin form
                ChooseLibraryAdmin chooseLibraryAdminForm = new ChooseLibraryAdmin();
                chooseLibraryAdminForm.Show();

                // Optionally hide or close the current admin login form
                this.Hide(); // Hides the AdminLoginForm
                             // this.Close(); // Alternatively, closes the AdminLoginForm if you don't need it anymore
            }
            else
            {
                MessageBox.Show("Invalid admin username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainLoginForm.Show();
            this.Close();
        }

        private bool IsAdminLoginValid(string username, string password)
        {
            if (!File.Exists(AdminUserFilePath))
            {
                MessageBox.Show("Admin user file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string[] lines = File.ReadAllLines(AdminUserFilePath);
            foreach (string line in lines)
            {
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
}

