﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartSystem
{
    public partial class ExpenseData : Form
    {
        public ExpenseData()
        {
            InitializeComponent();
        }

        DataTable dtExpense = new DataTable();
        string sql;
        DateTime[] searchedDate=new DateTime[2];
        
        private void ExpenseData_Load(object sender, EventArgs e)
        {
            sql = "select ExpenseId as 'Expense ID', DateCreate as 'Date Created',total as 'Total',e.Fname+' '+e.Lname 'Employee'  from expense ex join Employee e on ex.EmpID=e.EmpID;";

            SqlDataAdapter dataAdaptor = new SqlDataAdapter(sql,dataCon.Con);

            dataAdaptor.Fill(dtExpense);
            dgvExpenseData.DataSource=dtExpense;

            dgvExpenseData.Columns["Date Created"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvExpenseData.Columns["Total"].DefaultCellStyle.Format = "#,##0.00";

            dgvExpenseData.ClearSelection();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = "";
            
            if (rndID.Checked) {
                filter = "[Expense ID]='"+txtSearch.Text+"'";
            }
            else if (rndName.Checked)
            {
                filter = "[Employee] like '%" + txtSearch.Text+"%'";
            }
            else if (rndDateCreated.Checked)
            {
                string[] st = txtSearch.Text.Split('-');
                filter = "[Date Created]>='" + st[0] + "' AND [Date Created] <= '" + st[1] + "'";
            }

            dtExpense.DefaultView.RowFilter = filter;
        }



        private void dgvExpenseData_SelectionChanged(object sender, EventArgs e)
        {
            logToolStripMenuItem.Visible= editToolStripMenuItem.Visible = dgvExpenseData.SelectedRows.Count == 1;
            deleteToolStripMenuItem.Visible= dgvExpenseData.SelectedRows.Count >= 1;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dataRow = dtExpense.Rows[dgvExpenseData.SelectedRows[0].Index];
            CreateExpense addExpense = new CreateExpense(dataRow);
            addExpense.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to delete selected row(s)?","Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                int selectedRowIndex = dgvExpenseData.SelectedRows[0].Index;
                sql = "delete from expense where expenseID in(";

                sql += "'" + dgvExpenseData.Rows[selectedRowIndex].Cells["Expense ID"].Value + "',";


                sql = sql.Substring(0,sql.Length - 1) + ");";

                bool error = false;
                dataCon.ExecuteActionQry(sql, ref error);
                if (!error)
                {
                    dtExpense.Rows.RemoveAt(selectedRowIndex);
                    MessageBox.Show("Deleted successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateExpense addExpense = new CreateExpense(dtExpense);
            addExpense.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtExpense.DefaultView.RowFilter = string.Empty;

            rndID.Checked = true;
            
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ("'".IndexOf(e.KeyChar) > -1)
                e.KeyChar = '\0';
        }

        private void rndDateCreated_Click(object sender, EventArgs e)
        {

            SearchDate searchDate = new SearchDate(searchedDate,txtSearch,btnSearch);
            searchDate.ShowDialog();

            if (searchDate.DialogResult != DialogResult.Yes)
                rndID.Checked = true;
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dgvExpenseData.SelectedRows[0].Index;
            string id = dgvExpenseData.Rows[selectedRowIndex].Cells["Expense ID"].Value + "";
            sql = "select ExpenseLogID 'Invoice Log ID',editdate 'Edit Date',CONCAT(fname,' ',Lname) 'Edit by' from expenseLog ex join Employee e on ex.EditBy=e.EmpID where expenseId='"+id+"';";

            LogData expenseLog = new LogData("Log for Expense " + id, sql);

            expenseLog.ShowDialog();
        }

        private void rndID_CheckedChanged_1(object sender, EventArgs e)
        {
            txtSearch.Enabled = true;
            txtSearch.Text = "";

        }
    }
}
