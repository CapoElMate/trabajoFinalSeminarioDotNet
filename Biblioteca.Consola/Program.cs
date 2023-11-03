using System.Runtime.CompilerServices;

using Biblioteca.Aplicacion;
using Biblioteca.Repositorios;

//debug:
Console.ForegroundColor = ConsoleColor.Green; //esto lo hago para que se vea bien en la consola de mi pc.
Console.Clear();
Console.Clear();


var repositorioEstudiante = new RepositorioEstudianteTxt();     //inicializo el repositorio   
var repositorioDocente = new RepositorioDocenteTxt();           //inicializo el repositorio
var repositorioPrestamo = new RepositorioPrestamoTxt();         //inicializo el repositorio
var repositorioLibro = new RepositorioLibroTxt();               //inicializo el repositorio      

/*
    int cantLibrosPrestados(int idLibro);

    void realizarPrestamo(Prestamo prestamo);
    void devolverLibro(Prestamo devolucion);   

    List<Prestamo> listarPrestamos();

    List<Prestamo> listarPrestamosActivos();
*/


//inicializo los casos de uso e inyecto las dependencias de prestamos:
var realizarPrestamo = new RealizarPrestamoUseCase(repositorioPrestamo, repositorioLibro);
var devolverLibro = new DevolverLibroUseCase(repositorioPrestamo);
var listarPrestamosActivos = new ListarPrestamosActivosUseCase(repositorioPrestamo);
var listarPrestamos = new ListarPrestamosUseCase(repositorioPrestamo);

//inicializo los casos de uso e inyecto las dependencias de estudiantes:
var altaEstudiante = new AltaEstudianteUseCase(repositorioEstudiante);
var bajaEstudiante = new BajaEstudianteUseCase(repositorioEstudiante);
var listarEstudiantes = new ListarEstudiantesUseCase(repositorioEstudiante);
var modificarEstudiante = new ModificarEstudianteUseCase(repositorioEstudiante);

//inicializo los casos de uso e inyecto las dependencias de profesores:
var altaDocente = new AltaDocenteUseCase(repositorioDocente);
var bajaDocente = new BajaDocenteUseCase(repositorioDocente);
var listarDocentes = new ListarDocentesUseCase(repositorioDocente);
var modificarDocente = new ModificarDocenteUseCase(repositorioDocente);

//codigo de prueba estudiantes y docentes:


Estudiante[] estudiantes = {
    new Estudiante(123456, "Juan",  "Pérez",    "123 Calle Principal",      "Facultad de Ciencias",                     "555-123-4567", "juan.perez@example.com",           101, "Ingeniería Informática"),
    new Estudiante(234567, "Ana",   "López",    "456 Avenida Secundaria",   "Facultad de Ciencias Sociales",            "555-234-5678", "ana.lopez@example.com",            102, "Psicología"),
    new Estudiante(345678, "Luis",  "García",   "789 Calle Secundaria",     "Facultad de Ingeniería",                   "555-345-6789", "luis.garcia@example.com",          103, "Ingeniería Eléctrica"),
    new Estudiante(456789, "María", "Martínez", "101 Calle Principal",      "Facultad de Medicina",                     "555-456-7890", "maria.martinez@example.com",       104, "Medicina"),
    new Estudiante(567890, "Carlos","Fernández","202 Avenida Principal",    "Facultad de Artes",                        "555-567-8901", "carlos.fernandez@example.com",     105, "Artes Plásticas"),
    new Estudiante(678901, "Laura", "Rodríguez","303 Avenida Secundaria",   "Facultad de Derecho",                      "555-678-9012", "laura.rodriguez@example.com",      106, "Derecho"),
    new Estudiante(789012, "Miguel","Gómez",    "404 Calle Principal",      "Facultad de Economía",                     "555-789-0123", "miguel.gomez@example.com",         107, "Economía"),
    new Estudiante(890123, "Sofía", "Sánchez",  "505 Avenida Principal",    "Facultad de Ciencias de la Salud",         "555-890-1234", "sofia.sanchez@example.com",        108, "Enfermería"),
    new Estudiante(901234, "Pedro", "Hernández","606 Avenida Secundaria",   "Facultad de Ciencias Naturales",           "555-901-2345", "pedro.hernandez@example.com",      109, "Biología"),
    new Estudiante(012345, "Isabel","Torres",   "707 Calle Principal",      "Facultad de Ciencias de la Computación",   "555-012-345",  "isabel.torres@example.com",        110, "Ciencias de la Computación")
};

foreach (Estudiante est in estudiantes)
    altaEstudiante.Ejecutar(est);


