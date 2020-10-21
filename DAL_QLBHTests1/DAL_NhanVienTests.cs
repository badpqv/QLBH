using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL_QLBH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBH;
namespace DAL_QLBH.Tests
{
    [TestClass()]
    public class DAL_NhanVienTests
    {
       

        [TestMethod()]
        public void NhanVienDangNhap001()
        {
            DTO_Nhanvien nv = new DTO_Nhanvien();
            DAL_NhanVien login = new DAL_NhanVien();
            nv.EmailNv = "";
            nv.MatKhau = "abc";
            bool result = login.NhanVienDangNhap(nv);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void NhanVienQuenMkTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TaoMatKhauTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateMatKhauTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void VaiTroNhanVienTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertNhanVienTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SearchNhanVienTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateNhanVienTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteNhanVienTest()
        {
            Assert.Fail();
        }
    }
}