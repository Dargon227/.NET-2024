using DAL.IDALs;
using DAL.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALs
{
    public class DAL_Personas_EF : IDAL_Personas
    {
        public Persona AddPersona(Persona persona)
        {
            using (var context = new DBContext())
            {
                Personas personas = Personas.FromEntity(persona);
                context.Personas.Add(personas);
                context.SaveChanges();

                return personas.GetEntity();
            }
        }

        public void DeletePersona(long id)
        {
            using (var context = new DBContext())
            {
                var persona = context.Personas.Find(id);
                if (persona != null)
                {
                    context.Personas.Remove(persona);
                    context.SaveChanges();
                }
            }
        }

        public Persona GetPersona(long id)
        {
            using (var context = new DBContext())
            {
                var persona = context.Personas.Find(id);
                return persona?.GetEntity();
            }
        }

        public List<Persona> GetPersonas()
        {
            using (var context = new DBContext())
            {
                return context.Personas.Select(p => p.GetEntity()).ToList();
            }
        }

        public Persona UpdatePersona(Persona persona)
        {
            using (var context = new DBContext())
            {
                var existingPersona = context.Personas.Find(persona.Id);
                if (existingPersona != null)
                {
                    existingPersona.Nombre = persona.Nombre;
                    existingPersona.Apellido = persona.Apellido;
                    existingPersona.Documento = persona.Documento;
                    existingPersona.Telefono = persona.Telefono;
                    existingPersona.Direccion = persona.Direccion;
                    existingPersona.Nacimiento = persona.Nacimiento;

                    context.SaveChanges();
                    return existingPersona.GetEntity();
                }

                return null;
            }
        }
    }
}
