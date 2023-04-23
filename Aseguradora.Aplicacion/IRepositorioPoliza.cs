namespace Aseguradora.Aplicacion;

public interface IRepositorioPoliza {
    void AgregarPoliza(Poliza poliza);
    void ModificarPoliza(int id);
    void EliminarPoliza(int id);
    List<Poliza> ListarPolizas();
}