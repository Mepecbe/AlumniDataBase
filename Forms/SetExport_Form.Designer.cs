namespace DataBase.Forms
{
    partial class SetExport_Form
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
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.Export = new MetroFramework.Controls.MetroTile();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(271, 63);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(183, 187);
            this.metroTile1.TabIndex = 5;
            this.metroTile1.Text = "Выбрать путь";
            this.metroTile1.TileImage = global::DataBase.Properties.Resources.folder_with_check_mark;
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // Export
            // 
            this.Export.ActiveControl = null;
            this.Export.Location = new System.Drawing.Point(65, 63);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(183, 187);
            this.Export.TabIndex = 4;
            this.Export.Text = "На флешку";
            this.Export.TileImage = global::DataBase.Properties.Resources.flash_drive;
            this.Export.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Export.UseSelectable = true;
            this.Export.UseTileImage = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Ведомости";
            this.saveFileDialog1.Filter = "XML Файлы|*.xml";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // SetExport_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 285);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.Export);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "SetExport_Form";
            this.Resizable = false;
            this.Text = "Выбор метода экспорта";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile Export;
        private MetroFramework.Controls.MetroTile metroTile1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}