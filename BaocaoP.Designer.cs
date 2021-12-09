
namespace BTL
{
    partial class BaocaoP
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
            this.crv_p = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crv_p
            // 
            this.crv_p.ActiveViewIndex = -1;
            this.crv_p.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv_p.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv_p.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv_p.Location = new System.Drawing.Point(0, 0);
            this.crv_p.Name = "crv_p";
            this.crv_p.Size = new System.Drawing.Size(1373, 709);
            this.crv_p.TabIndex = 0;
            // 
            // BaocaoP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 709);
            this.Controls.Add(this.crv_p);
            this.Name = "BaocaoP";
            this.Text = "BaocaoP";
            this.Load += new System.EventHandler(this.BaocaoP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv_p;
    }
}