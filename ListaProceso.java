package sistemaoperativo;

public class ListaProceso {
    private Proceso proceso;
    private int maxPag;
    private int numProcesos;
    
//    public ListaProceso(){
//        
//    }
    
     public void setMaxPag(int maxPag){
        this.maxPag = maxPag;
    }
    public void setNumProcesos(int numProcesos){
        this.numProcesos = numProcesos;
    }
    
    public void setProceso(int id, int llegada, int tiempo, int estado, int numpag){
        if(proceso == null) {
            proceso = new Proceso(id, llegada, tiempo, estado, numpag);
        } 
        else {           
            Proceso nuevoProceso = new Proceso(id, llegada, tiempo, estado, numpag);   
            Proceso aux = new Proceso();
            aux = proceso;
            
            while(aux.getNextProceso() != null){
                aux = aux.getNextProceso();
            }
            aux.setNextProceso(nuevoProceso);
            //proceso = aux;
        }
    }
    
    public Proceso getProceso(){
        return proceso;
    }
    public int getMaxPag(){
        return maxPag;
    }
    public int getNumProcesos(){
        return numProcesos;
    }
    
    public Proceso getLastProceso(){
        Proceso aux = new Proceso();
            aux = proceso;
            
            while(aux.getNextProceso() != null){
                aux = aux.getNextProceso();
            }
            return aux;
    }
    
    public Proceso getProcesoByID(int id){
        Proceso aux = new Proceso();
            aux = proceso;
            
            while(aux.getNextProceso() != null ){
                if (aux.getId() == id) {
                    return aux;
                }
                aux = aux.getNextProceso();
            }
            return aux;
    }
    
    public void showState(){
        Pagina auxpaginacion = new Pagina();
        Proceso auxproceso = new Proceso();
        
        auxproceso = proceso;
        System.out.println("SO max pag: " + this.getMaxPag());
        
        System.out.println("SO Num procesos: " + this.getNumProcesos());
        
        while(auxproceso != null){
            System.out.println("\n---------------------------------------------------------");
            System.out.println("Proceso id: " + auxproceso.getId());
            System.out.println("Proceso llegada: " + auxproceso.getLlegada());
            System.out.println("Proceso estado: " + auxproceso.getEstado());
            System.out.println("Proceso num paginas : " + auxproceso.getNumeropaginas());
            System.out.println("Proceso tiempo: " + auxproceso.getTiempo());

            auxpaginacion = auxproceso.getListaPagina().getPagina();

            while(auxpaginacion != null){
                System.out.println("\nProceso pagina numero: " + auxpaginacion.getNumero());
                System.out.println("Proceso pagina residencia: " + auxpaginacion.getResidencia());
                System.out.println("Proceso pagina llegada: " + auxpaginacion.getLlegada());
                System.out.println("Proceso pagina acceso : " + auxpaginacion.getAcceso());
                System.out.println("Proceso pagina numero de accesos : " + auxpaginacion.getNumAcceso());
                System.out.println("Proceso pagina NURlectura: " + auxpaginacion.getNURlectura());
                System.out.println("Proceso pagina NURescritura: " + auxpaginacion.getNURescritura());
                System.out.println("Proceso pagina modificacion: " + auxpaginacion.getModificacion()); 
                auxpaginacion = auxpaginacion.getNextPagina();
            }
            auxproceso = auxproceso.getNextProceso();
        } // fin proceso while
    }
    
    public void FIFO(int ProcesoID, int PaginaID){
    int counter = 0;
    int lowerID = 0;
    int lower = 0;
    Pagina aux = new Pagina();
    aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();
    if(this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).getResidencia() == 0){
        while(aux != null){
            if(aux.getResidencia() == 1){
                counter++; 
            }
            //hacemos crecer al maximo
            if(aux.getLlegada() > lower){
                lower = aux.getLlegada();                
            }
            aux = aux.getNextPagina();
        }
        if(counter >= this.getMaxPag()){
            aux = this.getProcesoByID(ProcesoID).getListaPagina().getPagina();
            
            while(aux != null){
                if(aux.getLlegada() <= lower && aux.getResidencia() == 1){
                    lower = aux.getLlegada();
                    lowerID = aux.getNumero();
                }
                aux = aux.getNextPagina();
            }

            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(lowerID).setResidencia(0);
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setResidencia(1);
        } else {
            this.getProcesoByID(ProcesoID).getListaPagina().getPaginaByNumero(PaginaID).setResidencia(1);
        }
    }
    
    //return listapagina;
    }
}
