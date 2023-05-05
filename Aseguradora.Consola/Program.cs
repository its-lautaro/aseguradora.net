using Aseguradora.Aplicacion;
using Aseguradora.Repositorios;

//creamos los casos de uso inyectando dependencias
RepositorioPolizaTXT repoPoliza = new RepositorioPolizaTXT();
AgregarPolizaUseCase agregarPoliza = new AgregarPolizaUseCase(repoPoliza);
ModificarPolizaUseCase modificarPoliza = new ModificarPolizaUseCase(repoPoliza);
EliminarPolizaUseCase eliminarPoliza = new EliminarPolizaUseCase(repoPoliza);
ListarPolizasUseCase listarPolizas = new ListarPolizasUseCase(repoPoliza);

RepositorioVehiculoTXT repoVehiculo = new RepositorioVehiculoTXT();
AgregarVehiculoUseCase agregarVehiculo = new AgregarVehiculoUseCase(repoVehiculo);
ModificarVehiculoUseCase modificarVehiculo = new ModificarVehiculoUseCase(repoVehiculo);
EliminarVehiculoUseCase eliminarVehiculo = new EliminarVehiculoUseCase(repoVehiculo, repoPoliza);
ListarVehiculosUseCase listarVehiculos = new ListarVehiculosUseCase(repoVehiculo);

RepositorioTitularTXT repoTitular = new RepositorioTitularTXT();
AgregarTitularUseCase agregarTitular = new AgregarTitularUseCase(repoTitular);
ModificarTitularUseCase modificarTitular = new ModificarTitularUseCase(repoTitular);
EliminarTitularUseCase eliminarTitular = new EliminarTitularUseCase(repoTitular, repoVehiculo);
ListarTitularesUseCase listarTitulares = new ListarTitularesUseCase(repoTitular);
ListarTitularesConSusVehiculosUseCase listarTitularesConSusVehiculos = new ListarTitularesConSusVehiculosUseCase(repoTitular, repoVehiculo);

//Instanciamos un titular
Titular titular = new Titular(33123456, "García", "Juan", 221654132, "44 1413", "juan@hotmail.com");
Console.WriteLine($"Id del titular recién instanciado: {titular.Id}");
//agregamos el titular utilizando un método local
PersistirTitular(titular);
//el id que corresponde al titular es establecido por el repositorio
Console.WriteLine($"Id del titular una vez persistido: {titular.Id}");

//agregamos unos titulares más
titular = new Titular(123, "Lopez", "Maria", 221654132, "44 1413", "maria@hotmail.com");
PersistirTitular(titular);
titular = new Titular(456, "Sanchez", "Tomas", 221654132, "44 1413", "tomas@hotmail.com");
PersistirTitular(titular);
titular = new Titular(789, "Martinez", "Juana", 221654132, "44 1413", "juana@hotmail.com");
PersistirTitular(titular);

//listamos los titulares utilizando un método local
ListarTitulares();

//no debe ser posible agregar un titular con igual DNI que uno existente
Console.WriteLine("Intentando agregar un titular con DNI 123");
titular = new Titular(123, "Gomez", "Joaquin", 221654132, "44 1413", "joaquin@hotmail.com");
PersistirTitular(titular); //este titular no pudo persistirse

//Entonces vamos a modificar el titular existente
Console.WriteLine("Modificando el titular con DNI 123");
modificarTitular.Ejecutar(titular);
ListarTitulares();

//Eliminando el titular con id 3 dni 456
EliminarTitular(456);
ListarTitulares();

Console.WriteLine("--------------------------------------------------------------------");

//instanciamos un vehiculo
Vehiculo vehiculo = new Vehiculo("AAA 405 SN", "Toyota", 2016, 1);
Console.WriteLine($"Id del vehiculo recién instanciado: {vehiculo.Id}");
//agregamos el vehiculo utilizando un método local
PersistirVehiculo(vehiculo);
//el id que corresponde al vehiculo es establecido por el repositorio
Console.WriteLine($"Id del vehiculo una vez persistido: {vehiculo.Id}");

