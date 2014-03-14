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
        public GUI() {
            InitializeComponent();
            String path = "C:\\Users\\ecast_000\\Documents\\Visual Studio 2012\\Projects\\SistemaOperativo\\SistemaOperativo\\proc.txt";
            pcb procesos = SetProcesos(path);
            procesos.showState();

            Console.WriteLine("\n---------------------------------------------------------");
            procesos.LFU(3, 3);
            procesos.showState();
            tb1.Text = procesos.getTiempo().ToString();
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
    }
}
