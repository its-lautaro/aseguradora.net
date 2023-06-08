using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
namespace Aseguradora.Repositorios;

public class RepositorioTitularSQL : DbContext, IRepositorioTitular
{
#nullable disable
    public DbSet<Titular> Titulares { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
#nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=Aseguradora.sqlite");
    }

    public void AgregarTitular(Titular t)
    {
        if(!esUnico(t)) throw new Exception("El dni ya existe");

        Add(t);
        SaveChanges();
    }

    private bool esUnico(Titular t)
    {
        if (Titulares.Where<Titular>(n => n.DNI == t.DNI).Count() == 0) return true;
        else return false;

    }

    public void ModificarTitular(Titular t)
    {


    }

    public Titular EliminarTitular(int dni)
    {
        Titular t = new Titular(1, "test", "test", 1, "test", "test");

        return t;
    }
    public List<Titular> ListarTitulares()
    {
        return Titulares.ToList<Titular>();
    }
}
