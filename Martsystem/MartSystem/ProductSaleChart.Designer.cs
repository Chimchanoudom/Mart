namespace MartSystem
{
    partial class ProductSaleChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.rndYears = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rndMonth = new System.Windows.Forms.RadioButton();
            this.rndYear = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbShowing = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbProduct);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(298, 52);
            this.panel2.TabIndex = 4;
            // 
            // cbProduct
            // 
            this.cbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(102, 12);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(187, 33);
            this.cbProduct.TabIndex = 1;
            this.cbProduct.SelectedIndexChanged += new System.EventHandler(this.cbProduct_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnOk);
            this.panel6.Controls.Add(this.rndYears);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.rndMonth);
            this.panel6.Controls.Add(this.rndYear);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(576, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(462, 52);
            this.panel6.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.SeaGreen;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(351, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(99, 40);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Show";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rndYears
            // 
            this.rndYears.AutoSize = true;
            this.rndYears.Checked = true;
            this.rndYears.Location = new System.Drawing.Point(259, 13);
            this.rndYears.Name = "rndYears";
            this.rndYears.Size = new System.Drawing.Size(84, 29);
            this.rndYears.TabIndex = 5;
            this.rndYears.TabStop = true;
            this.rndYears.Text = "Years";
            this.rndYears.UseVisualStyleBackColor = true;
            this.rndYears.CheckedChanged += new System.EventHandler(this.rndYears_CheckedChanged);
            this.rndYears.Click += new System.EventHandler(this.rndYears_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "View:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // rndMonth
            // 
            this.rndMonth.AutoSize = true;
            this.rndMonth.Location = new System.Drawing.Point(85, 13);
            this.rndMonth.Name = "rndMonth";
            this.rndMonth.Size = new System.Drawing.Size(88, 29);
            this.rndMonth.TabIndex = 5;
            this.rndMonth.Text = "Month";
            this.rndMonth.UseVisualStyleBackColor = true;
            this.rndMonth.CheckedChanged += new System.EventHandler(this.rndMonth_CheckedChanged);
            this.rndMonth.Click += new System.EventHandler(this.rndDay_Click);
            // 
            // rndYear
            // 
            this.rndYear.AutoSize = true;
            this.rndYear.Location = new System.Drawing.Point(179, 13);
            this.rndYear.Name = "rndYear";
            this.rndYear.Size = new System.Drawing.Size(74, 29);
            this.rndYear.TabIndex = 5;
            this.rndYear.Text = "Year";
            this.rndYear.UseVisualStyleBackColor = true;
            this.rndYear.CheckedChanged += new System.EventHandler(this.rndYear_CheckedChanged);
            this.rndYear.Click += new System.EventHandler(this.rndYear_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 52);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(298, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(278, 52);
            this.panel3.TabIndex = 4;
            // 
            // txtSearch
            // 
            this.txtSearch.Enabled = false;
            this.txtSearch.Location = new System.Drawing.Point(26, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(234, 30);
            this.txtSearch.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbShowing);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 52);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1038, 49);
            this.panel4.TabIndex = 1;
            // 
            // cbShowing
            // 
            this.cbShowing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShowing.FormattingEnabled = true;
            this.cbShowing.Items.AddRange(new object[] {
            "Quantity",
            "Amount"});
            this.cbShowing.Location = new System.Drawing.Point(102, 6);
            this.cbShowing.Name = "cbShowing";
            this.cbShowing.Size = new System.Drawing.Size(187, 33);
            this.cbShowing.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Showing:";
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1038, 436);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chart);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 101);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1038, 436);
            this.panel5.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1038, 537);
            this.panel7.TabIndex = 2;
            // 
            // ProductSaleChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1038, 537);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel7);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProductSaleChart";
            this.Text = "ProductSaleChart";
            this.Load += new System.EventHandler(this.ProductSaleChart_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton rndYears;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rndMonth;
        private System.Windows.Forms.RadioButton rndYear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbShowing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
    }
}