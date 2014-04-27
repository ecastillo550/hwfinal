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
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.statedgv)).BeginInit();
            this.SuspendLayout();
            // 
            // statedgv
            // 
            this.statedgv.AllowUserToAddRows = false;
            this.statedgv.AllowUserToDeleteRows = false;
            this.statedgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statedgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statedgv.GridColor = System.Drawing.Color.DimGray;
            this.statedgv.Location = new System.Drawing.Point(0, 0);
            this.statedgv.Name = "statedgv";
            this.statedgv.ReadOnly = true;
            this.statedgv.Size = new System.Drawing.Size(921, 672);
            this.statedgv.TabIndex = 0;
            // 
            // cls
            // 
            this.cls.Location = new System.Drawing.Point(877, 0);
            this.cls.Name = "cls";
            this.cls.Size = new System.Drawing.Size(45, 33);
            this.cls.TabIndex = 1;
            this.cls.Text = "Cerrar";
            this.cls.UseVisualStyleBackColor = true;
            this.cls.Click += new System.EventHandler(this.cls_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // state
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 672);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
    }
}