
namespace example.GOODS
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Home_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pay = new System.Windows.Forms.ToolStripMenuItem();
            this.Loan = new System.Windows.Forms.ToolStripMenuItem();
            this.ปดยอดToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Member_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SentingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Home_ToolStripMenuItem,
            this.pay,
            this.Loan,
            this.ปดยอดToolStripMenuItem,
            this.Member_ToolStripMenuItem,
            this.SentingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1176, 45);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.menuStrip1_ItemAdded);
            // 
            // Home_ToolStripMenuItem
            // 
            this.Home_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Home_ToolStripMenuItem.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home_ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Home_ToolStripMenuItem.Image")));
            this.Home_ToolStripMenuItem.Name = "Home_ToolStripMenuItem";
            this.Home_ToolStripMenuItem.Size = new System.Drawing.Size(117, 41);
            this.Home_ToolStripMenuItem.Text = "หน้าเเรก";
            this.Home_ToolStripMenuItem.Click += new System.EventHandler(this.หนาเเรกToolStripMenuItem_Click);
            // 
            // pay
            // 
            this.pay.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pay.Image = ((System.Drawing.Image)(resources.GetObject("pay.Image")));
            this.pay.Name = "pay";
            this.pay.Size = new System.Drawing.Size(152, 41);
            this.pay.Text = "จ่าย สะสม/กู้";
            this.pay.Click += new System.EventHandler(this.pay_Click);
            // 
            // Loan
            // 
            this.Loan.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loan.Image = ((System.Drawing.Image)(resources.GetObject("Loan.Image")));
            this.Loan.Name = "Loan";
            this.Loan.Size = new System.Drawing.Size(62, 41);
            this.Loan.Text = "กู้";
            this.Loan.Click += new System.EventHandler(this.Loan_Click);
            // 
            // ปดยอดToolStripMenuItem
            // 
            this.ปดยอดToolStripMenuItem.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ปดยอดToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ปดยอดToolStripMenuItem.Image")));
            this.ปดยอดToolStripMenuItem.Name = "ปดยอดToolStripMenuItem";
            this.ปดยอดToolStripMenuItem.Size = new System.Drawing.Size(107, 41);
            this.ปดยอดToolStripMenuItem.Text = "ปิดยอด";
            // 
            // Member_ToolStripMenuItem
            // 
            this.Member_ToolStripMenuItem.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Member_ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Member_ToolStripMenuItem.Image")));
            this.Member_ToolStripMenuItem.Name = "Member_ToolStripMenuItem";
            this.Member_ToolStripMenuItem.Size = new System.Drawing.Size(149, 41);
            this.Member_ToolStripMenuItem.Text = "สมัครสมาชิก";
            this.Member_ToolStripMenuItem.Click += new System.EventHandler(this.สมครสมาชกToolStripMenuItem_Click);
            // 
            // SentingToolStripMenuItem
            // 
            this.SentingToolStripMenuItem.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SentingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SentingToolStripMenuItem.Image")));
            this.SentingToolStripMenuItem.Name = "SentingToolStripMenuItem";
            this.SentingToolStripMenuItem.Size = new System.Drawing.Size(92, 41);
            this.SentingToolStripMenuItem.Text = "ตั้งค่า";
            this.SentingToolStripMenuItem.Click += new System.EventHandler(this.SettingToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1176, 791);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "หน้าเเรก";
            this.Load += new System.EventHandler(this.Menu_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Home_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pay;
        private System.Windows.Forms.ToolStripMenuItem Loan;
        private System.Windows.Forms.ToolStripMenuItem ปดยอดToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Member_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SentingToolStripMenuItem;
    }
}