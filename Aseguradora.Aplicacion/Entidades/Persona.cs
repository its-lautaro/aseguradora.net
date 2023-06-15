namespace Aseguradora.Aplicacion.Entidades;

public abstract class Persona
{
    public int DNI { get; set; }
    public string Apellido { get; set; }
    public string Nombre { get; set; }
    public int Telefono { get; set; }

    public Persona(){
        this.DNI=-1;
        this.Apellido="";
        this.Nombre="";
        this.Telefono=-1;
    }
}
