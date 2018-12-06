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
    public partial class SearchDate : Form
    {
        public SearchDate()
        {
            InitializeComponent();
        }

        public SearchDate(DateTime[] searchedDate,object txtSearchDate,Button btnSearch)
        {
            InitializeComponent();
            this.txtSearchDate = txtSearchDate;
            this.btnSearch = btnSearch;

            if (searchedDate[0]>DateTime.MinValue)
            {
                dtpFrom.Value = searchedDate[0];
                dtpTo.Value = searchedDate[1];
            }
            this.searchedDate = searchedDate;
        }

        public SearchDate(Object txtSearchDate)
        {
            InitializeComponent();
            this.txtSearchDate = txtSearchDate;
        }

        object txtSearchDate;
        Button btnSearch;

        DateTime[] searchedDate;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (searchedDate != null)
            {
                if (RestrictionClass.validateBetweenTwoDate(dtpFrom.Value, dtpTo.Value))
                {
                    MessageBox.Show("The Date on the left side must be lessor than or equal to the date on the right side", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            else
            {
                if (dtpFrom.Value.Year>=dtpTo.Value.Year)
                {
                    MessageBox.Show("The year on the left side must be lessor than the year on the right side", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            


            TextBox txt = (TextBox)txtSearchDate;
            

            if (searchedDate == null)
            {
                DialogResult = DialogResult.Yes;
                DateTime date = dtpFrom.Value;

                DateTime min = new DateTime(date.Year, 1, 1, 0, 0, 0);
                date = dtpTo.Value;
                DateTime max = new DateTime(date.Year, 12, 31, 0, 0, 0);

               

                string st = min.Year + "/" + min.Month + "/" + min.Day + " - " + max.Year + "/" + max.Month + "/" + max.Day;

                txt.Text = st;
                return;
            }
            txt.Text = dtpFrom.Text + " - " + dtpTo.Text;

            searchedDate[0] = dtpFrom.Value;
            searchedDate[1] = dtpTo.Value;
            DialogResult = DialogResult.Yes;
            txt.Enabled = false;
            btnSearch.PerformClick();
            
        }

        private void SearchDate_Load(object sender, EventArgs e)
        {
            
        }
    }
}
