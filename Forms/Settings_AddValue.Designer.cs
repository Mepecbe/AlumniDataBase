namespace DataBase.Forms
{
    partial class Settings_AddValue
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.valueTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.TypeComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(58, 79);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(32, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Тип";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(58, 121);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(69, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Значение";
            // 
            // valueTextBox
            // 
            // 
            // 
            // 
            this.valueTextBox.CustomButton.Image = null;
            this.valueTextBox.CustomButton.Location = new System.Drawing.Point(176, 1);
            this.valueTextBox.CustomButton.Name = "";
            this.valueTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.valueTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.valueTextBox.CustomButton.TabIndex = 1;
            this.valueTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.valueTextBox.CustomButton.UseSelectable = true;
            this.valueTextBox.CustomButton.Visible = false;
            this.valueTextBox.Lines = new string[0];
            this.valueTextBox.Location = new System.Drawing.Point(133, 121);
            this.valueTextBox.MaxLength = 32767;
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.PasswordChar = '\0';
            this.valueTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.valueTextBox.SelectedText = "";
            this.valueTextBox.SelectionLength = 0;
            this.valueTextBox.SelectionStart = 0;
            this.valueTextBox.ShortcutsEnabled = true;
            this.valueTextBox.Size = new System.Drawing.Size(198, 23);
            this.valueTextBox.TabIndex = 2;
            this.valueTextBox.UseSelectable = true;
            this.valueTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.valueTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(133, 169);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(100, 23);
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "Добавить";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.ItemHeight = 23;
            this.TypeComboBox.Location = new System.Drawing.Point(133, 79);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(198, 29);
            this.TypeComboBox.TabIndex = 3;
            this.TypeComboBox.UseSelectable = true;
            // 
            // Settings_AddValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 227);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "Settings_AddValue";
            this.Text = "Добавление значения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButton1;
        public MetroFramework.Controls.MetroComboBox TypeComboBox;
        public MetroFramework.Controls.MetroTextBox valueTextBox;
    }
}