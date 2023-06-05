namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class AgregarSiniestroUseCase
{
    private readonly IRepositorioSiniestro _repo;
    public AgregarSiniestroUseCase(IRepositorioSiniestro repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Siniestro siniestro)
    {
        _repo.AgregarSiniestro(siniestro);
    }    
}