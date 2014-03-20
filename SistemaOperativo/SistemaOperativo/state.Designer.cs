namespace SistemaOperativo {
    partial class state {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.statedgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.statedgv)).BeginInit();
            this.SuspendLayout();
            // 
            // statedgv
            // 
            this.statedgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statedgv.Location = new System.Drawing.Point(12, 12);
            this.statedgv.Name = "statedgv";
            this.statedgv.Size = new System.Drawing.Size(770, 616);
            this.statedgv.TabIndex = 0;
            // 
            // state
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 640);
            this.Controls.Add(this.statedgv);
            this.Name = "state";
            this.Text = "state";
            this.Load += new System.EventHandler(this.state_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statedgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView statedgv;
    }
}