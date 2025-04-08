using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamPabuc.UI
{
    public partial class ManufacturersForm : Form
    {
        public ManufacturersForm()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilities.InitializeForm(typeof(ManufacturerDetailForm));
        }
    }
}
