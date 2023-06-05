using Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;
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

RepositorioTerceroTXT repoTercero = new RepositorioTerceroTXT();
AgregarTerceroUseCase agregarTercero= new AgregarTerceroUseCase(repoTercero);
ModificarTerceroUseCase modificarTercero= new ModificarTerceroUseCase(repoTercero);
EliminarTerceroUseCase eliminarTercero= new EliminarTerceroUseCase(repoTercero);
ListarTercerosUseCase listarTerceros = new ListarTercerosUseCase(repoTercero);

RepositorioSiniestroTXT repoSiniestro = new RepositorioSiniestroTXT();
AgregarSiniestroUseCase agregarSiniestro = new AgregarSiniestroUseCase(repoSiniestro);
ModificarSiniestroUseCase modificarSiniestro = new ModificarSiniestroUseCase(repoSiniestro);
EliminarSiniestroUseCase eliminarSiniestro = new EliminarSiniestroUseCase(repoTercero,repoSiniestro);
ListarSiniestrosUseCase listarSiniestros = new ListarSiniestrosUseCase(repoSiniestro);

// //Instanciamos un titular
// Titular titular = new Titular(33123456, "García", "Juan", 221654132, "44 1413", "juan@hotmail.com");
// Console.WriteLine($"Id del titular recién instanciado: {titular.Id}");
// //agregamos el titular utilizando un método local
// PersistirTitular(titular);
// //el id que corresponde al titular es establecido por el repositorio
// Console.WriteLine($"Id del titular una vez persistido: {titular.Id}");

// //agregamos unos titulares más
// titular = new Titular(123, "Lopez", "Maria", 221654132, "44 1413", "maria@hotmail.com");
// PersistirTitular(titular);
// titular = new Titular(456, "Sanchez", "Tomas", 221654132, "44 1413", "tomas@hotmail.com");
// PersistirTitular(titular);
// titular = new Titular(789, "Martinez", "Juana", 221654132, "44 1413", "juana@hotmail.com");
// PersistirTitular(titular);

// //listamos los titulares utilizando un método local
// ListarTitulares();

// //no debe ser posible agregar un titular con igual DNI que uno existente
// Console.WriteLine("Intentando agregar un titular con DNI 123");
// titular = new Titular(123, "Gomez", "Joaquin", 221654132, "44 1413", "joaquin@hotmail.com");
// PersistirTitular(titular); //este titular no pudo persistirse

// //Intentamos modificar un titular que no existe
// Titular noexisto = new Titular(42195854, "La Vecchia", "Lautaro", 221221221, "42 1413", "lautaro@tempmail.com");
// ModificarTitular(noexisto); //no me deja
// //ahora modificamos un titular existente
// ModificarTitular(titular);
// ListarTitulares();

// //Eliminando el titular con id 3 dni 456
// EliminarTitular(456);
// ListarTitulares();
// //Intentamos eliminar un titular con dni 456 de nuevo
// EliminarTitular(456); //no me deja

// Console.WriteLine("--------------------------------------------------------------------");

// //instanciamos un vehiculo
// Vehiculo vehiculo = new Vehiculo("AAA 405 SN", "Toyota", 2016, 1);
// Console.WriteLine($"Id del vehiculo recién instanciado: {vehiculo.Id}");
// //agregamos el vehiculo utilizando un método local
// PersistirVehiculo(vehiculo);
// //el id que corresponde al vehiculo es establecido por el repositorio
// Console.WriteLine($"Id del vehiculo una vez persistido: {vehiculo.Id}");

// //agregamos mas vehículos
// vehiculo = new Vehiculo("GFZ 463", "Ferrari", 2009, 1);
// PersistirVehiculo(vehiculo);
// vehiculo = new Vehiculo("FUM 420", "Ford", 2010, 2);
// PersistirVehiculo(vehiculo);
// Vehiculo UltimoVehiculo = new Vehiculo("FAA 542", "Volkswagen", 2003, 4);
// PersistirVehiculo(UltimoVehiculo);

// //listamos los vehiculos utilizando un método local
// ListarVehiculos();

// //Intentamos modificar un vehiculo que no existe
// Vehiculo noexistoV = new Vehiculo("YPS 542", "Volkswagen", 2015, 4);
// ModificarVehiculo(noexistoV); //no me deja
// //Vamos a modificar un vehiculo existente
// UltimoVehiculo.Marca = "Renault";
// ModificarVehiculo(UltimoVehiculo);
// ListarVehiculos();

// //Eliminando el vehiculo con id 2
// EliminarVehiculo(2);
// ListarVehiculos();
// //Intentando eliminar un vehiculo con id 2 de nuevo
// EliminarVehiculo(2);

// Console.WriteLine("--------------------------------------------------------------------");

// //instanciamos una poliza 
// Poliza poliza = new Poliza(1, 18_000, 1_900_000, Poliza.TipoCobertura.ResponsabilidadCivil, DateTime.Today, DateTime.Today.AddYears(1));
// Console.WriteLine($"Id de la poliza recién instanciada: {poliza.Id}");
// //agregamos a la poliza utilizando un método local
// PersistirPoliza(poliza);
// //el id que corresponde a la poliza es establecido por el repositorio
// Console.WriteLine($"Id de la poliza una vez persistida: {poliza.Id}");

// //agregamos mas polizas
// poliza = new Poliza(3, 18_000, 1_900_000, Poliza.TipoCobertura.TodoRiesgo, DateTime.Today, DateTime.Today.AddYears(1));
// PersistirPoliza(poliza);
// Poliza UltimaPoliza = new Poliza(4, 18_000, 1_900_000, Poliza.TipoCobertura.ResponsabilidadCivil, DateTime.Today, DateTime.Today.AddYears(1));
// PersistirPoliza(UltimaPoliza);

