using Biblioteca.Aplicacion;
using Biblioteca.Repositorios;

//debug:
Console.ForegroundColor = ConsoleColor.Green;
Console.Clear();

Libro[] libros = {
    //(string? autor, string? titulo, int añoPublicacion, string? genero, int numeroEjemplares)
    new Libro("borges", "librote", 2020, "comedia" , 1 ),
    new Libro(null, "ciencia radiante", 1820, "ciencia" , 2 ),
    //new Libro("pearson", "english manual 1º edition ", 2025, "idiomas" , 10 ),
    new Libro("pearson", "english manual 1º edition ", 2023, "idiomas" , 10 )
};

var repositorioLibro = new RepositorioLibroTxt();

var agregarLibro = new AltaLibroUseCase(repositorioLibro);
var verLibro = new VerLibroUseCase(repositorioLibro);
var bajaLibro = new BajaLibroUseCase(repositorioLibro);
var listarLibros = new ListarLibrosUseCase(repositorioLibro);
var modificarLibro = new ModificarLibroUseCase(repositorioLibro);

// foreach (Libro libro in libros)
//     agregarLibro.Ejecutar(libro);    

//bajaLibro.Ejecutar(8);

modificarLibro.Ejecutar(new Libro(0,"jesus", "biblia",100,"religion", 100 ));



// foreach(Libro libro in ListarLibros.Ejecutar()){
//     Console.WriteLine(libro);
// }

//Console.WriteLine(verLibro.Ejecutar(1));
