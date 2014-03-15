using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaOperativo {
    class ListaPagina {
        private Pagina pagina;

        public void setPagina(int numero, int residencia, int llegada, int acceso, int NURlectura, int NURescritura, int modificacion) {
            if (pagina == null) {
                pagina = new Pagina(numero, residencia, llegada, acceso, NURlectura, NURescritura, modificacion);
            }
            else {
                Pagina nuevaPagina = new Pagina(numero, residencia, llegada, acceso, NURlectura, NURescritura, modificacion);
                Pagina aux = new Pagina();
                aux = pagina;

                while (aux.getNextPagina() != null) {
                    aux = aux.getNextPagina();
                }
                aux.setNextPagina(nuevaPagina);
                //pagina = aux;  
            }
        }

        public void setPagina() {
            if (pagina == null) {
                pagina = new Pagina();
            }
            else {
                Pagina nuevaPagina = new Pagina();
                Pagina aux = new Pagina();
                aux = pagina;

                while (aux.getNextPagina() != null) {
                    aux = aux.getNextPagina();
                }
                aux.setNextPagina(nuevaPagina);
                //pagina = aux;  
            }
        }

        public Pagina getPagina() {
            return pagina;
        }

        public Pagina getPaginaByNumero(int numero) {
            Pagina aux = new Pagina();
            aux = pagina;

            while (aux.getNextPagina() != null) {
                if (aux.getNumero() == numero) {
                    return aux;
                }
                aux = aux.getNextPagina();
            }
            return aux;
        }

        public void NURreset() {
            Pagina aux = new Pagina();
            aux = pagina;

            while (aux.getNextPagina() != null) {
                aux.setModificacion(0);
                aux.setNURlectura(0);
                aux = aux.getNextPagina();
            }
        }
    }
}
