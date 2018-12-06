using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartSystem
{
    public partial class SearchMonth : Form
    {


        public SearchMonth(Object txtSearch,string behaviour)
        {
            InitializeComponent();
            this.txtSearch = txtSearch;
            this.behaviour = behaviour;

            Text = "Search " + behaviour;
        }

        object txtSearch;
        string behaviour;
       


        private void SearchMonth_Load(object sender, EventArgs e)
        {
            
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime date = dtpMonth.Value;
            DateTime minDate=DateTime.Today, maxDate=DateTime.Today;

            switch (behaviour)
            {
                case "month":
                    minDate = new DateTime(date.Year, date.Month, 1, 0, 0, 0);
                    maxDate = minDate.AddMonths(1).AddDays(-1);
                    break;
                case "year":
                    minDate = new DateTime(date.Year, 1, 1, 0, 0, 0);
                    maxDate = new DateTime(date.Year, 12, 31, 0, 0, 0);
                    break;
            }
            

            string st = minDate.Year + "/" + minDate.Month + "/" + minDate.Day + " - " + maxDate.Year + "/" + maxDate.Month + "/" + maxDate.Day;


            ((TextBox)txtSearch).Text = st;

            DialogResult = DialogResult.Yes;
                
        }
    }
}
