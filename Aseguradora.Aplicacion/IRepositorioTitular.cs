namespace Aseguradora.Aplicacion;

public interface IRepositorioTitular
{
    public void AgregarTitular(Titular t);
    public void ModificarTitular(int dni);
    public void EliminarTitular(int dni);
    List<Titular> ListarTitulares();
    
}