﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaOperativo {
    class pcb {
        private Proceso proceso;
        private int maxPag;
        private int numProcesos;
        private int tiempo;

        public void setTiempo() {
            Pagina auxpaginacion = new Pagina();
            Proceso auxproceso = new Proceso();
            int tiempomax = 0;
            auxproceso = proceso;

            while (auxproceso != null) {
                auxpaginacion = auxproceso.getListaPagina().getPagina();

                while (auxpaginacion != null) {
                    if (auxpaginacion.getAcceso() > tiempomax) {
                        tiempomax = auxpaginacion.getAcceso();
                    }

                    auxpaginacion = auxpaginacion.getNextPagina();
                }
                auxproceso = auxproceso.getNextProceso();
            } // fin proceso while

            this.tiempo = tiempomax;
        }

        public void setTiempo(int tiempo) {
            this.tiempo = tiempo;
        }
        public void TiempoPasa() {
            this.tiempo += 1;
        }
        public void setMaxPag(int maxPag) {
            this.maxPag = maxPag;
        }
        public void setNumProcesos(int numProcesos) {
            this.numProcesos = numProcesos;
        }

        public void setProceso(int id, int llegada, int tiempo, int estado, int numpag) {
            if (proceso == null) {
                proceso = new Proceso(id, llegada, tiempo, estado, numpag);
            }
            else {
                Proceso nuevoProceso = new Proceso(id, llegada, tiempo, estado, numpag);
                Proceso aux = new Proceso();
                aux = proceso;

                while (aux.getNextProceso() != null) {
                    aux = aux.getNextProceso();
                }
                aux.setNextProceso(nuevoProceso);
                //proceso = aux;
            }
        }

        public Proceso getProceso() {
            return proceso;
        }
        public int getMaxPag() {
            return maxPag;
        }
        public int getTiempo() {
            return tiempo;
        }
        public int getNumProcesos() {
            return numProcesos;
        }

        public Proceso getLastProceso() {
            Proceso aux = new Proceso();
            aux = proceso;

            while (aux.getNextProceso() != null) {
                aux = aux.getNextProceso();
            }
            return aux;
        }

        public Proceso getProcesoByID(int id) {
            Proceso aux = new Proceso();
            aux = proceso;

            while (aux.getNextProceso() != null) {
                if (aux.getId() == id) {
                    return aux;
                }
                aux = aux.getNextProceso();
            }
            return aux;
        }

        public int getRunningProccess() {
            int proc = -1;
            Proceso aux = new Proceso();
            aux = proceso;

            while (aux.getNextProceso() != null) {
                if (aux.getEstado() == 1) {
                    proc = aux.getId();
                }
                aux = aux.getNextProceso();
            }            
            return proc;
        }

        public void showState() {
            Pagina auxpaginacion = new Pagina();
            Proceso auxproceso = new Proceso();

            auxproceso = proceso;
            Console.WriteLine("SO max pag: " + this.getMaxPag());
            Console.WriteLine("SO Num procesos: " + this.getNumProcesos());
            Console.WriteLine("SO tiempo del sistema: " + this.getTiempo());

            while (auxproceso != null) {
                Console.WriteLine("\n---------------------------------------------------------");
                Console.WriteLine("Proceso id: " + auxproceso.getId());
                Console.WriteLine("Proceso llegada: " + auxproceso.getLlegada());
                Console.WriteLine("Proceso estado: " + auxproceso.getEstado());
                Console.WriteLine("Proceso num paginas : " + auxproceso.getNumeropaginas());
                Console.WriteLine("Proceso tiempo estimado: " + auxproceso.getTiempo());

                auxpaginacion = auxproceso.getListaPagina().getPagina();

                while (auxpaginacion != null) {
                    Console.WriteLine("\nProceso pagina numero: " + auxpaginacion.getNumero());
                    Console.WriteLine("Proceso pagina residencia: " + auxpaginacion.getResidencia());
                    Console.WriteLine("Proceso pagina llegada: " + auxpaginacion.getLlegada());
                    Console.WriteLine("Proceso pagina acceso : " + auxpaginacion.getAcceso());
                    Console.WriteLine("Proceso pagina numero de accesos : " + auxpaginacion.getNumAcceso());
                    Console.WriteLine("Proceso pagina numero de accesos INI: " + auxpaginacion.getNumAccesoINI());
                    Console.WriteLine("Proceso pagina NURlectura: " + auxpaginacion.getNURlectura());
                    Console.WriteLine("Proceso pagina modificacion: " + auxpaginacion.getModificacion());
                    Console.WriteLine("\n");
                    auxpaginacion = auxpaginacion.getNextPagina();
                }
                auxproceso = auxproceso.getNextProceso();
            } // fin proceso while
        }

        public void FIFO(int ProcesoID, int PaginaID) {
            int counter = 0;
            int lowerID = 0;
            int lower = 0;
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
        }

        public void LRU(int ProcesoID, int PaginaID) {
            int counter = 0;
            int lowerID = 0;
            int lower = 0;
            Pagina aux = new Pagina();
            aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();
            if (this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getResidencia() == 0) {
                while (aux != null) {
                    if (aux.getResidencia() == 1) {
                        counter++;
                    }
                    //hacemos crecer al maximo
                    if (aux.getAcceso() > lower) {
                        lower = aux.getLlegada();
                    }
                    aux = aux.getNextPagina();
                }
                if (counter >= this.getMaxPag()) {
                    aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();

                    while (aux != null) {
                        if (aux.getAcceso() <= lower && aux.getResidencia() == 1) {
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
        }

        public void LFU(int ProcesoID, int PaginaID) {
            int counter = 0;
            int lowerID = 0;
            int lower = 0;
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
            }//FIN siel bit residenciafue 0  
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setAcceso(this.getTiempo() + 1);
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID)
                    .setNumAcceso(this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso() + 1);
            this.TiempoPasa();
            if (this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso() - this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAccesoINI() >= 5) {
                //Se ha accesado mas de 5 veces
                this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setModificacion(1);
                this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setNumAccesoINI(this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso());
            }
        }

        public void NUR(int ProcesoID, int PaginaID) {
            int counter = 0;
            int pagID = -1;
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
            }//FIN siel bit residenciafue 0  
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setAcceso(this.getTiempo() + 1);
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setNumAcceso(this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso() + 1);
            this.TiempoPasa();
            if (this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso()-this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAccesoINI() >= 5) {
                //Se ha accesado mas de 5 veces
                this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setModificacion(1);
                this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setNumAccesoINI(this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getNumAcceso());
            }

            //procesos unicos de nur
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setNURlectura(1);
        }
    }
}
