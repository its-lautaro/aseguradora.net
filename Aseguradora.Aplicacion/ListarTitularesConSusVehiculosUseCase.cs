namespace Aseguradora.Aplicacion;

public class ListarTitularesConSusVehiculosUseCase
{
    private readonly IRepositorioTitular _repoT;
    private readonly IRepositorioVehiculo _repoV;

    public ListarTitularesConSusVehiculosUseCase(IRepositorioTitular repoT, IRepositorioVehiculo repoV)
    {
        this._repoT = repoT;
        this._repoV = repoV;
    }
    public List<Titular> Ejecutar()
    {
        List<Titular> titulares = _repoT.ListarTitulares();
        foreach (Titular titular in titulares)
        {
            List<Vehiculo> vehiculosTitular = _repoV.ListarVehiculosPorTitular(titular.Id);
            titular.Vehiculos=vehiculosTitular;
        }
        return titulares;
    }
}