using BUS_QLBH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmThongTinNV : Form
    {
        Thread th;
        string strEmail;
        BUS_NhanVien busNhanvien = new BUS_NhanVien();
        public frmThongTinNV(string email)
        {
            InitializeComponent();
            strEmail = email;
            txt_emailnv.Text = strEmail;
            txt_emailnv.Enabled = false;
            this.BringToFront();
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_doimatkhau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_passcu.Text))
            {
                MessageBox.Show("Bạn phải nhập mật khẩu cũ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txt_passcu.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txt_passmoi.Text))
            {
                MessageBox.Show("Bạn phải nhập mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_passcu.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txt_passmoi2.Text))
            {
                MessageBox.Show("Bạn phải nhập lại mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_passmoi2.Focus();
                return;
            }
            else if(txt_passmoi2.Text.Trim() != txt_passmoi.Text.Trim())
            {
                MessageBox.Show("Bạn phải nhập mật khẩu và nhập lại mật khẩu giống nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_passmoi.Focus();
                return;
            }
            else
            {
                if(MessageBox.Show("Bạn có chắc muốn cập nhật mật khẩu","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string matkhaumoi = busNhanvien.encryption(txt_passmoi.Text);
                    string matkhaucu = busNhanvien.encryption(txt_passcu.Text);
                    if (busNhanvien.UpdateMatKhau(txt_emailnv.Text, matkhaucu, matkhaumoi))
                    {
                        frmMain_QLBH.profile = 1;
                        frmMain_QLBH.session = 0;
                        MessageBox.Show("Cập nhật mật khẩu mới thành công, bạn cần đăng nhập lại");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng, cập nhật mật khẩu không thành công");
                        txt_passcu.Text = null;
                        txt_passmoi.Text = null;
                        txt_passmoi2.Text = null;
                    }
                }
                else
                {
                    txt_passcu.Text = null;
                    txt_passmoi.Text = null;
                    txt_passmoi2.Text = null;
                }
            }
        }
    }
}
