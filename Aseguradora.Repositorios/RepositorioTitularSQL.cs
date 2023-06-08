using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
namespace Aseguradora.Repositorios;

public class RepositorioTitularSQL: DbContext, IRepositorioTitular
{
    DbSet<Titular> titulares = AseguradoraContext.Instancia().Titulares;

    public void AgregarTitular(Titular t){
        AseguradoraContext.Instancia().Add(t);
        AseguradoraContext.Instancia().SaveChanges();
    }
    public void ModificarTitular(Titular t){

    }

    public Titular EliminarTitular(int dni){
        Titular t=new Titular(1,"test","test",1,"test","test");
        
        return t;
    }
    public List<Titular> ListarTitulares()
    {
        DbSet<Titular> titulares = AseguradoraContext.Instancia().Titulares;
        return titulares.ToList<Titular>();
    }
}
