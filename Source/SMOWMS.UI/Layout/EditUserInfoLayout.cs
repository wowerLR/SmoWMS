using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOWMS.UI.UserInfo;
using SMOWMS.DTOs.Enum;
using SMOWMS.UI.Menu;
using SMOWMS.UI.UserControl;

namespace SMOWMS.UI.Layout
{
    ////ToolboxItem用于控制是否添加自定义控件到工具箱，true添加，false不添加
    //[System.ComponentModel.ToolboxItem(true)]
    partial class EditUserInfoLayout : Smobiler.Core.Controls.MobileUserControl
    {
        /// <summary>
        /// 弹出框初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditUserInfoLayout_Load(object sender, EventArgs e)
        {
            try
            {
                frmToolBarMenu fm = (frmToolBarMenu)this.Form;
                frmMessageLayout fml = (frmMessageLayout)fm.tabPageView1.Controls[4];
                // String editLbltxt=((frmMessage)Form).eInfo.ToString();
                String editLbltxt = fml.eInfo.ToString();
                // if (((frmMessage)Form).eInfo == EuserInfo.修改昵称)
                if (fml.eInfo == EuserInfo.修改昵称)
                {
                    // if (((frmMessage)Form).lblName.Text.Trim().Length > 0)
                    //   txtEditInfo.Text = ((frmMessage)Form).lblName.Text;
                    if (fml.lblName.Text.Trim().Length > 0)
                        txtEditInfo.Text = fml.lblName.Text;
                    else
                        txtEditInfo.Text = "";
                }
            }
            catch(Exception ex)
            {
                Form.Toast(ex.Message);
            }
        }
        /// <summary>
        /// 取消操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Press(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 提交操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Press(object sender, EventArgs e)
        {
            try
            {
                frmToolBarMenu fm = (frmToolBarMenu)this.Form;
                frmMessageLayout fml = (frmMessageLayout)fm.tabPageView1.Controls[4];
                // if (((frmMessage)Form).eInfo == EuserInfo.修改昵称)
                if (fml.eInfo == EuserInfo.修改昵称)
                {
                    if (String.IsNullOrEmpty(txtEditInfo.Text.Trim()) == false)
                    {
                        //((frmMessage)Form).UpdateUserInfo(EuserInfo.修改昵称, txtEditInfo.Text);
                        //((frmMessage)Form).lblName.Text = txtEditInfo.Text;
                       fml.UpdateUserInfo(EuserInfo.修改昵称, txtEditInfo.Text);
                      fml.lblName.Text = txtEditInfo.Text;
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("当前尚未输入昵称!");
                    }
                }
            }
            catch(Exception ex)
            {
                Form.Toast(ex.Message);
            }
        }
    }
}