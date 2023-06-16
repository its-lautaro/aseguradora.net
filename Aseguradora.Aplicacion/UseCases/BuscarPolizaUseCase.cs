namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class BuscarPolizaUseCase
{
    private readonly IRepositorioPoliza _repo;
    public BuscarPolizaUseCase(IRepositorioPoliza repo)
    {
        this._repo = repo;
    }
    public Poliza Ejecutar(int id)
    {
        return _repo.BuscarPoliza(id);
    }    
}