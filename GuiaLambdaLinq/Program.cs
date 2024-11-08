using System;

namespace GestionInventario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Inventario inventario = new Inventario();

            while (true)
            {
                Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬\nBIENVENIDO A NUESTRO SISTEMA DE GESTIÓN DE INVENTARIO :D :▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                Console.WriteLine("A continuacion selecciona la opción de tu preferencia ^^ : ");
                Console.WriteLine("\n1. Agregar producto");
                Console.WriteLine("2. Actualizar precio de producto");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Filtrar y ordenar productos por precio mínimo");
                Console.WriteLine("5. Contar productos por rango de precio");
                Console.WriteLine("6. Generar reporte de inventario");
                Console.WriteLine("7. Salir");
                Console.Write("\nSeleccione una opción: ");

                int opcion;
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor, ingrese un número válido, intentelo nuevamente ^^.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el nombre del producto: ");
                        string nombreProducto = Console.ReadLine();
                        Console.Write("Ingrese el precio del producto: ");
                        decimal precioProducto;
                        if (decimal.TryParse(Console.ReadLine(), out precioProducto))
                        {
                            inventario.AgregarProductoConValidacion(nombreProducto, precioProducto);
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido. Debe ser un número.");
                        }
                        break;

                    case 2:
                        Console.Write("Ingrese el nombre del producto a actualizar: ");
                        nombreProducto = Console.ReadLine();
                        Console.Write("Ingrese el nuevo precio: ");
                        if (decimal.TryParse(Console.ReadLine(), out precioProducto))
                        {
                            inventario.ActualizarPrecioProducto(nombreProducto, precioProducto);
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido. Debe ser un número.");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese el nombre del producto a eliminar: ");
                        nombreProducto = Console.ReadLine();
                        inventario.EliminarProductoPorNombre(nombreProducto);
                        break;

                    case 4:
                        Console.Write("Ingrese el precio mínimo para filtrar: ");
                        if (decimal.TryParse(Console.ReadLine(), out precioProducto))
                        {
                            inventario.FiltrarYOrdenarProductos(precioProducto);
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido. Debe ser un número.");
                        }
                        break;

                    case 5:
                        inventario.ContarProductosPorRangoDePrecio();
                        break;

                    case 6:
                        inventario.GenerarReporteResumen();
                        break;

                    case 7:
                        Console.WriteLine("Saliendo del programa, gracias por preferirnos...");
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente ^^");
                        break;
                }
            }
        }
    }

}

