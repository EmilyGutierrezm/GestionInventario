using System;
using System.Collections.Generic;
using System.Linq;
 
namespace GestionInventario
{
    public class Inventario
    {
        private List<Producto> productos = new List<Producto>();

        // Método para agregar producto con validación
        public void AgregarProductoConValidacion(string nombreProducto, decimal precioProducto)
        {
            if (string.IsNullOrWhiteSpace(nombreProducto))
            {
                Console.WriteLine("El nombre del producto no puede estar vacío o solo contener espacios ;(");
                return;
            }

            if (precioProducto <= 0)
            {
                Console.WriteLine("El precio debe ser un valor positivo, intentalo nuevamnete ^^.");
                return;
            }

            productos.Add(new Producto { Nombre = nombreProducto, Precio = precioProducto });
            Console.WriteLine("Producto agregado correctamente :D");
        }

        // Método para actualizar precio
        public void ActualizarPrecioProducto(string nombreProducto, decimal nuevoPrecio)
        {
            var productoExistente = productos.FirstOrDefault(p => p.Nombre == nombreProducto);
            if (productoExistente != null)
            {
                productoExistente.Precio = nuevoPrecio;
                Console.WriteLine($"El precio del producto '{nombreProducto}' ha sido actualizado a {nuevoPrecio:C}.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado en el inventario ;( ");
            }
        }

        // Método para eliminar producto por nombre
        public void EliminarProductoPorNombre(string nombreProducto)
        {
            var productoAEliminar = productos.FirstOrDefault(p => p.Nombre == nombreProducto);
            if (productoAEliminar != null)
            {
                productos.Remove(productoAEliminar);
                Console.WriteLine($"¡Producto '{nombreProducto}' eliminado exitosamente del inventario!");
            }
            else
            {
                Console.WriteLine("Producto no encontrado en el inventario ;( ");
            }
        }

        // Método para filtrar y ordenar productos
        public void FiltrarYOrdenarProductos(decimal precioMinimo)
        {
            var productosFiltrados = productos
                .Where(p => p.Precio > precioMinimo)
                .OrderBy(p => p.Precio);

            Console.WriteLine("Productos filtrados y ordenados por precio:");
            foreach (var producto in productosFiltrados)
            {
                producto.MostrarInformacion();
            }
        }

        // Método para contar productos por rango de precio
        public void ContarProductosPorRangoDePrecio()
        {
            int productosMenoresA100 = productos.Count(p => p.Precio < 100);
            int productosEntre100Y500 = productos.Count(p => p.Precio >= 100 && p.Precio <= 500);
            int productosMayoresA500 = productos.Count(p => p.Precio > 500);

            Console.WriteLine($"Productos con precio menor a 100: {productosMenoresA100}");
            Console.WriteLine($"Productos con precio entre 100 y 500: {productosEntre100Y500}");
            Console.WriteLine($"Productos con precio mayor a 500: {productosMayoresA500}");
        }

        // Método para generar reporte del inventario
        public void GenerarReporteResumen()
        {
            if (!productos.Any())
            {
                Console.WriteLine("No hay productos en el inventario");
                return;
            }

            int totalProductos = productos.Count;
            decimal precioPromedio = productos.Average(p => p.Precio);
            decimal precioMaximo = productos.Max(p => p.Precio);
            decimal precioMinimo = productos.Min(p => p.Precio);

            var productoMasCaro = productos.FirstOrDefault(p => p.Precio == precioMaximo);
            var productoMasBarato = productos.FirstOrDefault(p => p.Precio == precioMinimo);

            Console.WriteLine($"Número total de productos: {totalProductos}");
            Console.WriteLine($"Precio promedio de productos: {precioPromedio:C}");
            Console.WriteLine($"Producto más caro: {productoMasCaro?.Nombre} - Precio: {productoMasCaro?.Precio:C}");
            Console.WriteLine($"Producto más barato: {productoMasBarato?.Nombre} - Precio: {productoMasBarato?.Precio:C}");
        }
    }

}
