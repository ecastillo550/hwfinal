using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaOperativo {
    class Pagina {
        private int numero;
        private int residencia;
        private int llegada;
        private int acceso;
        private int NURlectura;
        private int modificacion;
        private int numacceso;
        private int numaccesoINI;
        private Pagina nextPagina;

        public Pagina(int numero, int residencia, int llegada, int acceso, int numacceso, int NURlectura, int NURescritura) {
            this.setNumero(numero);
            this.setResidencia(residencia);
            this.setLlegada(llegada);
            this.setAcceso(acceso);
            this.setNURlectura(NURlectura);
            this.setNumAcceso(numacceso);
            this.setNumAccesoINI(numacceso);
            nextPagina = null;
        }
        public Pagina() {
            this.setNumero(0);
            this.setResidencia(0);
            this.setLlegada(0);
            this.setAcceso(0);
            this.setNumAcceso(0);
            this.setNURlectura(0);
            this.setModificacion(0);
            this.setNumAccesoINI(0);
            nextPagina = null;
        }

        public void setNumero(int numero) {
            this.numero = numero;
        }
        public void setNumAccesoINI(int numaccesoINI) {
            this.numaccesoINI = numaccesoINI;
        }
        public void setResidencia(int residencia) {
            this.residencia = residencia;
        }
        public void setLlegada(int llegada) {
            this.llegada = llegada;
        }
        public void setAcceso(int acceso) {
            this.acceso = acceso;
        }
        public void setNumAcceso(int numacceso) {
            this.numacceso = numacceso;
        }
        public void setNURlectura(int NURlectura) {
            this.NURlectura = NURlectura;
        }
        public void setModificacion(int modificacion) {
            this.modificacion = modificacion;
        }
        public void setNextPagina(Pagina nextPagina) {
            this.nextPagina = nextPagina;
        }

        public int getNumero() {
            return numero;
        }
        public int getResidencia() {
            return residencia;
        }
        public int getLlegada() {
            return llegada;
        }
        public int getAcceso() {
            return acceso;
        }
        public int getNumAcceso() {
            return numacceso;
        }
        public int getNumAccesoINI() {
            return numaccesoINI;
        }
        public int getNURlectura() {
            return NURlectura;
        }
        public int getModificacion() {
            return modificacion;
        }
        public Pagina getNextPagina() {
            return nextPagina;
        }

    }
}
