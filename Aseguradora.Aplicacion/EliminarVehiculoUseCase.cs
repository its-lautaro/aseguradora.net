namespace Aseguradora.Aplicacion;

public class EliminarVehiculoUseCase
{
    private readonly IRepositorioVehiculo _repoV;
    private readonly IRepositorioPoliza _repoP;

    public EliminarVehiculoUseCase(IRepositorioVehiculo repoV, IRepositorioPoliza repoP)
    {
        this._repoV = repoV;
        this._repoP= repoP;
    }
    public void Ejecutar(int id)
    {
        _repoV.EliminarVehiculo(id);
        int idP =-1;
        //suponiendo que hay una poliza por vehiculo
        List<Poliza> polizas = _repoP.ListarPolizas();
        foreach(Poliza poliza in polizas){
            if(poliza.IdVehiculo == id){
                idP=poliza.Id;
                break;
            }
        }
        _repoP.EliminarPoliza(idP);
    }    
}