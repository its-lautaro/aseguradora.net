namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public class RepositorioPolizaTXT : IRepositorioPoliza
{
    readonly string _nombreArch = "polizas.txt";

    public void AgregarPoliza(Poliza poliza)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(poliza.Id);
        sw.WriteLine(poliza.IdVehiculo);
        sw.WriteLine(poliza.ValorAsegurado);
        sw.WriteLine(poliza.Franquicia);
        sw.WriteLine(poliza.Cobertura);
        sw.WriteLine((poliza.Fecha_inicio).ToString());
        sw.WriteLine((poliza.Fecha_fin).ToString());
        sw.Close();
    }
    public void ModificarPoliza(int id) { }
    public void EliminarPoliza(int id)
    {
        List<Poliza> polizas = ListarPolizas();
        int pos_valid = -1;
        for (int i = polizas.Count - 1; i >= 0; i--)
        {
            if (polizas[i].Id == id)
            {
                pos_valid = i;
                break;
            }
        }
        if (pos_valid == -1)
        {
            throw new Exception("No se encontro el poliza con ese id");
        }
        else
        {
            polizas.RemoveAt(pos_valid);

        }
        GuardarLista(polizas);
    }
    private void GuardarLista(List<Poliza> lista)
    {
        using var sw = new StreamWriter(_nombreArch, false);
        foreach (Poliza poliza in lista)
        {
            sw.WriteLine(poliza.Id);
            sw.WriteLine(poliza.IdVehiculo);
            sw.WriteLine(poliza.ValorAsegurado);
            sw.WriteLine(poliza.Franquicia);
            sw.WriteLine(poliza.Cobertura);
            sw.WriteLine((poliza.Fecha_inicio).ToString());
            sw.WriteLine((poliza.Fecha_fin).ToString());
        }
        sw.Close();
    }
    public List<Poliza> ListarPolizas()
    {
        var resultado = new List<Poliza>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var poliza = new Poliza();
            poliza.Id = int.Parse(sr.ReadLine() ?? "");
            poliza.IdVehiculo = int.Parse(sr.ReadLine() ?? "");
            poliza.ValorAsegurado = int.Parse(sr.ReadLine() ?? "");
            poliza.Franquicia = int.Parse(sr.ReadLine() ?? "");
            if ((sr.ReadLine() ?? "") == "ResponsabilidadCivil")
            {
                poliza.Cobertura = Poliza.TipoCobertura.ResponsabilidadCivil;
            }
            else
            {
                poliza.Cobertura = Poliza.TipoCobertura.TodoRiesgo;

            }
            poliza.Fecha_inicio = DateTime.Parse(sr.ReadLine() ?? "");
            poliza.Fecha_fin = DateTime.Parse(sr.ReadLine() ?? "");
            resultado.Add(poliza);
        }
        return resultado;
    }
}