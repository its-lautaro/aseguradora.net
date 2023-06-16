namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class EliminarVehiculoUseCase
{
    private readonly IRepositorioVehiculo _repoV;
    private EliminarPolizaUseCase eliminarPoliza;
    private ListarPolizasUseCase listarPolizas;

    public EliminarVehiculoUseCase(IRepositorioVehiculo repoV, IRepositorioPoliza repoP, IRepositorioSiniestro repoS, IRepositorioTercero repoT)
    {
        this._repoV = repoV;
        
        eliminarPoliza = new EliminarPolizaUseCase(repoP,repoS,repoT);
        listarPolizas = new ListarPolizasUseCase(repoP);
    }
    public void Ejecutar(int id)
    {
        _repoV.EliminarVehiculo(id);
        int idP =-1;
        //suponiendo que hay una poliza por vehiculo
        List<Poliza> polizas = listarPolizas.Ejecutar();

        foreach(Poliza poliza in polizas){
            if(poliza.VehiculoId == id){
                idP=poliza.Id;
                break;
            }
        }
        //chequeo que tenga poliza
        if(idP!=-1)  eliminarPoliza.Ejecutar(idP);
    }    
}