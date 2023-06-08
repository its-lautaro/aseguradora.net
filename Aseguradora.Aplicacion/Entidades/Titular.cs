namespace Aseguradora.Aplicacion.Entidades;

public class Titular : Persona
{
    public int Id { get; set; }
    public string Direccion { get; set; }
    public string Correo { get; set; }

    public List<Vehiculo>? Vehiculos{
        get;
        set;
    }
    
    public Titular(int DNI, string Apellido, string Nombre, int Telefono, string Direccion, string Correo) : base(DNI, Apellido, Nombre, Telefono)
    {
        this.Correo = Correo;
        this.Direccion = Direccion;
    }

    public override string ToString()
    {
        return $"{Id}: DNI:{DNI} Apellido:{Apellido}, Nombre:{Nombre} Direccion:{Direccion} Tel.:{Telefono} Mail:{Correo}";
    }
}