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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void txtOld_KeyPress(object sender, KeyPressEventArgs e)
        {
            string st = @"'""";

            RestrictionClass.restrictFromKeyboard.restrictOnKeyPress(st, e);
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            string old;
            string New = txtNew.Text;
            string confirm = txtConfirm.Text;

            string sql = "select pwd from UserAcc where EmpID='" + UserLoginDetail.empID + "'";

            SqlDataReader dataReader = dataCon.ExecuteQry(sql);

            dataReader.Read();
            old = dataReader.GetString(0);

            if (old != txtOld.Text)
            {
                MessageBox.Show("Wrong old password", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (old == New)
            {
                MessageBox.Show("New password can't be the same as old password", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if  (New != confirm)
            {
                MessageBox.Show("New and confirm password doesn't match", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                bool error=false;
                sql = "update UserAcc set pwd='" + confirm + "' where empid='" + UserLoginDetail.empID + "'";

                dataCon.ExecuteActionQry(sql, ref error);

                if (!error)
                {
                    MessageBox.Show("Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
