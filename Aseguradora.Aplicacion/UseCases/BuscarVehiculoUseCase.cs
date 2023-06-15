namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class BuscarVehiculoUseCase
{
    private readonly IRepositorioVehiculo _repo;
    public BuscarVehiculoUseCase(IRepositorioVehiculo repo)
    {
        this._repo = repo;
    }
    public Vehiculo? Ejecutar(int id)
    {
        return _repo.BuscarVehiculo(id);
    }    
}