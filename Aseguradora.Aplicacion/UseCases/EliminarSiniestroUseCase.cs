namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class EliminarSiniestroUseCase
{
    private readonly IRepositorioSiniestro _repoS;
    private readonly IRepositorioTercero _repoT;
    public EliminarSiniestroUseCase(IRepositorioTercero repoT,IRepositorioSiniestro repoS)
    {
        _repoS = repoS;
        _repoT = repoT;
    }
    public void Ejecutar(int id)
    {   
        _repoS.EliminarSiniestro(id);

        List<Tercero> list = _repoT.ListarTerceros();
        int idT=-1;
        //Eliminar el tercero involucrado en el siniestro
        foreach (Tercero t in list){
            if (t.IdSiniestro == id ){
                idT=t.Id;
                break;
            }
        }
        _repoT.EliminarTercero(idT);
    }    
}