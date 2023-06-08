namespace Aseguradora.Aplicacion.Entidades;

public class Tercero : Persona
{
    public int Id { get; set; }
    
    public string? Aseguradora { get; set; }

    public int? SiniestroId { get; set; }

    public Tercero(){}
    
    public override string ToString()
    {
        return $"{Id}: {DNI} {Apellido}, {Nombre} {Telefono} {Aseguradora} {SiniestroId}";
    }

}