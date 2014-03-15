using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaOperativo {
    public partial class GUI : Form {
        static String path = "C:\\Users\\ecast_000\\Documents\\udem\\sistemaoperativo\\SistemaOperativo\\SistemaOperativo\\proc.txt";
        pcb procesos = SetProcesos(path);

        public GUI() {
            InitializeComponent();

            tbTiempoA.Text = procesos.getTiempo().ToString();

            tbNombre.Text = procesos.getProcesoByID(procesos.getRunningProccess()).getId().ToString();
            tbLlegada.Text = procesos.getProcesoByID(procesos.getRunningProccess()).getLlegada().ToString();
            Pagina auxpaginacion = procesos.getProcesoByID(procesos.getRunningProccess()).getListaPagina().getPagina();
            while (auxpaginacion != null) {
                cbPaginas.Items.Add(auxpaginacion.getNumero());
                auxpaginacion = auxpaginacion.getNextPagina();
            }
            
            cbAlgoritmos.Items.Add("FIFO");
            cbAlgoritmos.Items.Add("LFU");
            cbAlgoritmos.Items.Add("LRU");
            cbAlgoritmos.Items.Add("NUR");
            procesos.showState();

            dataGridView1.DataSource = procesos.DisplayPages(procesos.getRunningProccess());
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


        } //FINAL MAIN

        private void RefreshState() {
            //Tiempo
            procesos.TiempoPasa();
            tbTiempoA.Text = procesos.getTiempo().ToString();

            //Datagrid
            dataGridView1.DataSource = procesos.DisplayPages(procesos.getRunningProccess());
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            //Process info
            tbNombre.Text = procesos.getProcesoByID(procesos.getRunningProccess()).getId().ToString();
            tbLlegada.Text = procesos.getProcesoByID(procesos.getRunningProccess()).getLlegada().ToString();

            //combo box paginacion
            cbPaginas.Items.Clear();
            Pagina auxpaginacion = procesos.getProcesoByID(procesos.getRunningProccess()).getListaPagina().getPagina();
            while (auxpaginacion != null) {
                cbPaginas.Items.Add(auxpaginacion.getNumero());
                auxpaginacion = auxpaginacion.getNextPagina();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e) {
        }

        private static pcb SetProcesos(String path) {
            pcb procesos = new pcb();

            try {
                // Lectura del fichero
                string[] lines = System.IO.File.ReadAllLines(@path);
                String linea;
                int pointer = 0;
                String[] current;

                linea = lines[pointer].Trim();
                procesos.setMaxPag(int.Parse(linea));
                pointer++;

                linea = lines[pointer].Trim();
                procesos.setNumProcesos(int.Parse(linea));
                pointer++;

                int id, llegada, tiempo, estado, numpaginas;

                for (int numproc = 1; numproc <= procesos.getNumProcesos(); numproc++) {
                    linea = lines[pointer].Trim();
                    current = linea.Split(',');
                    id = numproc;
                    llegada = int.Parse(current[0].Trim());
                    tiempo = int.Parse(current[1].Trim());
                    estado = int.Parse(current[2].Trim());
                    pointer++;

                    linea = lines[pointer].Trim();
                    numpaginas = int.Parse(linea);
                    procesos.setProceso(id, llegada, tiempo, estado, numpaginas);
                    pointer++;

                    for (int numpag = 0; numpag <= procesos.getLastProceso().getNumeropaginas() - 1; numpag++) {
                        linea = lines[pointer].Trim();
                        current = linea.Split(',');
                        procesos.getLastProceso().setPagina(numpag,
                                                            int.Parse(current[0].Trim()),
                                                            int.Parse(current[1].Trim()),
                                                            int.Parse(current[2].Trim()),
                                                            int.Parse(current[3].Trim()),
                                                            int.Parse(current[4].Trim()),
                                                            int.Parse(current[5].Trim()));
                        pointer++;
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine("\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<Error de archivo>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
                e.ToString();
            }
            procesos.setTiempo();

            return procesos;
        } // fin Setprocesos 

        private void GUI_Load(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void cbPaginas_SelectedIndexChanged(object sender, EventArgs e) {



        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void bAlgoritmo_Click(object sender, EventArgs e) {
            int resp = -1;
            if (cbAlgoritmos.SelectedIndex == 0) {
                resp = procesos.FIFO(procesos.getRunningProccess(), Convert.ToInt32(cbPaginas.SelectedIndex));
            }
            if (cbAlgoritmos.SelectedIndex == 1) {
                resp = procesos.LFU(procesos.getRunningProccess(), Convert.ToInt32(cbPaginas.SelectedIndex));
            }
            if (cbAlgoritmos.SelectedIndex == 2) {
                resp = procesos.LRU(procesos.getRunningProccess(), Convert.ToInt32(cbPaginas.SelectedIndex));
            }
            if (cbAlgoritmos.SelectedIndex == 3) {
                resp = procesos.NUR(procesos.getRunningProccess(), Convert.ToInt32(cbPaginas.SelectedIndex));
            }

            if (resp == 0) {
                procesos.LoadProcess();
            }
            RefreshState();
        }

        private void bReseteoNur_Click(object sender, EventArgs e) {
            procesos.getProcesoByID(procesos.getRunningProccess()).getListaPagina().NURreset();
            RefreshState();
        }

        private void bCrear_Click(object sender, EventArgs e) {
            procesos.setProceso(procesos.getNumProcesos() + 1, 0, 0, 3,4);
            procesos.getLastProceso().setPagina();
            procesos.showState();
        }
    }
}
