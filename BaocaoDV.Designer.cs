
namespace BTL
{
    partial class BaocaoDV
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
            this.crv_dv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crv_dv
            // 
            this.crv_dv.ActiveViewIndex = -1;
            this.crv_dv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv_dv.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv_dv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv_dv.Location = new System.Drawing.Point(0, 0);
            this.crv_dv.Name = "crv_dv";
            this.crv_dv.Size = new System.Drawing.Size(1247, 702);
            this.crv_dv.TabIndex = 0;
            // 
            // BaocaoDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 702);
            this.Controls.Add(this.crv_dv);
            this.Name = "BaocaoDV";
            this.Text = "BaocaoDV";
            this.Load += new System.EventHandler(this.BaocaoDV_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv_dv;
    }
}