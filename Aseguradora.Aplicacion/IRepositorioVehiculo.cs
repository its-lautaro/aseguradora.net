namespace Aseguradora.Aplicacion;

public interface IRepositorioVehiculo {
    void AgregarVehiculo(Vehiculo vehiculo);
    void ModificarVehiculo(int id);
    void EliminarVehiculo(int id);
    List<Vehiculo> ListarVehiculos();
}