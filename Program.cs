using System.Collections.Generic;
using System;

List<Persona> listaPersonas = new List<Persona>();

int opcion;
do
{
    Console.Clear();
    Console.WriteLine("1. Crgar nueva persona");
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

            break;
        case 4:

            break;
        case 5:
            break;
    }
} while (opcion != 5);

void IngresarPersona()
{
    bool validacion = false;
    string nom = Funciones.IngresarTexto("Ingrese Nombre ");
    string ape = Funciones.IngresarTexto("Ingrese Apellido");
    int dni = 0;
    DateTime fn;
    do {
        fn = Funciones.IngresarFecha("Ingrese Fecha de Nacimiento (aaaa/mm/dd) ");
        dni = Funciones.IngresarDni("Ingrese DNI ");
        validacion = DniValido(dni) && fn < DateTime.Today;
    }while(validacion);
    string email = Funciones.IngresarTexto("Ingrese email");

    Persona unaPersona = new Persona(dni, nom, ape, fn, email);

    listaPersonas.Add(unaPersona);
}

void VerEstadisticas(){
    if(listaPersonas.Count > 0){
        Console.WriteLine("Estadísticas del censo:");
        Console.WriteLine("Cantidad de personas: " + listaPersonas.Count);
        Console.WriteLine("Cantidad de personas habilitadas para votar: ");
    }
    else Console.WriteLine("Aún no se ingresaron personas en la lista");
}
bool DniValido(int DNI){
    bool b = false;
    int i = 0;
    if(listaPersonas.Count > 0){
        while(!b){
            if (DNI != listaPersonas[i].DevolverDni()){
                b = true;
            }
        }
    }
    else return true;
    return b;
}

