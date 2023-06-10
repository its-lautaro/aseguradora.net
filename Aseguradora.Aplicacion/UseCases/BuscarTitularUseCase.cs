namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class BuscarTitularUseCase
{
    private readonly IRepositorioTitular _repo;
    public BuscarTitularUseCase(IRepositorioTitular repo)
    {
        this._repo = repo;
    }
    public Titular? Ejecutar(int dni)
    {
        return _repo.BuscarTitular(dni);
    }    
}