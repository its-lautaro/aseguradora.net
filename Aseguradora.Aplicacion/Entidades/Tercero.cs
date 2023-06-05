namespace Aseguradora.Aplicacion.Entidades;

public class Tercero : Persona
{
    public string Aseguradora { get; set; }

    public int IdSiniestro { get; set; }

    public Tercero(int dni, string apellido, string nombre, int tel, string aseguradora, int idsiniestro) : base(dni, apellido, nombre, tel)
    {
        Aseguradora = aseguradora;
        IdSiniestro = idsiniestro;
    }

}