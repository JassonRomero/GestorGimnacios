package models;

public class Gimnacios {

    private String nombre_negocio;
    private String descripcion;
    private String ubicacion;
    private String capacidad_maxima;
    private int porcentaje_permitido;


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

    public String getCapacidad_maxima() {
        return capacidad_maxima;
    }

    public void setCapacidad_maxima(String capacidad_maxima) {
        this.capacidad_maxima = capacidad_maxima;
    }

    public int getPorcentaje_permitido() {
        return porcentaje_permitido;
    }

    public void setPorcentaje_permitido(int porcentaje_permitido) {
        this.porcentaje_permitido = porcentaje_permitido;
    }



}
