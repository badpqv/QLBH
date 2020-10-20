using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                nhânViênToolStripMenuItem.Enabled = true;
                danhMụcToolStripMenuItem.Visible = true;
                đăngXuấtToolStripMenuItem.Enabled = true;
                thốngKêToolStripMenuItem.Visible = true;
                thốngKêSảnPhẩmToolStripMenuItem.Visible = true;
                hồSơNhânViênToolStripMenuItem.Visible = true;
                đăngNhậpToolStripMenuItem.Enabled = false;
                if (dn.vaitro == 0)
                {
                    VaiTroNV();
                }
            }
            else
            {
                nhânViênToolStripMenuItem.Enabled = false;
                danhMụcToolStripMenuItem.Visible = false;
                đăngXuấtToolStripMenuItem.Enabled = false;
                thốngKêToolStripMenuItem.Visible = false;
                thốngKêSảnPhẩmToolStripMenuItem.Visible = false;
                hồSơNhânViênToolStripMenuItem.Visible = false;
                đăngNhậpToolStripMenuItem.Enabled = true;
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
            session = 0;
            ResetValue();
        }

        private void hồSơNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinNV profileNv = new frmThongTinNV(email);
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

        }
    }
}
