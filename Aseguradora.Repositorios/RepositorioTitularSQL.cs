using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
namespace Aseguradora.Repositorios;

public class RepositorioTitularSQL: DbContext, IRepositorioTitular
{
    #nullable disable
    public DbSet<Titular> Titulares {get; set;}
    #nullable restore
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=Aseguradora.sqlite");
    }
    public void AgregarTitular(Titular t){
        

    }
    private bool unico(Titular t)
    {
        List<Titular> list = ListarTitulares();
        int dni = t.DNI;
        foreach (Titular i in list)
        {
            if (i.DNI == dni)
            {
                return false;
            }
        }
        return true;
    }
    public void ModificarTitular(Titular t){

    }

    public Titular EliminarTitular(int dni){
        Titular t=new Titular(1,"test","test",1,"test","test");
        
        return t;
    }
    public List<Titular> ListarTitulares()
    {
        return Titulares.ToList<Titular>();
    }
}
