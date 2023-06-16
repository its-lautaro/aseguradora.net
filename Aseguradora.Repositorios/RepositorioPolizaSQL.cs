namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entidades;

public class RepositorioPolizaSQL : IRepositorioPoliza
{
    AseguradoraContext db = new AseguradoraContext();
    public void AgregarPoliza(Poliza poliza)
    {
        if (poliza.Fecha_inicio == null | poliza.Fecha_fin == null) throw new Exception("La poliza debe tener fecha de inicio y fin de cobertura");
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
    public Poliza BuscarPoliza(int id){
        Poliza? encontrado = db.Polizas.Where(n => n.Id == id).SingleOrDefault();
        if (encontrado == null) throw new Exception("La poliza buscada no existe");
        return encontrado;
    }
}