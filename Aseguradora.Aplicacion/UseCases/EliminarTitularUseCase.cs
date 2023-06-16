namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class EliminarTitularUseCase
{
    private readonly IRepositorioTitular _repoT;

    private ListarTitularesConSusVehiculosUseCase listarTitularesConVehiculos;
    private EliminarPolizaUseCase eliminarPoliza;

    public EliminarTitularUseCase(IRepositorioTitular repoT, IRepositorioVehiculo repoV, IRepositorioPoliza repoP, IRepositorioSiniestro repoS, IRepositorioTercero repoTer)
    {
        _repoT = repoT;

        listarTitularesConVehiculos = new ListarTitularesConSusVehiculosUseCase(repoT, repoV);
        eliminarPoliza = new EliminarPolizaUseCase(repoP,repoS,repoTer);
    }
    public void Ejecutar(int dni)
    {
        //el titular a eliminar no existe
        int id;
        Titular? eliminado = _repoT.BuscarTitular(dni);
        if (eliminado!=null){
            id = eliminado.Id;
        }else{
            throw new Exception($"El titular con dni {dni} no existe");
        }

        List<Vehiculo>? vehiculos = listarTitularesConVehiculos.Ejecutar().Find(t => t.Id == id)?.Vehiculos;

        //el titular puede no tener vehiculos
        if (vehiculos != null)
        {
            foreach (Vehiculo v in vehiculos)
            {
                eliminarPoliza.Ejecutar(v.Id);
            }
        }

        //finalmente elimino el titular (elimina en cascada los vehiculos)
        _repoT.EliminarTitular(dni);
    }
}