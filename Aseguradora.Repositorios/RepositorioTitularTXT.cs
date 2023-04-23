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
        s_IdT = (lista.Count == 0) ? 0 : (lista.Last().Id + 1);
    }

    public void AgregarTitular(Titular t)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        t.Id = s_IdT;
        sw.WriteLine(t.Id);
        sw.WriteLine(t.DNI);
        sw.WriteLine(t.Apellido);
        sw.WriteLine(t.Nombre);
        sw.WriteLine(t.Telefono);
        sw.WriteLine(t.Direccion);
        sw.WriteLine(t.Correo);
        sw.Close();
    }

    public void EliminarTitular(int dni)
    {
        List<Titular> lista = ListarTitulares();
        //busqueda por dni
        int index = -1;
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].DNI == dni)
            {
                index = i;
                break;
            }
        }
        //manejar excepciones
        if (index == -1)
        {
            throw new Exception("No se encontro el titular con ese dni");
        }
        else lista.RemoveAt(index);
        
        GuardarLista(lista);
    }
    //Consultar como implementar. Que campo se modifica?
    public void ModificarTitular(int dni)
    {

    }

    private void GuardarLista(List<Titular> l){
        using var sw = new StreamWriter(_nombreArch, false);
        foreach (Titular t in l){
            sw.WriteLine(t.Id);
            sw.WriteLine(t.Apellido);
            sw.WriteLine(t.Nombre);
            sw.WriteLine(t.Telefono);
            sw.WriteLine(t.Direccion);
            sw.WriteLine(t.Correo);
        }
        sw.Close();
    }

// Cnsultar si es necesario el ?? "" o suponemos lineas nunca vacias
    public List<Titular> ListarTitulares()
    {
        List<Titular> _lista = new List<Titular>();
        using var sr = new StreamReader(_nombreArch);

        while(!sr.EndOfStream){
            int id = int.Parse(sr.ReadLine() ?? "");
            int dni = int.Parse(sr.ReadLine() ?? "");
            string apellido = sr.ReadLine() ?? "";
            string nombre = sr.ReadLine() ?? "";
            int tel = int.Parse(sr.ReadLine() ?? "");
            string dir = sr.ReadLine() ?? "";
            string mail = sr.ReadLine() ?? "";
            
            Titular t = new Titular(dni,apellido,nombre,tel,dir,mail);
            t.Id=id;
        }
        
        return _lista;
    }

}
