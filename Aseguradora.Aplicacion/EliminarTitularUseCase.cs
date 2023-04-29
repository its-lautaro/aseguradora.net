namespace Aseguradora.Aplicacion;

public class EliminarTitularUseCase
{
    private readonly IRepositorioVehiculo _repoV;
    private readonly IRepositorioTitular _repoT;
    public EliminarTitularUseCase(IRepositorioTitular repoT,IRepositorioVehiculo repoV)
    {
        _repoV = repoV;
        _repoT = repoT;
    }
    public void Ejecutar(int dni)
    {   
        Titular eliminado = _repoT.EliminarTitular(dni);
        List<Vehiculo> list = _repoV.ListarVehiculos();

        foreach (Vehiculo v in list){
            if (v.IdTitular == eliminado.Id) _repoV.EliminarVehiculo(v.Id);
        }
    }    
}