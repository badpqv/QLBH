using BUS_QLBH;
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
    public partial class frmThongke : Form
    {
        BUS_Hang busHang = new BUS_Hang();
        public frmThongke()
        {
            InitializeComponent();
        }
        private void LoadGridView_NhapKho()
        {
            dgv_nhapkho.AutoResizeColumns();
            dgv_nhapkho.DataSource = busHang.ThongKeHang();
            dgv_nhapkho.Columns[0].HeaderText = "Mã nhân viên";
            dgv_nhapkho.Columns[1].HeaderText = "Tên nhân viên";
            dgv_nhapkho.Columns[2].HeaderText = "Số lượng sản phẩm nhập";
        }
        private void LoadGridView_TonKho()
        {
            dgv_tonkho.AutoResizeColumns();
            dgv_tonkho.DataSource = busHang.ThongKeTonKho();
            dgv_tonkho.Columns[0].HeaderText = "Tên sản phẩm";
            dgv_tonkho.Columns[1].HeaderText = "Số lượng tồn";
        }
        private void frmThongke_Load(object sender, EventArgs e)
        {
            LoadGridView_NhapKho();
            LoadGridView_TonKho();
        }
    }
}
