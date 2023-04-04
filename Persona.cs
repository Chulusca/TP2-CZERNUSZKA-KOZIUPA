class Persona {
    private int dni{get;set;}
    private DateTime fechaNacimiento{get;set;}
    public string nombre{get;set;}
    public string apellido{get;set;}
    public string email{get;set;}
    private int edad{get;set;}

    public Persona(int DNI, string NOMBRE, string APELLIDO, DateTime FNAC, string EMAIL){
        dni = DNI; nombre = NOMBRE; apellido = APELLIDO; fechaNacimiento = FNAC; email = EMAIL;
        edad = MiEdad();
    }
    public Persona(){

    }
    private int MiEdad()
    {
        DateTime FechaNacimientoHoy = new DateTime(DateTime.Today.Year, fechaNacimiento.Month, fechaNacimiento.Day);
        if (FechaNacimientoHoy< DateTime.Today)  edad = DateTime.Today.Year - fechaNacimiento.Year;
            else   edad = DateTime.Today.Year - fechaNacimiento.Year -1;
        return edad; 
    }
    public bool PuedeVotar(){
        edad = MiEdad();
        return (edad >= 16);
    }
    public int DevolverDni(){
        return dni;
    }
}