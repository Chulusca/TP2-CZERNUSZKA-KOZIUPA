using System.Collections.Generic;
using System;

List<Persona> listaPersonas = new List<Persona>();

int opcion;
do
{
    Console.Clear();
    Console.WriteLine("1. Ingresar Alumno");
    Console.WriteLine("2. Ver Lista de Alumnos");
    Console.WriteLine("3. Salir");
    opcion = Funciones.IngresarEnteroEnRango("Elija opción: ", 1, 3);
    Console.Clear();
    switch (opcion)
    {
        case 1:
            IngresarAlumno();
            break;
        case 2:
            VerLista();
            break;
    }
} while (opcion != 3);

