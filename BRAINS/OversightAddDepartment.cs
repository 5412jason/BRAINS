using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class OversightAddDepartment : Form
    {
        public string dpmtName;
        public int dpmtPermissions;
        public OversightAddDepartment()
        {
            InitializeComponent();
        }

        private void departmentNameText_TextChanged(object sender, EventArgs e)
        {
            dpmtName = departmentNameText.Text;
        }

        private void departmentPermissionsText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dpmtPermissions = Int32.Parse(departmentPermissionsText.Text);
            }
            catch
            {
                dpmtPermissions = 0;
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DepartmentManagement addDpmt = new DepartmentManagement();

            addDpmt.addDepartment(dpmtName, dpmtPermissions);
            
            this.Close();
        }
    }
}
