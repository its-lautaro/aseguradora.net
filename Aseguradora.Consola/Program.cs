using Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Repositorios;

//creamos los casos de uso inyectando dependencias
RepositorioTitularSQL repoTitular = new RepositorioTitularSQL();
AseguradoraContext dbContext = new AseguradoraContext();

ListarTitularesUseCase listarTitulares = new ListarTitularesUseCase(repoTitular);
AgregarTitularUseCase agregarTitular = new AgregarTitularUseCase(repoTitular);

Titular t = new Titular(42123456,"Prueba","Titular",221,"Calle falsa 123","jordan@michael.com");

dbContext.Inicializar();
PersistirTitular(t);
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

//métodos locales
void PersistirTitular(Titular t)
{
    try
    {
        agregarTitular.Ejecutar(t);
    }
    catch (Exception e) //excepciones de i/o
    {
        Console.WriteLine(e.Message);
    }
}

