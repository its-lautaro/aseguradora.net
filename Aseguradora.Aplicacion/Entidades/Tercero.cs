namespace Aseguradora.Aplicacion.Entidades;

public class Tercero : Persona
{
    public int Id { get; set; }
    
    public string Aseguradora { get; set; }

    public int IdSiniestro { get; set; }

    public Tercero(int DNI, string Apellido, string Nombre, int Telefono, string Aseguradora, int IdSiniestro) : base(DNI, Apellido, Nombre, Telefono)
    {
        this.Id = Id;
        this.Aseguradora = Aseguradora;
        this.IdSiniestro = IdSiniestro;
    }

    public override string ToString()
    {
        return $"{Id}: {DNI} {Apellido}, {Nombre} {Telefono} {Aseguradora} {IdSiniestro}";
    }

}