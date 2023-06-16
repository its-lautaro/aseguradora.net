namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class BuscarSiniestroUseCase
{
    private readonly IRepositorioSiniestro _repo;
    public BuscarSiniestroUseCase(IRepositorioSiniestro repo)
    {
        this._repo = repo;
    }
    public Siniestro? Ejecutar(int id)
    {
        return _repo.BuscarSiniestro(id);
    }    
}