namespace Aseguradora.Aplicacion;

public class Vehiculo
{
    static int s_id = 0;
    private int _id;
    public int Id
    {
        get { return _id; }
        set
        {
            _id = value;
            s_id++;
        }
    }
    public string? Dominio { get; set; }
    public string? Marca { get; set; }
    public int Año { get; set; }
    public int IdTitular { get; set; }

    public Vehiculo(){} //lo uso para hacer la lista

    public Vehiculo(string dominio, string marca, int año, int idtitular){
        Id=s_id;
        Dominio=dominio;
        Marca=marca;
        Año=año;
        IdTitular=idtitular;
    }
}