
namespace Group5.GUI
{
    partial class ShowAddEditGUI
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
            this.cboRoomId = new System.Windows.Forms.ComboBox();
            this.dtpShowDate = new System.Windows.Forms.DateTimePicker();
            this.cboSlot = new System.Windows.Forms.ComboBox();
            this.cboFilmId = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShowId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboRoomId
            // 
            this.cboRoomId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoomId.Enabled = false;
            this.cboRoomId.FormattingEnabled = true;
            this.cboRoomId.Location = new System.Drawing.Point(154, 41);
            this.cboRoomId.Margin = new System.Windows.Forms.Padding(2);
            this.cboRoomId.Name = "cboRoomId";
            this.cboRoomId.Size = new System.Drawing.Size(146, 28);
            this.cboRoomId.TabIndex = 0;
            this.cboRoomId.SelectedIndexChanged += new System.EventHandler(this.cboRoomId_SelectedIndexChanged);
            // 
            // dtpShowDate
            // 
            this.dtpShowDate.CustomFormat = "dd/MM/yyyy";
            this.dtpShowDate.Enabled = false;
            this.dtpShowDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShowDate.Location = new System.Drawing.Point(154, 88);
            this.dtpShowDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpShowDate.Name = "dtpShowDate";
            this.dtpShowDate.Size = new System.Drawing.Size(146, 27);
            this.dtpShowDate.TabIndex = 1;
            this.dtpShowDate.ValueChanged += new System.EventHandler(this.dtpShowDate_ValueChanged);
            // 
            // cboSlot
            // 
            this.cboSlot.FormattingEnabled = true;
            this.cboSlot.Location = new System.Drawing.Point(154, 141);
            this.cboSlot.Margin = new System.Windows.Forms.Padding(2);
            this.cboSlot.Name = "cboSlot";
            this.cboSlot.Size = new System.Drawing.Size(146, 28);
            this.cboSlot.TabIndex = 2;
            // 
            // cboFilmId
            // 
            this.cboFilmId.FormattingEnabled = true;
            this.cboFilmId.Location = new System.Drawing.Point(154, 186);
            this.cboFilmId.Margin = new System.Windows.Forms.Padding(2);
            this.cboFilmId.Name = "cboFilmId";
            this.cboFilmId.Size = new System.Drawing.Size(146, 28);
            this.cboFilmId.TabIndex = 3;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(154, 235);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(121, 27);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(61, 295);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 27);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(236, 295);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 27);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Room:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Slot:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Film:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Price:";
            // 
            // txtShowId
            // 
            this.txtShowId.Location = new System.Drawing.Point(470, 41);
            this.txtShowId.Margin = new System.Windows.Forms.Padding(2);
            this.txtShowId.Name = "txtShowId";
            this.txtShowId.Size = new System.Drawing.Size(121, 27);
            this.txtShowId.TabIndex = 12;
            this.txtShowId.Visible = false;
            // 
            // ShowAddEditGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 375);
            this.ControlBox = false;
            this.Controls.Add(this.txtShowId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.cboFilmId);
            this.Controls.Add(this.cboSlot);
            this.Controls.Add(this.dtpShowDate);
            this.Controls.Add(this.cboRoomId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ShowAddEditGUI";
            this.ShowInTaskbar = false;
            this.Text = "ShowAddEditGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboRoomId;
        private System.Windows.Forms.DateTimePicker dtpShowDate;
        private System.Windows.Forms.ComboBox cboSlot;
        private System.Windows.Forms.ComboBox cboFilmId;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtShowId;
    }
}