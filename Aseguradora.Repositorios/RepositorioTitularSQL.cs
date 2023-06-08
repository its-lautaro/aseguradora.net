using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
namespace Aseguradora.Repositorios;

public class RepositorioTitularSQL :  IRepositorioTitular
{
    AseguradoraContext db = new AseguradoraContext();
    public void AgregarTitular(Titular t)
    {
        if(!esUnico(t)) throw new Exception("El dni ya existe");

        db.Add(t);
        db.SaveChanges();
    }

    private bool esUnico(Titular t)
    {
        if (db.Titulares.Any(n => n.DNI == t.DNI)) return true;
        else return false;

    }

    public void ModificarTitular(Titular t)
    {
        //Lo busca por DNI
        var existente = db.Titulares.Where(n=>n.DNI == t.DNI).SingleOrDefault();
        
        if (existente == null) throw new Exception("No se pudo modificar, no existe\n");

        existente.Apellido = t.Apellido;
        existente.Nombre = t.Nombre;
        existente.Correo = t.Correo;
        existente.Direccion = t.Direccion;
        existente.Vehiculos = t.Vehiculos;
        existente.Telefono=t.Telefono;

        db.SaveChanges();
    }

    public Titular EliminarTitular(int dni)
    {
        Titular t = new Titular(1, "test", "test", 1, "test", "test");

        return t;
    }
    public List<Titular> ListarTitulares()
    {
        return db.Titulares.ToList<Titular>();
    }
}
