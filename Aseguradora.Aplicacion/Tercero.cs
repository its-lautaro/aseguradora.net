namespace Aseguradora.Aplicacion;

public class Tercero : Persona
{
    public string Aseguradora { get; set; }

    public string IdSiniestro { get; set; }

    public Tercero(int dni, string apellido, string nombre, int tel, string aseguradora, string idsiniestro) : base(dni, apellido, nombre, tel)
    {
        Aseguradora = aseguradora;
        IdSiniestro = idsiniestro;
    }

}