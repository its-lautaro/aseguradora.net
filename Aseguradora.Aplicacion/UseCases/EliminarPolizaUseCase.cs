namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class EliminarPolizaUseCase
{
    private readonly IRepositorioPoliza _repoP;
    private readonly IRepositorioSiniestro _repoS;

    public EliminarPolizaUseCase(IRepositorioPoliza repoP, IRepositorioSiniestro repoS)
    {
        this._repoP = repoP;
        this._repoS = repoS;
    }
    public void Ejecutar(int id)
    {
        _repoP.EliminarPoliza(id);
        //puede haber mas de un siniestro por poliza
        List<Siniestro> siniestros = _repoS.ListarSiniestros();
        List<int>? indiceS = new List<int>();
        foreach (Siniestro s in siniestros){
            if (s.PolizaId == id){
                indiceS.Add(s.Id);
            }
        }
        foreach (int i in indiceS){
            siniestros.RemoveAt(i);
        }
    }    
}