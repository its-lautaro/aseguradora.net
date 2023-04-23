namespace Aseguradora.Aplicacion;

public class Poliza
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
    public int IdVehiculo { get; set; }
    public int ValorAsegurado { get; set; }
    public int Franquicia { get; set; }

    public enum TipoCobertura{
        ResponsabilidadCivil,
        TodoRiesgo
    }
    public TipoCobertura Cobertura { get; set; }
    public DateTime Fecha_inicio { get; set; }
    public DateTime Fecha_fin { get; set; }

    public Poliza(){} //idem Vehiculo

    public Poliza (int idvehiculo, int valorasegurado, int franquicia, TipoCobertura cobertura, DateTime fecha_inicio, DateTime fecha_fin){
        Id=s_id;
        IdVehiculo=idvehiculo;
        ValorAsegurado=valorasegurado;
        Franquicia=franquicia;
        Cobertura=cobertura;
        Fecha_inicio=fecha_inicio;
        Fecha_fin=fecha_fin;
    }
}