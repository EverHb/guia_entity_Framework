using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


class Program
{
    static void Main()
    {

        while (true)
        {
            using (var context = new Context())
            {
                Console.WriteLine("\nListado de Estudiantes:");

                using (var contextdb = new Context())
                {
                    contextdb.Database.EnsureCreated();

                    var estudiante = new Student() { Id = 04, Nombre = "Pepito", Apellidos = "Pérez", Sexo = "Masculino", Edad = 20 };
                    contextdb.Add(estudiante);
                    contextdb.SaveChanges();

                    foreach (var s in context.Estudiante.ToList())
                    {
                        Console.WriteLine($"ID: {s.Id}, Nombre: {s.Nombre} {s.Apellidos}, Edad: {s.Edad}, Sexo: {s.Sexo}");
                    }
                }

                Console.WriteLine("\nIngrese los datos de los nuevos estudiantes:");

                Console.Write("Id: ");
                if (int.TryParse(Console.ReadLine(), out int id)) 

                    Console.Write("Nombre: ");
                var nombre = Console.ReadLine();

                Console.Write("Apellido: ");
                var apellido = Console.ReadLine();

                Console.Write("Sexo: ");
                var sexo = Console.ReadLine();

                Console.Write("Edad: ");
                if (int.TryParse(Console.ReadLine(), out int edad))
                {
                    var nuevoEstudiante = new Student
                    {
                        Id = id,
                        Nombre = nombre,
                        Apellidos = apellido,
                        Sexo = sexo,
                        Edad = edad
                    };

                    try
                    {
                        context.Estudiante.Add(nuevoEstudiante);
                        context.SaveChanges();
                        Console.WriteLine("Estudiante se agrego correctamente.");
                    }
                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine("Error al agregar estudiante. Asegúrate de que los datos sean válidos.");
                    }
                }
                else
                {
                    Console.WriteLine("Edad no válida. Intente nuevamente.");
                }

                Console.Write("¿Si desea agregar más estudiantes, presione (S) y si ya no desea ingresar, presione (N): ");
                var respuesta = Console.ReadLine();
                if (respuesta?.Trim().ToLower() != "s")
                {
                    break;
                }
            }
        }
    }
}

