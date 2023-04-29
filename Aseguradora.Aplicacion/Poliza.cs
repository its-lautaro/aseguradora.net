namespace Aseguradora.Aplicacion;

public class Poliza
{
    public int Id
    {
        get ; set;
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
        Id=-1;
        IdVehiculo=idvehiculo;
        ValorAsegurado=valorasegurado;
        Franquicia=franquicia;
        Cobertura=cobertura;
        Fecha_inicio=fecha_inicio;
        Fecha_fin=fecha_fin;
    }
    public override string ToString()
    {
        return $"{Id}: Vehiculo: {IdVehiculo}, Valor: ARS {ValorAsegurado}, Franquicia: ARS {Franquicia}, Tipo de cobertura: {Cobertura},  Vigencia desde {Fecha_inicio} hasta {Fecha_fin}";
    }
}