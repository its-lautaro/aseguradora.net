using Aseguradora.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
namespace Aseguradora.Repositorios;

public class AseguradoraContext : DbContext
{

    private static AseguradoraContext? instancia;
    
    #nullable disable
    public DbSet<Titular> Titulares { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Tercero> Terceros { get; set; }
    public DbSet<Siniestro> Siniestros { get; set; }
    public DbSet<Poliza> Polizas { get; set; }
    #nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=Aseguradora.sqlite");
    }

    private AseguradoraContext()
    {
        //Se asegura que exista la base de datos
        Database.EnsureCreated();
        if (Titulares.Count() == 0)
        {
            PopularDB();
        }
    }

    private void PopularDB()
    {
        Titular t = new Titular(42195854, "La Vecchia", "Lautaro", 221, "Wallaby 42, Sydney", "lautaro@mail.com");
        Add(t);
        t = new Titular(42765432, "Segovia", "Maite", 221, "La villa", "maite@mail.com");
        Add(t);
        Vehiculo v = new Vehiculo("AA405SN", "Toyota", 2016, 1);
        Add(v);
        v = new Vehiculo("GZT 204", "Toyota", 2016, 2);
        Add(v);
        SaveChanges();
    }

    public static AseguradoraContext Instancia()
    {
        if (instancia == null)
        {
            instancia = new AseguradoraContext();
        }
        return instancia;
    }
}