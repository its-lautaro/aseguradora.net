namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entidades;

public class RepositorioPolizaSQL : IRepositorioPoliza
{
    AseguradoraContext db = new AseguradoraContext();
    public void AgregarPoliza(Poliza poliza)
    {
        db.Add(poliza);
        db.SaveChanges();
    }
    public void ModificarPoliza(Poliza poliza)
    {
        //La busca por Id
        var existente = db.Polizas.Find(poliza.Id);

        if (existente == null) throw new Exception("No se encontro la poliza con ese id\n");

        existente.VehiculoId = poliza.VehiculoId;
        existente.ValorAsegurado = poliza.ValorAsegurado;
        existente.Franquicia = poliza.Franquicia;
        existente.Cobertura = poliza.Cobertura;
        existente.Fecha_inicio = poliza.Fecha_inicio;
        existente.Fecha_fin = poliza.Fecha_fin;

        db.SaveChanges();
    }
    public void EliminarPoliza(int id)
    {
        var borrarP = db.Polizas.Find(id);
        if (borrarP == null) throw new Exception("No se encontro la poliza con ese id");

        db.Remove(borrarP); //se borra realmente con el db.SaveChanges()
        db.SaveChanges();
    }
    public List<Poliza> ListarPolizas()
    {
        List<Poliza> lista = db.Polizas.ToList();
        return lista;
    }
    public Poliza? BuscarPoliza(int id){
        //La propiedad id de la poliza nunca va a ser null si esta persistido en la base de datos
        #nullable disable
        Poliza encontrado = db.Polizas.Where(n => n.Id == id).SingleOrDefault();
        #nullable restore
        return encontrado;
    }
}