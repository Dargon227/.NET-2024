using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shared
{
    public class Vehiculo
    {
        public long Id { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Matricula { get; set; }
        public long PersonaId { get; set; }

        public string GetString()
        {
            return $"Id: {Id}, Marca: {Marca}, modelo: {Modelo}, Matricula: {Matricula}, PersonaId: {PersonaId}";
        }
    }
}
