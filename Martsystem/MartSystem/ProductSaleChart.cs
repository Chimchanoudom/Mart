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
using System.Windows.Forms.DataVisualization.Charting;


namespace MartSystem
{
    public partial class ProductSaleChart : Form
    {
        public ProductSaleChart()
        {
            InitializeComponent();
        }

        SqlDataReader dataReader;
        string sql;
        

       
        DataTable dtResult = new DataTable();


        private void ProductSaleChart_Load(object sender, EventArgs e)
        {
           


            sql = "select proID, proName from product;";
            dataCon.Con.Open();
            dataReader = dataCon.ExecuteQry(sql);
            while (dataReader.Read())
            {
                ComboboxItem item = new ComboboxItem(dataReader.GetString(1), dataReader.GetString(0));
                cbProduct.Items.Add(item);
            }

            dataCon.Con.Close();


            dataCon.Con.Open();
            sql = "select year(ISNULL(min(dateCreated),GETDATE())) min, year(isnull(max(dateCreated),GETDATE())) max from invoice;";
            dataReader = dataCon.ExecuteQry(sql);
            dataReader.Read();


            int minYear = dataReader.GetInt32(0);
            int maxYear = dataReader.GetInt32(1);
           
            

            dataCon.Con.Close();
            

            cbProduct.SelectedIndex  = 0;


            cbShowing.SelectedIndex = 0;
            cbShowing.SelectedIndexChanged += CbShowing_SelectedIndexChanged;
        }

        

        string viewAs = "Year";

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


        private void rndDay_Click(object sender, EventArgs e)
        {
            
            SearchMonth searchMonth = new SearchMonth(txtSearch,"month");
            searchMonth.ShowDialog();

            if (searchMonth.DialogResult == DialogResult.Yes)
            {
                viewAs = "day";
            }
            else
            {
                txtSearch.Text = "";
            }
        }

        private void rndYear_Click(object sender, EventArgs e)
        {
            SearchMonth searchMonth = new SearchMonth(txtSearch,"year");
            searchMonth.ShowDialog();

            if (searchMonth.DialogResult == DialogResult.Yes)
            {
                viewAs = "month";
            }
            else
            {
                txtSearch.Text = "";
            }

        }

        int maxQty, maxAmount;

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (txtSearch.Text == "")
            {
                return;
            }
            dtResult.Rows.Clear();

            string proID = ((ComboboxItem)cbProduct.SelectedItem).Value + "";

            string[] st = txtSearch.Text.Split('-');

            string formatedMin = st[0];
            string formatedMax = st[1];


            sql = "exec getProductSale '" + viewAs + "','" + proID + "','" + formatedMin + "','" + formatedMax + "';";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, dataCon.Con);
            dataAdapter.Fill(dtResult);


            if (dtResult.Rows.Count == 0) return;

            

            dataCon.Con.Open();
            sql = "SELECT sum(qty) Qty,sum(subTotal) SubTotal from invoiceDetail id join invoice i on i.invId=id.invID  where proID='"+proID+"' and cast(DateCreated as date)>='"+formatedMin+"' and cast(DateCreated as date)<='"+formatedMax+"';";
            dataReader = dataCon.ExecuteQry(sql);
            dataReader.Read();
            maxQty =Convert.ToInt32(dataReader.GetValue(0));
            maxAmount = Convert.ToInt32(dataReader.GetValue(1));
            dataCon.Con.Close();


            CbShowing_SelectedIndexChanged(null, null);
        }

        private void rndYears_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void rndMonth_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rndYear_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CbShowing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "") return;

            string[] st = txtSearch.Text.Split('-');

            int max = cbShowing.Text == "Quantity" ? maxQty : maxAmount;
           

            int xMin = 1, xMax = 0, yMin = 0, yMax = max, xInterval = 1;

            DateTime date = DateTime.Parse(st[1]);
            switch (viewAs)
            {
                case "day":
                    xMax = date.Day;
                    break;
                case "month":
                    xMax = 12;

                    break;
                case "year":

                    xMax = date.Year - (DateTime.Parse(st[1])).Year;
                    break;
            }

            chart.ChartAreas[0].AxisX.Minimum = xMin;
            chart.ChartAreas[0].AxisY.Minimum = yMin;

            //chart.ChartAreas[0].AxisX.Maximum = xMax;
            chart.ChartAreas[0].AxisY.Maximum = yMax;

            chart.ChartAreas[0].AxisX.Interval = xInterval;
            chart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            //chart.ChartAreas[0].AxisY.Interval = 1;

            chart.Series.Clear();
            chart.Series.Add(cbProduct.Text);
            chart.Series[cbProduct.Text].ChartType = SeriesChartType.Spline;
            chart.Series[cbProduct.Text].Color = Color.Red;
            chart.Series[cbProduct.Text].IsVisibleInLegend = false;


            int min;
            if (viewAs == "year")
            {
                date = DateTime.Parse(st[0]);
                min = date.Year;
            }
            else
            {
                min = 1;

            }

            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                chart.Series[0].Points.AddXY(i + 1, dtResult.Rows[i][cbShowing.Text]);
                chart.Series[0].Points[i].AxisLabel = min + "";
                min++;
            }
        }

        private void rndYears_Click(object sender, EventArgs e)
        {
            SearchDate searchDate = new SearchDate(txtSearch);
            searchDate.ShowDialog();

            if (searchDate.DialogResult == DialogResult.Yes)
            {
                viewAs = "year";
                
               
            }
            else
            {
                txtSearch.Text = "";
            }
            
        }
    }
}
