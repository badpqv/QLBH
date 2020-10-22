using BUS_QLBH;
using DTO_QLBH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmHang : Form
    {
        BUS_Hang busHang = new BUS_Hang();
        string strEmail = frmMain_QLBH.email;
        string fileaddress;
        string filename;
        string filesavepath;
        string checkUrlImage;
        public frmHang()
        {
            InitializeComponent();
        }
        private void LoadGridView_Hang()
        {
           dgv_hang.DataSource = busHang.getHang();
        }
        private void ResetValues()
        {
            foreach(Control c in this.Controls)
            {
                if(c is TextBox)
                {
                    if (((TextBox)c).Name != txt_timkiem.Name)
                        ((TextBox)c).Text = null;
                }
            }
            btn_update.Enabled = false;
            btn_xoa.Enabled = false;
            btn_luu.Enabled = true;
            pbox_hinhanh.Image = null;
        }
        private void frmHang_Load(object sender, EventArgs e)
        {
            LoadGridView_Hang();
            ResetValues();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgv_hang.Rows[e.RowIndex];
                    btn_update.Enabled = true;
                    btn_xoa.Enabled = true;
                    btn_luu.Enabled = false;
                    string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    txt_mahang.Text = row.Cells[0].Value.ToString();
                    txt_tenhang.Text = row.Cells[1].Value.ToString();
                    txt_soluong.Text = row.Cells[2].Value.ToString();
                    txt_gianhap.Text = row.Cells[3].Value.ToString();
                    txt_giaban.Text = row.Cells[4].Value.ToString();
                    txt_hinh.Text = row.Cells[5].Value.ToString();
                    checkUrlImage = txt_hinh.Text;
                    txt_ghichu.Text = row.Cells[6].Value.ToString();
                    pbox_hinhanh.Image = Image.FromFile(saveDirectory + row.Cells[5].Value.ToString());
                }
                catch
                {
                    btn_xoa.Enabled = false;
                    btn_update.Enabled = false;
                    pbox_hinhanh.Image = null;
                    return;
                }
            }
        }

        private void btn_mohinh_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Chọn ảnh minh họa cho sản phẩm";
            openFile.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            openFile.FilterIndex = 0;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fileaddress = openFile.FileName;
                pbox_hinhanh.Image = Image.FromFile(fileaddress);
                filename = Path.GetFileName(openFile.FileName);
                string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                filesavepath = saveDirectory + "\\Images\\" + filename;
                txt_hinh.Text = "\\Images\\" + filename;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            int intSoluong;
            bool isInt = int.TryParse(txt_soluong.Text.Trim().ToString(), out intSoluong);
            float floatDonGiaNhap;
            bool isFloatNhap = float.TryParse(txt_gianhap.Text.Trim().ToString(), out floatDonGiaNhap);  float floatDonGiaBan;
            bool isFloatBan = float.TryParse(txt_giaban.Text.Trim().ToString(), out floatDonGiaBan);
            if(txt_tenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_tenhang.Focus();
                return;
            }
            else if(!isInt || int.Parse(txt_soluong.Text) < 0)
            {
                MessageBox.Show("Số lượng phải là số và >0");
                txt_soluong.Focus();
                return;
            }
            else if(!isFloatNhap || float.Parse(txt_gianhap.Text) < 0)
            {
                MessageBox.Show("Giá nhập phải là số và >0");
                txt_soluong.Focus();
                return;
            }
            else if (!isFloatBan || float.Parse(txt_giaban.Text) < 0)
            {
                MessageBox.Show("Giá bán phải là số và >0");
                txt_soluong.Focus();
                return;
            }
            else if(txt_hinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải upload hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_mohinh.Focus();
            }
            else
            {
                DTO_Hang hang = new DTO_Hang(txt_tenhang.Text, int.Parse(txt_soluong.Text), float.Parse(txt_gianhap.Text), float.Parse(txt_giaban.Text), "\\Images\\" + filename, txt_ghichu.Text, strEmail);
                if (busHang.InsertHang(hang))
                {
                    MessageBox.Show("Thêm sản phẩm thành công");
                    LoadGridView_Hang();
                    File.Copy(fileaddress, filesavepath, true);
                    ResetValues();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm không thành công");
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int intSoluong;
            bool isInt = int.TryParse(txt_soluong.Text.Trim().ToString(), out intSoluong);
            float floatDonGiaNhap;
            bool isFloatNhap = float.TryParse(txt_gianhap.Text.Trim().ToString(), out floatDonGiaNhap); float floatDonGiaBan;
            bool isFloatBan = float.TryParse(txt_giaban.Text.Trim().ToString(), out floatDonGiaBan);
            if (txt_tenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_tenhang.Focus();
                return;
            }
            else if (!isInt || int.Parse(txt_soluong.Text) < 0)
            {
                MessageBox.Show("Số lượng phải là số và >0");
                txt_soluong.Focus();
                return;
            }
            else if (!isFloatNhap || float.Parse(txt_gianhap.Text) < 0)
            {
                MessageBox.Show("Giá nhập phải là số và >0");
                txt_soluong.Focus();
                return;
            }
            else if (!isFloatBan || float.Parse(txt_giaban.Text) < 0)
            {
                MessageBox.Show("Giá bán phải là số và >0");
                txt_soluong.Focus();
                return;
            }
            else if (txt_hinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải upload hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_mohinh.Focus();
            }
            else
            {
                DTO_Hang hang = new DTO_Hang(int.Parse(txt_mahang.Text), txt_tenhang.Text, int.Parse(txt_soluong.Text), float.Parse(txt_gianhap.Text), float.Parse(txt_giaban.Text), txt_hinh.Text, txt_ghichu.Text);
                if(MessageBox.Show("Bạn có chắc muốn sửa?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busHang.UpdateHang(hang))
                    {
                        if (txt_hinh.Text != checkUrlImage)
                            File.Copy(fileaddress, filesavepath, true);
                        MessageBox.Show("Sửa thành công");
                        ResetValues();
                        LoadGridView_Hang();
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

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DTO_Hang hang = new DTO_Hang();
            hang.MaHang = int.Parse(txt_mahang.Text);
            if(MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busHang.DeleteHang(hang.MaHang))
                {
                    MessageBox.Show("Xoá thành công");
                    ResetValues();
                    LoadGridView_Hang();
                }
                else
                {
                    MessageBox.Show("Xoá không thành công");

                }
            }
            else
            {
                ResetValues();
            }
        }

        private void btn_danhsach_Click(object sender, EventArgs e)
        {
            LoadGridView_Hang();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if(txt_timkiem.Text =="Nhập tên sản phẩm")
            {
                txt_timkiem.Text = "";
                txt_timkiem.ForeColor = Color.Black;
            }
        }

        private void txt_timkiem_Leave(object sender, EventArgs e)
        {
            if (txt_timkiem.Text == "")
            {
                txt_timkiem.Text = "Nhập tên sản phẩm";
                txt_timkiem.ForeColor = Color.Silver;
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            if (txt_timkiem.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập tên sản phẩm cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_timkiem.Focus();
                return;
            }
            else
            {
                dgv_hang.DataSource = busHang.SearchHang(txt_timkiem.Text);
            }
        }
    }
}