//agregamos mas vehículos
vehiculo = new Vehiculo("GFZ 463", "Ferrari", 2009, 1);
PersistirVehiculo(vehiculo);
vehiculo = new Vehiculo("FUM 420", "Ford", 2010, 2);
PersistirVehiculo(vehiculo);
Vehiculo UltimoVehiculo = new Vehiculo("FAA 542", "Volkswagen", 2003, 4);
PersistirVehiculo(UltimoVehiculo);

//listamos los vehiculos utilizando un método local
ListarVehiculos();

//Vamos a modificar un vehiculo existente
Console.WriteLine("Modificando el vehiculo con id 4");
UltimoVehiculo.Marca = "Renault";
modificarVehiculo.Ejecutar(UltimoVehiculo);
ListarVehiculos();

//Eliminando el vehiculo con id 2
EliminarVehiculo(2);
ListarVehiculos();
Console.WriteLine("--------------------------------------------------------------------");
//instanciamos una poliza 
Poliza poliza = new Poliza(1, 18_000, 1_900_000, Poliza.TipoCobertura.ResponsabilidadCivil, DateTime.Today, DateTime.Today.AddYears(1));
Console.WriteLine($"Id de la poliza recién instanciada: {poliza.Id}");
//agregamos a la poliza utilizando un método local
PersistirPoliza(poliza);
//el id que corresponde a la poliza es establecido por el repositorio
Console.WriteLine($"Id de la poliza una vez persistida: {poliza.Id}");

//agregamos mas polizas
poliza = new Poliza(3, 18_000, 1_900_000, Poliza.TipoCobertura.TodoRiesgo, DateTime.Today, DateTime.Today.AddYears(1));
PersistirPoliza(poliza);
Poliza UltimaPoliza = new Poliza(4, 18_000, 1_900_000, Poliza.TipoCobertura.ResponsabilidadCivil, DateTime.Today, DateTime.Today.AddYears(1));
PersistirPoliza(UltimaPoliza);

//listamos las polizas utilizando un método local
ListarPolizas();

//Vamos a modificar una poliza existente
Console.WriteLine("Modificando el vencimiento de la poliza con id 3");
UltimaPoliza.Fecha_fin = DateTime.Today.AddYears(4);
modificarPoliza.Ejecutar(UltimaPoliza);
ListarPolizas();

//Eliminando la poliza con id 1
EliminarPoliza(1);
ListarPolizas();

//Listamos los titulares con sus vehiculosPersistirVehiculo(vehiculo);
ListarTitularesConSusVehiculos();

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
void ListarTitulares()
{
    Console.WriteLine("Listando todos los titulares");
    List<Titular> lista = listarTitulares.Ejecutar();
    foreach (Titular t in lista)
    {
        Console.WriteLine(t);
    }
}
void EliminarTitular(int dni)
{
    Console.WriteLine($"Eliminando el titular con dni {dni}");
    try
    {
        eliminarTitular.Ejecutar(dni);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void PersistirVehiculo(Vehiculo v)
{
    try
    {
        agregarVehiculo.Ejecutar(v);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void ListarVehiculos()
{
    Console.WriteLine("Listando todos los vehículos");
    List<Vehiculo> lista = listarVehiculos.Ejecutar();
    foreach (Vehiculo v in lista)
    {
        Console.WriteLine(v);
    }
}

void EliminarVehiculo(int id)
{
    Console.WriteLine($"Eliminando el vehiculo con id {id}");
    try
    {
        eliminarVehiculo.Ejecutar(id);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void PersistirPoliza(Poliza p)
{
    try
    {
        agregarPoliza.Ejecutar(p);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void ListarPolizas()
{
    Console.WriteLine("Listando todas las polizas");
    List<Poliza> lista = listarPolizas.Ejecutar();
    foreach (Poliza p in lista)
    {
        Console.WriteLine(p);
    }
}
void EliminarPoliza(int id)
{
    Console.WriteLine($"Eliminando la poliza con id {id}");
    try
    {
        eliminarPoliza.Ejecutar(id);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void ListarTitularesConSusVehiculos()
{
    Console.WriteLine("Listando titulares con sus vehiculos");
    List<Titular> lista = listarTitularesConSusVehiculos.Ejecutar();
    foreach (Titular t in lista)
    {
        Console.WriteLine(t);
        if (t.Vehiculos != null)
        {
            foreach (Vehiculo v in t.Vehiculos)
            {
                Console.WriteLine("  * "+v);
            }
        }
    }
}