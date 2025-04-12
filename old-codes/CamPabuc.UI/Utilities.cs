using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamPabuc.UI
{
    public static class Utilities
    {
        public static MdiContainerForm mdiContainer;
        public static void InitializeForm(Type formType)
        {
            var childForm = mdiContainer.MdiChildren.FirstOrDefault(f => f.GetType() == formType);

            if (childForm != null)
            {
                childForm.BringToFront();
            }
            else
            {
                childForm = (Form)Activator.CreateInstance(formType);
                if (childForm != null)
                {
                    childForm.MdiParent = mdiContainer;
                    mdiContainer.MdiChildren.Append(childForm);
                    childForm.Show();
                }
            }

            if (childForm != null && childForm.WindowState != FormWindowState.Normal)
            {
                childForm.WindowState = FormWindowState.Normal;
                childForm.BringToFront();
            }
        }

    }
}