Docente[] docentes = {
    new Docente(12345, "Juan",  "Pérez", "Calle 123; Ciudad Universitaria",     "Facultad de Ciencias",     "555-123-4567", "juan.perez@example.com",   67890, 2010),
    new Docente(54321, "María", "Gómez", "Avenida 456; Ciudad Universitaria",   "Facultad de Artes",        "555-987-6543", "maria.gomez@example.com",  54321, 2008),
    new Docente(98765, "Pedro", "López", "Calle 789; Ciudad Universitaria",     "Facultad de Ingeniería",   "555-234-5678", "pedro.lopez@example.com",  34567, 2012)
};

foreach (Docente doc in docentes)
    altaDocente.Ejecutar(doc);


//elimino el estudiantes con esa id:
bajaEstudiante.Ejecutar(6);

//elimino el docente con esa id:
bajaDocente.Ejecutar(11);


modificarDocente.Ejecutar( new Docente(10 ,999, "michael" , "jackson" , "santa barbara-california" , 
                                                "Academia Universitaria de Baile" , "0800-01101001" , "michael.jack@oficial.com" 
                                              , 123 , 2000) );

modificarEstudiante.Ejecutar(new Estudiante(0, 23456, "Tony", "Stark", "Torre Stark Ciudad de los Vengadores", 
                                                      "Facultad de Ingeniería Avanzada", "555-789-0123", "tony.stark@example.com", 
                                                      272, "ingenieria mecatronica" ) );


Console.WriteLine("\n\nlistando docentes: \n");
foreach (Docente doc in listarDocentes.Ejecutar())
    Console.WriteLine(doc);

Console.WriteLine("\n\nlistando estudiantes: ");
foreach (Estudiante est in listarEstudiantes.Ejecutar())
    Console.WriteLine(est);







//codigo de prueba libros:
///*


//inicializo los casos de uso e inyecto las dependencias de libros:
var altaLibro = new AltaLibroUseCase(repositorioLibro);
var verLibro = new VerLibroUseCase(repositorioLibro);
var bajaLibro = new BajaLibroUseCase(repositorioLibro);
var listarLibros = new ListarLibrosUseCase(repositorioLibro);
var modificarLibro = new ModificarLibroUseCase(repositorioLibro);


//creo una lista de libros:
Libro[] libros = 
{
    new Libro("George Orwell","1984",1949,"Ciencia ficción",3),
    new Libro("Gabriel García Márquez","Cien años de soledad",1967,"Ficción",23),
    new Libro("Harper Lee","Matar a un ruiseñor",1960,"Drama",1),
    new Libro("Paulo Coelho","El alquimista",1988,"Autoayuda",8),
    new Libro("Dan Brown","El código Da Vinci",2003,"Suspenso",3),
    new Libro("Jane Austen","Orgullo y prejuicio",1813,"Romance",1),
    new Libro("J.K. Rowling","Harry Potter y la piedra filosofal",1997,"Fantasía",10),
    new Libro("Stieg Larsson","Los hombres que no amaban a las mujeres",2005,"Misterio",2),
    new Libro("Miguel de Cervantes","Don Quijote de la Mancha",1605,"Clásico",5),
    new Libro("Carlos Ruiz Zafón","La sombra del viento",2001,"Misterio",1)
};

//Guardo los libros en el repositorio 
//NOTA: cada vez que ejecuto el programa se van a guardar de nuevo. comentar esta linea para evitarlo.
foreach (Libro libro in libros)
    altaLibro.Ejecutar(libro);    

//elimino el libro con esa id:
//bajaLibro.Ejecutar(6);

//modifico el libro 0 y 7:  (lo remplazo con el señor de los anillos)
modificarLibro.Ejecutar(new Libro(0,"J.R.R. Tolkien","La Comunidad del Anillo",1954,"Fantasía",1));
modificarLibro.Ejecutar(new Libro(7,"J.R.R. Tolkien","Las Dos Torres",1954,"Fantasía",3));



//listo en consola todos los libros guardados
Console.WriteLine("\n\nlistando libros: ");
foreach(Libro libro in listarLibros.Ejecutar()){
    Console.WriteLine(libro);
}

//Console.WriteLine(verLibro.Ejecutar(1));

//*/


//codigo de prueba prestamos:
 ///*
 
Prestamo[] prestamos = {
    new Prestamo(0,0,DateTime.Now),
    new Prestamo(1,2,DateTime.Now),
    new Prestamo(5,5,DateTime.Now),
    new Prestamo(3,1,DateTime.Now)
};

foreach (Prestamo prestamo in prestamos)
    realizarPrestamo.Ejecutar(prestamo);

prestamos[0].devolver(DateTime.Now, true);
prestamos[1].devolver(DateTime.Now, true);

devolverLibro.Ejecutar(prestamos[0]);
devolverLibro.Ejecutar(prestamos[1]);


Console.WriteLine("\n prestamos: \n\n");

foreach (Prestamo p in listarPrestamos.Ejecutar()){
    Console.WriteLine(p);
}

Console.WriteLine("\n prestamos activos: \n\n");

foreach (Prestamo p in listarPrestamosActivos.Ejecutar()){
    Console.WriteLine(p);
}

 //*/


