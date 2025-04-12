using CamPabuc.DataAccess;

namespace CamPabuc.UI
{
    public partial class MdiContainerForm : Form
    {
        public MdiContainerForm()
        {
            Settings.SyncSettings();

            InitializeComponent();

            Utilities.mdiContainer = this;
        }

        private void manufacturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilities.InitializeForm(typeof(ManufacturersForm));
        }

       
        private void shoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilities.InitializeForm(typeof(ShoesForm));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MdiContainerForm_Load(object sender, EventArgs e)
        {
            Utilities.InitializeForm(typeof(ShoesForm));
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilities.InitializeForm(typeof(SettingsForm));
        }
    }
}