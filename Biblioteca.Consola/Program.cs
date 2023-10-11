using Biblioteca.Aplicacion;
using Biblioteca.Repositorios;

//debug:
Console.ForegroundColor = ConsoleColor.Green; //esto lo hago para que se vea bien en la consola de mi pc.
Console.Clear();


//inicializo los repositorios
var repositorioLibro = new RepositorioLibroTxt();

/*

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
bajaLibro.Ejecutar(6);

//modifico el libro 0 y 7:  (lo remplazo con el señor de los anillos)
modificarLibro.Ejecutar(new Libro(0,"J.R.R. Tolkien","La Comunidad del Anillo",1954,"Fantasía",1));
modificarLibro.Ejecutar(new Libro(7,"J.R.R. Tolkien","Las Dos Torres",1954,"Fantasía",3));



//listo en consola todos los libros guardados
foreach(Libro libro in listarLibros.Ejecutar()){
    Console.WriteLine(libro);
}

//Console.WriteLine(verLibro.Ejecutar(1));

*/



//inicializo los casos de uso e inyecto las dependencias de alumnos:
