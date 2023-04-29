namespace Aseguradora.Aplicacion;

public interface IRepositorioTitular
{
    public void AgregarTitular(Titular t);
    public void ModificarTitular(Titular t);
    public void EliminarTitular(int dni);
    List<Titular> ListarTitulares();
    List<Vehiculo> ListarTitularesConSusVehiculos();
}