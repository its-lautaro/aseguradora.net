namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entidades;

public class RepositorioSiniestroSQL : IRepositorioSiniestro
{
    AseguradoraContext db = new AseguradoraContext();
    public void AgregarSiniestro(Siniestro s)
    {
        db.Add(s);
        db.SaveChanges();
    }
    public Siniestro EliminarSiniestro(int id)
    {
        var borrarS = db.Siniestros.Find(id);
        if (borrarS == null) throw new Exception("No se encontro el siniestro con ese id");

        db.Remove(borrarS); //se borra realmente con el db.SaveChanges()
        db.SaveChanges();

        return borrarS;
    }
    public void ModificarSiniestro(Siniestro siniestro)
    {
        //La busca por Id
        var existente = db.Siniestros.Find(siniestro.Id);

        if (existente == null) throw new Exception("No se encontro el siniestro con ese id\n");

        existente.PolizaId = siniestro.PolizaId;
        existente.Descripcion = siniestro.Descripcion;
        existente.Direccion = siniestro.Direccion;
        existente.Fecha_ingreso = siniestro.Fecha_ingreso;
        existente.Fecha_incidente = siniestro.Fecha_incidente;

        db.SaveChanges();
    }
    public List<Siniestro> ListarSiniestros()
    {
        List<Siniestro> lista = db.Siniestros.ToList();
        return lista;
    }
}
