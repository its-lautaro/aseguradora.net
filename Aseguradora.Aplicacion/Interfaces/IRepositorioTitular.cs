using Aseguradora.Aplicacion.Entidades;
namespace Aseguradora.Aplicacion.Interfaces;

public interface IRepositorioTitular
{
    public void AgregarTitular(Titular t);
    public void ModificarTitular(Titular t);
    public Titular EliminarTitular(int dni);
    //Recibe el dni o el dni parcial de un titular. Devuelve una lista con las coincidencias. La lista puede estar vacia.
    public Titular? BuscarTitular(int dni);

    List<Titular> ListarTitulares();
}