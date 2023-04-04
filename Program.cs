using System.Collections.Generic;
using System;

List<Persona> listaPersonas = new List<Persona>();

int opcion;
do
{
    Console.Clear();
    Console.WriteLine("1. Cargar nueva persona");
    Console.WriteLine("2. Ver estadisticas");
    Console.WriteLine("3. Buscar Persona");
    Console.WriteLine("4. Cambiar email");
    Console.WriteLine("5. Salir");
    opcion = Funciones.IngresarEnteroEnRango("Elija opción: ", 1, 5);
    Console.Clear();
    switch (opcion)
    {
        case 1:
            IngresarPersona();
            break;
        case 2:
            VerEstadisticas();
            break;
        case 3:
            int dniBuscado = Funciones.IngresarDni("Ingrese el DNI de la persona que quiere buscar ");
            int posBuscado = BuscarPosPersona(dniBuscado);
            Console.WriteLine("Nombre: " + listaPersonas[posBuscado].nombre);
            Console.WriteLine("Apellido: " + listaPersonas[posBuscado].apellido);
            Console.WriteLine("Email: " + listaPersonas[posBuscado].email);
            Console.WriteLine("Fecha de Nacimiento: " + listaPersonas[posBuscado].DevolverFN());
            Console.WriteLine("Edad: " + listaPersonas[posBuscado].DevolverEdad());
            if(listaPersonas[posBuscado].PuedeVotar()) Console.WriteLine("Puede votar");
            else Console.WriteLine("No puede votar");
            break;
        case 4:
            ModificarMail();
            break;
        case 5:
            break;
    }
} while (opcion != 5);

void IngresarPersona()
{
    bool validacion = false;
    string nom = Funciones.IngresarTexto("Ingrese Nombre ");
    string ape = Funciones.IngresarTexto("Ingrese Apellido ");
    int dni = 0;
    DateTime fn;
    do {
        fn = Funciones.IngresarFecha("Ingrese Fecha de Nacimiento (aaaa/mm/dd) ");
        dni = Funciones.IngresarDni("Ingrese DNI ");
        validacion = DniValido(dni) && fn < DateTime.Today;
    }while (validacion == false);
    string email = Funciones.IngresarTexto("Ingrese email");

    Persona unaPersona = new Persona(dni, nom, ape, fn, email);

    listaPersonas.Add(unaPersona);
}

void VerEstadisticas(){
    if(listaPersonas.Count > 0){
        Console.WriteLine("Estadísticas del censo:");
        Console.WriteLine("Cantidad de personas: " + listaPersonas.Count);
        int cantHabilitados = CalcularCantHabilitadosVotar();
        Console.WriteLine($"Cantidad de personas habilitadas para votar: {cantHabilitados}");
        int promedioEdad = CalcularEdadPromedio();
        Console.WriteLine($"Promedio de Edad: {promedioEdad}");
    }
    else Console.WriteLine("Aún no se ingresaron personas en la lista");
}
bool DniValido(int DNI){
    bool b = false;
    int i = 0;
    if(listaPersonas.Count > 0){
        while(!b){
            if (DNI != listaPersonas[i].DevolverDni()) b = true;
        }
    }
    else return true;
    return b;
}
int CalcularCantHabilitadosVotar(){
    int cantHabilitados = 0;
    foreach(Persona p in listaPersonas){
        if(p.PuedeVotar()) cantHabilitados += 1;
    }
    return cantHabilitados;
}
int CalcularEdadPromedio(){
    int totalEdades = 0;
    foreach(Persona p in listaPersonas){
        totalEdades += p.DevolverEdad();
    }
    return totalEdades / listaPersonas.Count;    
}
int BuscarPosPersona(int dniBuscado){
    bool dniEncontrado = false;
    int contador = -1;
    if(listaPersonas.Count > 0){
        while(dniEncontrado == false && contador < listaPersonas.Count){
            contador++;
            if(dniBuscado == listaPersonas[contador].DevolverDni()) dniEncontrado = true;
        }
    }
    else Console.WriteLine("Aún no se ingresaron personas en la lista");
    return contador;
}
void ModificarMail(){
    int dniUsuario = Funciones.IngresarDni("Ingrese el dni del usuario al que le quiere cambiar el mail");
    string emailModificado = Funciones.IngresarTexto("Ingrese su nuevo email");
    int posUsuario = BuscarPosPersona(dniUsuario);
    listaPersonas[posUsuario].email = emailModificado;
}