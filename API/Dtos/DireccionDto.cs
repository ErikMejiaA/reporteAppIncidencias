namespace API.Dtos;
public class DireccionDto
{
    public int Id_codigo { get; set; }
    public string ? Calle { get; set; }
    public string ? Carrera { get; set; }
    public string ? Numero { get; set; }
    public string ? Letra { get; set; }
    public string ? Diagonal { get; set; }
    public string ? Barrio { get; set; }
    public string ? Nro_puerta { get; set; }
    public string ? Tipo_residencia { get; set; }

    //foranea 
    //public string ? Id_personaFK { get; set; }

}
