namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entidades;

public class RepositorioVehiculoSQL : IRepositorioVehiculo
{
    AseguradoraContext db = new AseguradoraContext();
    public void AgregarVehiculo(Vehiculo vehiculo)
    {
        db.Add(vehiculo);
        db.SaveChanges();
    }
    public void ModificarVehiculo(Vehiculo vehiculo)
    {
        //Lo busca por Id
        var existente = db.Vehiculos.Where(n => n.Id == vehiculo.Id).SingleOrDefault();

        if (existente == null) throw new Exception("No se encontro el vehiculo con ese id\n");

        existente.Dominio = vehiculo.Dominio;
        existente.Marca = vehiculo.Marca;
        existente.Año = vehiculo.Año;
        existente.TitularId = vehiculo.TitularId;

        db.SaveChanges();
    }
    public void EliminarVehiculo(int id)
    {
        var borrarV = db.Vehiculos.Where(n => n.Id == id).SingleOrDefault();
        if (borrarV == null) throw new Exception("No se encontro el vehiculo con ese id");

        db.Remove(borrarV); //se borra realmente con el db.SaveChanges()
        db.SaveChanges();
    }
    public List<Vehiculo> ListarVehiculos()
    {
        List<Vehiculo> lista = db.Vehiculos.ToList();
        return lista;
    }

    public List<Vehiculo> ListarVehiculosPorTitular(int idT)
    {
        List<Vehiculo> lista = db.Vehiculos.Where(n => n.TitularId == idT).ToList();
        return lista;

    }
}