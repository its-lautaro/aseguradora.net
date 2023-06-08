using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entidades;
namespace Aseguradora.Repositorios;

public class RepositorioTitularSQL : IRepositorioTitular
{
    AseguradoraContext db = new AseguradoraContext();
    public void AgregarTitular(Titular t)
    {
        if (!esUnico(t)) throw new Exception("Error al agregar. El dni ya existe");

        db.Add(t);
        db.SaveChanges();
    }

    private bool esUnico(Titular t)
    {
        if (db.Titulares.Any(n => n.DNI == t.DNI)) return false;
        else return true;

    }
    public void ModificarTitular(Titular t)
    {
        //Lo busca por DNI
        Titular? existente = db.Titulares.Where(n => n.DNI == t.DNI).SingleOrDefault();

        if (existente == null) throw new Exception("Error al modificar. El dni no existe");

        existente.Apellido = t.Apellido;
        existente.Nombre = t.Nombre;
        existente.Correo = t.Correo;
        existente.Direccion = t.Direccion;
        existente.Vehiculos = t.Vehiculos;
        existente.Telefono = t.Telefono;

        db.SaveChanges();
    }

    public Titular EliminarTitular(int dni)
    {
        Titular? borrar = db.Titulares.Where(n => n.DNI == dni).SingleOrDefault();

        if (borrar == null) throw new Exception("Error al borrar. No existe el dni");

        db.Remove(borrar);

        db.SaveChanges();

        return borrar;
    }
    public List<Titular> ListarTitulares()
    {
        return db.Titulares.ToList<Titular>();
    }
}
