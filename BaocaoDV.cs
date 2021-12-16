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
    public partial class BaocaoDV : Form
    {
        public BaocaoDV()
        {
            InitializeComponent();
        }
        string Map;
        public BaocaoDV(string text)
        {
            InitializeComponent();
            this.Map = text;
        }

        private void BaocaoDV_Load(object sender, EventArgs e)
        {
            string sql = "select * from tblDichVu where MaP='"+Map+"'";
            DataTable dt = new DataTable();
            DataProvider provider = new DataProvider();

            dt = provider.ExecuteQuery(sql);


            DichVu bcdv = new DichVu();
            bcdv.SetDataSource(dt);
            crv_dv.ReportSource = bcdv;
            crv_dv.Refresh();
        }
    }
}
