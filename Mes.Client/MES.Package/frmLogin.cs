using MES.Libraries;
using Mes.Package.Common;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mes.Package
{
    public partial class frmLogin : Form
    {
       
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
        }       

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                if (this.txtUserID.Text == "")
                {
                    MessageBox.Show("请输入用户ID。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtUserID.Focus();
                    this.DialogResult = DialogResult.None;
                    return;
                }

                if (this.txtPassword.Text == "")
                {
                    this.DialogResult =  MessageBox.Show("请输入用户密码。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtPassword.Focus();
                    this.DialogResult = DialogResult.None;
                    return;
                }

                using (ProxyBE p = new ProxyBE())
                {
                    User theUser = p.Client.GetUserByUserCode(null, txtUserID.Text);
                    if (theUser == null)
                    {
                        MessageBox.Show("用户不存在。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtUserID.Focus();
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                    else
                    {
                        if (CEncrypt.DecryptString(theUser.Password) != this.txtPassword.Text)
                        {
                            MessageBox.Show("密码不正确。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.txtUserID.Focus();
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                    }
                    OnlineUser onlineuser = new OnlineUser();
                    onlineuser.UserID = theUser.UserID;
                    onlineuser.UserCode = theUser.UserCode;
                    onlineuser.UserName = theUser.UserName;
                    onlineuser.CompanyID = theUser.CompanyID;
                    CGlobal.CurrentUser = onlineuser; 
                    result = true;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            if (result)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }        

        private void btnCancle_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("您确定要离开系统吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
        }       
    }
}
