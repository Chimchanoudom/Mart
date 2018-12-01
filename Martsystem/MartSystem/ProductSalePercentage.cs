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
    public partial class ProductSalePercentage : Form
    {
        public ProductSalePercentage()
        {
            InitializeComponent();
        }

        SqlDataAdapter dataAdaptor;
        DataTable dt=new DataTable();
       

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("The date on the left side must be lesser than the date on the right side");
                return;
            }
            txtSearch.Text = "";
            getData();

        }

        private void ProductSalePercentage_Load(object sender, EventArgs e)
        {

            DateTime now = DateTime.Now;
            dtpTo.Value = now;
            dtpFrom.Value = now.AddDays(-30);
            getData();
            
        }

        void getData()
        {
            dgv.DataSource = null;
            dt.Rows.Clear();
            string stFrom, stTo;
            stFrom = dtpFrom.Value.Year + "/" + dtpFrom.Value.Month + "/" + dtpFrom.Value.Day;
            stTo = dtpTo.Value.Year + "/" + dtpTo.Value.Month + "/" + dtpTo.Value.Day;


            string sql = "exec getSalePercentage '" + stFrom + "','" + stTo + "'";
            dataAdaptor = new SqlDataAdapter(sql, dataCon.Con);

            dataAdaptor.Fill(dt);
            dgv.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = "Description like '%" + txtSearch.Text + "%'";
            dt.DefaultView.RowFilter = filter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Empty;
        }
    }
}
