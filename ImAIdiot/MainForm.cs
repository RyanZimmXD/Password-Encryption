using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ImAIdiot.Models;
using System.Configuration;

namespace ImAIdiot
{
    public partial class MainForm : Form
    {
        const string folderPath = @"C:\Users\ryanz\source\repos\ImAIdiot\Information";
        private string filePath = Path.Combine(folderPath, "passwords.txt");

        DataHandler dataHandler;



        public MainForm()
        {
            InitializeComponent();
            //Instance = this;
        }
        public MainForm(string Key, string IV)
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dataHandler = new DataHandler();
            try
            {
                UpdateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To read Files" + ex);
                this.Close();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewPasswords newPassword = new frmNewPasswords();
            newPassword.ShowDialog();
            UpdateGrid();
        }

        private void gridPasswords_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            editGridData();

        }

        private void gridPasswords_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to delete this?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                File.Delete(getFileName());
            }
            else { e.Cancel = true; }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Check this later
            DialogResult result = MessageBox.Show("Are you sure you wish to delete this", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                File.Delete(getFileName());

            }
            UpdateGrid();
        }


        private void UpdateGrid()
        {
            gridPasswords.Rows.Clear();
            foreach (PasswordInformation pi in dataHandler.DecryptDataFromFile())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(gridPasswords);
                row.Cells[0].Value = pi.username;
                row.Cells[1].Value = pi.websiteName;
                row.Cells[2].Value = pi.password;
                row.Cells[3].Value = pi.email;
                gridPasswords.Rows.Add(row);
            }
        }

        private void gridPasswords_SelectionChanged(object sender, EventArgs e)
        {
            if (gridPasswords.SelectedRows.Count == 1)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            editGridData();

        }
        private void editGridData()
        {
            
            if (gridPasswords.SelectedRows.Count == 1)
            {
                string email = gridPasswords.SelectedRows[0].Cells[0].Value.ToString();
                string website = gridPasswords.SelectedRows[0].Cells[1].Value.ToString();
                string username = gridPasswords.SelectedRows[0].Cells[2].Value.ToString();
                string password = gridPasswords.SelectedRows[0].Cells[3].Value.ToString();
                PasswordInformation p = new PasswordInformation(username, website, password, email);
                frmNewPasswords nwP = new frmNewPasswords(p, getFileName());
                nwP.ShowDialog();
                UpdateGrid();
            }
        }

        private string getFileName()
        {
            int filePathIndex = gridPasswords.SelectedRows[0].Index; //It goes through each selected Row
            try
            {
                string[] FileNames = Directory.GetFiles("./Information");
                return FileNames[filePathIndex];
            }
            catch
            {
                MessageBox.Show("Failed to delete file"); return "ERROR";
            } //Need to go back and add trys and catches to everything :( thats going to take forever.}
        }
    }
}



