namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public class RepositorioVehiculoTXT : IRepositorioVehiculo
{
    readonly string _nombreArch = "vehiculos.txt";
    static int s_id;
    public RepositorioVehiculoTXT()
    {
        //inicializar id
        List<Vehiculo> lista = ListarVehiculos();
        s_id = (lista.Count == 0) ? 0 : (lista.Last().Id + 1);
    }
    public void AgregarVehiculo(Vehiculo vehiculo)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        vehiculo.Id=s_id;
        s_id++;
        sw.WriteLine(vehiculo.Id);
        sw.WriteLine(vehiculo.Dominio);
        sw.WriteLine(vehiculo.Marca);
        sw.WriteLine(vehiculo.Año);
        sw.WriteLine(vehiculo.IdTitular);
        sw.Close();
    }
    public void ModificarVehiculo(Vehiculo vehiculo) { }
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