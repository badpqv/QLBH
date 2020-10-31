using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmMain_QLBH : Form
    {
        frmDangNhap dn;
        public static int session = 0;
        public static int profile = 0;
        public static string email = "";
        Thread th;
        public frmMain_QLBH()
        {
            InitializeComponent();
            this.BackgroundImage = this.BackgroundImage;
        }
       
        private void frmMain_QLBH_Load(object sender, EventArgs e)
        {
            ResetValue();
            if (profile == 1)
            {
                hồSơNhânViênToolStripMenuItem.Visible = false;
                profile = 0;
            }
      
        }
        private void ResetValue()
        {
            if(session == 1)
            {
                nhânViênToolStripMenuItem.Visible = true;
                nhânViênToolStripMenuItem.Enabled = true;
                danhMụcToolStripMenuItem.Visible = true;
                đăngXuấtToolStripMenuItem.Enabled = true;
                thốngKêToolStripMenuItem.Visible = true;
                thốngKêSảnPhẩmToolStripMenuItem.Visible = true;
                hồSơNhânViênToolStripMenuItem.Visible = true;
                đăngNhậpToolStripMenuItem.Enabled = false;
                thongtinNVToolStripMenuItem.Visible = true;
                if (dn.vaitro ==  "Nhân viên")
                {
                    VaiTroNV();
                }
                thongtinNVToolStripMenuItem.Text = "Xin chào," + email;
            }
            else
            {
                nhânViênToolStripMenuItem.Visible = false;
                nhânViênToolStripMenuItem.Enabled = true;
                danhMụcToolStripMenuItem.Visible = false;
                đăngXuấtToolStripMenuItem.Enabled = false;
                thốngKêToolStripMenuItem.Visible = false;
                thốngKêSảnPhẩmToolStripMenuItem.Visible = false;
                hồSơNhânViênToolStripMenuItem.Visible = false;
                đăngNhậpToolStripMenuItem.Enabled = true;
                thongtinNVToolStripMenuItem.Visible = false;
            }
        }
        private void VaiTroNV()
        {
            nhânViênToolStripMenuItem.Visible = false;
            thốngKêToolStripMenuItem.Visible = false;
        }
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach(Form frm in this.MdiChildren)
            {
                if(frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
             dn = new frmDangNhap();
            if (!CheckExistForm(dn.Name))
            {
                dn.MdiParent = this;
                dn.Show();
                dn.FormClosed += new FormClosedEventHandler(frmDangNhap_FormClosed);
            }
            else
            {
                ActiveChildForm(dn.Name);
            }
        }
        private void frmDangNhap_FormClosed(object sender,EventArgs e)
        {
            this.Refresh();
            frmMain_QLBH_Load(sender, e);
        }
       
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Đăng xuất?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                session = 0;
                ResetValue();
                foreach (Form f in this.MdiChildren)
                {
                    f.Close();
                }
            }
            else
            {
                return;
            }
        }

        private void hồSơNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoSoNhanvien profileNv = new frmHoSoNhanvien(email);
            if (!CheckExistForm(profileNv.Name))
            {
                profileNv.MdiParent = this;
                profileNv.Show();
                profileNv.FormClosed += new FormClosedEventHandler(frmThongTinNv_FormClosed);
            }
            else
                ActiveChildForm(profileNv.Name);
        }
        private void frmThongTinNv_FormClosed(object sender,EventArgs e)
        {
            this.Refresh();
            frmMain_QLBH_Load(sender, e);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frmNhanVien = new frmNhanVien();
            if (!CheckExistForm(frmNhanVien.Name))
            {
                frmNhanVien.MdiParent = this;
                frmNhanVien.Show();
            }
            else
            {
                ActiveChildForm(frmNhanVien.Name);
            }
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang khachHang = new frmKhachHang();
            if (!CheckExistForm(khachHang.Name))
            {
                khachHang.MdiParent = this;
                khachHang.Show();
            }
            else
            {
                ActiveChildForm(khachHang.Name);
            }
        }

        private void hướngDẫnSữDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("www.facebook.com/photo?fbid=825473581324374&set=a.104845840053822");
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHang frmHang = new frmHang();
            if (!CheckExistForm(frmHang.Name))
            {
                frmHang.MdiParent = this;
                frmHang.Show();
            }
            else
            {
                ActiveChildForm(frmHang.Name);
            }
        }

        private void frmMain_QLBH_MdiChildActivate(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                label1.SendToBack();
            else
                label1.BringToFront();
        }

        private void thốngKêSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongke frmThongke = new frmThongke();
            if (!CheckExistForm(frmThongke.Name))
            {
                frmThongke.MdiParent = this;
                frmThongke.Show();
            }
            else
            {
                ActiveChildForm(frmThongke.Name);
            }
        }

        private void giớiThiệuPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\SOF205_Project document.docx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmMain_QLBH_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result =MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.ExitThread();
            else
                e.Cancel = true;
        }
    }
}
