using ImAIdiot.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImAIdiot
{
    public partial class frmNewPasswords : Form
    {
        bool isEdit = false;
        string oldFilePath = "";
        //public static frmNewPasswords Instance;
        DataHandler dataHandler = new DataHandler();
        public frmNewPasswords()
        {
            InitializeComponent();
        }

        public frmNewPasswords(PasswordInformation passwordInfo, string oldFilePath)
        {
            InitializeComponent();
            this.oldFilePath = oldFilePath;

            isEdit = true;
            txtEmail.Text = passwordInfo.email;
            txtPassword.Text = passwordInfo.password;
            txtName.Text = passwordInfo.websiteName;
            txtUsername.Text = passwordInfo.username;

        }

        private void frmNewPasswords_Load(object sender, EventArgs e)
        {

        }

        private bool IsFormValid()
        {
            bool IsValid = true;
            //Can add more validation later
            if (txtName.Text == "" || txtName.Text == null)
            {
                IsValid = false;
                lblNameError.Visible = true;
                lblNameError.Text = "Name Is empty.";
            }

            if (txtPassword.Text == "" || txtPassword.Text == null)
            {
                IsValid = false;
                lblPasswordError.Visible = true;
                lblPasswordError.Text = "Password is empty.";
            }

            if (txtEmail.Text == "" || txtEmail.Text == null)
            {
                IsValid = false;
                lblEmailError.Visible = true;
                lblEmailError.Text = "Email is empty.";
            }

            if (txtUsername.Text == "" || txtUsername.Text == null)
            {
                IsValid = false;
                lblUsernameError.Visible = true;
                lblUsernameError.Text = "Username is empty.";

            }

            return IsValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                PasswordInformation p = new PasswordInformation(txtUsername.Text, txtName.Text, txtPassword.Text, txtEmail.Text);

                if (isEdit)
                {
                    dataHandler.EditFile(oldFilePath, p);
                }
                else { dataHandler.encryptData(p); }
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewPasswords_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.Control && e.KeyCode == Keys.S && IsFormValid())
            {
                btnSave.PerformClick();
            }
        }
    }
}
