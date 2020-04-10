using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class Oversight : Form
    {
        private readonly AccountManagement accountManagement;
        private readonly DepartmentManagement departmentManagement;
        private readonly StenerManagement stenerManagement;
        private readonly ViolationManagement violationManagement;
        private StenerManagementMode currentStenerManagementMode = StenerManagementMode.None;
        private List<QuestionSet> questionSets;
        private List<UserData> usersData;
        private List<Violation> violations;

        public Oversight()
        {
            InitializeComponent();

            stenerManagement = new StenerManagement();
            departmentManagement = new DepartmentManagement();
            accountManagement = new AccountManagement();
            violationManagement = new ViolationManagement();
        }

        public Oversight(UserData user)
        {
            InitializeComponent();

            stenerManagement = new StenerManagement();
            departmentManagement = new DepartmentManagement();
            accountManagement = new AccountManagement();
            violationManagement = new ViolationManagement();
        }
    }
}