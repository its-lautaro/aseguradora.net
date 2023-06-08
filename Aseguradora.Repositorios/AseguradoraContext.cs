using Aseguradora.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
namespace Aseguradora.Repositorios;

public class AseguradoraContext : DbContext
{
    
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

    public AseguradoraContext()
    {
        //Se asegura que exista la base de datos
        Database.EnsureCreated();
        //Asegurarse de setear el modo journal=DELETE
        var connection = Database.GetDbConnection();
        connection.Open();
        using (var command = connection.CreateCommand()){
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
        }
    }
}