using BTL.DAO;
using BTL.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTL
{
    public partial class BaocaoKH : Form
    {
        public BaocaoKH()
        {
            InitializeComponent();
        }

        private void BaocaoKH_Load(object sender, EventArgs e)
        {
            string sql = "select * from tblKhachHang";
            DataTable dt = new DataTable();
            DataProvider provider = new DataProvider();

            dt = provider.ExecuteQuery(sql);


            KhachHang bckh = new KhachHang();
            bckh.SetDataSource(dt);
            crv_kh.ReportSource = bckh;
            crv_kh.Refresh();
        }
    }
}
