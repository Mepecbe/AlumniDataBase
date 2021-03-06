﻿namespace DataBase
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.Export = new MetroFramework.Controls.MetroTile();
            this.Show = new MetroFramework.Controls.MetroTile();
            this.Add = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(868, 5);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "СТИЛЬ";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(689, 73);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(183, 187);
            this.metroTile1.TabIndex = 5;
            this.metroTile1.Text = "Настройки";
            this.metroTile1.TileImage = global::DataBase.Properties.Resources.settings_gear;
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // Export
            // 
            this.Export.ActiveControl = null;
            this.Export.Location = new System.Drawing.Point(482, 73);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(183, 187);
            this.Export.TabIndex = 3;
            this.Export.Text = "Экспорт";
            this.Export.TileImage = global::DataBase.Properties.Resources.flash_drive;
            this.Export.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Export.UseSelectable = true;
            this.Export.UseTileImage = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // Show
            // 
            this.Show.ActiveControl = null;
            this.Show.Location = new System.Drawing.Point(272, 73);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(183, 187);
            this.Show.TabIndex = 2;
            this.Show.Text = "Просмотр ведомостей";
            this.Show.TileImage = global::DataBase.Properties.Resources.documents_symbol;
            this.Show.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Show.UseSelectable = true;
            this.Show.UseTileImage = true;
            this.Show.Click += new System.EventHandler(this.Show_Click);
            // 
            // Add
            // 
            this.Add.ActiveControl = null;
            this.Add.Location = new System.Drawing.Point(61, 73);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(183, 187);
            this.Add.TabIndex = 0;
            this.Add.Text = "Добавление ведомостей";
            this.Add.TileImage = global::DataBase.Properties.Resources._128;
            this.Add.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add.UseSelectable = true;
            this.Add.UseTileImage = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 312);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.Show);
            this.Controls.Add(this.Add);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "База данных выпускников";
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile Add;
        private MetroFramework.Controls.MetroTile Show;
        private MetroFramework.Controls.MetroTile Export;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTile metroTile1;
    }
}

