namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class AgregarTitularUseCase
{
    private readonly IRepositorioTitular _repo;
    public AgregarTitularUseCase(IRepositorioTitular repo)
    {
        this._repo = repo;
    }
    
    public void Ejecutar(Titular titular)
    {
        _repo.AgregarTitular(titular);

    }
}