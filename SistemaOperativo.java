package sistemaoperativo;

public class SistemaOperativo {

    public static void main(String[] args) {
        ListaProceso procesos = new ListaProceso();
        Pagina auxpaginacion = new Pagina();
        Proceso auxproceso = new Proceso();
        
        procesos.setProceso(1,1,1,1,1);
        procesos.getLastProceso().setPagina(1,1,1,1,1,1,1);
        procesos.getLastProceso().setPagina(2,2,2,2,2,2,2);
        procesos.getLastProceso().setPagina(3,3,3,3,3,3,3);
        procesos.getLastProceso().setPagina(4,4,4,4,4,4,4);
        
        procesos.setProceso(2,2,2,2,2);
        procesos.getLastProceso().setPagina(5,5,5,5,5,5,5);
        procesos.getLastProceso().setPagina(6,33333,6,6,6,6,6);
        
        procesos.setProceso(3,3,3,3,3);
        procesos.getLastProceso().setPagina(7,7,7,7,7,7,7);
        procesos.getLastProceso().setPagina(8,8,8,8,8,8,8);
        
        auxproceso = procesos.getProceso();
        System.out.println("Proceso idddddd: " + procesos.getProcesoByID(3).getId());
        
        System.out.println("pag residenciaaa: " + procesos.getProcesoByID(2).getListaPagina().getPaginaByNumero(6).getResidencia());
        
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
                System.out.println("Proceso pagina NURlectura: " + auxpaginacion.getNURlectura());
                System.out.println("Proceso pagina NURescritura: " + auxpaginacion.getNURescritura());
                System.out.println("Proceso pagina modificacion: " + auxpaginacion.getModificacion()); 
                auxpaginacion = auxpaginacion.getNextPagina();
            }
            auxproceso = auxproceso.getNextProceso();
        }
    }
    
}
