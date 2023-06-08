namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entidades;

public class RepositorioSiniestroTXT : IRepositorioSiniestro
{
    readonly string _nombreArch = "siniestros.txt";
    static int s_IdS;

    public RepositorioSiniestroTXT()
    {
        //inicializar id
        List<Siniestro> lista = ListarSiniestros();
        s_IdS = (lista.Count == 0) ? 1 : (lista.Last().Id + 1);
    }

    public void AgregarSiniestro(Siniestro s)
    {
        // Consultar si hay que chequear repetidos
        // if(!unico(t)) throw new Exception("El dni ya existe");

        using var sw = new StreamWriter(_nombreArch, true);
        s.Id = s_IdS;
        s_IdS++;
        sw.WriteLine(s.Id);
        sw.WriteLine(s.PolizaId);
        sw.WriteLine(s.Descripcion);
        sw.WriteLine(s.Direccion);
        sw.WriteLine(s.Fecha_incidente.ToString());
        sw.WriteLine(s.Fecha_ingreso.ToString());
        sw.Close();
    }

    // private bool unico(Titular t)
    // {
    //     List<Titular> list = ListarTitulares();
    //     int dni = t.DNI;
    //     foreach (Titular i in list)
    //     {
    //         if (i.DNI == dni)
    //         {
    //             return false;
    //         }
    //     }
    //     return true;
    // }
    public Siniestro EliminarSiniestro(int id)
    {
        List<Siniestro> siniestros = ListarSiniestros();
        Siniestro eliminado;
        //Verifico si existe el siniestro a eliminar
        int pos_valid = -1;
        for (int i = (siniestros.Count - 1); i >= 0; i--)
        {
            if (siniestros[i].Id == id)
            {
                pos_valid = i;
                break;
            }
        }
        if (pos_valid == -1)
        {
            throw new Exception("No se encontro el siniestro con ese id");
        }
        else
        {
            eliminado = siniestros[pos_valid];
            siniestros.RemoveAt(pos_valid);

        }
        GuardarLista(siniestros);
        return eliminado;
    }
    private void GuardarLista(List<Siniestro> lista)
    {
        using var sw = new StreamWriter(_nombreArch, false);
        foreach (var s in lista)
        {
            sw.WriteLine(s.Id);
            sw.WriteLine(s.PolizaId);
            sw.WriteLine(s.Descripcion);
            sw.WriteLine(s.Direccion);
            sw.WriteLine(s.Fecha_incidente.ToString());
            sw.WriteLine(s.Fecha_ingreso.ToString());
        }
        sw.Close();
    }
    public void ModificarSiniestro(Siniestro siniestro)
    {
        int myid = siniestro.Id;
        List<Siniestro> siniestros = ListarSiniestros();
        int pos_valid = -1;
        for (int i = siniestros.Count - 1; i >= 0; i--)
        {
            if (siniestros[i].Id == myid)
            {
                pos_valid = i;
                break;
            }
        }
        if (pos_valid == -1)
        {
            throw new Exception("No se encontro el siniestro con ese id");
        }
        else
        {
            siniestro.Id= siniestros[pos_valid].Id;
            siniestros.RemoveAt(pos_valid);
            siniestros.Insert(pos_valid, siniestro);
        }
        GuardarLista(siniestros);
    }
    public List<Siniestro> ListarSiniestros()
    {
        List<Siniestro> _lista = new List<Siniestro>();
        try
        {
            using StreamReader sr = new StreamReader(_nombreArch);
            while (!sr.EndOfStream)
            {
                int id = int.Parse(sr.ReadLine() ?? "");
                int idPoliza = int.Parse(sr.ReadLine() ?? "");
                string descripcion = sr.ReadLine() ?? "";
                string direccion = sr.ReadLine() ?? "";
                DateTime fecha_inc = DateTime.Parse(sr.ReadLine() ?? "");
                DateTime fecha_ing = DateTime.Parse(sr.ReadLine() ?? "");

                Siniestro s = new Siniestro(idPoliza,fecha_ing,fecha_inc,direccion,descripcion);
                s.Id = id;
                _lista.Add(s);
            }
        }
        catch (FileNotFoundException)
        {
            return _lista;
        }
        return _lista;
    }
}
