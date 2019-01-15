namespace WindowsFormsApplication3
{
    partial class frm2
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
            this.txtzpl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtzpl
            // 
            this.txtzpl.Location = new System.Drawing.Point(9, 7);
            this.txtzpl.Multiline = true;
            this.txtzpl.Name = "txtzpl";
            this.txtzpl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtzpl.Size = new System.Drawing.Size(223, 282);
            this.txtzpl.TabIndex = 0;
            // 
            // frm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 301);
            this.Controls.Add(this.txtzpl);
            this.Name = "frm2";
            this.Text = "Printing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtzpl;

    }
}