// //listamos las polizas utilizando un método local
// ListarPolizas();

// //Intentamos modificar una poliza que no existe
// Poliza noexistoP = new Poliza(3, 25_000, 5_000_000, Poliza.TipoCobertura.TodoRiesgo, DateTime.Today, DateTime.Today.AddYears(5));
// ModificarPoliza(noexistoP);
// //Vamos a modificar una poliza existente
// UltimaPoliza.Fecha_fin = DateTime.Today.AddYears(4);
// ModificarPoliza(UltimaPoliza);
// ListarPolizas();

// //Eliminando la poliza con id 1
// EliminarPoliza(1);
// ListarPolizas();
// //Intentamos eliminar una poliza con id 1 de nuevo
// EliminarPoliza(1);

// Console.WriteLine("--------------------------------------------------------------------");
// //Listamos los titulares con sus vehiculos
// ListarTitularesConSusVehiculos();
//Console.WriteLine("--------------------------------------------------------------------");

//instanciamos un titular
Titular titular = new Titular(42195854,"La Vecchia","Lautaro",22156565,"42 1413","lautaro@gmail.com");
Console.WriteLine($"Titular instanciado: id:{titular.Id}");
PersistirTitular(titular);
Console.WriteLine($"Titular persistido: id:{titular.Id}");
//instanciamos un vehiculo
Vehiculo vehiculo = new Vehiculo("AA405SN","Toyota",2015,1);
Console.WriteLine($"Vehiculo instanciado: id:{vehiculo.Id}");
PersistirVehiculo(vehiculo);
Console.WriteLine($"Vehiculo persistido: id:{vehiculo.Id}");
//instanciamos una poliza
Poliza poliza = new Poliza(1,100_000,150_000,Poliza.TipoCobertura.ResponsabilidadCivil,DateTime.Parse("05/06/2023"),DateTime.Parse("05/06/2023").AddYears(1));
Console.WriteLine($"Poliza instanciada: id:{poliza.Id}");
PersistirPoliza(poliza);
Console.WriteLine($"Poliza persistida: id:{poliza.Id}");
//instanciamos un siniestro
Siniestro siniestro = new Siniestro(1,DateTime.Today,DateTime.Today,"42 1413","el titular iba en contra mano y el tercero iba en bicicleta");
Console.WriteLine($"Siniestro instanciado: id:{siniestro.Id}");
PersistirSiniestro(siniestro);
Console.WriteLine($"Siniestro persistido: id:{siniestro.Id}");
//instanciamos un tercero
Tercero tercero = new Tercero(42195854,"Segovia","Maite",22123456,"N/A",1);
Console.WriteLine($"Tercero instanciado: id:{tercero.Id}");
PersistirTercero(tercero);
Console.WriteLine($"Tercero persitido: id:{tercero.Id}");

List<Tercero> terceros = listarTerceros.Ejecutar();
List<Siniestro> siniestros = listarSiniestros.Ejecutar();

//imprimir Terceros
ListarTerceros();
//imprimir Siniestros
ListarSiniestros();
//borrar siniestro de maite
EliminarSiniestro(1);
//verificar que maite no este
ListarTerceros();
Console.WriteLine("--------------------------------- FIN --------------------------");
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

void ModificarTitular(Titular t)
{
    Console.WriteLine($"Modificando el titular con DNI {t.DNI}");
    try
    {
        modificarTitular.Ejecutar(t);
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

void ModificarVehiculo(Vehiculo v)
{
    Console.WriteLine($"Modificando el vehiculo con id {v.Id}");
    try
    {
        modificarVehiculo.Ejecutar(v);
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

void ModificarPoliza(Poliza p)
{
    Console.WriteLine($"Modificando la poliza con id {p.Id}");
    try
    {
        modificarPoliza.Ejecutar(p);
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
                Console.WriteLine("  * " + v);
            }
        }
    }
}
void PersistirTercero(Tercero t)
{
    try
    {
        agregarTercero.Ejecutar(t);
    }
    catch (Exception e) //excepciones de i/o
    {
        Console.WriteLine(e.Message);
    }
}
void ListarTerceros()
{
    Console.WriteLine("Listando todos los terceros");
    List<Tercero> lista = listarTerceros.Ejecutar();
    foreach (Tercero t in lista)
    {
        Console.WriteLine(t);
    }
}
void EliminarTercero(int id)
{
    Console.WriteLine($"Eliminando el tercero con id {id}");
    try
    {
        eliminarTercero.Ejecutar(id);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void ModificarTercero(Tercero t)
{
    Console.WriteLine($"Modificando el tercero con id {t.Id}");
    try
    {
        modificarTercero.Ejecutar(t);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void PersistirSiniestro(Siniestro s)
{
    try
    {
        agregarSiniestro.Ejecutar(s);
    }
    catch (Exception e) //excepciones de i/o
    {
        Console.WriteLine(e.Message);
    }
}
void ListarSiniestros()
{
    Console.WriteLine("Listando todos los siniestros");
    List<Siniestro> lista = listarSiniestros.Ejecutar();
    foreach (Siniestro s in lista)
    {
        Console.WriteLine(s);
    }
}
void EliminarSiniestro(int id)
{
    Console.WriteLine($"Eliminando el siniestro con id {id}");
    try
    {
        eliminarSiniestro.Ejecutar(id);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void ModificarSiniestro(Siniestro s)
{
    Console.WriteLine($"Modificando el siniestro con id {s.Id}");
    try
    {
        modificarSiniestro.Ejecutar(s);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

