using Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Repositorios;

//creamos los casos de uso inyectando dependencias
RepositorioTitularSQL repoTitular = new RepositorioTitularSQL();

ListarTitularesUseCase listarTitulares = new ListarTitularesUseCase(repoTitular);

ListarTitulares();

void ListarTitulares()
{
    Console.WriteLine("Listando todos los titulares");
    List<Titular> lista = listarTitulares.Ejecutar();
    foreach (Titular t in lista)
    {
        Console.WriteLine(t);
    }
}

// //instanciamos un titular
// Titular titular = new Titular(123, "ApellidoTest", "NombreTest", 456, "42 1413", "lautaro@gmail.com");
// Console.WriteLine($"Titular instanciado: id:{titular.Id}");
// PersistirTitular(titular);
// Console.WriteLine($"Titular persistido: id:{titular.Id}");

//métodos locales
// void PersistirTitular(Titular t)
// {
//     try
//     {
//         agregarTitular.Ejecutar(t);
//     }
//     catch (Exception e) //excepciones de i/o
//     {
//         Console.WriteLine(e.Message);
//     }
// }