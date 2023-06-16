namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class ModificarSiniestroUseCase
{
    private readonly IRepositorioSiniestro _repo;
    private ListarPolizasUseCase listarPolizas;
    public ModificarSiniestroUseCase(IRepositorioSiniestro repo, IRepositorioPoliza repoP)
    {
        this._repo = repo;
        listarPolizas = new ListarPolizasUseCase(repoP);
    }
    public void Ejecutar(Siniestro siniestro)
    {
        List<Poliza> polizas = listarPolizas.Ejecutar();
        DateTime? fechaI = null, fechaF = null;
        foreach (Poliza p in polizas)
        {
            if (p.Id == siniestro.PolizaId)
            {
                fechaI = p.Fecha_inicio;
                fechaF = p.Fecha_fin;
                break;
            }
        }
        if (fechaI < siniestro.Fecha_incidente && fechaF > siniestro.Fecha_incidente)
        {
            _repo.ModificarSiniestro(siniestro);
        }
        else
        {
            throw new Exception("El titular no cuenta con cobertura vigente");
        }
        
    }
}