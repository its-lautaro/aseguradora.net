namespace Aseguradora.Aplicacion;

public abstract class Persona
{
    public int DNI { get; set; }
    protected int _id;
    
    public int Id{get;set;}
    public string Apellido { get; set; }
    public string Nombre { get; set; }
    public int Telefono { get; set; }

    public Persona(int dni, string apellido, string nombre, int telefono)
    {
        Id = -1;
        DNI = dni;
        Apellido = apellido;
        Nombre = nombre;
        Telefono = telefono;
    }
}
