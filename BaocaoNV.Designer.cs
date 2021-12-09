
namespace BTL
{
    partial class BaocaoNV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crv_nv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crv_nv
            // 
            this.crv_nv.ActiveViewIndex = -1;
            this.crv_nv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv_nv.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv_nv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv_nv.Location = new System.Drawing.Point(0, 0);
            this.crv_nv.Name = "crv_nv";
            this.crv_nv.Size = new System.Drawing.Size(1266, 699);
            this.crv_nv.TabIndex = 0;
            // 
            // NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 699);
            this.Controls.Add(this.crv_nv);
            this.Name = "NhanVien";
            this.Text = "NhanVien";
            this.Load += new System.EventHandler(this.NhanVien_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv_nv;
    }
}