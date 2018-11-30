using System;
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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();

        }

        public Stock(string proName)
        {
            InitializeComponent();
            this.proName = proName;
        }
        string proName;

        DataTable dtStock = new DataTable();
        string sql;
        
        private void Stock_Load(object sender, EventArgs e)
        {
             sql = "select stockid 'Stock ID', ProName 'Product Name',importDate 'Import Date',s.Qty 'Quantity',s.UnitPrice 'Unit Price',ExpiredDate 'Expire Date' ,case when ExpiredDate<=(select convert(date,GETDATE())) then '1' else '0' end 'isExpired' from stock s join Product p on s.ProID=p.ProID join Import i on s.ImportID=i.ImportID ;";


            SqlDataAdapter dataAdaptor = new SqlDataAdapter(sql,dataCon.Con);

            dataAdaptor.Fill(dtStock);

            dgvStock.DataSource = dtStock;

           
            dgvStock.Columns["isExpired"].Visible = false;

           

            dgvStock.Columns["Import Date"].DefaultCellStyle.Format =
                dgvStock.Columns["Expire Date"].DefaultCellStyle.Format
                = "dd/MM/yyyy";

            ChangeRowForeColor();

            if (proName != "")
            {
                txtSearch.Text = proName;
                btnSearch.PerformClick();
            }

        }

        void ChangeRowForeColor()
        {

            foreach (DataGridViewRow row in dgvStock.Rows)
            {
                if (row.Cells["isExpired"].Value + "" == "1")
                    row.DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        DateTime[] searchedDate = new DateTime[2];

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = "";
            if (rndProductName.Checked) filter = "[Product Name]";

            if (rndImportDate.Checked)
            {
                string[] st = txtSearch.Text.Split('-');
                filter = "[Import Date]>='" + st[0] + "' AND [Import Date] <= '" + st[1] + "'";
                
            }
            else if (rndExpiredDate.Checked||rndAlmostExpired.Checked)
            {
                string[] st = txtSearch.Text.Split('-');
                filter = "[Expire Date]>='" + st[0] + "' AND [Expire Date] <= '" + st[1] + "'";
               
            }
            else
            {
                if (rndProductName.Checked) filter += " like '%" + txtSearch.Text + "%'";
                else if (rndExpired.Checked) filter = "[isExpired]='1'";
            }

            try
            {
                dtStock.DefaultView.RowFilter = filter;
                ChangeRowForeColor();
            }
            catch (Exception)
            {
                MessageBox.Show("Encounter Error");
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtStock.DefaultView.RowFilter = string.Empty;
            ChangeRowForeColor();
        }

        private void rndImportDate_Click(object sender, EventArgs e)
        {
            SearchDate searchDate = new SearchDate(searchedDate,txtSearch,btnSearch);
            searchDate.ShowDialog();

            if (searchDate.DialogResult != DialogResult.Yes)
                rndProductName.Checked = true;

        }

        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvStock.Rows[dgvStock.SelectedRows[0].Index];
                deleteToolStripMenuItem.Visible = selectedRow.DefaultCellStyle.ForeColor == Color.Red;
            }
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete selected row?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                int selectedIndex = dgvStock.SelectedRows[0].Index;
                string stockID = dgvStock.Rows[selectedIndex].Cells["Stock ID"].Value + "";
                sql = "delete from stock where stockID='" + stockID + "'";

                bool error = false;
                dataCon.ExecuteActionQry(sql, ref error);

                if (!error)
                {
                    MessageBox.Show("Delete sucessful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtStock.Rows.RemoveAt(selectedIndex);
                }
            }
        }

        private void rndExpired_Click(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void dgvStock_Sorted(object sender, EventArgs e)
        {
            ChangeRowForeColor();
        }

        private void rndAlmostExpired_Click(object sender, EventArgs e)
        {
            
            SearchAlmostExpired expired = new SearchAlmostExpired(txtSearch,btnSearch);

            expired.ShowDialog();

            if (expired.DialogResult!= DialogResult.Yes)
            {
                rndProductName.Checked = true;
            }


        }

        private void rndProductName_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }
    }
}
