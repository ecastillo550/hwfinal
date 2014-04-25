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
            this.cls = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.statedgv)).BeginInit();
            this.SuspendLayout();
            // 
            // statedgv
            // 
            this.statedgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statedgv.Location = new System.Drawing.Point(12, 39);
            this.statedgv.Name = "statedgv";
            this.statedgv.Size = new System.Drawing.Size(702, 616);
            this.statedgv.TabIndex = 0;
            // 
            // cls
            // 
            this.cls.Location = new System.Drawing.Point(639, 10);
            this.cls.Name = "cls";
            this.cls.Size = new System.Drawing.Size(75, 23);
            this.cls.TabIndex = 1;
            this.cls.Text = "Cerrar";
            this.cls.UseVisualStyleBackColor = true;
            this.cls.Click += new System.EventHandler(this.cls_Click);
            // 
            // state
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 672);
            this.ControlBox = false;
            this.Controls.Add(this.cls);
            this.Controls.Add(this.statedgv);
            this.DoubleBuffered = true;
            this.Name = "state";
            this.Text = "state";
            this.Load += new System.EventHandler(this.state_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statedgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView statedgv;
        private System.Windows.Forms.Button cls;
    }
}