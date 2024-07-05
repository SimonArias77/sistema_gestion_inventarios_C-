// SISTEMA DE GESTIÓN DE INVENTARIOS DE UNA TIENDA //

// FUNCIÓN: AGREGAR PRODUCTOS AL INVENTARIO
// FUNCIÓN: ACTUALIZAR STOCK DE PRODUCTOS
// FUNCIÓN: BUSCAR PRODUCTOS POR NOMBRE
// FUNCIÓN: ELIMINAR PRODUCTOS DEL INVENTARIO

using System;
using System.Collections.Generic;

class Program
{
    // Lista estática de diccionarios para almacenar los productos
    static List<Dictionary<string, object>> productos = new List<Dictionary<string, object>>();

    static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            MostrarMenu();
            Console.WriteLine("Seleccione una opción:");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarProducto();
                    break;
                case "2":
                    ActualizarStock();
                    break;
                case "3":
                    BuscarProducto();
                    break;
                case "4":
                    MostrarInventario();
                    break;
                case "5":
                    EliminarProducto();
                    break;
                case "6":
                    CalcularValorInventario();
                    break;
                case "7":
                    salir = true;
                    Console.WriteLine("Saliendo del programa.");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("=== Gestión de Inventario ===");
        Console.WriteLine("1. Agregar Producto");
        Console.WriteLine("2. Actualizar Stock");
        Console.WriteLine("3. Buscar Producto por Nombre");
        Console.WriteLine("4. Mostrar Inventario Completo");
        Console.WriteLine("5. Eliminar Producto del Inventario");
        Console.WriteLine("6. Calcular Valor Total del Inventario");
        Console.WriteLine("7. Salir");
    }

    static void AgregarProducto()
    {
        Console.WriteLine("Ingrese el nombre del producto:");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese el precio unitario del producto:");
        int precio;
        while (!int.TryParse(Console.ReadLine(), out precio) || precio <= 0)
        {
            Console.WriteLine("Precio inválido. Intente de nuevo:");
        }

        Console.WriteLine("Ingrese la cantidad inicial disponible:");
        int cantidad;
        while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < 0)
        {
            Console.WriteLine("Cantidad inválida. Intente de nuevo:");
        }

        // Crear un nuevo diccionario para el producto y agregarlo al productos
        Dictionary<string, object> nuevoProducto = new Dictionary<string, object>();
        nuevoProducto.Add("Nombre", nombre);
        nuevoProducto.Add("Precio", precio);
        nuevoProducto.Add("Cantidad", cantidad);

        productos.Add(nuevoProducto);

        Console.WriteLine($"Producto '{nombre}' agregado al productos.");
    }

    static void ActualizarStock()
    {
        Console.WriteLine("Ingrese el nombre del producto para actualizar su stock:");
        string nombre = Console.ReadLine();

        Dictionary<string, object> productoEncontrado = productos.Find(p => p["Nombre"].ToString() == nombre);

        if (productoEncontrado != null)
        {
            Console.WriteLine($"Producto encontrado: {productoEncontrado["Nombre"]} - Precio: {productoEncontrado["Precio"]} - Cantidad disponible: {productoEncontrado["Cantidad"]}");

            Console.WriteLine("Ingrese la cantidad a añadir (positivo) o restar (negativo):");
            int cantidadActualizacion;
            while (!int.TryParse(Console.ReadLine(), out cantidadActualizacion))
            {
                Console.WriteLine("Cantidad inválida. Intente de nuevo:");
            }

            productoEncontrado["Cantidad"] = (int)productoEncontrado["Cantidad"] + cantidadActualizacion;
            Console.WriteLine($"Stock actualizado. Nuevo stock: {productoEncontrado["Cantidad"]}");
        }
        else
        {
            Console.WriteLine($"Producto '{nombre}' no encontrado en el productos.");
        }
    }

    static void BuscarProducto()
    {
        Console.WriteLine("Ingrese el nombre del producto a buscar:");
        string nombre = Console.ReadLine();

        Dictionary<string, object> productoEncontrado = productos.Find(p => p["Nombre"].ToString() == nombre);

        if (productoEncontrado != null)
        {
            Console.WriteLine($"Producto encontrado: {productoEncontrado["Nombre"]} - Precio: {productoEncontrado["Precio"]} - Cantidad disponible: {productoEncontrado["Cantidad"]}");
        }
        else
        {
            Console.WriteLine($"Producto '{nombre}' no encontrado en el productos.");
        }
    }

    static void MostrarInventario()
    {
        Console.WriteLine("=== Inventario Completo ===");
        foreach (var producto in productos)
        {
            Console.WriteLine($"Nombre: {producto["Nombre"]} - Precio: {producto["Precio"]} - Cantidad disponible: {producto["Cantidad"]}");
        }
    }
// existe un metodo llamado "string.format" para implementar la tabla
    static void EliminarProducto()
    {
        Console.WriteLine("Ingrese el nombre del producto a eliminar:");
        string nombre = Console.ReadLine();

        Dictionary<string, object> productoEncontrado = productos.Find(p => p["Nombre"].ToString() == nombre);

        if (productoEncontrado != null)
        {
            productos.Remove(productoEncontrado);
            Console.WriteLine($"Producto '{nombre}' eliminado del productos.");
        }
        else
        {
            Console.WriteLine($"Producto '{nombre}' no encontrado en el productos.");
        }
    }

    static void CalcularValorInventario()
    {
        double valorTotal = 0;

        foreach (var producto in productos)
        {
            valorTotal += Convert.ToDouble(producto["Precio"]) * Convert.ToInt32(producto["Cantidad"]);
        }

        Console.WriteLine($"El valor total del productos es: {valorTotal}");
    }
}
