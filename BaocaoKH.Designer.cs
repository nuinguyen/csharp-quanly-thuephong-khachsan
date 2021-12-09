
namespace BTL
{
    partial class BaocaoKH
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
            this.crv_kh = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crv_kh
            // 
            this.crv_kh.ActiveViewIndex = -1;
            this.crv_kh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv_kh.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv_kh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv_kh.Location = new System.Drawing.Point(0, 0);
            this.crv_kh.Name = "crv_kh";
            this.crv_kh.Size = new System.Drawing.Size(1355, 717);
            this.crv_kh.TabIndex = 0;
            // 
            // BaocaoKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 717);
            this.Controls.Add(this.crv_kh);
            this.Name = "BaocaoKH";
            this.Text = "BaocaoKH";
            this.Load += new System.EventHandler(this.BaocaoKH_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv_kh;
    }
}