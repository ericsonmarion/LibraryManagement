namespace LogIn
{
    partial class ChooseLibrary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseLibrary));
            this.EinLibBtn = new System.Windows.Forms.Button();
            this.RizLibBtn = new System.Windows.Forms.Button();
            this.lblEinBtn = new System.Windows.Forms.Label();
            this.lblRizLib = new System.Windows.Forms.Label();
            this.pb_white = new System.Windows.Forms.PictureBox();
            this.lblWelcomeUser = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblAvailableSeatsRizal = new System.Windows.Forms.Label();
            this.lblAvaialbleSeatsEinstein = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_white)).BeginInit();
            this.SuspendLayout();
            // 
            // EinLibBtn
            // 
            this.EinLibBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EinLibBtn.BackgroundImage = global::LogIn.Properties.Resources.CLIR_EINSTEIN;
            this.EinLibBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EinLibBtn.Location = new System.Drawing.Point(201, 161);
            this.EinLibBtn.Name = "EinLibBtn";
            this.EinLibBtn.Size = new System.Drawing.Size(464, 343);
            this.EinLibBtn.TabIndex = 12;
            this.EinLibBtn.UseVisualStyleBackColor = true;
            this.EinLibBtn.Click += new System.EventHandler(this.EinLibBtn_Click);
            // 
            // RizLibBtn
            // 
            this.RizLibBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RizLibBtn.BackgroundImage = global::LogIn.Properties.Resources.CLIR_RIZAL;
            this.RizLibBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RizLibBtn.Location = new System.Drawing.Point(713, 161);
            this.RizLibBtn.Name = "RizLibBtn";
            this.RizLibBtn.Size = new System.Drawing.Size(456, 343);
            this.RizLibBtn.TabIndex = 13;
            this.RizLibBtn.UseVisualStyleBackColor = true;
            this.RizLibBtn.Click += new System.EventHandler(this.RizLibBtn_Click);
            // 
            // lblEinBtn
            // 
            this.lblEinBtn.AutoSize = true;
            this.lblEinBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblEinBtn.Font = new System.Drawing.Font("Javanese Text", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEinBtn.ForeColor = System.Drawing.Color.Blue;
            this.lblEinBtn.Location = new System.Drawing.Point(303, 522);
            this.lblEinBtn.Name = "lblEinBtn";
            this.lblEinBtn.Size = new System.Drawing.Size(249, 75);
            this.lblEinBtn.TabIndex = 14;
            this.lblEinBtn.Text = "CLIR Einstein";
            // 
            // lblRizLib
            // 
            this.lblRizLib.AutoSize = true;
            this.lblRizLib.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRizLib.Font = new System.Drawing.Font("Javanese Text", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRizLib.ForeColor = System.Drawing.Color.Red;
            this.lblRizLib.Location = new System.Drawing.Point(848, 522);
            this.lblRizLib.Name = "lblRizLib";
            this.lblRizLib.Size = new System.Drawing.Size(199, 75);
            this.lblRizLib.TabIndex = 15;
            this.lblRizLib.Text = "CLIR Rizal";
            // 
            // pb_white
            // 
            this.pb_white.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pb_white.Location = new System.Drawing.Point(396, 11);
            this.pb_white.Name = "pb_white";
            this.pb_white.Size = new System.Drawing.Size(488, 69);
            this.pb_white.TabIndex = 16;
            this.pb_white.TabStop = false;
            this.pb_white.Click += new System.EventHandler(this.pb_white_Click);
            // 
            // lblWelcomeUser
            // 
            this.lblWelcomeUser.AutoSize = true;
            this.lblWelcomeUser.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblWelcomeUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeUser.Location = new System.Drawing.Point(481, 95);
            this.lblWelcomeUser.Name = "lblWelcomeUser";
            this.lblWelcomeUser.Size = new System.Drawing.Size(423, 63);
            this.lblWelcomeUser.TabIndex = 17;
            this.lblWelcomeUser.Text = "lblWelcomeUser";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(1166, 648);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(170, 61);
            this.btnLogout.TabIndex = 94;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblAvailableSeatsRizal
            // 
            this.lblAvailableSeatsRizal.AutoSize = true;
            this.lblAvailableSeatsRizal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAvailableSeatsRizal.Font = new System.Drawing.Font("Javanese Text", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableSeatsRizal.ForeColor = System.Drawing.Color.Red;
            this.lblAvailableSeatsRizal.Location = new System.Drawing.Point(787, 574);
            this.lblAvailableSeatsRizal.Name = "lblAvailableSeatsRizal";
            this.lblAvailableSeatsRizal.Size = new System.Drawing.Size(279, 75);
            this.lblAvailableSeatsRizal.TabIndex = 95;
            this.lblAvailableSeatsRizal.Text = "Available seats: ";
            // 
            // lblAvaialbleSeatsEinstein
            // 
            this.lblAvaialbleSeatsEinstein.AutoSize = true;
            this.lblAvaialbleSeatsEinstein.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAvaialbleSeatsEinstein.Font = new System.Drawing.Font("Javanese Text", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvaialbleSeatsEinstein.ForeColor = System.Drawing.Color.Blue;
            this.lblAvaialbleSeatsEinstein.Location = new System.Drawing.Point(268, 574);
            this.lblAvaialbleSeatsEinstein.Name = "lblAvaialbleSeatsEinstein";
            this.lblAvaialbleSeatsEinstein.Size = new System.Drawing.Size(269, 75);
            this.lblAvaialbleSeatsEinstein.TabIndex = 96;
            this.lblAvaialbleSeatsEinstein.Text = "Available seats:";
            // 
            // ChooseLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.lblAvaialbleSeatsEinstein);
            this.Controls.Add(this.lblAvailableSeatsRizal);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblWelcomeUser);
            this.Controls.Add(this.pb_white);
            this.Controls.Add(this.lblRizLib);
            this.Controls.Add(this.lblEinBtn);
            this.Controls.Add(this.RizLibBtn);
            this.Controls.Add(this.EinLibBtn);
            this.Name = "ChooseLibrary";
            this.Text = "Library";
            this.Load += new System.EventHandler(this.ChooseLibrary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_white)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button EinLibBtn;
        private System.Windows.Forms.Button RizLibBtn;
        private System.Windows.Forms.Label lblEinBtn;
        private System.Windows.Forms.Label lblRizLib;
        private System.Windows.Forms.PictureBox pb_white;
        private System.Windows.Forms.Label lblWelcomeUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblAvailableSeatsRizal;
        private System.Windows.Forms.Label lblAvaialbleSeatsEinstein;
    }
}