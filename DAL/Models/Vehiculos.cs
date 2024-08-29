using Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    internal class Vehiculos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Marca { get; set; }

        [Required]
        [StringLength(20)]
        public string Modelo { get; set; }

        [Required]
        [StringLength(20)]
        public string Matricula { get; set; }

        [Required]
        public long PersonaId { get; set; } // Cambiado de Persona a PersonaId

        public Vehiculo GetEntity()
        {
            return new Vehiculo()
            {
                Id = Id,
                Marca = Marca,
                Modelo = Modelo,
                Matricula = Matricula,
                PersonaId = PersonaId, // Mapeo de PersonaId
            };
        }

        public static Vehiculos FromEntity(Vehiculo vehiculo)
        {
            return new Vehiculos()
            {
                Id = vehiculo.Id,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Matricula = vehiculo.Matricula,
                PersonaId = vehiculo.PersonaId, // Mapeo de PersonaId
            };
        }
    }
}
