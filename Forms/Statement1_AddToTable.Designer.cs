namespace DataBase.Forms
{
    partial class Statement1_AddToTable
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
            this.components = new System.ComponentModel.Container();
            this.metroListView1 = new MetroFramework.Controls.MetroListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.удалитьВыбранноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.TextBox_Year = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.TextBox_Organization = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.TextBox_Position = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.TextBox_Note = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.TextBox_FIO = new MetroFramework.Controls.MetroTextBox();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьВыбранноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_Button = new MetroFramework.Controls.MetroButton();
            this.metroContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroListView1
            // 
            this.metroListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.metroListView1.ContextMenuStrip = this.metroContextMenu1;
            this.metroListView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView1.FullRowSelect = true;
            this.metroListView1.Location = new System.Drawing.Point(20, 267);
            this.metroListView1.Name = "metroListView1";
            this.metroListView1.OwnerDraw = true;
            this.metroListView1.Size = new System.Drawing.Size(985, 413);
            this.metroListView1.TabIndex = 0;
            this.metroListView1.UseCompatibleStateImageBehavior = false;
            this.metroListView1.UseSelectable = true;
            this.metroListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "Year";
            this.columnHeader4.Text = "Год";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "Organization";
            this.columnHeader1.Text = "Наименование организации, адрес";
            this.columnHeader1.Width = 277;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "Position";
            this.columnHeader2.Text = "Принят на должность";
            this.columnHeader2.Width = 225;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "Note";
            this.columnHeader3.Text = "Примечание";
            this.columnHeader3.Width = 157;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.удалитьВыбранноеToolStripMenuItem,
            this.изменитьВыбранноеToolStripMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(194, 70);
            // 
            // удалитьВыбранноеToolStripMenuItem
            // 
            this.удалитьВыбранноеToolStripMenuItem.Name = "удалитьВыбранноеToolStripMenuItem";
            this.удалитьВыбранноеToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.удалитьВыбранноеToolStripMenuItem.Text = "Удалить выбранное";
            this.удалитьВыбранноеToolStripMenuItem.Click += new System.EventHandler(this.удалитьВыбранноеToolStripMenuItem_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(90, 107);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(30, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Год";
            // 
            // TextBox_Year
            // 
            // 
            // 
            // 
            this.TextBox_Year.CustomButton.Image = null;
            this.TextBox_Year.CustomButton.Location = new System.Drawing.Point(279, 1);
            this.TextBox_Year.CustomButton.Name = "";
            this.TextBox_Year.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBox_Year.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_Year.CustomButton.TabIndex = 1;
            this.TextBox_Year.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_Year.CustomButton.UseSelectable = true;
            this.TextBox_Year.CustomButton.Visible = false;
            this.TextBox_Year.Lines = new string[0];
            this.TextBox_Year.Location = new System.Drawing.Point(126, 107);
            this.TextBox_Year.MaxLength = 32767;
            this.TextBox_Year.Name = "TextBox_Year";
            this.TextBox_Year.PasswordChar = '\0';
            this.TextBox_Year.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_Year.SelectedText = "";
            this.TextBox_Year.SelectionLength = 0;
            this.TextBox_Year.SelectionStart = 0;
            this.TextBox_Year.ShortcutsEnabled = true;
            this.TextBox_Year.Size = new System.Drawing.Size(301, 23);
            this.TextBox_Year.TabIndex = 2;
            this.TextBox_Year.UseSelectable = true;
            this.TextBox_Year.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_Year.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(459, 72);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(133, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Организация, адрес";
            // 
            // TextBox_Organization
            // 
            // 
            // 
            // 
            this.TextBox_Organization.CustomButton.Image = null;
            this.TextBox_Organization.CustomButton.Location = new System.Drawing.Point(355, 1);
            this.TextBox_Organization.CustomButton.Name = "";
            this.TextBox_Organization.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBox_Organization.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_Organization.CustomButton.TabIndex = 1;
            this.TextBox_Organization.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_Organization.CustomButton.UseSelectable = true;
            this.TextBox_Organization.CustomButton.Visible = false;
            this.TextBox_Organization.Lines = new string[0];
            this.TextBox_Organization.Location = new System.Drawing.Point(598, 72);
            this.TextBox_Organization.MaxLength = 32767;
            this.TextBox_Organization.Name = "TextBox_Organization";
            this.TextBox_Organization.PasswordChar = '\0';
            this.TextBox_Organization.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_Organization.SelectedText = "";
            this.TextBox_Organization.SelectionLength = 0;
            this.TextBox_Organization.SelectionStart = 0;
            this.TextBox_Organization.ShortcutsEnabled = true;
            this.TextBox_Organization.Size = new System.Drawing.Size(377, 23);
            this.TextBox_Organization.TabIndex = 4;
            this.TextBox_Organization.UseSelectable = true;
            this.TextBox_Organization.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_Organization.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(90, 144);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(75, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Должность";
            // 
            // TextBox_Position
            // 
            // 
            // 
            // 
            this.TextBox_Position.CustomButton.Image = null;
            this.TextBox_Position.CustomButton.Location = new System.Drawing.Point(234, 1);
            this.TextBox_Position.CustomButton.Name = "";
            this.TextBox_Position.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBox_Position.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_Position.CustomButton.TabIndex = 1;
            this.TextBox_Position.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_Position.CustomButton.UseSelectable = true;
            this.TextBox_Position.CustomButton.Visible = false;
            this.TextBox_Position.Lines = new string[0];
            this.TextBox_Position.Location = new System.Drawing.Point(171, 144);
            this.TextBox_Position.MaxLength = 32767;
            this.TextBox_Position.Name = "TextBox_Position";
            this.TextBox_Position.PasswordChar = '\0';
            this.TextBox_Position.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_Position.SelectedText = "";
            this.TextBox_Position.SelectionLength = 0;
            this.TextBox_Position.SelectionStart = 0;
            this.TextBox_Position.ShortcutsEnabled = true;
            this.TextBox_Position.Size = new System.Drawing.Size(256, 23);
            this.TextBox_Position.TabIndex = 6;
            this.TextBox_Position.UseSelectable = true;
            this.TextBox_Position.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_Position.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(459, 107);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(87, 19);
            this.metroLabel4.TabIndex = 7;
            this.metroLabel4.Text = "Примечание";
            // 
            // TextBox_Note
            // 
            // 
            // 
            // 
            this.TextBox_Note.CustomButton.Image = null;
            this.TextBox_Note.CustomButton.Location = new System.Drawing.Point(375, 1);
            this.TextBox_Note.CustomButton.Name = "";
            this.TextBox_Note.CustomButton.Size = new System.Drawing.Size(47, 47);
            this.TextBox_Note.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_Note.CustomButton.TabIndex = 1;
            this.TextBox_Note.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_Note.CustomButton.UseSelectable = true;
            this.TextBox_Note.CustomButton.Visible = false;
            this.TextBox_Note.Lines = new string[0];
            this.TextBox_Note.Location = new System.Drawing.Point(552, 107);
            this.TextBox_Note.MaxLength = 32767;
            this.TextBox_Note.Multiline = true;
            this.TextBox_Note.Name = "TextBox_Note";
            this.TextBox_Note.PasswordChar = '\0';
            this.TextBox_Note.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_Note.SelectedText = "";
            this.TextBox_Note.SelectionLength = 0;
            this.TextBox_Note.SelectionStart = 0;
            this.TextBox_Note.ShortcutsEnabled = true;
            this.TextBox_Note.Size = new System.Drawing.Size(423, 60);
            this.TextBox_Note.TabIndex = 8;
            this.TextBox_Note.UseSelectable = true;
            this.TextBox_Note.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_Note.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(86, 185);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(341, 45);
            this.metroButton1.TabIndex = 9;
            this.metroButton1.Text = "Добавить";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(90, 72);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(40, 19);
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "ФИО";
            // 
            // TextBox_FIO
            // 
            // 
            // 
            // 
            this.TextBox_FIO.CustomButton.Image = null;
            this.TextBox_FIO.CustomButton.Location = new System.Drawing.Point(269, 1);
            this.TextBox_FIO.CustomButton.Name = "";
            this.TextBox_FIO.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBox_FIO.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_FIO.CustomButton.TabIndex = 1;
            this.TextBox_FIO.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_FIO.CustomButton.UseSelectable = true;
            this.TextBox_FIO.CustomButton.Visible = false;
            this.TextBox_FIO.Lines = new string[0];
            this.TextBox_FIO.Location = new System.Drawing.Point(136, 72);
            this.TextBox_FIO.MaxLength = 32767;
            this.TextBox_FIO.Name = "TextBox_FIO";
            this.TextBox_FIO.PasswordChar = '\0';
            this.TextBox_FIO.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_FIO.SelectedText = "";
            this.TextBox_FIO.SelectionLength = 0;
            this.TextBox_FIO.SelectionStart = 0;
            this.TextBox_FIO.ShortcutsEnabled = true;
            this.TextBox_FIO.Size = new System.Drawing.Size(291, 23);
            this.TextBox_FIO.TabIndex = 11;
            this.TextBox_FIO.UseSelectable = true;
            this.TextBox_FIO.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_FIO.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // изменитьВыбранноеToolStripMenuItem
            // 
            this.изменитьВыбранноеToolStripMenuItem.Name = "изменитьВыбранноеToolStripMenuItem";
            this.изменитьВыбранноеToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.изменитьВыбранноеToolStripMenuItem.Text = "Изменить выбранное";
            this.изменитьВыбранноеToolStripMenuItem.Click += new System.EventHandler(this.изменитьВыбранноеToolStripMenuItem_Click);
            // 
            // Edit_Button
            // 
            this.Edit_Button.Location = new System.Drawing.Point(459, 185);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Size = new System.Drawing.Size(516, 45);
            this.Edit_Button.TabIndex = 12;
            this.Edit_Button.Text = "Закончить редактирование";
            this.Edit_Button.UseSelectable = true;
            this.Edit_Button.Visible = false;
            this.Edit_Button.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // Statement1_AddToTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 700);
            this.Controls.Add(this.Edit_Button);
            this.Controls.Add(this.TextBox_FIO);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.TextBox_Note);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.TextBox_Position);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.TextBox_Organization);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.TextBox_Year);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroListView1);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "Statement1_AddToTable";
            this.Text = "Добавление";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Statement1_AddToTable_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.Statement1_AddToTable_ResizeEnd);
            this.metroContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox TextBox_Year;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox TextBox_Organization;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox TextBox_Position;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox TextBox_Note;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem удалитьВыбранноеToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        public MetroFramework.Controls.MetroTextBox TextBox_FIO;
        public MetroFramework.Controls.MetroListView metroListView1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьВыбранноеToolStripMenuItem;
        private MetroFramework.Controls.MetroButton Edit_Button;
    }
}