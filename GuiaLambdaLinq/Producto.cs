﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario
{
    public class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Producto: {Nombre}, Precio: {Precio:C}");
        }
    }

}
