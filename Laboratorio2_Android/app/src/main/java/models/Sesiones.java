package models;

public class Sesiones {

    private Integer codSesion;
    private String gimnasioReserva;
    private String fechaReserva;
    private String horario;
    private int cupos;

    public Integer getCodSesion() {
        return codSesion;
    }

    public void setCodSesion(Integer codSesion) {
        this.codSesion = codSesion;
    }

    public String getGimnasioReserva() {
        return gimnasioReserva;
    }

    public void setGimnasioReserva(String gimnasioReserva) {
        this.gimnasioReserva = gimnasioReserva;
    }

    public String getFechaReserva() {
        return fechaReserva;
    }

    public void setFechaReserva(String fechaReserva) {
        this.fechaReserva = fechaReserva;
    }

    public String getHorario() {
        return horario;
    }

    public void setHorario(String horario) {
        this.horario = horario;
    }

    public int getCupos() {
        return cupos;
    }

    public void setCupos(int cupos) {
        this.cupos = cupos;
    }


}
