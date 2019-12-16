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
    public partial class OversightRemoveDepartment : Form
    {
        public string departmentToDelete;
        public OversightRemoveDepartment()
        {
            InitializeComponent();
        }

        private void OversightRemoveDepartment_Load(object sender, EventArgs e)
        {

        }

        private void departmentNameText_TextChanged(object sender, EventArgs e)
        {
            departmentToDelete = departmentNameText.Text;
        }

        private void deleteDepartmentButton_Click(object sender, EventArgs e)
        {
            DepartmentManagement removeDpmt = new DepartmentManagement();
            int tempDeleteDpmtStr = Convert.ToInt32(departmentToDelete);
            removeDpmt.removeDeparment(tempDeleteDpmtStr);

            this.Close();
        }

    }
}
