
namespace BTL
{
    partial class BaocaoHD
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
            this.crv_hd = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crv_hd
            // 
            this.crv_hd.ActiveViewIndex = -1;
            this.crv_hd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv_hd.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv_hd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv_hd.Location = new System.Drawing.Point(0, 0);
            this.crv_hd.Name = "crv_hd";
            this.crv_hd.Size = new System.Drawing.Size(1229, 704);
            this.crv_hd.TabIndex = 0;
            // 
            // BaocaoHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 704);
            this.Controls.Add(this.crv_hd);
            this.Name = "BaocaoHD";
            this.Text = "BaocaoHD";
            this.Load += new System.EventHandler(this.BaocaoHD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv_hd;
    }
}