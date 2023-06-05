namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entidades;

public class RepositorioTerceroTXT : IRepositorioTercero
{
    readonly string _nombreArch = "terceros.txt";
    static int s_IdT;

    public RepositorioTerceroTXT()
    {
        //inicializar id
        List<Tercero> lista = ListarTerceros();
        s_IdT = (lista.Count == 0) ? 1 : (lista.Last().Id + 1);
    }

    public void AgregarTercero(Tercero t)
    {
        if(!unico(t)) throw new Exception("El dni ya existe");

        using var sw = new StreamWriter(_nombreArch, true);
        t.Id = s_IdT;
        s_IdT++;
        sw.WriteLine(t.Id);
        sw.WriteLine(t.DNI);
        sw.WriteLine(t.Apellido);
        sw.WriteLine(t.Nombre);
        sw.WriteLine(t.Telefono);
        sw.WriteLine(t.Aseguradora);
        sw.WriteLine(t.IdSiniestro);
        sw.Close();
    }

    private bool unico(Tercero t)
    {
        List<Tercero> list = ListarTerceros();
        int dni = t.DNI;
        foreach (Tercero i in list)
        {
            if (i.DNI == dni)
            {
                return false;
            }
        }
        return true;
    }
    public void EliminarTercero(int id)
    {
        List<Tercero> terceros = ListarTerceros();
        int pos_valid = -1;
        for (int i = terceros.Count - 1; i >= 0; i--)
        {
            if (terceros[i].Id == id)
            {
                pos_valid = i;
                break;
            }
        }
        if (pos_valid == -1)
        {
            throw new Exception("No se encontro el tercero con ese id");
        }
        else
        {
            terceros.RemoveAt(pos_valid);

        }
        GuardarLista(terceros);
    }
    private void GuardarLista(List<Tercero> l)
    {
        using var sw = new StreamWriter(_nombreArch, false);
        foreach (Tercero t in l)
        {
            sw.WriteLine(t.Id);
            sw.WriteLine(t.DNI);
            sw.WriteLine(t.Apellido);
            sw.WriteLine(t.Nombre);
            sw.WriteLine(t.Telefono);
            sw.WriteLine(t.Aseguradora);
            sw.WriteLine(t.IdSiniestro);
        }
        sw.Close();
    }
    public void ModificarTercero(Tercero tercero)
    {
        int myid=tercero.Id;
        List<Tercero> terceros = ListarTerceros();
        int pos_valid = -1;
        for (int i = terceros.Count - 1; i >= 0; i--)
        {
            if (terceros[i].Id == myid)
            {
                pos_valid = i;
                break;
            }
        }
        if (pos_valid == -1)
        {
            throw new Exception("No se encontro el tercero con ese id");
        }
        else
        {
            tercero.Id= terceros[pos_valid].Id;
            terceros.RemoveAt(pos_valid);
            terceros.Insert(pos_valid, tercero);

        }
        GuardarLista(terceros);
    }    
    public List<Tercero> ListarTerceros()
    {
        List<Tercero> _lista = new List<Tercero>();
        try
        {
            using StreamReader sr = new StreamReader(_nombreArch);
            while (!sr.EndOfStream)
            {
                int id = int.Parse(sr.ReadLine() ?? "");
                int dni = int.Parse(sr.ReadLine() ?? "");
                string apellido = sr.ReadLine() ?? "";
                string nombre = sr.ReadLine() ?? "";
                int tel = int.Parse(sr.ReadLine() ?? "");
                string aseg = sr.ReadLine() ?? "";
                int idS = int.Parse(sr.ReadLine() ?? "");

                Tercero t = new Tercero(dni, apellido, nombre, tel, aseg, idS);
                t.Id = id;
                _lista.Add(t);
            }
        }
        catch (FileNotFoundException)
        {
            return _lista;
        }
        return _lista;
    }
}
