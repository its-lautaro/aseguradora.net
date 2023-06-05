namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class ListarPolizasUseCase
{
    private readonly IRepositorioPoliza _repo;
    public ListarPolizasUseCase(IRepositorioPoliza repo)
    {
        this._repo = repo;
    }
    public List<Poliza> Ejecutar()
    {
       return  _repo.ListarPolizas();
    }    
}