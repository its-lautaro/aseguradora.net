namespace Aseguradora.Aplicacion.Entidades;

public class Siniestro{
    public int Id { get; set; }
    public int? PolizaId { get; set; }
    public DateTime? Fecha_ingreso { get; set; }
    public DateTime? Fecha_incidente { get; set; }
    public string? Direccion { get; set; }
    public string? Descripcion { get; set; }

    public Siniestro (){}
    public override string ToString()
    {
        return $"{Id}: Poliza: {PolizaId}, Fecha ingreso: {Fecha_ingreso}, Fecha incidente: {Fecha_incidente}, Direccion: {Direccion},  Descripcion: {Descripcion}";
    }
}