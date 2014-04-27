using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaOperativo {
    class Proceso {
        private int id;
        private int llegada;
        private int estado;
        private int numeropaginas;
        private int tiempototalestimado;
        private int tiempototalestimadoUnchanged;
        private ListaPagina listapagina;
        private Proceso nextProceso;

        public Proceso(int id, int llegada, int tiempo, int estado, int numpag) {
            setId(id);
            setLlegada(llegada);
            setEstado(estado);
            setNumeropaginas(numpag);
            setTiempo(tiempo);
            listapagina = new ListaPagina();
            setTiempoUnchanged(tiempo);
        }

        public Proceso() {
            listapagina = new ListaPagina();
        }

        public void setId(int id) {
            this.id = id;
        }
        public void setLlegada(int llegada) {
            this.llegada = llegada;
        }
        public void setEstado(int estado) {
            this.estado = estado;
        }
        public void setNumeropaginas(int numeropaginas) {
            this.numeropaginas = numeropaginas;
        }
        public void setTiempo(int tiempototalestimado) {
            this.tiempototalestimado = tiempototalestimado;
        }
        public void setTiempoUnchanged(int tiempototalestimadoUnchanged) {
            this.tiempototalestimadoUnchanged = tiempototalestimadoUnchanged;
        }
        public void setTiempoMenos() {
            this.tiempototalestimado -= 1;
        }
        //llamada hacia listapagina que llama a set pagina-- conservamos el nombre para simplificacion
        public void setPagina(int numero, int residencia, int llegada, int acceso, int NURlectura, int NURescritura, int modificacion) {
            this.listapagina.setPagina(numero, residencia, llegada, acceso, NURlectura, NURescritura, modificacion);
        }
        public void setPagina() {
            this.listapagina.setPagina();
        }
        public void setNextProceso(Proceso nextProceso) {
            this.nextProceso = nextProceso;
        }
        public int getId() {
            return id;
        }
        public int getLlegada() {
            return llegada;
        }
        public int getEstado() {
            return estado;
        }
        public int getNumeropaginas() {
            return numeropaginas;
        }
        public int getTiempo() {
            return tiempototalestimado;
        }
        public int getTiempoUnchanged() {
            return tiempototalestimadoUnchanged;
        }
        public ListaPagina getListaPagina() {
            return listapagina;
        }
        public Proceso getNextProceso() {
            return nextProceso;
        }
    }
}
