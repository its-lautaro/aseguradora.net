namespace Aseguradora.Aplicacion.Entidades;

public class Siniestro{
    static int s_id = 0;
    private int _id;
    public int Id
    {
        get { return _id; }
        private set
        {
            _id = value;
            s_id++;
        }
    }
    public int IdPoliza { get; set; }
    public DateTime Fecha_ingreso { get; set; }
    public DateTime Fecha_incidente { get; set; }
    public string Direccion { get; set; }
    public string Descripcion { get; set; }

    public Siniestro(int idpoliza, DateTime fecha_ingreso, DateTime fecha_incidente, string direccion, string descripcion){
        Id=s_id;
        IdPoliza=idpoliza;
        Fecha_ingreso=fecha_ingreso;
        Fecha_incidente=fecha_incidente;
        Direccion=direccion;
        Descripcion=descripcion;
    }
}