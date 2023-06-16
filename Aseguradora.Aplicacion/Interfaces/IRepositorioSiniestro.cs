using Aseguradora.Aplicacion.Entidades;
namespace Aseguradora.Aplicacion.Interfaces;

public interface IRepositorioSiniestro
{
    public void AgregarSiniestro(Siniestro s);
    public void ModificarSiniestro(Siniestro s);
    public Siniestro EliminarSiniestro(int id);
    List<Siniestro> ListarSiniestros();
    public Siniestro? BuscarSiniestro(int id);
}