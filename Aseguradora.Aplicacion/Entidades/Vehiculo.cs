namespace Aseguradora.Aplicacion.Entidades;

public class Vehiculo
{
    public int Id
    {
        get ;set; }
    public string? Dominio { get; set; }
    public string? Marca { get; set; }
    public int Año { get; set; }
    public int TitularId { get; set; }

    public Vehiculo(){} //lo uso para hacer la lista

    public Vehiculo(string dominio, string marca, int año, int titularid){
        Dominio=dominio;
        Marca=marca;
        Año=año;
        TitularId=titularid;
    }

    public override string ToString()
    {
        return $"{Id}: Titular: {TitularId}, Dominio: {Dominio}, Marca: {Marca}, Año: {Año}";
    }
}