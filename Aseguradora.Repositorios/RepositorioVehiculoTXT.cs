namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public class RepositorioVehiculoTXT : IRepositorioVehiculo
{
    readonly string _nombreArch = "vehiculos.txt";

    public void AgregarVehiculo(Vehiculo vehiculo)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(vehiculo.Id);
        sw.WriteLine(vehiculo.Dominio);
        sw.WriteLine(vehiculo.Marca);
        sw.WriteLine(vehiculo.Año);
        sw.WriteLine(vehiculo.IdTitular);
        sw.Close();
    }
    public void ModificarVehiculo(int id) { }
    public void EliminarVehiculo(int id)
    {
        List<Vehiculo> vehiculos = ListarVehiculos();
        int pos_valid = -1;
        for (int i = vehiculos.Count - 1; i >= 0; i--)
        {
            if (vehiculos[i].Id == id)
            {
                pos_valid = i;
                break;
            }
        }
        if (pos_valid == -1)
        {
            throw new Exception("No se encontro el vehiculo con ese id");
        }
        else
        {
            vehiculos.RemoveAt(pos_valid);

        }
        GuardarLista(vehiculos);
    }
    private void GuardarLista(List<Vehiculo> lista)
    {
        using var sw = new StreamWriter(_nombreArch, false);
        foreach (Vehiculo vehiculo in lista)
        {
            sw.WriteLine(vehiculo.Id);
            sw.WriteLine(vehiculo.Dominio);
            sw.WriteLine(vehiculo.Marca);
            sw.WriteLine(vehiculo.Año);
            sw.WriteLine(vehiculo.IdTitular);
        }
        sw.Close();
    }
    public List<Vehiculo> ListarVehiculos()
    {
        var resultado = new List<Vehiculo>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var vehiculo = new Vehiculo();
            vehiculo.Id = int.Parse(sr.ReadLine() ?? "");
            vehiculo.Dominio = sr.ReadLine() ?? "";
            vehiculo.Marca = sr.ReadLine() ?? "";
            vehiculo.Año = int.Parse(sr.ReadLine() ?? "");
            vehiculo.IdTitular = int.Parse(sr.ReadLine() ?? "");
            resultado.Add(vehiculo);
        }
        return resultado;
    }
}