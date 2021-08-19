
namespace example.Bank
{
    partial class Setting
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
            this.P1 = new System.Windows.Forms.Panel();
            this.LBsetting = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CHB_edittime = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.TB_Max = new System.Windows.Forms.TextBox();
            this.TB_Min = new System.Windows.Forms.TextBox();
            this.P1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // P1
            // 
            this.P1.BackColor = System.Drawing.Color.White;
            this.P1.Controls.Add(this.LBsetting);
            this.P1.Controls.Add(this.tabControl1);
            this.P1.Location = new System.Drawing.Point(18, 42);
            this.P1.Name = "P1";
            this.P1.Size = new System.Drawing.Size(732, 657);
            this.P1.TabIndex = 99;
            // 
            // LBsetting
            // 
            this.LBsetting.AutoSize = true;
            this.LBsetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBsetting.Location = new System.Drawing.Point(290, 14);
            this.LBsetting.Name = "LBsetting";
            this.LBsetting.Size = new System.Drawing.Size(236, 58);
            this.LBsetting.TabIndex = 99;
            this.LBsetting.Text = "ตั้งค่าระบบ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(32, 92);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(678, 535);
            this.tabControl1.TabIndex = 98;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.CHB_edittime);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.B_Cancel);
            this.tabPage1.Controls.Add(this.B_Save);
            this.tabPage1.Controls.Add(this.TB_Max);
            this.tabPage1.Controls.Add(this.TB_Min);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(670, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "กำหนดค่าเริ่มต้น";
            // 
            // CHB_edittime
            // 
            this.CHB_edittime.AutoSize = true;
            this.CHB_edittime.Location = new System.Drawing.Point(155, 158);
            this.CHB_edittime.Name = "CHB_edittime";
            this.CHB_edittime.Size = new System.Drawing.Size(260, 36);
            this.CHB_edittime.TabIndex = 7;
            this.CHB_edittime.Text = "อณุญาตให้แก้ไขเวลา";
            this.CHB_edittime.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Max";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Min";
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(155, 213);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(97, 45);
            this.B_Cancel.TabIndex = 11;
            this.B_Cancel.Text = "ยกเลิก";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click_1);
            // 
            // B_Save
            // 
            this.B_Save.Location = new System.Drawing.Point(309, 213);
            this.B_Save.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(90, 45);
            this.B_Save.TabIndex = 10;
            this.B_Save.Text = "บันทึก";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click_1);
            // 
            // TB_Max
            // 
            this.TB_Max.Location = new System.Drawing.Point(155, 93);
            this.TB_Max.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.TB_Max.MaxLength = 10;
            this.TB_Max.Name = "TB_Max";
            this.TB_Max.Size = new System.Drawing.Size(238, 38);
            this.TB_Max.TabIndex = 5;
            this.TB_Max.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Max_KeyPress_1);
            // 
            // TB_Min
            // 
            this.TB_Min.Location = new System.Drawing.Point(155, 29);
            this.TB_Min.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.TB_Min.MaxLength = 10;
            this.TB_Min.Name = "TB_Min";
            this.TB_Min.Size = new System.Drawing.Size(238, 38);
            this.TB_Min.TabIndex = 6;
            this.TB_Min.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Min_KeyPress_1);
            // 
            // TBtest
            // 
            this.TBtest.AutoSize = true;
            this.TBtest.Location = new System.Drawing.Point(541, 387);
            this.TBtest.Name = "TBtest";
            this.TBtest.Size = new System.Drawing.Size(27, 37);
            this.TBtest.TabIndex = 1;
            this.TBtest.Text = "0";
            this.TBtest.Visible = false;
            // 
            // PBSilder
            // 
            this.PBSilder.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.PBSilder.Location = new System.Drawing.Point(21, 387);
            this.PBSilder.Name = "PBSilder";
            this.PBSilder.Size = new System.Drawing.Size(487, 34);
            this.PBSilder.TabIndex = 0;
            this.PBSilder.TabStop = false;
            this.PBSilder.Visible = false;
            this.PBSilder.Click += new System.EventHandler(this.PBSilder_Click);
            this.PBSilder.Paint += new System.Windows.Forms.PaintEventHandler(this.PBSilder_Paint);
            this.PBSilder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBSilder_MouseDown);
            this.PBSilder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBSilder_MouseMove);
            this.PBSilder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBSilder_MouseUp);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(769, 712);
            this.Controls.Add(this.P1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.P1.ResumeLayout(false);
            this.P1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel P1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label LBsetting;
        private System.Windows.Forms.CheckBox CHB_edittime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.TextBox TB_Max;
        private System.Windows.Forms.TextBox TB_Min;
    }
}