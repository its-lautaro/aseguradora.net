namespace Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;
public class EliminarSiniestroUseCase
{
    private readonly IRepositorioSiniestro _repoS;

    private readonly EliminarTerceroUseCase eliminarTercero;
    private readonly ListarTercerosUseCase listarTerceros;
    public EliminarSiniestroUseCase(IRepositorioTercero repoT, IRepositorioSiniestro repoS)
    {
        _repoS = repoS;

        eliminarTercero = new EliminarTerceroUseCase(repoT);
        listarTerceros = new ListarTercerosUseCase(repoT);
    }
    public void Ejecutar(int id)
    {
        _repoS.EliminarSiniestro(id);

        //puede haber mas de un tercero involucrado en el siniestro
        List<Tercero> terceros = listarTerceros.Ejecutar();
        foreach (Tercero t in terceros)
        {
            if (t.SiniestroId == id)
            {
                eliminarTercero.Ejecutar(t.Id);
            }
        }
    }
}