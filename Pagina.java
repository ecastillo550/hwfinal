package sistemaoperativo;

public class Pagina {
    private int numero;
    private int residencia;
    private int llegada;
    private int acceso;
    private int NURlectura;
    private int NURescritura;
    private int modificacion;
    private Pagina nextPagina;
    
    public Pagina(int numero, int residencia, int llegada, int acceso, int NURlectura, int NURescritura, int modificacion){
        this.setNumero(numero);
        this.setResidencia(residencia);
        this.setLlegada(llegada);
        this.setAcceso(acceso);
        this.setNURlectura(NURlectura);
        this.setNURescritura(NURescritura);
        this.setModificacion(modificacion); 
        nextPagina = null;
    }
    public Pagina(){
        this.setNumero(0);
        this.setResidencia(0);
        this.setLlegada(0);
        this.setAcceso(0);
        this.setNURlectura(0);
        this.setNURescritura(0);
        this.setModificacion(0); 
        nextPagina = null;
    }
    
    public void setNumero(int numero){
        this.numero = numero;
    }
    public void setResidencia(int residencia){
        this.residencia = residencia;
    }
    public void setLlegada(int llegada){
        this.llegada = llegada;
    }
    public void setAcceso(int acceso){
        this.acceso = acceso;
    }
    public void setNURlectura(int NURlectura){
        this.NURlectura = NURlectura;
    }
    public void setNURescritura(int NURescritura){
        this.NURescritura = NURescritura;
    }
    public void setModificacion(int modificacion){
        this.modificacion = modificacion;
    }
    public void setNextPagina(Pagina nextPagina){
        this.nextPagina = nextPagina;
    }
    
    public int getNumero(){
        return numero;
    }
    public int getResidencia(){
        return residencia;
    }
    public int getLlegada(){
        return llegada;
    }
    public int getAcceso(){
        return acceso;
    }
    public int getNURlectura(){
        return NURlectura;
    }
    public int getNURescritura(){
        return NURescritura;
    }
    public int getModificacion(){
        return modificacion;
    }
    public Pagina getNextPagina(){
        return nextPagina;
    }
    
}
