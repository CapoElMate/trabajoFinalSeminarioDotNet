namespace Biblioteca.Aplicacion;


public class Libro{

    public int? Id {get; set;}
    public string? autor {get; protected set;}
    public string? titulo {get; protected set;}
    
    
    //propiedad de navegacion:
    public List<Prestamo>? Prestamos {get; set;} 


    private int _añoPublicacion;
    public int añoPublicacion{
        
        get => _añoPublicacion;

        // si el año llega a ser mayor que el año actual, guarda -1, sino el valor.
        protected set => _añoPublicacion =    (value <= DateTime.Now.Year)  
                                                ? value 
                                                :throw new ArgumentException("el año de publi es mayor que el actual");
    }

    public string? genero {get;protected set;}

    public int numeroEjemplares {get; set;}
    
//CONSTRUCTOR:


    //constructor vacio. Esto soluciona un error con entity framework
    public Libro(){
        this.Id = null;
        añoPublicacion = 0;
        numeroEjemplares = 0;
        autor = "";
        titulo = "";
        genero = "";
        Prestamos = new List<Prestamo>();
    }

    public Libro(string? autor, string? titulo, int añoPublicacion, string? genero, int numeroEjemplares){
        this.Id = null;
        this.autor = autor;
        this.titulo = titulo;
        this.añoPublicacion = añoPublicacion;
        this.genero = genero;
        this.numeroEjemplares = numeroEjemplares;
        Prestamos = new List<Prestamo>();
    }

    public Libro(int Id,string? autor, string? titulo, int añoPublicacion, string? genero, int numeroEjemplares){
        this.Id = Id;
        this.autor = autor;
        this.titulo = titulo;
        this.añoPublicacion = añoPublicacion;
        this.genero = genero;
        this.numeroEjemplares = numeroEjemplares;
        Prestamos = new List<Prestamo>();
    }
    

    //to string:

    public override string ToString()
    {
        return $"{Id},{autor},{titulo},{añoPublicacion},{genero},{numeroEjemplares}";
    }

}