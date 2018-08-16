using System.ComponentModel;
using System.Configuration.Install;

namespace Mes.BE
{
    [RunInstaller(true)]
    public partial class BE_Installer : Installer
    {
        public BE_Installer()
        {
            InitializeComponent();
        }
    }
}
