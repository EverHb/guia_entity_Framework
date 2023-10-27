using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

class conexionDB 
{
    static void Main()
    {
        using (var context = new Context())
        {
            context.Database.EnsureCreated();

            while (true)
            {
                Console.WriteLine("1. Mostrar | 2. Actualizar | 3. Eliminar | 4. Salir");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Mostrar(context);
                        break;
                    case "2":
                        Actualizar(context);
                        break;
                    case "3":
                        Eliminar(context);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }

    static void Mostrar(Context ctx)
    {
        ctx.Estudiante.ToList().ForEach(s => Console.WriteLine($"ID: {s.Id}, Nombre: {s.Nombre} {s.Apellidos}, Edad: {s.Edad}, Sexo: {s.Sexo}"));
    }

    static void Actualizar(Context ctx)
    {
        int id = LeerInt("ID del estudiante a actualizar: ");
        var estudiante = ctx.Estudiante.FirstOrDefault(e => e.Id == id);

        if (estudiante != null)
        {
            Console.WriteLine("¿Qué atributo desea modificar? (NOMBRE, APELLIDO, SEXO, EDAD)");
            var atributo = Console.ReadLine().ToUpper();

            switch (atributo)
            {
                case "NOMBRE":
                    estudiante.Nombre = LeerString("Nuevo nombre: ");
                    break;
                case "APELLIDO":
                    estudiante.Apellidos = LeerString("Nuevo apellido: ");
                    break;
                case "SEXO":
                    estudiante.Sexo = LeerString("Nuevo sexo: ");
                    break;
                case "EDAD":
                    estudiante.Edad = LeerInt("Nueva edad: ");
                    break;
                default:
                    Console.WriteLine("Atributo no válido.");
                    return;
            }

            ctx.SaveChanges();
            Console.WriteLine("Estudiante actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
    }

    static void Eliminar(Context ctx)
    {
        int id = LeerInt("ID del estudiante a eliminar: ");
        var estudiante = ctx.Estudiante.SingleOrDefault(e => e.Id == id);

        if (estudiante != null)
        {
            ctx.Estudiante.Remove(estudiante);
            ctx.SaveChanges();
            Console.WriteLine("Estudiante eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
    }

    static int LeerInt(string mensaje)
    {
        Console.Write(mensaje);
        return int.TryParse(Console.ReadLine(), out int result) ? result : 0;
    }

    static string LeerString(string mensaje)
    {
        Console.Write(mensaje);
        return Console.ReadLine();
    }
}



