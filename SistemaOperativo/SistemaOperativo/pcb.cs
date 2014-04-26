using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SistemaOperativo
{
    class pcb
    {
        private Proceso proceso;
        private Proceso DummyPlug;
        private int maxPag;
        private int numProcesos;
        private int tiempo;
        private int quantum;
        private int LlegadaBlocked;

        public pcb() {
            //En caso de error se desplegara el DummyPlug
            DummyPlug = new Proceso(-1, -1, 2, 4, 1);
            DummyPlug.setPagina();
        }

        // los buenos Sets de la vida
        public void setTiempo()
        {
            Pagina auxpaginacion = new Pagina();
            Proceso auxproceso = new Proceso();
            int tiempomax = 0;
            auxproceso = proceso;

            while (auxproceso != null)
            {
                auxpaginacion = auxproceso.getListaPagina().getPagina();

                while (auxpaginacion != null)
                {
                    if (auxpaginacion.getAcceso() > tiempomax)
                    {
                        tiempomax = auxpaginacion.getAcceso();
                    }

                    auxpaginacion = auxpaginacion.getNextPagina();
                }
                auxproceso = auxproceso.getNextProceso();
            } // fin proceso while

            this.tiempo = tiempomax;
        }
        public void setTiempo(int tiempo)
        {
            this.tiempo = tiempo;
        }
        public void TiempoPasa()
        {
            this.tiempo += 1;
            this.getProcesoByID(this.getRunningProccess()).setTiempoMenos();
        }
        public int getQuantum() {
            return quantum;
        }
        public void setQuantum(int quantum) {
            this.quantum = quantum;
        }
        public void setMaxPag(int maxPag)
        {
            this.maxPag = maxPag;
        }
        public void setNumProcesos(int numProcesos)
        {
            this.numProcesos = numProcesos;
        }

        public void setProceso(int id, int llegada, int tiempo, int estado, int numpag)
        {
            if (proceso == null)
            {
                proceso = new Proceso(id, llegada, tiempo, estado, numpag);
            }
            else
            {
                Proceso nuevoProceso = new Proceso(id, llegada, tiempo, estado, numpag);
                Proceso aux = new Proceso();
                aux = proceso;
                int counter = 1;

                while (aux.getNextProceso() != null)
                {
                    counter++;
                    aux = aux.getNextProceso();
                }
                aux.setNextProceso(nuevoProceso);

                if (counter >= this.getNumProcesos()) {
                    this.setNumProcesos(counter + 1);
                }
            }
        }

        // metodos de control
        public Proceso getProceso()
        {
            return proceso;
        }
        public int getMaxPag()
        {
            return maxPag;
        }
        public int getTiempo()
        {
            return tiempo;
        }
        public int getNumProcesos()
        {
            return numProcesos;
        }

        // Metodos de estado
        public DataTable DisplayPages(int ProcesoID) {
            DataTable table = new DataTable();
            table.Columns.Add("Pagina", Type.GetType("System.String"));
            table.Columns.Add("R", Type.GetType("System.String"));
            table.Columns.Add("Llegada", Type.GetType("System.String"));
            table.Columns.Add("Ultimo acceso", Type.GetType("System.String"));
            table.Columns.Add("Acceso", Type.GetType("System.String"));
            table.Columns.Add("NURlectura", Type.GetType("System.String"));
            table.Columns.Add("Modificacion", Type.GetType("System.String"));

            Pagina aux = new Pagina();
            aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();

            while (aux != null) {
                table.Rows.Add(aux.getNumero(),
                aux.getResidencia(),
                aux.getLlegada(),
                aux.getAcceso(),
                aux.getNumAcceso(),
                aux.getNURlectura(),
                aux.getModificacion());
                aux = aux.getNextPagina();
            }

            return table;
        }
        public DataTable DisplayPagesState() {
            DataTable table = new DataTable();
            table.Columns.Add("Proceso", Type.GetType("System.String"));
            table.Columns.Add("Estado", Type.GetType("System.String"));
            table.Columns.Add("LlegadaPROC", Type.GetType("System.String"));
            table.Columns.Add("Tiempo Rest", Type.GetType("System.String"));
            table.Columns.Add("Pagina", Type.GetType("System.String"));
            table.Columns.Add("R", Type.GetType("System.String"));
            table.Columns.Add("Llegada", Type.GetType("System.String"));
            table.Columns.Add("Ultimo acceso", Type.GetType("System.String"));
            table.Columns.Add("Acceso", Type.GetType("System.String"));
            table.Columns.Add("NURlectura", Type.GetType("System.String"));
            table.Columns.Add("Modificacion", Type.GetType("System.String"));

            Pagina auxpaginacion = new Pagina();
            Proceso auxproceso = new Proceso();
            auxproceso = proceso;

            while (auxproceso != null) {

                auxpaginacion = auxproceso.getListaPagina().getPagina();
                while (auxpaginacion != null) {
                    table.Rows.Add(auxproceso.getId(),
                        auxproceso.getEstado(),
                        auxproceso.getLlegada(),
                        auxproceso.getTiempo(),
                        auxpaginacion.getNumero(),
                        auxpaginacion.getResidencia(),
                        auxpaginacion.getLlegada(),
                        auxpaginacion.getAcceso(),
                        auxpaginacion.getNumAcceso(),
                        auxpaginacion.getNURlectura(),
                        auxpaginacion.getModificacion());
                    auxpaginacion = auxpaginacion.getNextPagina();
                }
                auxproceso = auxproceso.getNextProceso();
            } // fin proceso while

            return table;
        }
        public Proceso getLastProceso()
        {
            Proceso aux = new Proceso();
            aux = this.getProceso();

            while (aux.getNextProceso() != null)
            {
                aux = aux.getNextProceso();
            }
            return aux;
        }
        public Proceso getProcesoByID(int id)
        {
            Proceso aux = new Proceso();
            aux = proceso;
            if (id == -1) {
                return DummyPlug;
            }
            while (aux.getNextProceso() != null)
            {
                if (aux.getId() == id)
                {
                    return aux;
                }
                aux = aux.getNextProceso();
            }
            return aux;
        }
        public int getRunningProccess()
        {
            int proc = -1;
            Proceso aux = new Proceso();
            aux = proceso;
            while (aux != null)
            {
                if (aux.getEstado() == 1)
                {
                    proc = aux.getId();
                }
                aux = aux.getNextProceso();
            }

            //if (this.getProcesoByID(proc).getEstado() == 3 || this.getProcesoByID(proc).getEstado() == 4 || this.getProcesoByID(proc).getEstado() == 2) {
            //    return -1;
            //}
            return proc;
        }
        public void showState(){
        Pagina auxpaginacion = new Pagina();
        Proceso auxproceso = new Proceso();
        
        auxproceso = proceso;
        Console.WriteLine("SO max pag: " + this.getMaxPag());
        Console.WriteLine("SO Num procesos: " + this.getNumProcesos());
        Console.WriteLine("SO tiempo del sistema: " + this.getTiempo());
        
        while(auxproceso != null){
            Console.WriteLine("\n---------------------------------------------------------");
            Console.WriteLine("Proceso id: " + auxproceso.getId());
            Console.WriteLine("Proceso llegada: " + auxproceso.getLlegada());
            Console.WriteLine("Proceso estado: " + auxproceso.getEstado());
            Console.WriteLine("Proceso num paginas : " + auxproceso.getNumeropaginas());
            Console.WriteLine("Proceso tiempo estimado: " + auxproceso.getTiempo());

            auxpaginacion = auxproceso.getListaPagina().getPagina();

            while(auxpaginacion != null){
                Console.WriteLine("\nProceso pagina numero: " + auxpaginacion.getNumero());
                Console.WriteLine("Proceso pagina residencia: " + auxpaginacion.getResidencia());
                Console.WriteLine("Proceso pagina llegada: " + auxpaginacion.getLlegada());
                Console.WriteLine("Proceso pagina acceso : " + auxpaginacion.getAcceso());
                Console.WriteLine("Proceso pagina numero de accesos : " + auxpaginacion.getNumAcceso());
                Console.WriteLine("Proceso pagina NURlectura: " + auxpaginacion.getNURlectura());
                Console.WriteLine("Proceso pagina modificacion: " + auxpaginacion.getModificacion());
                Console.WriteLine("\n-------------------------------------"); 
                auxpaginacion = auxpaginacion.getNextPagina();
            }
            auxproceso = auxproceso.getNextProceso();
        } // fin proceso while
    }

        // Metodos de paginacion
        public int FIFO(int ProcesoID, int PaginaID) {
            int counter = 0;
            int lowerID = 0;
            int lower = 0;
            int FallodePag = -1;
            Pagina aux = new Pagina();
            aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();
            if (this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getResidencia() == 0) {
                while (aux != null) {
                    if (aux.getResidencia() == 1) {
                        counter++;
                    }
                    //hacemos crecer al maximo
                    if (aux.getLlegada() > lower) {
                        lower = aux.getLlegada();
                    }
                    aux = aux.getNextPagina();
                }
                if (counter >= this.getMaxPag()) {
                    aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();

                    while (aux != null) {
                        if (aux.getLlegada() <= lower && aux.getResidencia() == 1) {
                            lower = aux.getLlegada();
                            lowerID = aux.getNumero();
                        }
                        aux = aux.getNextPagina();
                    }

                    this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(lowerID).setResidencia(0);
                    this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setResidencia(1);
                }
                else {
                    this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setResidencia(1); // si hay menos qe el max de pag
                }
                FallodePag = 1;
            }
            else {
                FallodePag = 0;
            }
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setAcceso(this.getTiempo() + 1);
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID)
                    .setNumAcceso(this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso() + 1);
            this.TiempoPasa();
            if (this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso() - this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAccesoINI() >= 5) {
                //Se ha accesado mas de 5 veces
                this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setModificacion(1);
                this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setNumAccesoINI(this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso());
            }
            return FallodePag;
        }
        public int LRU(int ProcesoID, int PaginaID) {
            int counter = 0;
            int lowerID = 0;
            int lower = 0;
            int FallodePag = -1;
            Pagina aux = new Pagina();
            aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();
            if (this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getResidencia() == 0) {
                while (aux != null) {
                    if (aux.getResidencia() == 1) {
                        counter++;
                    }
                    //hacemos crecer al maximo
                    if (aux.getAcceso() > lower) {
                        lower = aux.getAcceso();
                    }
                    aux = aux.getNextPagina();
                }
                if (counter >= this.getMaxPag()) {
                    aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();

                    while (aux != null) {
                        if (aux.getAcceso() <= lower && aux.getResidencia() == 1) {
                            lower = aux.getAcceso();
                            lowerID = aux.getNumero();
                        }
                        aux = aux.getNextPagina();
                    }

                    this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(lowerID).setResidencia(0);
                    this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setResidencia(1);
                }
                else {
                    this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setResidencia(1); // si hay menos qe el max de pag
                }
                FallodePag = 1;
            }
            else {
                FallodePag = 0;
            }
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setAcceso(this.getTiempo() + 1);
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID)
                    .setNumAcceso(this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso() + 1);
            this.TiempoPasa();
            if (this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso() - this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAccesoINI() >= 5) {
                //Se ha accesado mas de 5 veces
                this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setModificacion(1);
                this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setNumAccesoINI(this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso());
            }
            return FallodePag;
        }
        public int LFU(int ProcesoID, int PaginaID) {
            int counter = 0;
            int lowerID = 0;
            int lower = 0;
            int FallodePag = -1;
            Pagina aux = new Pagina();
            aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();
            if (this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getResidencia() == 0) {
                while (aux != null) {
                    if (aux.getResidencia() == 1) {
                        counter++;
                    }
                    //hacemos crecer al maximo
                    if (aux.getNumAcceso() > lower) {
                        lower = aux.getLlegada();
                    }
                    aux = aux.getNextPagina();
                }
                if (counter >= this.getMaxPag()) {
                    aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();

                    while (aux != null) {
                        if (aux.getNumAcceso() <= lower && aux.getResidencia() == 1) {
                            lower = aux.getLlegada();
                            lowerID = aux.getNumero();
                        }
                        aux = aux.getNextPagina();
                    }

                    this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(lowerID).setResidencia(0);
                    this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setResidencia(1);
                }
                else {
                    this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setResidencia(1); // si hay menos qe el max de pag
                }
                FallodePag = 1;
            }//FIN siel bit residenciafue 0 
            else {
                FallodePag = 0;
            }
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setAcceso(this.getTiempo() + 1);
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID)
                    .setNumAcceso(this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso() + 1);
            this.TiempoPasa();
            if (this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso() - this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAccesoINI() >= 5) {
                //Se ha accesado mas de 5 veces
                this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setModificacion(1);
                this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setNumAccesoINI(this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso());
            }
            return FallodePag;
        }
        public int NUR(int ProcesoID, int PaginaID) {
            int counter = 0;
            int pagID = -1;
            int FallodePag = -1;
            Pagina aux = new Pagina();

            aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();
            if (this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getResidencia() == 0) {
                while (aux != null) { // counter inicial
                    if (aux.getResidencia() == 1) {
                        counter++;
                    }
                    aux = aux.getNextPagina();
                }

                if (counter >= this.getMaxPag()) {
                    aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();

                    while (aux != null) { // primer caso 0,0
                        if (aux.getNURlectura() == 0 && aux.getModificacion() == 0 && aux.getNumero() != PaginaID) {
                            pagID = aux.getNumero();
                        }
                        aux = aux.getNextPagina();
                    }

                    if (pagID == -1) { // segundo caso 1,0
                        aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();

                        while (aux != null) {
                            if (aux.getNURlectura() == 1 && aux.getModificacion() == 0 && aux.getNumero() != PaginaID) {
                                pagID = aux.getNumero();
                            }
                            aux = aux.getNextPagina();
                        }
                    }

                    if (pagID == -1) { // tercer caso 0,1
                        aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();

                        while (aux != null) {
                            if (aux.getNURlectura() == 0 && aux.getModificacion() == 1 && aux.getNumero() != PaginaID) {
                                pagID = aux.getNumero();
                            }
                            aux = aux.getNextPagina();
                        }
                    }

                    if (pagID == -1) { // cuarto caso 1,1
                        aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();

                        while (aux != null) {
                            if (aux.getNURlectura() == 1 && aux.getModificacion() == 1 && aux.getNumero() != PaginaID) {
                                pagID = aux.getNumero();
                            }
                            aux = aux.getNextPagina();
                        }
                    }

                    if (pagID == -1) { // ERROR GARRAFAL
                        Console.WriteLine("Error en paginacion, nur no encuentra candidato a cambiar.");
                    }
                    else {

                        this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(pagID).setResidencia(0);
                        this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setResidencia(1);
                    }
                } // FIN counter > limite de pags
                else {
                    this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setResidencia(1); // si hay menos qe el max de pag
                }
                FallodePag = 1;
            }//FIN siel bit residenciafue 0  
            else {
                FallodePag = 0;
            }
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setAcceso(this.getTiempo() + 1);
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setNumAcceso(this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso() + 1);
            this.TiempoPasa();
            if (this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso() - this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAccesoINI() >= 5) {
                //Se ha accesado mas de 5 veces
                this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setModificacion(1);
                this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setNumAccesoINI(this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso());
            }

            //procesos unicos de nur
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setNURlectura(1);
            return FallodePag;
        }

        // Metodos de control de procesos
        public int QuantumRestante(int ProcID) {
            return this.getQuantum() - (this.getTiempo() - this.getProcesoByID(ProcID).getLlegada());
        }
        public void LoadProcess(int LoadID) {
            int proc = -1;
            Proceso aux = new Proceso();
            aux = proceso;
            while (aux.getNextProceso() != null) {
                if (aux.getEstado() == 1) {
                    proc = aux.getId();
                }
                aux = aux.getNextProceso();
            }
            this.getProcesoByID(proc).setEstado(3);
            this.getProcesoByID(LoadID).setEstado(1);
        }
        
        //Used By Round Robbin or QuantumCheck()
        public void LoadProcess() {
            int proc = -2;
            int procSig = -2;
            int mayor = 0;
            int menor = 0;
            Proceso aux = new Proceso();
            aux = this.getProceso();
            // agarramos el proceso en ejecucion
            while (aux != null) {
                if (aux.getEstado() == 1) {
                    proc = aux.getId();
                }
                if (aux.getLlegada() > mayor) {
                    mayor = aux.getLlegada();
                }
                aux = aux.getNextProceso();
            }
            menor = mayor;

            aux = this.getProceso();
            // agarramos el proceso con la llegada mas baja
            while (aux != null) {
                if (aux.getEstado() == 3) {
                    if (aux.getLlegada() <= menor) {
                        menor = aux.getLlegada();
                        procSig = aux.getId();
                    }
                }
                aux = aux.getNextProceso();
            }
            if (proc != -2) {
                if (this.GetTiempoRestante(proc) <= 0) {
                    this.getProcesoByID(proc).setEstado(4);
                }
                else {
                    this.getProcesoByID(proc).setEstado(3);
                }
            }
            
            if (this.GetTiempoRestante(procSig) > 0) {
                this.getProcesoByID(procSig).setLlegada(this.getTiempo());
                this.getProcesoByID(procSig).setEstado(1);
            }
            if (this.GetTiempoRestante(procSig) <= 0) {
                this.getProcesoByID(procSig).setEstado(4);
            }
        }  
        public void BlockProcess(int LoadID) {
            int proc = -2;
            Proceso aux = new Proceso();
            aux = this.getProceso();
            // agarramos el proceso en ejecucion
            while (aux != null) {
                if (aux.getEstado() == 2) {
                    proc = aux.getId();
                }
                aux = aux.getNextProceso();
            }
            if (proc != -2) {
                this.getProcesoByID(proc).setEstado(3);
                this.getProcesoByID(proc).setLlegada(this.getTiempo());
            }
            this.LlegadaBlocked = this.getTiempo();
            this.getProcesoByID(LoadID).setEstado(2);
        }
        public void UnBlockProcess(int LoadID) {
            this.getProcesoByID(LoadID).setEstado(3);
            this.getProcesoByID(LoadID).setLlegada(this.getTiempo());
        }
        public int GetTiempoRestante(int ProcID) {
            return this.getProcesoByID(ProcID).getTiempo();
        }

        // QuantumCheck a.k.a. Round Robin!
        public void QuantumCheck(int ProcID) {
            if (this.getTiempo() - this.getProcesoByID(ProcID).getLlegada() >= this.getQuantum()) {
                this.LoadProcess();
            }
            if (this.GetTiempoRestante(ProcID) <= 0) {
                this.LoadProcess();
            }
        }

        // Metodos de procesos
        public void PROCfifo() {
            int proc = -2;
            int procSig = -2;
            int mayor = 0;
            int menor = 0;
            Proceso aux = new Proceso();
            aux = this.getProceso();
            // agarramos el proceso en ejecucion
            while (aux != null) {
                if (aux.getEstado() == 1) {
                    proc = aux.getId();
                }
                if (aux.getLlegada() > mayor) {
                    mayor = aux.getLlegada();
                }
                aux = aux.getNextProceso();
            }
            menor = mayor;

            if (GetTiempoRestante(proc) <= 0 || proc == -2) {
                aux = this.getProceso();
                // agarramos el proceso con la llegada mas baja
                while (aux != null) {
                    if (aux.getEstado() == 3) {
                        if (aux.getLlegada() <= menor) {
                            menor = aux.getLlegada();
                            procSig = aux.getId();
                        }      
                    }
                    aux = aux.getNextProceso();
                }
                if (this.GetTiempoRestante(procSig) > 0) {
                    this.getProcesoByID(procSig).setLlegada(this.getTiempo());
                    this.getProcesoByID(procSig).setEstado(1);
                }
                if (this.GetTiempoRestante(procSig) <= 0) {
                    this.getProcesoByID(procSig).setEstado(4);
                }
                if (proc != -2) {
                    this.getProcesoByID(proc).setEstado(4);
                }  
            }
        }
        public void SJF() {
            int proc = -2;
            int procSig = -2;
            int mayor = 0;
            int menor = 0;
            Proceso aux = new Proceso();
            aux = this.getProceso();
            // agarramos el proceso en ejecucion
            while (aux != null) {
                if (aux.getEstado() == 1) {
                    proc = aux.getId();
                }
                if (aux.getTiempo() > mayor) {
                    mayor = aux.getTiempo();
                }
                aux = aux.getNextProceso();
            }
            menor = mayor;

            if (GetTiempoRestante(proc) <= 0 || proc == -2) {
                aux = this.getProceso();
                // agarramos el proceso con la llegada mas baja
                while (aux != null) {
                    if (aux.getEstado() == 3) {
                        if (aux.getTiempo() <= menor) {
                            menor = aux.getTiempo();
                            procSig = aux.getId();
                        }
                    }
                    aux = aux.getNextProceso();
                }
                if (this.GetTiempoRestante(procSig) > 0) {
                    this.getProcesoByID(procSig).setLlegada(this.getTiempo());
                    this.getProcesoByID(procSig).setEstado(1);
                }
                if (this.GetTiempoRestante(procSig) <= 0) {
                    this.getProcesoByID(procSig).setEstado(4);
                }
                if (proc != -2) {
                    this.getProcesoByID(proc).setEstado(4);
                }
            }
        }
        public void SRT() {
            int proc = -2;
            int procSig = -2;
            int mayor = 0;
            int menor = 0;
            Boolean SRTFlag = false;
            Proceso aux = new Proceso();
            aux = this.getProceso();
            // agarramos el proceso en ejecucion
            while (aux != null) {
                if (aux.getEstado() == 1) {
                    proc = aux.getId();
                }
                if (aux.getTiempo() > mayor) {
                    mayor = aux.getTiempo();
                }
                if (aux.getTiempo() < this.getProcesoByID(proc).getTiempo() && aux.getTiempo() >0) {
                    SRTFlag = true;
                }
                aux = aux.getNextProceso();
            }
            menor = mayor;
            // proc = -2 --> no hay procesos en ejecucion
            if (GetTiempoRestante(proc) <= 0 || proc == -2 || SRTFlag) {
                aux = this.getProceso();
                // agarramos el proceso con la llegada mas baja
                while (aux != null) {
                    if (aux.getEstado() == 3) {
                        if (aux.getTiempo() <= menor) {
                            menor = aux.getTiempo();
                            procSig = aux.getId();
                        }
                    }
                    aux = aux.getNextProceso();
                }
                if (proc != -2) {
                    if (this.GetTiempoRestante(proc) <= 0) {
                        this.getProcesoByID(proc).setEstado(4);
                    }
                    else {
                        this.getProcesoByID(proc).setEstado(3);
                    }
                }

                if (this.GetTiempoRestante(procSig) > 0) {
                    this.getProcesoByID(procSig).setLlegada(this.getTiempo());
                    this.getProcesoByID(procSig).setEstado(1);
                } 
                else {
                    this.getProcesoByID(procSig).setEstado(4);
                }
            }
        }
        public void HRRN() {
            int proc = -2;
            int procSig = -2;
            double Ratio = 0;
            double MaxRatio = 0;
            double RatioActual = 0;
            Proceso aux = new Proceso();
            aux = this.getProceso();
            // agarramos el proceso en ejecucion
            while (aux != null) {
                //Sacamos el HRRN
                if (aux.getTiempo() > 0) {
                    Ratio = ((this.getTiempo() - aux.getLlegada()) + aux.getTiempo()) / aux.getTiempo();
                    if (Ratio > MaxRatio) {
                        // agarramos el proceso con el mayor ratio de una vez
                        procSig = aux.getId();
                        MaxRatio = Ratio;
                    }
                }   
                if (aux.getEstado() == 1) {
                    proc = aux.getId();
                    RatioActual = Ratio;
                }
         
                aux = aux.getNextProceso();
            }
            // proc = -2 --> no hay procesos en ejecucion
            if (GetTiempoRestante(proc) <= 0 || proc == -2 || RatioActual < MaxRatio) {
                aux = this.getProceso();

                if (proc != -2) {
                    if (this.GetTiempoRestante(proc) <= 0) {
                        this.getProcesoByID(proc).setEstado(4);
                    }
                    else {
                        this.getProcesoByID(proc).setEstado(3);
                    }
                }

                if (this.GetTiempoRestante(procSig) > 0) {
                    this.getProcesoByID(procSig).setLlegada(this.getTiempo());
                    this.getProcesoByID(procSig).setEstado(1);
                }
                else {
                    this.getProcesoByID(procSig).setEstado(4);
                }
            }
        }
        public void CheckAlgorithm(int algorithm) {
            int proc = -2;
            Proceso aux = new Proceso();
            aux = this.getProceso();
            // agarramos el proceso en ejecucion
            while (aux != null) {
                if (aux.getEstado() == 2) {
                    proc = aux.getId();
                }
                aux = aux.getNextProceso();
            }

            if (proc != -2) {
                if (this.getTiempo() - this.LlegadaBlocked > 1) {
                    this.UnBlockProcess(proc);
                }
                
            }
            switch (algorithm) {
                case 0:
                    // roundrobin
                    this.QuantumCheck(this.getRunningProccess());
                    break;
                case 1:
                    this.PROCfifo();
                    break;
                case 2:
                    // SJF
                    this.SJF();
                    break;
                case 3:
                    // SRT
                    this.SRT();
                    break;
                case 4:
                    // HRRN
                    this.HRRN();
                    break;
                default:
                    this.PROCfifo();
                    break;
            }
        }
    }
}