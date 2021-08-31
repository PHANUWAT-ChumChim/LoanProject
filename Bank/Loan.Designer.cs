﻿
using System;

namespace example.Bank
{
    partial class Loan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LGuarantorAmount = new System.Windows.Forms.Label();
            this.BSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel16 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.TBGuarantorNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BTsave = new System.Windows.Forms.Button();
            this.DGVGuarantor = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LLoanAmount = new System.Windows.Forms.Label();
            this.CBPayMonth = new System.Windows.Forms.ComboBox();
            this.CBPayYear = new System.Windows.Forms.ComboBox();
            this.TBInterestRate = new System.Windows.Forms.TextBox();
            this.TBPayNo = new System.Windows.Forms.TextBox();
            this.TBLoanAmount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DGVLoanDetail = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.CByeartap3 = new System.Windows.Forms.ComboBox();
            this.BTResearchtap3 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.BLoanDocUpload = new System.Windows.Forms.Button();
            this.BPrintLoanDoc = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.TBSavingAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBLoanStatus = new System.Windows.Forms.TextBox();
            this.BL = new System.Windows.Forms.Label();
            this.TBLoanNo = new System.Windows.Forms.TextBox();
            this.LBContractNumber = new System.Windows.Forms.Label();
            this.BSearchTeacher = new System.Windows.Forms.Button();
            this.TBTeacherName = new System.Windows.Forms.TextBox();
            this.TBTeacherNo = new System.Windows.Forms.TextBox();
            this.LB2Ne = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LB1Id = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGuarantor)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLoanDetail)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LGuarantorAmount);
            this.panel1.Controls.Add(this.BSave);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Location = new System.Drawing.Point(21, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1165, 712);
            this.panel1.TabIndex = 99;
            // 
            // LGuarantorAmount
            // 
            this.LGuarantorAmount.AutoSize = true;
            this.LGuarantorAmount.Font = new System.Drawing.Font("TH Sarabun New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGuarantorAmount.Location = new System.Drawing.Point(23, 620);
            this.LGuarantorAmount.Name = "LGuarantorAmount";
            this.LGuarantorAmount.Size = new System.Drawing.Size(48, 40);
            this.LGuarantorAmount.TabIndex = 100;
            this.LGuarantorAmount.Text = "0/4";
            // 
            // BSave
            // 
            this.BSave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSave.Location = new System.Drawing.Point(803, 624);
            this.BSave.Name = "BSave";
            this.BSave.Size = new System.Drawing.Size(342, 79);
            this.BSave.TabIndex = 99;
            this.BSave.Text = "บันทึก";
            this.BSave.UseVisualStyleBackColor = false;
            this.BSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(8, 165);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1138, 453);
            this.tabControl1.TabIndex = 97;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.panel16);
            this.tabPage1.Controls.Add(this.BTsave);
            this.tabPage1.Controls.Add(this.DGVGuarantor);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 45);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1130, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "เลือกผู้ค้ำ";
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.White;
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.button1);
            this.panel16.Controls.Add(this.TBGuarantorNo);
            this.panel16.Controls.Add(this.label3);
            this.panel16.Location = new System.Drawing.Point(0, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(368, 72);
            this.panel16.TabIndex = 98;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("TH Sarabun New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageKey = "(none)";
            this.button1.Location = new System.Drawing.Point(296, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 43);
            this.button1.TabIndex = 88;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TBGuarantorNo
            // 
            this.TBGuarantorNo.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBGuarantorNo.Location = new System.Drawing.Point(118, 14);
            this.TBGuarantorNo.Name = "TBGuarantorNo";
            this.TBGuarantorNo.Size = new System.Drawing.Size(170, 43);
            this.TBGuarantorNo.TabIndex = 87;
            this.TBGuarantorNo.TextChanged += new System.EventHandler(this.TBGuarantorNo_TextChanged);
            this.TBGuarantorNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBGuarantorNo_KeyDown);
            this.TBGuarantorNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBGuarantorNo_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 37);
            this.label3.TabIndex = 86;
            this.label3.Text = "รหัสผู้มีสิ้นค้ำ";
            // 
            // BTsave
            // 
            this.BTsave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTsave.Location = new System.Drawing.Point(781, 491);
            this.BTsave.Name = "BTsave";
            this.BTsave.Size = new System.Drawing.Size(342, 79);
            this.BTsave.TabIndex = 94;
            this.BTsave.Text = "บันทึก";
            this.BTsave.UseVisualStyleBackColor = false;
            // 
            // DGVGuarantor
            // 
            this.DGVGuarantor.AllowUserToAddRows = false;
            this.DGVGuarantor.BackgroundColor = System.Drawing.Color.White;
            this.DGVGuarantor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVGuarantor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.DGVGuarantor.Location = new System.Drawing.Point(3, 78);
            this.DGVGuarantor.Name = "DGVGuarantor";
            this.DGVGuarantor.ReadOnly = true;
            this.DGVGuarantor.RowHeadersVisible = false;
            this.DGVGuarantor.RowHeadersWidth = 51;
            this.DGVGuarantor.RowTemplate.Height = 24;
            this.DGVGuarantor.Size = new System.Drawing.Size(1123, 320);
            this.DGVGuarantor.TabIndex = 93;
            this.DGVGuarantor.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DGVGuarantor_RowsAdded);
            this.DGVGuarantor.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DGVGuarantor_RowsRemoved);
            this.DGVGuarantor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DGVGuarantor_MouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "รหัส";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ชื่อ";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 349;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ยอดเงินค้ำ";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 340;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LLoanAmount);
            this.tabPage2.Controls.Add(this.CBPayMonth);
            this.tabPage2.Controls.Add(this.CBPayYear);
            this.tabPage2.Controls.Add(this.TBInterestRate);
            this.tabPage2.Controls.Add(this.TBPayNo);
            this.tabPage2.Controls.Add(this.TBLoanAmount);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 45);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1130, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "การกู้";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LLoanAmount
            // 
            this.LLoanAmount.AutoSize = true;
            this.LLoanAmount.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLoanAmount.Location = new System.Drawing.Point(656, 94);
            this.LLoanAmount.Name = "LLoanAmount";
            this.LLoanAmount.Size = new System.Drawing.Size(37, 37);
            this.LLoanAmount.TabIndex = 17;
            this.LLoanAmount.Text = "( )";
            // 
            // CBPayMonth
            // 
            this.CBPayMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBPayMonth.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBPayMonth.FormattingEnabled = true;
            this.CBPayMonth.Location = new System.Drawing.Point(430, 190);
            this.CBPayMonth.Name = "CBPayMonth";
            this.CBPayMonth.Size = new System.Drawing.Size(151, 44);
            this.CBPayMonth.TabIndex = 15;
            this.CBPayMonth.SelectedIndexChanged += new System.EventHandler(this.CBPayMonth_SelectedIndexChanged);
            // 
            // CBPayYear
            // 
            this.CBPayYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBPayYear.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBPayYear.FormattingEnabled = true;
            this.CBPayYear.Location = new System.Drawing.Point(638, 190);
            this.CBPayYear.Name = "CBPayYear";
            this.CBPayYear.Size = new System.Drawing.Size(151, 44);
            this.CBPayYear.TabIndex = 16;
            this.CBPayYear.SelectedIndexChanged += new System.EventHandler(this.CBPayYear_SelectedIndexChanged);
            // 
            // TBInterestRate
            // 
            this.TBInterestRate.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBInterestRate.Location = new System.Drawing.Point(802, 292);
            this.TBInterestRate.Name = "TBInterestRate";
            this.TBInterestRate.Size = new System.Drawing.Size(89, 43);
            this.TBInterestRate.TabIndex = 12;
            this.TBInterestRate.Text = "1";
            this.TBInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBInterestRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBInterestRate_KeyPress);
            // 
            // TBPayNo
            // 
            this.TBPayNo.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPayNo.Location = new System.Drawing.Point(370, 289);
            this.TBPayNo.Name = "TBPayNo";
            this.TBPayNo.Size = new System.Drawing.Size(254, 43);
            this.TBPayNo.TabIndex = 13;
            this.TBPayNo.Text = "12";
            this.TBPayNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBPayNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBPayNo_KeyPress);
            // 
            // TBLoanAmount
            // 
            this.TBLoanAmount.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBLoanAmount.Location = new System.Drawing.Point(371, 91);
            this.TBLoanAmount.MaxLength = 8;
            this.TBLoanAmount.Name = "TBLoanAmount";
            this.TBLoanAmount.Size = new System.Drawing.Size(254, 43);
            this.TBLoanAmount.TabIndex = 14;
            this.TBLoanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBLoanAmount.TextChanged += new System.EventHandler(this.TBLoanAmount_TextChanged);
            this.TBLoanAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBLoanAmount_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(365, 193);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 37);
            this.label12.TabIndex = 6;
            this.label12.Text = "เดือน";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(603, 193);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 37);
            this.label11.TabIndex = 7;
            this.label11.Text = "ปี";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(670, 295);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 37);
            this.label14.TabIndex = 8;
            this.label14.Text = "อัตราดอกเบี้ย";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(240, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 37);
            this.label10.TabIndex = 9;
            this.label10.Text = "เริ่มชำระ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(240, 292);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 37);
            this.label13.TabIndex = 10;
            this.label13.Text = "จำนวนงวด";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(245, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 37);
            this.label8.TabIndex = 11;
            this.label8.Text = "วงเงินกู้";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DGVLoanDetail);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 45);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1130, 404);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "รายละเอียดการชำระ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DGVLoanDetail
            // 
            this.DGVLoanDetail.AllowUserToAddRows = false;
            this.DGVLoanDetail.AllowUserToDeleteRows = false;
            this.DGVLoanDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLoanDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column4,
            this.Column5,
            this.Column6});
            this.DGVLoanDetail.Location = new System.Drawing.Point(6, 88);
            this.DGVLoanDetail.Name = "DGVLoanDetail";
            this.DGVLoanDetail.ReadOnly = true;
            this.DGVLoanDetail.RowHeadersVisible = false;
            this.DGVLoanDetail.RowHeadersWidth = 51;
            this.DGVLoanDetail.RowTemplate.Height = 24;
            this.DGVLoanDetail.Size = new System.Drawing.Size(1118, 320);
            this.DGVLoanDetail.TabIndex = 110;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "เดือน / ปี";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "เงินต้น";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ดอกเบี้ย";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "รวมที่ต้องจ่าย";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.CByeartap3);
            this.panel3.Controls.Add(this.BTResearchtap3);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(287, 72);
            this.panel3.TabIndex = 109;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.White;
            this.label23.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(18, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 37);
            this.label23.TabIndex = 99;
            this.label23.Text = "ปี";
            // 
            // CByeartap3
            // 
            this.CByeartap3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CByeartap3.Font = new System.Drawing.Font("TH Sarabun New", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CByeartap3.FormattingEnabled = true;
            this.CByeartap3.Items.AddRange(new object[] {
            "2021",
            "2020",
            "2019",
            "2018",
            "2017",
            "2015"});
            this.CByeartap3.Location = new System.Drawing.Point(64, 17);
            this.CByeartap3.Name = "CByeartap3";
            this.CByeartap3.Size = new System.Drawing.Size(103, 39);
            this.CByeartap3.TabIndex = 84;
            // 
            // BTResearchtap3
            // 
            this.BTResearchtap3.BackColor = System.Drawing.Color.White;
            this.BTResearchtap3.Enabled = false;
            this.BTResearchtap3.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTResearchtap3.Location = new System.Drawing.Point(182, 14);
            this.BTResearchtap3.Name = "BTResearchtap3";
            this.BTResearchtap3.Size = new System.Drawing.Size(90, 45);
            this.BTResearchtap3.TabIndex = 86;
            this.BTResearchtap3.Text = "ค้นหา";
            this.BTResearchtap3.UseVisualStyleBackColor = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel9);
            this.tabPage4.Location = new System.Drawing.Point(4, 45);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1130, 404);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "เอกสารกู้ยื่ม";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.panel4);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1122, 398);
            this.panel9.TabIndex = 109;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.BLoanDocUpload);
            this.panel4.Controls.Add(this.BPrintLoanDoc);
            this.panel4.Location = new System.Drawing.Point(14, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1095, 520);
            this.panel4.TabIndex = 122;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TH Sarabun New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(56, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(408, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "อัพโหลดเอกสารสัญญากู้ที่มีลายเซ็นครบถ้าน";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("TH Sarabun New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label15.Location = new System.Drawing.Point(56, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(200, 40);
            this.label15.TabIndex = 5;
            this.label15.Text = "พิมพ์เอกสารสัญญากู้";
            // 
            // BLoanDocUpload
            // 
            this.BLoanDocUpload.Location = new System.Drawing.Point(510, 157);
            this.BLoanDocUpload.Name = "BLoanDocUpload";
            this.BLoanDocUpload.Size = new System.Drawing.Size(224, 66);
            this.BLoanDocUpload.TabIndex = 2;
            this.BLoanDocUpload.Text = "อัพโหลดเอกสาร";
            this.BLoanDocUpload.UseVisualStyleBackColor = true;
            this.BLoanDocUpload.Click += new System.EventHandler(this.BLoanDocUpload_Click);
            // 
            // BPrintLoanDoc
            // 
            this.BPrintLoanDoc.Location = new System.Drawing.Point(510, 66);
            this.BPrintLoanDoc.Name = "BPrintLoanDoc";
            this.BPrintLoanDoc.Size = new System.Drawing.Size(224, 66);
            this.BPrintLoanDoc.TabIndex = 3;
            this.BPrintLoanDoc.Text = "พิมพ์เอกสาร";
            this.BPrintLoanDoc.UseVisualStyleBackColor = true;
            this.BPrintLoanDoc.Click += new System.EventHandler(this.BPrintLoanDoc_Click_1);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.TBSavingAmount);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.TBLoanStatus);
            this.panel7.Controls.Add(this.BL);
            this.panel7.Controls.Add(this.TBLoanNo);
            this.panel7.Controls.Add(this.LBContractNumber);
            this.panel7.Controls.Add(this.BSearchTeacher);
            this.panel7.Controls.Add(this.TBTeacherName);
            this.panel7.Controls.Add(this.TBTeacherNo);
            this.panel7.Controls.Add(this.LB2Ne);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.LB1Id);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1165, 134);
            this.panel7.TabIndex = 63;
            // 
            // TBSavingAmount
            // 
            this.TBSavingAmount.Enabled = false;
            this.TBSavingAmount.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBSavingAmount.Location = new System.Drawing.Point(816, 86);
            this.TBSavingAmount.Name = "TBSavingAmount";
            this.TBSavingAmount.Size = new System.Drawing.Size(321, 43);
            this.TBSavingAmount.TabIndex = 91;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(730, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 37);
            this.label4.TabIndex = 90;
            this.label4.Text = "หุ้นสะสม";
            // 
            // TBLoanStatus
            // 
            this.TBLoanStatus.Enabled = false;
            this.TBLoanStatus.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBLoanStatus.Location = new System.Drawing.Point(483, 78);
            this.TBLoanStatus.Name = "TBLoanStatus";
            this.TBLoanStatus.Size = new System.Drawing.Size(231, 43);
            this.TBLoanStatus.TabIndex = 89;
            // 
            // BL
            // 
            this.BL.AutoSize = true;
            this.BL.BackColor = System.Drawing.Color.White;
            this.BL.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BL.ForeColor = System.Drawing.Color.Black;
            this.BL.Location = new System.Drawing.Point(414, 81);
            this.BL.Name = "BL";
            this.BL.Size = new System.Drawing.Size(71, 37);
            this.BL.TabIndex = 88;
            this.BL.Text = "สถานะ";
            // 
            // TBLoanNo
            // 
            this.TBLoanNo.Enabled = false;
            this.TBLoanNo.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBLoanNo.Location = new System.Drawing.Point(146, 78);
            this.TBLoanNo.Name = "TBLoanNo";
            this.TBLoanNo.Size = new System.Drawing.Size(263, 43);
            this.TBLoanNo.TabIndex = 87;
            // 
            // LBContractNumber
            // 
            this.LBContractNumber.AutoSize = true;
            this.LBContractNumber.BackColor = System.Drawing.Color.White;
            this.LBContractNumber.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBContractNumber.ForeColor = System.Drawing.Color.Black;
            this.LBContractNumber.Location = new System.Drawing.Point(18, 81);
            this.LBContractNumber.Name = "LBContractNumber";
            this.LBContractNumber.Size = new System.Drawing.Size(122, 37);
            this.LBContractNumber.TabIndex = 86;
            this.LBContractNumber.Text = "เลขที่สัญญากู้";
            // 
            // BSearchTeacher
            // 
            this.BSearchTeacher.BackColor = System.Drawing.Color.White;
            this.BSearchTeacher.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BSearchTeacher.BackgroundImage")));
            this.BSearchTeacher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BSearchTeacher.Font = new System.Drawing.Font("TH Sarabun New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSearchTeacher.ImageKey = "(none)";
            this.BSearchTeacher.Location = new System.Drawing.Point(310, 14);
            this.BSearchTeacher.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.BSearchTeacher.Name = "BSearchTeacher";
            this.BSearchTeacher.Size = new System.Drawing.Size(43, 43);
            this.BSearchTeacher.TabIndex = 85;
            this.BSearchTeacher.UseVisualStyleBackColor = false;
            this.BSearchTeacher.Click += new System.EventHandler(this.BSearchTeacher_Click);
            // 
            // TBTeacherName
            // 
            this.TBTeacherName.Enabled = false;
            this.TBTeacherName.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTeacherName.Location = new System.Drawing.Point(484, 12);
            this.TBTeacherName.Name = "TBTeacherName";
            this.TBTeacherName.Size = new System.Drawing.Size(446, 43);
            this.TBTeacherName.TabIndex = 83;
            // 
            // TBTeacherNo
            // 
            this.TBTeacherNo.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTeacherNo.Location = new System.Drawing.Point(70, 14);
            this.TBTeacherNo.MaxLength = 6;
            this.TBTeacherNo.Name = "TBTeacherNo";
            this.TBTeacherNo.Size = new System.Drawing.Size(230, 43);
            this.TBTeacherNo.TabIndex = 82;
            this.TBTeacherNo.TextChanged += new System.EventHandler(this.TBTeacherNo_TextChanged);
            this.TBTeacherNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBTeacherNo_KeyDown);
            // 
            // LB2Ne
            // 
            this.LB2Ne.AutoSize = true;
            this.LB2Ne.BackColor = System.Drawing.Color.White;
            this.LB2Ne.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB2Ne.ForeColor = System.Drawing.Color.Black;
            this.LB2Ne.Location = new System.Drawing.Point(401, 15);
            this.LB2Ne.Name = "LB2Ne";
            this.LB2Ne.Size = new System.Drawing.Size(78, 37);
            this.LB2Ne.TabIndex = 68;
            this.LB2Ne.Text = "ชื่อ-สกุล";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(243, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 32);
            this.label1.TabIndex = 68;
            // 
            // LB1Id
            // 
            this.LB1Id.AutoSize = true;
            this.LB1Id.BackColor = System.Drawing.Color.White;
            this.LB1Id.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB1Id.ForeColor = System.Drawing.Color.Black;
            this.LB1Id.Location = new System.Drawing.Point(16, 17);
            this.LB1Id.Name = "LB1Id";
            this.LB1Id.Size = new System.Drawing.Size(49, 37);
            this.LB1Id.TabIndex = 67;
            this.LB1Id.Text = "รหัส";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Loan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1206, 809);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loan";
            this.Text = "Loan";
            this.Load += new System.EventHandler(this.Loan_Load);
            this.SizeChanged += new System.EventHandler(this.Loan_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGuarantor)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVLoanDetail)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        private void BPrintLoanDoc_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button BTsave;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox CByeartap3;
        private System.Windows.Forms.Button BTResearchtap3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button BLoanDocUpload;
        private System.Windows.Forms.Button BPrintLoanDoc;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button BSearchTeacher;
        private System.Windows.Forms.TextBox TBTeacherName;
        private System.Windows.Forms.TextBox TBTeacherNo;
        private System.Windows.Forms.Label LB2Ne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB1Id;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TBGuarantorNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DGVGuarantor;
        private System.Windows.Forms.TextBox TBLoanStatus;
        private System.Windows.Forms.Label BL;
        private System.Windows.Forms.TextBox TBLoanNo;
        private System.Windows.Forms.Label LBContractNumber;
        private System.Windows.Forms.Button BSave;
        private System.Windows.Forms.ComboBox CBPayMonth;
        private System.Windows.Forms.ComboBox CBPayYear;
        private System.Windows.Forms.TextBox TBInterestRate;
        private System.Windows.Forms.TextBox TBPayNo;
        private System.Windows.Forms.TextBox TBLoanAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView DGVLoanDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TextBox TBSavingAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label LLoanAmount;
        private System.Windows.Forms.Label LGuarantorAmount;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}