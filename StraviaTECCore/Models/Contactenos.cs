using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Contactenos
    {
        public Contactenos(string nombre, string apellidos, string[] telefono, string email, string razon, int id)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Email = email;
            Razon = razon;
            Id = id;
        }

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string[] Telefono { get; set; }
        public string Email { get; set; }
        public string Razon { get; set; }
        public int Id { get; set; }
    }
}
