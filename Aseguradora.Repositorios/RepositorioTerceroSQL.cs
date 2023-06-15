namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entidades;

public class RepositorioTerceroSQL : IRepositorioTercero
{
    AseguradoraContext db = new AseguradoraContext();
    public void AgregarTercero(Tercero t)
    {
        if (!esUnico(t)) throw new Exception("Error al agregar. El dni ya existe");
        db.Terceros.Add(t);
        db.SaveChanges();
    }
    private bool esUnico(Tercero t)
    {
        if (db.Terceros.Any(n => n.DNI == t.DNI)) return false;
        else return true;
    }

    public void ModificarTercero(Tercero t)
    {
        //Lo busca por Id
        Tercero? existente = db.Terceros.Find(t.Id);

        if (existente == null) throw new Exception("Error al modificar. El tercero no existe");

        existente.Apellido = t.Apellido;
        existente.Nombre = t.Nombre;
        existente.Telefono = t.Telefono;
        existente.Aseguradora = t.Aseguradora;
        existente.DNI = t.DNI;
        existente.SiniestroId = t.SiniestroId;

        db.SaveChanges();
    }

    public void EliminarTercero(int id)
    {
        Tercero? borrar = db.Terceros.Find(id);

        if (borrar == null) throw new Exception("Error al borrar. No existe el tercero con ese id");

        db.Remove(borrar);

        db.SaveChanges();
    }
    public List<Tercero> ListarTerceros()
    {
        return db.Terceros.ToList<Tercero>();
    }
}
