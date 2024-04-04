namespace ImAIdiot
{
    partial class MainForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.gridPasswords = new System.Windows.Forms.DataGridView();
            this.columnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnWebsite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridPasswords)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(713, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridPasswords
            // 
            this.gridPasswords.AllowUserToAddRows = false;
            this.gridPasswords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPasswords.ColumnHeadersHeight = 29;
            this.gridPasswords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnEmail,
            this.columnWebsite,
            this.ColumnUsername,
            this.columnPassword});
            this.gridPasswords.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gridPasswords.GridColor = System.Drawing.Color.PowderBlue;
            this.gridPasswords.Location = new System.Drawing.Point(10, 52);
            this.gridPasswords.Name = "gridPasswords";
            this.gridPasswords.ReadOnly = true;
            this.gridPasswords.RowHeadersWidth = 51;
            this.gridPasswords.RowTemplate.Height = 24;
            this.gridPasswords.Size = new System.Drawing.Size(778, 375);
            this.gridPasswords.TabIndex = 6;
            this.gridPasswords.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridPasswords_RowHeaderMouseDoubleClick);
            this.gridPasswords.SelectionChanged += new System.EventHandler(this.gridPasswords_SelectionChanged);
            this.gridPasswords.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridPasswords_UserDeletingRow);
            // 
            // columnEmail
            // 
            this.columnEmail.HeaderText = "Email";
            this.columnEmail.MinimumWidth = 8;
            this.columnEmail.Name = "columnEmail";
            this.columnEmail.ReadOnly = true;
            this.columnEmail.Width = 125;
            // 
            // columnWebsite
            // 
            this.columnWebsite.HeaderText = "Website";
            this.columnWebsite.MinimumWidth = 6;
            this.columnWebsite.Name = "columnWebsite";
            this.columnWebsite.ReadOnly = true;
            this.columnWebsite.Width = 75;
            // 
            // ColumnUsername
            // 
            this.ColumnUsername.HeaderText = "Username";
            this.ColumnUsername.MinimumWidth = 6;
            this.ColumnUsername.Name = "ColumnUsername";
            this.ColumnUsername.ReadOnly = true;
            this.ColumnUsername.Width = 125;
            // 
            // columnPassword
            // 
            this.columnPassword.HeaderText = "Password";
            this.columnPassword.MinimumWidth = 6;
            this.columnPassword.Name = "columnPassword";
            this.columnPassword.ReadOnly = true;
            this.columnPassword.Width = 200;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(618, 23);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(526, 23);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gridPasswords);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPasswords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView gridPasswords;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnWebsite;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPassword;
    }
}