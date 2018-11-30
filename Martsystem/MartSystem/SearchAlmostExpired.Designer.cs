namespace MartSystem
{
    partial class SearchAlmostExpired
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
            this.cbCon = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch1 = new System.Windows.Forms.Button();
            this.txtValue = new MartSystem.Custom_Controls.NumberTextBox();
            this.SuspendLayout();
            // 
            // cbCon
            // 
            this.cbCon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbCon.FormattingEnabled = true;
            this.cbCon.Items.AddRange(new object[] {
            "Years",
            "Months",
            "Weeks",
            "Days"});
            this.cbCon.Location = new System.Drawing.Point(128, 19);
            this.cbCon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCon.Name = "cbCon";
            this.cbCon.Size = new System.Drawing.Size(241, 33);
            this.cbCon.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search by:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(13, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Value:";
            // 
            // btnSearch1
            // 
            this.btnSearch1.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSearch1.FlatAppearance.BorderSize = 0;
            this.btnSearch1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch1.ForeColor = System.Drawing.Color.White;
            this.btnSearch1.Location = new System.Drawing.Point(18, 112);
            this.btnSearch1.Name = "btnSearch1";
            this.btnSearch1.Size = new System.Drawing.Size(101, 41);
            this.btnSearch1.TabIndex = 3;
            this.btnSearch1.Text = "Search";
            this.btnSearch1.UseVisualStyleBackColor = false;
            this.btnSearch1.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtValue
            // 
            this.txtValue.FloatNumber = false;
            this.txtValue.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.txtValue.Location = new System.Drawing.Point(128, 65);
            this.txtValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(241, 34);
            this.txtValue.TabIndex = 2;
            // 
            // SearchAlmostExpired
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(405, 176);
            this.Controls.Add(this.btnSearch1);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCon);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SearchAlmostExpired";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchAlmostExpired";
            this.Load += new System.EventHandler(this.SearchAlmostExpired_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCon;
        private System.Windows.Forms.Label label1;
        private Custom_Controls.NumberTextBox txtValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch1;
    }
}