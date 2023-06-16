namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class EliminarPolizaUseCase
{
    private readonly IRepositorioPoliza _repoP;

    private readonly EliminarSiniestroUseCase eliminarSiniestro;
    private readonly ListarSiniestrosUseCase listarSiniestros;

    public EliminarPolizaUseCase(IRepositorioPoliza repoP, IRepositorioSiniestro repoS, IRepositorioTercero repoT)
    {
        this._repoP = repoP;

        eliminarSiniestro = new EliminarSiniestroUseCase(repoT,repoS);
        listarSiniestros = new ListarSiniestrosUseCase(repoS);
    }
    public void Ejecutar(int id)
    {
        _repoP.EliminarPoliza(id);
        //puede haber mas de un siniestro por poliza
        List<Siniestro> siniestros = listarSiniestros.Ejecutar();
        
        foreach (Siniestro s in siniestros)
        {
            if (s.PolizaId == id)
            {
                eliminarSiniestro.Ejecutar(s.Id);
            }
        }
    }
}