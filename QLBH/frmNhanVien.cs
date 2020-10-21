using BUS_QLBH;
using DTO_QLBH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmNhanVien : Form
    {
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        public frmNhanVien()
        {
            InitializeComponent();
            this.BringToFront();
        }
        private void LoadGridView_NhanVien()
        {
            dg_NhanVien.DataSource = busNhanVien.getNhanVien();
            dg_NhanVien.Columns[2].HeaderText = "Tên nhân viên";
            dg_NhanVien.Columns[3].HeaderText = "Email";
            dg_NhanVien.Columns[4].HeaderText = "Địa chỉ";
            dg_NhanVien.Columns[5].HeaderText = "Vai trò";
            dg_NhanVien.Columns[6].HeaderText = "Tình trạng";
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadGridView_NhanVien();
            ResetValues();
        }
        public bool isValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            ResetValues();
           
        }
        private void ResetValues()
        {
            foreach(Control c in this.Controls)
            {
                if(c is TextBox)
                {
                    ((TextBox)c).Text = null;
                }
             
            }
            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            rad_admin.Checked = false;
            rad_nv.Checked = false;
            rad_hd.Checked = false;
            rad_ngunghd.Checked = false;
            txt_emailnv.Focus();
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            int role = 0;
            if (rad_admin.Checked)
                role = 1;
            int tinhtrang = 0;
            if (rad_hd.Checked)
                tinhtrang = 1;
            if (txt_emailnv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_emailnv.Focus();
                return;
            }
            else if (!isValid(txt_emailnv.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập đúng định dạng mail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_emailnv.Focus();
                return;
            }
            if(txt_tennv.Text.Trim().Length ==0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_tennv.Focus();
                return;
            }
            else if (txt_diachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_diachi.Focus();
                return;
            }
            if(!rad_admin.Checked && !rad_nv.Checked)
            {
                MessageBox.Show("Bạn phải chọn vai trò nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_tennv.Focus();
                return;
            }
           else if (!rad_hd.Checked && !rad_ngunghd.Checked)
            {
                MessageBox.Show("Bạn phải chọn trạng thái nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_tennv.Focus();
                return;
            }
            else
            {
                DTO_Nhanvien nv = new DTO_Nhanvien(txt_emailnv.Text,txt_tennv.Text,txt_diachi.Text,role,tinhtrang);
                if (busNhanVien.InsertNhanVien(nv))
                {
                    MessageBox.Show("Thêm thành công");
                    ResetValues();
                    LoadGridView_NhanVien();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            dg_NhanVien.DataSource = busNhanVien.SearchNhanVien(txt_timkiem.Text);
        }

        private void dg_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dg_NhanVien.Rows[e.RowIndex];
                btn_luu.Enabled = false;
                btn_sua.Enabled = true;
                btn_xoa.Enabled = true;
                txt_emailnv.Text = row.Cells[3].Value.ToString();
                txt_tennv.Text = row.Cells[2].Value.ToString();
                txt_diachi.Text = row.Cells[4].Value.ToString();
                if (row.Cells[5].Value.ToString() == "1")
                {
                    rad_admin.Checked = true;
                }
                else
                {
                    rad_nv.Checked = true;
                }
                if (row.Cells[6].Value.ToString() == "1")
                {
                    rad_hd.Checked = true;
                }
                else
                {
                    rad_ngunghd.Checked = true;
                }
            }
        
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (txt_tennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên");
                txt_tennv.Focus();
                return;
            }
            else if (txt_diachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ nhân viên");
                txt_diachi.Focus();
                return;
            }
            else
            {
                int role =0;
                if (rad_admin.Checked)
                    role = 1;
                int tinhtrang = 0;
                if (rad_hd.Checked)
                    tinhtrang = 1;
                DTO_Nhanvien nv = new DTO_Nhanvien(txt_emailnv.Text, txt_tennv.Text, txt_diachi.Text, role, tinhtrang);
                if(MessageBox.Show("Bạn có chắc muốn sửa","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (busNhanVien.UpdateNhanVien(nv))
                    {
                        MessageBox.Show("Sửa thành công");
                        ResetValues();
                        LoadGridView_NhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công");

                    }
                }
                else
                {
                    ResetValues();
                }
                
            }
        }

        private void txt_timkiem_Enter(object sender, EventArgs e)
        {
            if(txt_timkiem.Text == "Tìm kiếm nhân viên")
            {
                txt_timkiem.Text = "";
                txt_timkiem.ForeColor = Color.Black;
            }
        }

        private void txt_timkiem_Leave(object sender, EventArgs e)
        {
            if (txt_timkiem.Text == "")
            {
                txt_timkiem.Text = "Tìm kiếm nhân viên";
                txt_timkiem.ForeColor = Color.Silver;
            }
        }

        private void btn_danhsach_Click(object sender, EventArgs e)
        {
            LoadGridView_NhanVien();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if(txt_emailnv.Text.Trim().Length ==0)
            {
                MessageBox.Show("Nhập email nhân viên muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_emailnv.Focus();
                return;
            }
            else
            {
                    if(MessageBox.Show("Bạn có chắc muốn xóa","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                    if (busNhanVien.DeleteNhanVien(txt_emailnv.Text))
                    {
                        MessageBox.Show("Xáo thành công");
                        ResetValues();
                        LoadGridView_NhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Xáo không thành công");

                    }

                    }
                else
                {
                    ResetValues();
                }
            }
        }
    }
}
