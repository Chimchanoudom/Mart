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
    public partial class SearchAlmostExpired : Form
    {
        public SearchAlmostExpired( object searchValue,Button btnSearch)
        {
            InitializeComponent();
            this.searchValue = searchValue;
            this.btnSearch = btnSearch;
        }

        object searchValue;
        Button btnSearch;


        private void SearchAlmostExpired_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            foreach(Control c in Controls)
            {
                if (c.Text == "")
                {
                    MessageBox.Show("Please fill in required information", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            
           

            DateTime now = DateTime.Now;
            now = dataCon.getOnlyDatePart(now);

            DateTime from = now;

            int value = int.Parse(txtValue.Text);

            switch (cbCon.Text)
            {
                case "Years":
                    from = from.AddYears(-value);
                    break;
                case "Months":
                    from = from.AddMonths(-value);
                    break;
                case "Weeks":
                    from = from.AddDays(-value*7);
                    break;
                case "Days":
                    from = from.AddDays(-value);
                    break;
            }
            
            ((TextBox)searchValue).Text = from.Day + "/" + from.Month + "/" + from.Year + " - " + now.Day + "/" + now.Month + "/" + now.Year;

            btnSearch.PerformClick();
            DialogResult = DialogResult.Yes;
        }
    }
}
