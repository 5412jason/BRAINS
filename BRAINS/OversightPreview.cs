using System;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class OversightPreview : Form
    {
        private readonly Preview preview;
        private readonly int qSetId;

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
            if (qSetId > 0)
            {
                var qSetResult = preview.PreviewStener(qSetId);
                previewTextBox.Text = qSetResult;
            }
        }
    }
}