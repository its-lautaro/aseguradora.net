namespace Aseguradora.Aplicacion.Entidades;

public class Tercero : Persona
{
    public int Id { get; set; }
    
    public string Aseguradora { get; set; }

    public int SiniestroId { get; set; }

    public Tercero(int DNI, string Apellido, string Nombre, int Telefono, string Aseguradora, int IdSiniestro) : base(DNI, Apellido, Nombre, Telefono)
    {
        this.Aseguradora = Aseguradora;
        this.SiniestroId = IdSiniestro;
    }

    public override string ToString()
    {
        return $"{Id}: {DNI} {Apellido}, {Nombre} {Telefono} {Aseguradora} {SiniestroId}";
    }

}