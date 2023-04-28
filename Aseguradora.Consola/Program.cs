using Aseguradora.Aplicacion;
using Aseguradora.Repositorios;

//creamos los casos de uso inyectando dependencias
RepositorioTitularTXT repoTitular = new RepositorioTitularTXT();
AgregarTitularUseCase agregarTitular = new AgregarTitularUseCase(repoTitular);
ListarTitularesUseCase listarTitulares = new ListarTitularesUseCase(repoTitular);
ModificarTitularUseCase modificarTitular = new ModificarTitularUseCase(repoTitular);
//EliminarTitularUseCase eliminarTitular = new EliminarTitularUseCase(repoTitular);
//Instanciamos un titular
Titular titular = new Titular(33123456, "García", "Juan", 221654132, "44 1413", "meme@hotmail.com");

Console.WriteLine($"Id del titular recién instanciado: {titular.Id}");

//agregamos el titular utilizando un método local
PersistirTitular(titular);
//el id que corresponde al titular es establecido por el repositorio
Console.WriteLine($"Id del titular una vez persistido: {titular.Id}");
//agregamos unos titulares más
Titular titular2 = new Titular(333456456, "García", "Juan", 221654132, "44 1413", "meme@hotmail.com");
Titular titular3 = new Titular(33189056, "García", "Juan", 221654132, "44 1413", "meme@hotmail.com");
Titular titular4 = new Titular(33100056, "García", "Juan", 221654132, "44 1413", "meme@hotmail.com");
PersistirTitular(titular2);
PersistirTitular(titular3);
PersistirTitular(titular4);

//listamos los titulares utilizando un método local
ListarTitulares();
//no debe ser posible agregar un titular con igual DNI que uno existente
Console.WriteLine("Intentando agregar un titular con DNI 20654987");
Titular titular5 = new Titular(33123456, "García", "Juan", 221654132, "44 1413", "meme@hotmail.com");
PersistirTitular(titular5); //este titular no pudo persistirse

// //Entonces vamos a modificar el titular existente
// Console.WriteLine("Modificando el titular con DNI 33123456");
// modificarTitular.Ejecutar(titular);
// ListarTitulares();
// //Eliminando un titular
// Console.WriteLine("Eliminando al titular con id 1");
// eliminarTitular.Ejecutar(1);
// ListarTitulares();

//métodos locales
void PersistirTitular(Titular t)
{
    try
    {
        agregarTitular.Ejecutar(t);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void ListarTitulares()
{
    Console.WriteLine("Listando todos los titulares de vehículos");
    List<Titular> lista = listarTitulares.Ejecutar();
    foreach (Titular t in lista)
    {
        Console.WriteLine(t);
    }
}