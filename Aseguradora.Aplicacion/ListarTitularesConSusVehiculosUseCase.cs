namespace Aseguradora.Aplicacion;

public class ListarTitularesConSusVehiculosUseCase
{
    private readonly IRepositorioTitular _repo;
    public ListarTitularesConSusVehiculosUseCase(IRepositorioTitular repo)
    {
        this._repo = repo;
    }
    public void Ejecutar()
    {
        _repo.ListarTitularesConSusVehiculos();
    }    
}