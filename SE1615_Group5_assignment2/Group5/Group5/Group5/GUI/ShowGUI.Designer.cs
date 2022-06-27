
namespace Group5.GUI
{
    partial class ShowGUI
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpShowDate = new System.Windows.Forms.DateTimePicker();
            this.cboFilmId = new System.Windows.Forms.ComboBox();
            this.cboRoomId = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 294);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1288, 364);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(45, 218);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(208, 34);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Create a new...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Film:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "RoomID:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(390, 159);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(101, 34);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpShowDate
            // 
            this.dtpShowDate.CustomFormat = "dd/MM/yyyy";
            this.dtpShowDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShowDate.Location = new System.Drawing.Point(175, 100);
            this.dtpShowDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpShowDate.Name = "dtpShowDate";
            this.dtpShowDate.Size = new System.Drawing.Size(182, 31);
            this.dtpShowDate.TabIndex = 6;
            // 
            // cboFilmId
            // 
            this.cboFilmId.DataSource = this.label1.Controls;
            this.cboFilmId.FormattingEnabled = true;
            this.cboFilmId.Location = new System.Drawing.Point(175, 31);
            this.cboFilmId.Margin = new System.Windows.Forms.Padding(2);
            this.cboFilmId.Name = "cboFilmId";
            this.cboFilmId.Size = new System.Drawing.Size(182, 33);
            this.cboFilmId.TabIndex = 7;
            // 
            // cboRoomId
            // 
            this.cboRoomId.FormattingEnabled = true;
            this.cboRoomId.Location = new System.Drawing.Point(175, 159);
            this.cboRoomId.Margin = new System.Windows.Forms.Padding(2);
            this.cboRoomId.Name = "cboRoomId";
            this.cboRoomId.Size = new System.Drawing.Size(182, 33);
            this.cboRoomId.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "The number of shows:";
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Location = new System.Drawing.Point(231, 267);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(22, 25);
            this.lblNo.TabIndex = 10;
            this.lblNo.Text = "0";
            // 
            // ShowGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 685);
            this.Controls.Add(this.lblNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboRoomId);
            this.Controls.Add(this.cboFilmId);
            this.Controls.Add(this.dtpShowDate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ShowGUI";
            this.Text = "ShowGUI";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpShowDate;
        private System.Windows.Forms.ComboBox cboFilmId;
        private System.Windows.Forms.ComboBox cboRoomId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNo;
    }
}