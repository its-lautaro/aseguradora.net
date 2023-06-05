namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class AgregarSiniestroUseCase
{
    private readonly IRepositorioSiniestro _repoS;
    private readonly IRepositorioPoliza _repoP;
    public AgregarSiniestroUseCase(IRepositorioSiniestro repoS, IRepositorioPoliza repoP)
    {
        this._repoS = repoS;
        this._repoP = repoP;
    }
    public void Ejecutar(Siniestro siniestro)
    {
        List<Poliza> polizas= _repoP.ListarPolizas();
        DateTime? fechaI=null, fechaF=null;
        foreach(Poliza p in polizas){
            if (p.Id==siniestro.IdPoliza){
                fechaI=p.Fecha_inicio;
                fechaF=p.Fecha_fin;
                break;
            }
        }
        if(fechaI>siniestro.Fecha_incidente && fechaF<siniestro.Fecha_incidente){
            _repoS.AgregarSiniestro(siniestro);
        }
        else{
            throw new Exception ("El titular no cuenta con cobertura vigente");
        }
    }    
}