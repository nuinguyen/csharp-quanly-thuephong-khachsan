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
    public partial class BaocaoNV : Form
    {
        public BaocaoNV()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            string sql = "select * from tblNhanVien";
            DataTable dt = new DataTable();
            DataProvider provider = new DataProvider();

            dt = provider.ExecuteQuery(sql);

            NhanVien bchd = new NhanVien();
            bchd.SetDataSource(dt);
            crv_nv.ReportSource = bchd;
            crv_nv.Refresh();
        }
    }
}
