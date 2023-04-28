namespace Aseguradora.Aplicacion;

public class Titular : Persona
{
    public string Direccion { get; set; }
    public string Correo { get; set; }

    public List<int> Vehiculos;
    
    public Titular(int dni, string apellido, string nombre, int tel, string direccion, string correo) : base(dni, apellido, nombre, tel)
    {
        Correo = correo;
        Direccion = direccion;
    }

    public override string ToString()
    {
        return $"{Id}: {DNI} {Apellido}, {Nombre} {Direccion} {Telefono} {Correo}";
    }
}