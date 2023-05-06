namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
public class RepositorioTitularTXT : IRepositorioTitular
{
    readonly string _nombreArch = "titulares.txt";
    static int s_IdT;

    public RepositorioTitularTXT()
    {
        //inicializar id
        List<Titular> lista = ListarTitulares();
        s_IdT = (lista.Count == 0) ? 1 : (lista.Last().Id + 1);
    }

    public void AgregarTitular(Titular t)
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
        sw.WriteLine(t.Direccion);
        sw.WriteLine(t.Correo);
        sw.Close();
    }

    private bool unico(Titular t)
    {
        List<Titular> list = ListarTitulares();
        int dni = t.DNI;
        foreach (Titular i in list)
        {
            if (i.DNI == dni)
            {
                return false;
            }
        }
        return true;
    }
    public Titular EliminarTitular(int dni)
    {
        List<Titular> lista = ListarTitulares();
        Titular eliminado;
        //busqueda por dni
        int index = GetIdTitular(dni, lista);
        //manejar excepcionessr.Close();
        if (index == -1)
        {
            throw new Exception($"No se encontro el titular con dni {dni}");
        }
        else
        {
            eliminado = lista[index];
            lista.RemoveAt(index);
        }
        GuardarLista(lista);
        return eliminado;
    }
    public void ModificarTitular(Titular t)
    {
        List<Titular> lista = ListarTitulares();
        //busqueda por dni
        int index = GetIdTitular(t.DNI, lista);
        //manejar
        if (index == -1)
        {
            throw new Exception($"No se encontro el titular con dni {t.DNI}");
        }
        else
        {
            t.Id= lista[index].Id;
            lista.RemoveAt(index);
            lista.Insert(index, t);
        }

        GuardarLista(lista);
    }
    private int GetIdTitular(int dni, List<Titular> lista)
    {
        int index = -1;

        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].DNI == dni)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    private void GuardarLista(List<Titular> l)
    {
        using var sw = new StreamWriter(_nombreArch, false);
        foreach (Titular t in l)
        {
            sw.WriteLine(t.Id);
            sw.WriteLine(t.DNI);
            sw.WriteLine(t.Apellido);
            sw.WriteLine(t.Nombre);
            sw.WriteLine(t.Telefono);
            sw.WriteLine(t.Direccion);
            sw.WriteLine(t.Correo);
        }
        sw.Close();
    }
    public List<Titular> ListarTitulares()
    {
        List<Titular> _lista = new List<Titular>();
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
                string dir = sr.ReadLine() ?? "";
                string mail = sr.ReadLine() ?? "";

                Titular t = new Titular(dni, apellido, nombre, tel, dir, mail);
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
