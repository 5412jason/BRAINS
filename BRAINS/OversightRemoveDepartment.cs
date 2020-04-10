using System;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class OversightRemoveDepartment : Form
    {
        public string DepartmentToDelete;

        public OversightRemoveDepartment()
        {
            InitializeComponent();
        }

        private void DepartmentNameText_TextChanged(object sender, EventArgs e)
        {
            DepartmentToDelete = departmentNameText.Text;
        }

        private void DeleteDepartmentButton_Click(object sender, EventArgs e)
        {
            var removeDpmt = new DepartmentManagement();
            var tempDeleteDpmtStr = Convert.ToInt32(DepartmentToDelete);
            removeDpmt.removeDeparment(tempDeleteDpmtStr);

            Close();
        }
    }
}