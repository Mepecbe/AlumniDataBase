namespace DataBase.Forms
{
    partial class Settings_Form
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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВыбранноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.PathToStatement2File = new MetroFramework.Controls.MetroTextBox();
            this.PathToStatement1File = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CreateStatement1 = new MetroFramework.Controls.MetroButton();
            this.CreateStatement2 = new MetroFramework.Controls.MetroButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.metroContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroListView1
            // 
            this.metroListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.metroListView1.ContextMenuStrip = this.metroContextMenu1;
            this.metroListView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView1.FullRowSelect = true;
            this.metroListView1.Location = new System.Drawing.Point(20, 236);
            this.metroListView1.Name = "metroListView1";
            this.metroListView1.OwnerDraw = true;
            this.metroListView1.Size = new System.Drawing.Size(564, 256);
            this.metroListView1.TabIndex = 0;
            this.metroListView1.UseCompatibleStateImageBehavior = false;
            this.metroListView1.UseSelectable = true;
            this.metroListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Наименование";
            this.columnHeader1.Width = 229;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Значение";
            this.columnHeader2.Width = 290;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.удалитьВыбранноеToolStripMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(184, 48);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // удалитьВыбранноеToolStripMenuItem
            // 
            this.удалитьВыбранноеToolStripMenuItem.Name = "удалитьВыбранноеToolStripMenuItem";
            this.удалитьВыбранноеToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.удалитьВыбранноеToolStripMenuItem.Text = "Удалить выбранное";
            this.удалитьВыбранноеToolStripMenuItem.Click += new System.EventHandler(this.удалитьВыбранноеToolStripMenuItem_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(62, 141);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(318, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Файл с ведомостями распределения выпускников";
            // 
            // PathToStatement2File
            // 
            // 
            // 
            // 
            this.PathToStatement2File.CustomButton.Image = null;
            this.PathToStatement2File.CustomButton.Location = new System.Drawing.Point(431, 1);
            this.PathToStatement2File.CustomButton.Name = "";
            this.PathToStatement2File.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.PathToStatement2File.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PathToStatement2File.CustomButton.TabIndex = 1;
            this.PathToStatement2File.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PathToStatement2File.CustomButton.UseSelectable = true;
            this.PathToStatement2File.CustomButton.Visible = false;
            this.PathToStatement2File.Lines = new string[0];
            this.PathToStatement2File.Location = new System.Drawing.Point(87, 163);
            this.PathToStatement2File.MaxLength = 32767;
            this.PathToStatement2File.Name = "PathToStatement2File";
            this.PathToStatement2File.PasswordChar = '\0';
            this.PathToStatement2File.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PathToStatement2File.SelectedText = "";
            this.PathToStatement2File.SelectionLength = 0;
            this.PathToStatement2File.SelectionStart = 0;
            this.PathToStatement2File.ShortcutsEnabled = true;
            this.PathToStatement2File.Size = new System.Drawing.Size(453, 23);
            this.PathToStatement2File.TabIndex = 2;
            this.PathToStatement2File.UseSelectable = true;
            this.PathToStatement2File.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PathToStatement2File.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // PathToStatement1File
            // 
            // 
            // 
            // 
            this.PathToStatement1File.CustomButton.Image = null;
            this.PathToStatement1File.CustomButton.Location = new System.Drawing.Point(431, 1);
            this.PathToStatement1File.CustomButton.Name = "";
            this.PathToStatement1File.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.PathToStatement1File.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PathToStatement1File.CustomButton.TabIndex = 1;
            this.PathToStatement1File.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PathToStatement1File.CustomButton.UseSelectable = true;
            this.PathToStatement1File.CustomButton.Visible = false;
            this.PathToStatement1File.Lines = new string[0];
            this.PathToStatement1File.Location = new System.Drawing.Point(87, 87);
            this.PathToStatement1File.MaxLength = 32767;
            this.PathToStatement1File.Name = "PathToStatement1File";
            this.PathToStatement1File.PasswordChar = '\0';
            this.PathToStatement1File.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PathToStatement1File.SelectedText = "";
            this.PathToStatement1File.SelectionLength = 0;
            this.PathToStatement1File.SelectionStart = 0;
            this.PathToStatement1File.ShortcutsEnabled = true;
            this.PathToStatement1File.Size = new System.Drawing.Size(453, 23);
            this.PathToStatement1File.TabIndex = 4;
            this.PathToStatement1File.UseSelectable = true;
            this.PathToStatement1File.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PathToStatement1File.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(62, 65);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(347, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Файл с ведомостями персонального учета выпусников";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(465, 116);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 5;
            this.metroButton1.Text = "Открыть";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(465, 193);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.TabIndex = 6;
            this.metroButton2.Text = "Открыть";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Файлы XML (*.xml) | *.xml";
            // 
            // CreateStatement1
            // 
            this.CreateStatement1.Location = new System.Drawing.Point(386, 116);
            this.CreateStatement1.Name = "CreateStatement1";
            this.CreateStatement1.Size = new System.Drawing.Size(75, 23);
            this.CreateStatement1.TabIndex = 7;
            this.CreateStatement1.Text = "Создать";
            this.CreateStatement1.UseSelectable = true;
            this.CreateStatement1.Click += new System.EventHandler(this.CreateStatement1_Click);
            // 
            // CreateStatement2
            // 
            this.CreateStatement2.Location = new System.Drawing.Point(386, 193);
            this.CreateStatement2.Name = "CreateStatement2";
            this.CreateStatement2.Size = new System.Drawing.Size(75, 23);
            this.CreateStatement2.TabIndex = 8;
            this.CreateStatement2.Text = "Создать";
            this.CreateStatement2.UseSelectable = true;
            this.CreateStatement2.Click += new System.EventHandler(this.CreateStatement2_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Файлы XML (*.xml) | *.xml";
            // 
            // Settings_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 512);
            this.Controls.Add(this.CreateStatement2);
            this.Controls.Add(this.CreateStatement1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.PathToStatement1File);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.PathToStatement2File);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroListView1);
            this.Name = "Settings_Form";
            this.Text = "Настройки";
            this.Shown += new System.EventHandler(this.Settings_Form_Shown);
            this.metroContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroListView metroListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьВыбранноеToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox PathToStatement2File;
        private MetroFramework.Controls.MetroTextBox PathToStatement1File;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroButton CreateStatement1;
        private MetroFramework.Controls.MetroButton CreateStatement2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}