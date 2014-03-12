package sistemaoperativo;

import java.io.*;

public class SistemaOperativo {

    public static void main(String[] args) {
        String path = "C:\\Users\\erick\\Documents\\NetBeansProjects\\SistemaOperativo\\src\\sistemaoperativo\\proc.txt";
        ListaProceso procesos = SetProcesos(path);
        procesos.showState();
        
        System.out.println("\n---------------------------------------------------------");
        procesos.FIFO(2, 3);
        System.out.println("\ncambio de pagina a cargar 1 proc3: " + procesos.getProcesoByID(3).getListaPagina().getPaginaByNumero(1).getResidencia());
        procesos.showState();
        procesos.FIFO(2, 0);
        procesos.showState();
    }//fin main
    
    public static ListaProceso SetProcesos(String path) {
      File archivo = null;
      FileReader fileReader = null;
      BufferedReader bufferedReader = null;
      String[] current;
      
      ListaProceso procesos = new ListaProceso();
      
      try {
         // Apertura del fichero y creacion de BufferedReader para poder
         // hacer una lectura comoda (disponer del metodo readLine()).
         archivo = new File (path);
         fileReader = new FileReader (archivo);
         bufferedReader = new BufferedReader(fileReader);  
         
         // Lectura del fichero
         String linea;
         
         linea = bufferedReader.readLine().trim();
         procesos.setMaxPag(Integer.parseInt(linea));
         
         linea = bufferedReader.readLine().trim();
         procesos.setNumProcesos(Integer.parseInt(linea));
         
         int id, llegada, tiempo, estado, numpaginas;
         
         for(int numproc = 1 ; numproc <= procesos.getNumProcesos(); numproc++){
             linea = bufferedReader.readLine().trim();
             current = linea.split(",");
             id = numproc;
             llegada = Integer.parseInt(current[0].trim());
             tiempo = Integer.parseInt(current[1].trim());
             estado = Integer.parseInt(current[2].trim());
             
             linea = bufferedReader.readLine().trim();
             numpaginas = Integer.parseInt(linea);
             procesos.setProceso(id, llegada, tiempo, estado, numpaginas);
             
             for(int numpag = 0 ; numpag <= procesos.getLastProceso().getNumeropaginas()-1; numpag++){
                linea = bufferedReader.readLine().trim();
                current = linea.split(",");
                procesos.getLastProceso().setPagina(numpag,
                                                    Integer.parseInt(current[0].trim()),
                                                    Integer.parseInt(current[1].trim()),
                                                    Integer.parseInt(current[2].trim()),
                                                    Integer.parseInt(current[3].trim()),
                                                    Integer.parseInt(current[4].trim()),
                                                    Integer.parseInt(current[5].trim()));
             }
         }
      }
      catch(Exception e) {
         System.out.println("\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<Error de archivo>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
         // e.printStackTrace();
      } 
      finally {
         // En el finally cerramos el fichero, para asegurarnos
         // que se cierra tanto si todo va bien como si salta
         // una excepcion.
         try {                   
            if( null != fileReader ) {  
               fileReader.close();    
            }                 
         } 
         catch (Exception e2) {
            e2.printStackTrace();
         }
      }
    return procesos;
    } // fin Setprocesos  
}
