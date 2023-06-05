using Aseguradora.Aplicacion.Entidades;
namespace Aseguradora.Aplicacion.Interfaces;

public interface IRepositorioTercero
{
    public void AgregarTercero(Tercero t);
    public void ModificarTercero(Tercero t);
    public void EliminarTercero(int id);
    List<Tercero> ListarTerceros();
}