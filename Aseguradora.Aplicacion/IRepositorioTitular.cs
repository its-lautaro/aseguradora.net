namespace Aseguradora.Aplicacion;

public interface IRepositorioTitular
{
    public void AgregarTitular(Titular t);
    public void ModificarTitular(Titular t);
    public Titular EliminarTitular(int dni);
    List<Titular> ListarTitulares();
}