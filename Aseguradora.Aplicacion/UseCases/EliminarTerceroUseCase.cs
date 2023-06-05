namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class EliminarTerceroUseCase
{
    private readonly IRepositorioTercero _repoT;
    public EliminarTerceroUseCase(IRepositorioTercero repoT)
    {
        _repoT = repoT;
    }
    public void Ejecutar(int id)
    {   
        _repoT.EliminarTercero(id);
    }    
}