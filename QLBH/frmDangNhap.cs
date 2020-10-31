using DTO_QLBH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBH;
using System.Net.Mail;
using System.Net;
using QLBH.Properties;
using System.IO;

namespace QLBH
{
    public partial class frmDangNhap : Form
    {
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        public string vaitro { set; get; }
        public frmDangNhap()
        {
            InitializeComponent();
            this.TopLevel = true;
            this.TopMost = true;
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            frmMain_QLBH.session = 0;
            txt_emailnv.Text = Settings.Default.emailNv;
            txt_pass.Text = Settings.Default.passWord;
            cbox_remember.Checked = Settings.Default.isRemember;
        }
       
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            DTO_Nhanvien nv = new DTO_Nhanvien();
            nv.EmailNv = txt_emailnv.Text;
            nv.MatKhau = busNhanVien.encryption(txt_pass.Text);
            if (busNhanVien.NhanVienDangNhap(nv))
            {
                frmMain_QLBH.session = 1;
                frmMain_QLBH.email = txt_emailnv.Text;
                DataTable dt = busNhanVien.VaiTroNhanVien(nv.EmailNv);
                vaitro = dt.Rows[0][0].ToString();
                MessageBox.Show("Đăng nhập thành công");
                if (cbox_remember.Checked)
                {
                    Settings.Default.emailNv = txt_emailnv.Text;
                    Settings.Default.passWord = txt_pass.Text;
                    Settings.Default.isRemember = true;
                    Settings.Default.Save();
                }
                if (!cbox_remember.Checked)
                {
                    Settings.Default.emailNv = "";
                    Settings.Default.passWord = "";
                    Settings.Default.isRemember = false;
                    Settings.Default.Save();
                }
           
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công. Kiểm tra lại mail hoặc mật khẩu");
                txt_emailnv.Text = null;
                txt_pass.Text = null;
                txt_emailnv.Focus();
            }
        }

        private void btn_quenmk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_emailnv.Text))
            {
                if (busNhanVien.NhanVienQuenMk(txt_emailnv.Text))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(RandomString(4, true));
                    builder.Append(RandomNumber(1000, 9999));
                    builder.Append(RandomString(2, false));
                    string matkhaumoi = busNhanVien.encryption(builder.ToString());
                    busNhanVien.TaoMatKhau(txt_emailnv.Text, matkhaumoi);
                    SendEmail(txt_emailnv.Text, matkhaumoi);
                }
                else
                {
                    MessageBox.Show("Email không tồn tại, vui lòng nhập lại email");
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập email nhận thông tin phục hồi mật khẩu");
                txt_emailnv.Focus();
            }
        }
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for(int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }
            return builder.ToString();
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public void SendEmail(string email, string matkhau)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                NetworkCredential cred = new NetworkCredential("pv20092001@gmail.com","123abcABC");
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("pv20092001@gmail.com");
                msg.To.Add(email);
                msg.Subject = "Bạn đã sử dụng tính năng quên mật khẩu ";
                msg.Body = "Chào and/chị, mật khẩu mới để truy cập phần mềm là: " + matkhau;
                client.Credentials = cred;
                client.EnableSsl = true;
                client.Send(msg);
                MessageBox.Show("Một email phục hồi mật khẩu đã được gửi tới bạn");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
