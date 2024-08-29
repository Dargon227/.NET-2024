using DAL.DALs;
using DAL.IDALs;
using Shared;

IDAL_Personas dalPersonas = new DAL_Personas_EF();
IDAL_Vehiculos dalVehiculos = new DAL_Vehiculos_EF();

string comando = "NUEVA";

Console.WriteLine("Bienvenido a mi primera app .NET!!!");

do
{
    Console.WriteLine("Ingrese comando (NUEVA_PERSONA/NUEVO_VEHICULO/IMPRIMIR_PERSONAS/IMPRIMIR_VEHICULOS/MODIFICAR_PERSONA/MODIFICAR_VEHICULO/ELIMINAR_PERSONA/ELIMINAR_VEHICULO/EXIT): ");

    try
    {
        comando = Console.ReadLine().ToUpper();

        switch (comando)
        {
            case "NUEVA_PERSONA":
                Persona nuevaPersona = new Persona();
                Console.WriteLine("Ingrese el nombre de la persona: ");
                nuevaPersona.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido de la persona: ");
                nuevaPersona.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese el documento de la persona: ");
                nuevaPersona.Documento = Console.ReadLine();
                Console.WriteLine("Ingrese el teléfono de la persona: ");
                nuevaPersona.Telefono = Console.ReadLine();
                Console.WriteLine("Ingrese la dirección de la persona: ");
                nuevaPersona.Direccion = Console.ReadLine();
                Console.WriteLine("Ingrese la fecha de nacimiento de la persona: ");
                nuevaPersona.Nacimiento = Console.ReadLine();
                dalPersonas.AddPersona(nuevaPersona);
                Console.WriteLine("Persona agregada con éxito.");
                break;

            case "NUEVO_VEHICULO":
                Vehiculo nuevoVehiculo = new Vehiculo();
                Console.WriteLine("Ingrese la marca del vehículo: ");
                nuevoVehiculo.Marca = Console.ReadLine();
                Console.WriteLine("Ingrese el modelo del vehículo: ");
                nuevoVehiculo.Modelo = Console.ReadLine();
                Console.WriteLine("Ingrese la matrícula del vehículo: ");
                nuevoVehiculo.Matricula = Console.ReadLine();
                Console.WriteLine("Ingrese el ID de la persona asociada al vehículo: ");
                if (long.TryParse(Console.ReadLine(), out long personaId))
                {
                    nuevoVehiculo.PersonaId = personaId;
                    dalVehiculos.AddVehiculo(nuevoVehiculo);
                    Console.WriteLine("Vehículo agregado con éxito.");
                }
                else
                {
                    Console.WriteLine("ID de persona inválido.");
                }
                break;

            case "IMPRIMIR_PERSONAS":
                Console.WriteLine("Ingrese Nombre o Documento:");
                string filtroPersona = Console.ReadLine();

                List<Persona> personasFiltradas =
                    dalPersonas.GetPersonas().Where(p => p.Nombre.Contains(filtroPersona) || p.Documento.Contains(filtroPersona))
                            .OrderBy(p => p.Nombre)
                            .ToList();

                if (personasFiltradas.Count > 0)
                {
                    foreach (Persona p in personasFiltradas)
                        Console.WriteLine(p.GetString());
                }
                else
                {
                    Console.WriteLine("No se encontraron personas con ese filtro.");
                }
                break;

            case "IMPRIMIR_VEHICULOS":
                List<Vehiculo> vehiculos = dalVehiculos.GetVehiculos();
                if (vehiculos.Count > 0)
                {
                    foreach (Vehiculo v in vehiculos)
                        Console.WriteLine(v.GetString());
                }
                else
                {
                    Console.WriteLine("No se encontraron vehículos.");
                }
                break;

            case "MODIFICAR_PERSONA":
                Console.WriteLine("Ingrese el ID de la persona a modificar: ");
                if (long.TryParse(Console.ReadLine(), out long idModificarPersona))
                {
                    Persona personaAModificar = dalPersonas.GetPersona(idModificarPersona);
                    if (personaAModificar != null)
                    {
                        Console.WriteLine($"Modificando a: {personaAModificar.GetString()}");

                        Console.WriteLine("Ingrese el nuevo nombre (dejar en blanco para mantener el actual): ");
                        string nuevoNombre = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nuevoNombre))
                        {
                            personaAModificar.Nombre = nuevoNombre;
                        }

                        Console.WriteLine("Ingrese el nuevo apellido (dejar en blanco para mantener el actual): ");
                        string nuevoApellido = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nuevoApellido))
                        {
                            personaAModificar.Apellido = nuevoApellido;
                        }

                        Console.WriteLine("Ingrese el nuevo documento (dejar en blanco para mantener el actual): ");
                        string nuevoDocumento = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nuevoDocumento))
                        {
                            personaAModificar.Documento = nuevoDocumento;
                        }

                        Console.WriteLine("Ingrese el nuevo teléfono (dejar en blanco para mantener el actual): ");
                        string nuevoTelefono = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nuevoTelefono))
                        {
                            personaAModificar.Telefono = nuevoTelefono;
                        }

                        Console.WriteLine("Ingrese la nueva dirección (dejar en blanco para mantener la actual): ");
                        string nuevaDireccion = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nuevaDireccion))
                        {
                            personaAModificar.Direccion = nuevaDireccion;
                        }

                        Console.WriteLine("Ingrese la nueva fecha de nacimiento (dejar en blanco para mantener la actual): ");
                        string nuevaNacimiento = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nuevaNacimiento))
                        {
                            personaAModificar.Nacimiento = nuevaNacimiento;
                        }

                        dalPersonas.UpdatePersona(personaAModificar);
                        Console.WriteLine("Persona modificada con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Persona no encontrada.");
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido.");
                }
                break;

            case "MODIFICAR_VEHICULO":
                Console.WriteLine("Ingrese el ID del vehículo a modificar: ");
                if (long.TryParse(Console.ReadLine(), out long idModificarVehiculo))
                {
                    Vehiculo vehiculoAModificar = dalVehiculos.GetVehiculo(idModificarVehiculo);
                    if (vehiculoAModificar != null)
                    {
                        Console.WriteLine($"Modificando vehículo: {vehiculoAModificar.GetString()}");

                        Console.WriteLine("Ingrese la nueva marca (dejar en blanco para mantener la actual): ");
                        string nuevaMarca = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nuevaMarca))
                        {
                            vehiculoAModificar.Marca = nuevaMarca;
                        }

                        Console.WriteLine("Ingrese el nuevo modelo (dejar en blanco para mantener el actual): ");
                        string nuevoModelo = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nuevoModelo))
                        {
                            vehiculoAModificar.Modelo = nuevoModelo;
                        }

                        Console.WriteLine("Ingrese la nueva matrícula (dejar en blanco para mantener la actual): ");
                        string nuevaMatricula = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nuevaMatricula))
                        {
                            vehiculoAModificar.Matricula = nuevaMatricula;
                        }

                        Console.WriteLine("Ingrese el nuevo ID de la persona asociada (dejar en blanco para mantener el actual): ");
                        string nuevoPersonaIdInput = Console.ReadLine();
                        if (long.TryParse(nuevoPersonaIdInput, out long nuevoPersonaId) && nuevoPersonaId > 0)
                        {
                            vehiculoAModificar.PersonaId = nuevoPersonaId;
                        }

                        dalVehiculos.UpdateVehiculo(vehiculoAModificar);
                        Console.WriteLine("Vehículo modificado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Vehículo no encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido.");
                }
                break;

            case "ELIMINAR_PERSONA":
                Console.WriteLine("Ingrese el ID de la persona a eliminar: ");
                if (long.TryParse(Console.ReadLine(), out long idEliminarPersona))
                {
                    Persona personaAEliminar = dalPersonas.GetPersona(idEliminarPersona);
                    if (personaAEliminar != null)
                    {
                        dalPersonas.DeletePersona(idEliminarPersona);
                        Console.WriteLine("Persona eliminada con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Persona no encontrada.");
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido.");
                }
                break;

            case "ELIMINAR_VEHICULO":
                Console.WriteLine("Ingrese el ID del vehículo a eliminar: ");
                if (long.TryParse(Console.ReadLine(), out long idEliminarVehiculo))
                {
                    Vehiculo vehiculoAEliminar = dalVehiculos.GetVehiculo(idEliminarVehiculo);
                    if (vehiculoAEliminar != null)
                    {
                        dalVehiculos.DeleteVehiculo(idEliminarVehiculo);
                        Console.WriteLine("Vehículo eliminado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Vehículo no encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido.");
                }
                break;

            case "EXIT":
                break;

            default:
                Console.WriteLine("Comando no reconocido.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
while (comando != "EXIT");

Console.WriteLine("Hasta luego!!!");
Console.ReadLine();
