namespace API.Dtos;
public class TipoTelefonoMovilDto 
{
    public int Id_codigo { get; set; }
    public string ? Nombre_tipoTelMov { get; set; }
    public string ? Descripcion { get; set; }

    //List<G>
    public List<PersonaTelefonoMovilDto> ? PersonaTelefonoMoviles { get; set; }
        
}
