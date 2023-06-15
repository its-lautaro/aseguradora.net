namespace Aseguradora.Aplicacion.Entidades;

public class Vehiculo
{
    public int Id
    {
        get ;set; }
    public string Dominio { get; set; }
    public string Marca { get; set; }
    public int Año { get; set; }
    public int TitularId { get; set; }

    public Vehiculo(){
        this.Dominio="";
        this.Marca="";
        this.Año=-1;
        this.TitularId=-1;
    } //lo uso para hacer la lista

    public override string ToString()
    {
        return $"{Id}: Titular: {TitularId}, Dominio: {Dominio}, Marca: {Marca}, Año: {Año}";
    }
}