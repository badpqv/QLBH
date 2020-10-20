using BUS_QLBH;
using DTO_QLBH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmKhachHang : Form
    {
        BUS_Khach busKhach = new BUS_Khach();
        string stremail = frmMain_QLBH.email;
        public frmKhachHang()
        {
            InitializeComponent();
        }
        private void LoadGridView_Khach()
        {
            dataGridView1.DataSource = busKhach.getKhach();
            dataGridView1.Columns[0].HeaderText = "Điện thoại";
            dataGridView1.Columns[1].HeaderText = "Tên khách";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Giới tính";
        }
        private void ResetValues()
        {
            foreach(Control c in this.Controls)
            {
                if(c is TextBox)
                {
                    ((TextBox)c).Text = null;
                }
                rad_nam.Checked = false;
                rad_nu.Checked = false;
                btn_update.Enabled = false;
                btn_xoa.Enabled = false;
            }
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadGridView_Khach();
            ResetValues();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            float intDienThoai;
            bool isInt = float.TryParse(txt_sdt.Text.Trim().ToString(),out intDienThoai);
            string gioitinh = "Nam";
            if (rad_nu.Checked)
                gioitinh = "Nữ";
            if (txt_tenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_tenkhach.Focus();
                return;
            }
            else if(!isInt || float.Parse(txt_sdt.Text)<0)
            {
                MessageBox.Show("Bạn phải nhập đúng định dạng điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_sdt.Focus();
                return;
            } 
            if(!rad_nam.Checked && !rad_nu.Checked)
            {
                MessageBox.Show("Bạn phải chọn giới tính khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_sdt.Focus();
                return;
            }
            else if(txt_diachi.Text.Trim().Length ==0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_diachi.Focus();
                return;
            }
            else
            {
             
                DTO_Khachhang khach = new DTO_Khachhang(txt_sdt.Text, txt_tenkhach.Text, txt_diachi.Text, gioitinh, stremail);
                if (busKhach.InsertKhach(khach))
                {
                    LoadGridView_Khach();
                    MessageBox.Show("Thêm thành công");
                    ResetValues();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            btn_update.Enabled = true;
            btn_xoa.Enabled = true;
            btn_luu.Enabled = false;
            txt_diachi.Text = row.Cells[2].Value.ToString();
            txt_tenkhach.Text = row.Cells[1].Value.ToString();
            txt_sdt.Text = row.Cells[0].Value.ToString();
            if(row.Cells[4].Value.ToString() == "Nam")
            {
                rad_nam.Checked = true;
            }
            else
            {
                rad_nu.Checked = true;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if(txt_sdt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập số đt của khách cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_sdt.Focus();
                return;
            }
            else
            {
                if(MessageBox.Show("Bạn có chắc muốn xóa","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busKhach.DeleteKhach(txt_sdt.Text))
                    {
                        LoadGridView_Khach();
                        MessageBox.Show("Xóa thành công");
                        ResetValues();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công");

                    }
                }
                else
                {
                    ResetValues();
                }
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            float intDienThoai;
            bool isInt = float.TryParse(txt_sdt.Text.Trim().ToString(), out intDienThoai);
            string gioitinh = "Nam";
            if (rad_nu.Checked)
                gioitinh = "Nữ";
            if (txt_tenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_tenkhach.Focus();
                return;
            }
            else if (!isInt || float.Parse(txt_sdt.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập đúng định dạng điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_sdt.Focus();
                return;
            }
            if (!rad_nam.Checked && !rad_nu.Checked)
            {
                MessageBox.Show("Bạn phải chọn giới tính khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_sdt.Focus();
                return;
            }
            else if (txt_diachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_diachi.Focus();
                return;
            }
            else
            {
                DTO_Khachhang khachhang = new DTO_Khachhang(txt_sdt.Text, txt_tenkhach.Text, txt_diachi.Text, gioitinh, stremail);
                if(MessageBox.Show("Bạn có chắc muốn sửa?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busKhach.UpdateKhach(khachhang))
                    {
                        LoadGridView_Khach();
                        MessageBox.Show("Sửa thành công");
                        ResetValues();
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
    }
}
