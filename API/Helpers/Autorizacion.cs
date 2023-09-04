namespace API.Helpers;
public class Autorizacion
{
    public enum Roles
    {
        Administrador,
        Gerente,
        Empleado,
        Persona,
        Trainer,
        Camper

    }

    public const Roles rol_predeterminado = Roles.Persona;
        
}
