﻿namespace DataBase.Forms
{
    partial class Show_Form
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.metroListView1 = new MetroFramework.Controls.MetroListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Statement1_Table = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.печатьВедомостиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.metroListView2 = new MetroFramework.Controls.MetroListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Statements2_Table = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.печатьВедомостиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеВедомостиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВедомостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Statement1_Table.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.Statements2_Table.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tabPage1);
            this.metroTabControl1.Controls.Add(this.tabPage2);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(1007, 509);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.metroListView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(999, 467);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Выпускники";
            // 
            // metroListView1
            // 
            this.metroListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.metroListView1.ContextMenuStrip = this.Statement1_Table;
            this.metroListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView1.FullRowSelect = true;
            this.metroListView1.GridLines = true;
            this.metroListView1.Location = new System.Drawing.Point(0, 0);
            this.metroListView1.Name = "metroListView1";
            this.metroListView1.OwnerDraw = true;
            this.metroListView1.Size = new System.Drawing.Size(999, 467);
            this.metroListView1.TabIndex = 0;
            this.metroListView1.UseCompatibleStateImageBehavior = false;
            this.metroListView1.UseSelectable = true;
            this.metroListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Год";
            this.columnHeader1.Width = 181;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Группа";
            this.columnHeader2.Width = 118;
            // 
            // Statement1_Table
            // 
            this.Statement1_Table.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.печатьВедомостиToolStripMenuItem1,
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.Statement1_Table.Name = "Statement1_Table";
            this.Statement1_Table.Size = new System.Drawing.Size(216, 70);
            // 
            // печатьВедомостиToolStripMenuItem1
            // 
            this.печатьВедомостиToolStripMenuItem1.Name = "печатьВедомостиToolStripMenuItem1";
            this.печатьВедомостиToolStripMenuItem1.Size = new System.Drawing.Size(215, 22);
            this.печатьВедомостиToolStripMenuItem1.Text = "Печать ведомости";
            this.печатьВедомостиToolStripMenuItem1.Click += new System.EventHandler(this.печатьВедомостиToolStripMenuItem1_Click);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать ведомость";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить ведомость";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.metroListView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(999, 467);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Распределение";
            // 
            // metroListView2
            // 
            this.metroListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader5});
            this.metroListView2.ContextMenuStrip = this.Statements2_Table;
            this.metroListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroListView2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView2.FullRowSelect = true;
            this.metroListView2.GridLines = true;
            this.metroListView2.Location = new System.Drawing.Point(0, 0);
            this.metroListView2.Name = "metroListView2";
            this.metroListView2.OwnerDraw = true;
            this.metroListView2.Size = new System.Drawing.Size(999, 467);
            this.metroListView2.TabIndex = 0;
            this.metroListView2.UseCompatibleStateImageBehavior = false;
            this.metroListView2.UseSelectable = true;
            this.metroListView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "Speciality";
            this.columnHeader4.Text = "Специальность";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 657;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "Year";
            this.columnHeader3.Text = "Год";
            this.columnHeader3.Width = 85;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Количество записей в таблице";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 253;
            // 
            // Statements2_Table
            // 
            this.Statements2_Table.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.печатьВедомостиToolStripMenuItem,
            this.редактированиеВедомостиToolStripMenuItem,
            this.удалитьВедомостьToolStripMenuItem});
            this.Statements2_Table.Name = "Statements2_Table";
            this.Statements2_Table.Size = new System.Drawing.Size(226, 92);
            // 
            // печатьВедомостиToolStripMenuItem
            // 
            this.печатьВедомостиToolStripMenuItem.Name = "печатьВедомостиToolStripMenuItem";
            this.печатьВедомостиToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.печатьВедомостиToolStripMenuItem.Text = "Печать ведомости";
            this.печатьВедомостиToolStripMenuItem.Click += new System.EventHandler(this.печатьВедомостиToolStripMenuItem_Click);
            // 
            // редактированиеВедомостиToolStripMenuItem
            // 
            this.редактированиеВедомостиToolStripMenuItem.Name = "редактированиеВедомостиToolStripMenuItem";
            this.редактированиеВедомостиToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.редактированиеВедомостиToolStripMenuItem.Text = "Редактирование ведомости";
            this.редактированиеВедомостиToolStripMenuItem.Click += new System.EventHandler(this.редактированиеВедомостиToolStripMenuItem_Click);
            // 
            // удалитьВедомостьToolStripMenuItem
            // 
            this.удалитьВедомостьToolStripMenuItem.Name = "удалитьВедомостьToolStripMenuItem";
            this.удалитьВедомостьToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.удалитьВедомостьToolStripMenuItem.Text = "Удалить ведомость";
            this.удалитьВедомостьToolStripMenuItem.Click += new System.EventHandler(this.удалитьВедомостьToolStripMenuItem_Click);
            // 
            // Show_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 589);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "Show_Form";
            this.Text = "Обозреватель ведомостей";
            this.Shown += new System.EventHandler(this.Show_Form_Shown);
            this.ResizeEnd += new System.EventHandler(this.Show_Form_ResizeEnd);
            this.Resize += new System.EventHandler(this.Show_Form_Resize);
            this.metroTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.Statement1_Table.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.Statements2_Table.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MetroFramework.Controls.MetroListView metroListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private MetroFramework.Controls.MetroListView metroListView2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private MetroFramework.Controls.MetroContextMenu Statements2_Table;
        private System.Windows.Forms.ToolStripMenuItem печатьВедомостиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеВедомостиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьВедомостьToolStripMenuItem;
        private MetroFramework.Controls.MetroContextMenu Statement1_Table;
        private System.Windows.Forms.ToolStripMenuItem печатьВедомостиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
    }
}