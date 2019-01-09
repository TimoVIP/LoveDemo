using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loveDemo
{
    public partial class TransForm : Form
    {
        Boolean m_IsFullScreen = false;//标记是否全屏
        public TransForm()
        {
            InitializeComponent();
        }

        private void TransForm_Load(object sender, EventArgs e)
        {
            m_IsFullScreen = !m_IsFullScreen;//点一次全屏，再点还原。  
            this.SuspendLayout();
            if (m_IsFullScreen)//全屏 ,按特定的顺序执行
            {
                share.SetFormFullScreen(m_IsFullScreen);
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.Activate();//
            }
            else//还原，按特定的顺序执行——窗体状态，窗体边框，设置任务栏和工作区域
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                share.SetFormFullScreen(m_IsFullScreen);
                this.Activate();
            }
            this.ResumeLayout(false);

            //透明
            this.BackColor = Color.Black;
            //this.TransparencyKey = this.BackColor; //让窗体透明   

            //添加花瓣

        }

        private void TransForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)//esc键盘退出全屏
            {
                if (m_IsFullScreen)
                {
                    e.Handled = true;
                    this.WindowState = FormWindowState.Normal;//还原  
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    share.SetFormFullScreen(false);
                }
            }
            //改为退出
            if (e.KeyCode == Keys.Escape)
            {
                share.SetFormFullScreen(false);
                Application.Exit();
            }
        }
    }
}
