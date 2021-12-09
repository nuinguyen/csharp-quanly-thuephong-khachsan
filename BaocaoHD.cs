using BTL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BTL.Reports;

namespace BTL
{
    public partial class BaocaoHD : Form
    {
        public BaocaoHD()
        {
            InitializeComponent();
        }
        string maHD;
        public BaocaoHD(string ma)
        {
            InitializeComponent();
            this.maHD = ma;
        }

        private void BaocaoHD_Load(object sender, EventArgs e)
        {
          /*  create proc sp_hd
   (
   @id varchar(20)
   )
   as
   begin
 select tblChiTietPhong.MaP,tblChiTietDichVu.MaDV,
 tblKhachHang.TenKH,tblKhachHang.SDT,tblKhachHang.DiaChi
 ,tblHoaDon.NgayNhan,tblChiTietDichVu.SoLuong, tblChiTietDichVu.DonGia as GiaDV,tblChiTietPhong.DonGia as GiaP,tblChiTietPhong.SoNgayThue
 ,tblDichVu.TenDV,tblPhong.TenP,tblPhong.LoaiP,tblNhanVien.TenNV
 from tblChiTietPhong
 left join tblChiTietDichVu on tblChiTietDichVu.Map = tblChiTietPhong.Map
 left join tblDichVu on tblDichVu.MaDV = tblChiTietDichVu.MaDV
 join tblPhong on tblPhong.MaP = tblChiTietPhong.MaP
 join tblHoaDon on tblHoaDon.MaHD = tblChiTietPhong.MaHD
  join tblKhachHang on tblHoaDon.MaKH = tblKhachHang.MaKH
    join tblNhanVien on tblHoaDon.MaNV = tblNhanVien.MaNV
 where tblChiTietPhong.MaHD = @id

 end
 go*/
            // MessageBox.Show(maHD.ToString());
            string sql = "exec sp_hd @id='" + maHD + "'";
           // +  "exec sp_dv @id='" + "DV1" + "'";
            DataTable dt = new DataTable();
            DataProvider provider = new DataProvider();

            dt = provider.ExecuteQuery(sql);

            HoaDon bchd = new HoaDon();
            bchd.SetDataSource(dt);
            crv_hd.ReportSource = bchd;
            crv_hd.Refresh();
        }
    }
}
