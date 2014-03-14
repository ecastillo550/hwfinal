namespace SistemaOperativo
{
    partial class GUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbTiempoA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbQuantumRestante = new System.Windows.Forms.TextBox();
            this.tbEnvejecimiento = new System.Windows.Forms.TextBox();
            this.tbCpuAsignado = new System.Windows.Forms.TextBox();
            this.tbLlegada = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.cbPaginas = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbAlgoritmos = new System.Windows.Forms.ComboBox();
            this.bAlgoritmo = new System.Windows.Forms.Button();
            this.bReseteoNur = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.cbAlgoritmoCpu = new System.Windows.Forms.ComboBox();
            this.bAlgoritmoCpu = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.cbInterrupcion = new System.Windows.Forms.ComboBox();
            this.bInterrumpir = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbNombrePnew = new System.Windows.Forms.TextBox();
            this.tbPagpnew = new System.Windows.Forms.TextBox();
            this.tbejetotalPnew = new System.Windows.Forms.TextBox();
            this.bCrear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiempo Actual";
            // 
            // tbTiempoA
            // 
            this.tbTiempoA.Location = new System.Drawing.Point(94, 10);
            this.tbTiempoA.Name = "tbTiempoA";
            this.tbTiempoA.ReadOnly = true;
            this.tbTiempoA.Size = new System.Drawing.Size(46, 20);
            this.tbTiempoA.TabIndex = 1;
            this.tbTiempoA.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Proceso Actual";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Llegada";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cpu Asignado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Envejecimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Quantum Restante";
            // 
            // tbQuantumRestante
            // 
            this.tbQuantumRestante.Location = new System.Drawing.Point(115, 181);
            this.tbQuantumRestante.Name = "tbQuantumRestante";
            this.tbQuantumRestante.ReadOnly = true;
            this.tbQuantumRestante.Size = new System.Drawing.Size(50, 20);
            this.tbQuantumRestante.TabIndex = 9;
            // 
            // tbEnvejecimiento
            // 
            this.tbEnvejecimiento.Location = new System.Drawing.Point(115, 158);
            this.tbEnvejecimiento.Name = "tbEnvejecimiento";
            this.tbEnvejecimiento.ReadOnly = true;
            this.tbEnvejecimiento.Size = new System.Drawing.Size(50, 20);
            this.tbEnvejecimiento.TabIndex = 10;
            // 
            // tbCpuAsignado
            // 
            this.tbCpuAsignado.Location = new System.Drawing.Point(115, 136);
            this.tbCpuAsignado.Name = "tbCpuAsignado";
            this.tbCpuAsignado.ReadOnly = true;
            this.tbCpuAsignado.Size = new System.Drawing.Size(50, 20);
            this.tbCpuAsignado.TabIndex = 11;
            // 
            // tbLlegada
            // 
            this.tbLlegada.Location = new System.Drawing.Point(115, 114);
            this.tbLlegada.Name = "tbLlegada";
            this.tbLlegada.ReadOnly = true;
            this.tbLlegada.Size = new System.Drawing.Size(50, 20);
            this.tbLlegada.TabIndex = 12;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(115, 91);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.ReadOnly = true;
            this.tbNombre.Size = new System.Drawing.Size(50, 20);
            this.tbNombre.TabIndex = 13;
            // 
            // cbPaginas
            // 
            this.cbPaginas.FormattingEnabled = true;
            this.cbPaginas.Location = new System.Drawing.Point(15, 229);
            this.cbPaginas.Name = "cbPaginas";
            this.cbPaginas.Size = new System.Drawing.Size(121, 21);
            this.cbPaginas.TabIndex = 14;
            this.cbPaginas.SelectedIndexChanged += new System.EventHandler(this.cbPaginas_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(200, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(209, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tablas de Páginas del Proceso Actual";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(820, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Memoria";
            // 
            // cbAlgoritmos
            // 
            this.cbAlgoritmos.FormattingEnabled = true;
            this.cbAlgoritmos.Location = new System.Drawing.Point(784, 46);
            this.cbAlgoritmos.Name = "cbAlgoritmos";
            this.cbAlgoritmos.Size = new System.Drawing.Size(121, 21);
            this.cbAlgoritmos.TabIndex = 16;
            // 
            // bAlgoritmo
            // 
            this.bAlgoritmo.Location = new System.Drawing.Point(784, 75);
            this.bAlgoritmo.Name = "bAlgoritmo";
            this.bAlgoritmo.Size = new System.Drawing.Size(121, 23);
            this.bAlgoritmo.TabIndex = 17;
            this.bAlgoritmo.Text = "Cambiar Algoritmo";
            this.bAlgoritmo.UseVisualStyleBackColor = true;
            this.bAlgoritmo.Click += new System.EventHandler(this.bAlgoritmo_Click);
            // 
            // bReseteoNur
            // 
            this.bReseteoNur.Location = new System.Drawing.Point(784, 104);
            this.bReseteoNur.Name = "bReseteoNur";
            this.bReseteoNur.Size = new System.Drawing.Size(121, 23);
            this.bReseteoNur.TabIndex = 18;
            this.bReseteoNur.Text = "Reseteo Bits  NUR";
            this.bReseteoNur.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(171, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(607, 226);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(820, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "CUP";
            // 
            // cbAlgoritmoCpu
            // 
            this.cbAlgoritmoCpu.FormattingEnabled = true;
            this.cbAlgoritmoCpu.Location = new System.Drawing.Point(785, 175);
            this.cbAlgoritmoCpu.Name = "cbAlgoritmoCpu";
            this.cbAlgoritmoCpu.Size = new System.Drawing.Size(121, 21);
            this.cbAlgoritmoCpu.TabIndex = 21;
            // 
            // bAlgoritmoCpu
            // 
            this.bAlgoritmoCpu.Location = new System.Drawing.Point(785, 203);
            this.bAlgoritmoCpu.Name = "bAlgoritmoCpu";
            this.bAlgoritmoCpu.Size = new System.Drawing.Size(121, 23);
            this.bAlgoritmoCpu.TabIndex = 22;
            this.bAlgoritmoCpu.Text = "button1";
            this.bAlgoritmoCpu.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(793, 244);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "CUP";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(850, 237);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(54, 20);
            this.numericUpDown1.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(200, 288);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Solicitud de Interrupción";
            // 
            // cbInterrupcion
            // 
            this.cbInterrupcion.FormattingEnabled = true;
            this.cbInterrupcion.Location = new System.Drawing.Point(174, 304);
            this.cbInterrupcion.Name = "cbInterrupcion";
            this.cbInterrupcion.Size = new System.Drawing.Size(184, 21);
            this.cbInterrupcion.TabIndex = 26;
            // 
            // bInterrumpir
            // 
            this.bInterrumpir.Location = new System.Drawing.Point(374, 302);
            this.bInterrumpir.Name = "bInterrumpir";
            this.bInterrumpir.Size = new System.Drawing.Size(138, 23);
            this.bInterrumpir.TabIndex = 27;
            this.bInterrumpir.Text = "Interrumpir";
            this.bInterrumpir.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(785, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Nuevo Proceso";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(785, 340);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Nombre";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(793, 365);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Paginas";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(758, 389);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Ejecusion Total";
            // 
            // tbNombrePnew
            // 
            this.tbNombrePnew.Location = new System.Drawing.Point(854, 330);
            this.tbNombrePnew.Name = "tbNombrePnew";
            this.tbNombrePnew.ReadOnly = true;
            this.tbNombrePnew.Size = new System.Drawing.Size(50, 20);
            this.tbNombrePnew.TabIndex = 32;
            // 
            // tbPagpnew
            // 
            this.tbPagpnew.Location = new System.Drawing.Point(854, 356);
            this.tbPagpnew.Name = "tbPagpnew";
            this.tbPagpnew.ReadOnly = true;
            this.tbPagpnew.Size = new System.Drawing.Size(50, 20);
            this.tbPagpnew.TabIndex = 33;
            // 
            // tbejetotalPnew
            // 
            this.tbejetotalPnew.Location = new System.Drawing.Point(854, 382);
            this.tbejetotalPnew.Name = "tbejetotalPnew";
            this.tbejetotalPnew.ReadOnly = true;
            this.tbejetotalPnew.Size = new System.Drawing.Size(51, 20);
            this.tbejetotalPnew.TabIndex = 34;
            // 
            // bCrear
            // 
            this.bCrear.Location = new System.Drawing.Point(831, 408);
            this.bCrear.Name = "bCrear";
            this.bCrear.Size = new System.Drawing.Size(75, 23);
            this.bCrear.TabIndex = 35;
            this.bCrear.Text = "Crear";
            this.bCrear.UseVisualStyleBackColor = true;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 439);
            this.Controls.Add(this.bCrear);
            this.Controls.Add(this.tbejetotalPnew);
            this.Controls.Add(this.tbPagpnew);
            this.Controls.Add(this.tbNombrePnew);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.bInterrumpir);
            this.Controls.Add(this.cbInterrupcion);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.bAlgoritmoCpu);
            this.Controls.Add(this.cbAlgoritmoCpu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bReseteoNur);
            this.Controls.Add(this.bAlgoritmo);
            this.Controls.Add(this.cbAlgoritmos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbPaginas);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.tbLlegada);
            this.Controls.Add(this.tbCpuAsignado);
            this.Controls.Add(this.tbEnvejecimiento);
            this.Controls.Add(this.tbQuantumRestante);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTiempoA);
            this.Controls.Add(this.label1);
            this.Name = "GUI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTiempoA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbQuantumRestante;
        private System.Windows.Forms.TextBox tbEnvejecimiento;
        private System.Windows.Forms.TextBox tbCpuAsignado;
        private System.Windows.Forms.TextBox tbLlegada;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.ComboBox cbPaginas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbAlgoritmos;
        private System.Windows.Forms.Button bAlgoritmo;
        private System.Windows.Forms.Button bReseteoNur;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbAlgoritmoCpu;
        private System.Windows.Forms.Button bAlgoritmoCpu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbInterrupcion;
        private System.Windows.Forms.Button bInterrumpir;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbNombrePnew;
        private System.Windows.Forms.TextBox tbPagpnew;
        private System.Windows.Forms.TextBox tbejetotalPnew;
        private System.Windows.Forms.Button bCrear;
    }
}

