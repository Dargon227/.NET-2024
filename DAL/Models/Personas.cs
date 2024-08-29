using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class Personas {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public long Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; } = "";

        [Required]
        [StringLength(30)]
        public string Apellido { get; set; } = "";

        [Required]
        [StringLength(8)]
        public string Documento { get; set; } = "";

        [Required]
        [StringLength(10)]
        public string Telefono { get; set; } = "";

        [Required]
        [StringLength(10)]
        public string Direccion { get; set; } = "";

        [Required]
        [StringLength(10)]
        public string Nacimiento { get; set; } = "";

        public Persona GetEntity()
        {
            return new Persona()
            {
                Id = Id,
                Documento = Documento,
                Nombre = Nombre,
                Apellido = Apellido,
                Telefono = Telefono,
                Direccion = Direccion,
                Nacimiento = Nacimiento
            };
        }

        public static Personas FromEntity(Persona persona)
        {
            return new Personas()
            {
                Id = persona.Id,
                Documento = persona.Documento,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Telefono = persona.Telefono,
                Direccion = persona.Direccion,
                Nacimiento = persona.Nacimiento
            };
        }
    }
}
