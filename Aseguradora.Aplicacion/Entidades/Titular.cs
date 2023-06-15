namespace Aseguradora.Aplicacion.Entidades;

public class Titular : Persona
{
    public int Id { get; set; }
    public string Direccion { get; set; }
    public string Correo { get; set; }

    public List<Vehiculo> Vehiculos{
        get;
        set;
    }
    public Titular(){
        this.Direccion="";
        this.Correo="";
        Vehiculos= new List<Vehiculo>();
    }

    public override string ToString()
    {
        return $"{Id}: DNI:{DNI} Apellido:{Apellido}, Nombre:{Nombre} Direccion:{Direccion} Tel.:{Telefono} Mail:{Correo}";
    }
}