﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace MartSystem
{
    public partial class LogIN : Form
    {
        public LogIN()
        {
            InitializeComponent();
        }

        private void btnExite_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool select = false;
        private void bunifuCustomLabel1_MouseDown(object sender, MouseEventArgs e)
        {
            select = true;
        }

        private void bunifuCustomLabel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (select == true)
                this.Location = e.Location;
        }

        private void bunifuCustomLabel1_MouseLeave(object sender, EventArgs e)
        {
            select = false;
        }
       BunifuThinButton2  btn;
        private void btnLogIn_MouseHover(object sender, EventArgs e)
        {
            btn = (BunifuThinButton2)sender;
            btn.Font = new Font(btnLogIn.Font.FontFamily, 18);
        }

        private void btnLogIn_MouseLeave(object sender, EventArgs e)
        {
            btn = (BunifuThinButton2)sender;
            btn.Font = new Font(btnLogIn.Font.FontFamily, 12);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            bool incorrectedInfo = false;
            foreach (DataRow Dr in dt.Rows)
            {
                //MessageBox.Show(Dr["UserAcc"].ToString());
                //MessageBox.Show(Dr["Pwd"].ToString());
                if ((txtuserName.Text== Dr["UserAcc"].ToString() && txtpass.Text == Dr["Pwd"].ToString()))
                {
                    if (Convert.ToBoolean(Dr["Active"]) == true)
                    {
                        MessageBox.Show("Welcome " + Dr["Fname"] + " " + Dr["Lname"]);
                        Dom_SqlClass.empID = Dr["EmpID"].ToString();
                        Dom_SqlClass.fName = Dr["Fname"].ToString();
                        Dom_SqlClass.lName = Dr["Lname"].ToString();
                        Dom_SqlClass.position = Dr["Position"].ToString();
                        //new Import().ShowDialog();
                        this.DialogResult = DialogResult.OK;
                        Form1 f = new Form1();
                        f.Show();
                        incorrectedInfo = false;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Your Account is Deactive !");
                        break;
                    }
                }
                else
                {
                    incorrectedInfo = true;
                    //MessageBox.Show("Incorrect Password or User Name !");
                    //break;
                }
            }
            if (incorrectedInfo)
                MessageBox.Show("Incorrect Password or User Name !");
        }
        DataTable dt;
        private void LogIN_Load(object sender, EventArgs e)
        {
            dataCon.getRateAndDaysAlmostExp();

            dt = Dom_SqlClass.retriveData("Employee join UserAcc on Employee.EmpID=UserAcc.EmpID", "", new string[] {"*"});

            string fileDir = AppDomain.CurrentDomain.BaseDirectory + @"Image\Product\";
            DirectoryInfo di =Directory.CreateDirectory(fileDir);
            dataCon.getRateAndDaysAlmostExp();
        }

        private void txtpass_MouseClick(object sender, MouseEventArgs e)
        {
            txtpass.ForeColor = Color.Green;
        }

        private void txtpass_MouseUp(object sender, MouseEventArgs e)
        {
            txtpass.ForeColor = Color.Black;
        }

        private void txtpass_MouseEnter(object sender, EventArgs e)
        {
           // txtpass_MouseClick(null, null);
        }

        private void txtpass_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnLogIn_Click(null, null);
        }
    }
}
