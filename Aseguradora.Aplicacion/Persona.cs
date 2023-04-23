namespace Aseguradora.Aplicacion;
/*
Consultar implementacion. Deben ser abstractas las propiedades?
*/
public abstract class Persona
{
    public int DNI { get; set; }
    private int _id;
    public int Id
    {
        get{
            return _id;
        }
        set
        {
            _id = value;
            _id++;
        }
    }
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
