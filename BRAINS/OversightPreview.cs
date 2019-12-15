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
    public partial class OversightPreview : Form
    {
        private Preview preview;
        private int qSetId;
        

        public OversightPreview()
        {
            InitializeComponent();
            preview = new Preview();

        }
        public OversightPreview(int qSetId)
        {
            InitializeComponent();
            preview = new Preview();
            this.qSetId = qSetId;

        }

        public void OversightPreview_Load(object sender, EventArgs e)
        {
            string qSetResult=preview.previewStener(qSetId);
            previewTextBox.Text = qSetResult;

        }
    }
}
