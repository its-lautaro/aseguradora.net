namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class BuscarTerceroUseCase
{
    private readonly IRepositorioTercero _repo;
    public BuscarTerceroUseCase(IRepositorioTercero repo)
    {
        this._repo = repo;
    }
    public Tercero? Ejecutar(int id)
    {
        return _repo.BuscarTercero(id);
    }    
}