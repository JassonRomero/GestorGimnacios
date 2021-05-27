package models;



public class Login  {

    private String nombre_negocio;
    private String descripcion;
    private String ubicacion;
    private int capacidad_maxima;
    private int porcentaje_permitido;
    private String horarioA;
    private String horarioC;


    public String getNombre_negocio() {
        return nombre_negocio;
    }

    public void setNombre_negocio(String nombre_negocio) {
        this.nombre_negocio = nombre_negocio;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public String getUbicacion() {
        return ubicacion;
    }

    public void setUbicacion(String ubicacion) {
        this.ubicacion = ubicacion;
    }

    public int getCapacidad_maxima() {
        return capacidad_maxima;
    }

    public void setCapacidad_maxima(int capacidad_maxima) {
        this.capacidad_maxima = capacidad_maxima;
    }

    public int getPorcentajePermitido() {
        return porcentaje_permitido;
    }

    public void setPorcentajePermitido(int porcentajePermitido) {
        this.porcentaje_permitido = porcentajePermitido;

    }

    public String getHorarioA() {
        return horarioA;
    }

    public void setHorarioA(String horarioA) {
        this.horarioA = horarioA;
    }

    public String getHorarioC() {
        return horarioC;
    }

    public void setHorarioC(String horarioC) {
        this.horarioC = horarioC;
    }

    @Override
    public String toString() {
        return "Login{" +
                "nombre_negocio='" + nombre_negocio + '\'' +
                ", descripcion='" + descripcion + '\'' +
                ", ubicacion='" + ubicacion + '\'' +
                ", capacidad_maxima=" + capacidad_maxima +
                ", porcentaje_permitido=" + porcentaje_permitido +
                '}';
    }
}