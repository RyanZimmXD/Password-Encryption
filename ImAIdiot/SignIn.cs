using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImAIdiot
{
    public partial class SignIn : Form
    {
        public static SignIn Instance;
        public SignIn()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           txtPassword.Text = "0123456789ABCDEF";
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            
            this.Hide();    
            //MainForm mf = new MainForm();
            //MainForm mf = new MainForm(txtPassword.Text, "FEDCBA9876543210");
            //mf.ShowDialog();
            //this.Close();
            
        }
    }
    }

