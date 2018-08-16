namespace Mes.BE
{
    partial class BE_Installer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BE_ServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            this.BE_ServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            // 
            // BE_ServiceInstaller
            // 
            this.BE_ServiceInstaller.Description = "数据处理服务引擎，停止此服务系统将不能正常工作。";
            this.BE_ServiceInstaller.DisplayName = "Mes.BE.v1.0";
            this.BE_ServiceInstaller.ServiceName = "Mes.BE.v1.0";
            this.BE_ServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // BE_ServiceProcessInstaller
            // 
            this.BE_ServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.BE_ServiceProcessInstaller.Password = null;
            this.BE_ServiceProcessInstaller.Username = null;
            // 
            // BE_Installer
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.BE_ServiceInstaller,
            this.BE_ServiceProcessInstaller});

        }

        private System.ServiceProcess.ServiceInstaller BE_ServiceInstaller;
        private System.ServiceProcess.ServiceProcessInstaller BE_ServiceProcessInstaller;

        #endregion
    }
}