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
    public partial class BaocaoP : Form
    {
        string maP;
        public BaocaoP(string text)
        {
            InitializeComponent();
            this.maP = text;

        }
        public BaocaoP()
        {
            InitializeComponent();
        }

        private void BaocaoP_Load(object sender, EventArgs e)
        {
            string sql;
            if (maP != null)
            {
                sql = "select * from tblPhong where MaP='" + maP + "'";
            }
            else
            {
                sql = "select * from tblPhong";
            }
            DataTable dt = new DataTable();
            DataProvider provider = new DataProvider();
            dt = provider.ExecuteQuery(sql);
            Phong bckh = new Phong();
            bckh.SetDataSource(dt);
            crv_p.ReportSource = bckh;
            crv_p.Refresh();
        }
    }
}
