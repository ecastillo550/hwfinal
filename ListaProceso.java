package sistemaoperativo;

public class ListaProceso {
    private Proceso proceso;
    
//    public ListaProceso(){
//        
//    }
    
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
    
    public Proceso getLastProceso(){
        Proceso aux = new Proceso();
            aux = proceso;
            
            while(aux.getNextProceso() != null){
                aux = aux.getNextProceso();
            }
            return aux;
    }
}
