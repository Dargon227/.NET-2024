using DAL.IDALs;
using DAL.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DALs
{
    public class DAL_Vehiculos_EF : IDAL_Vehiculos
    {
        public void AddVehiculo(Vehiculo vehiculo)
        {
            using (var context = new DBContext())
            {
                Vehiculos vehiculoEntity = Vehiculos.FromEntity(vehiculo);
                context.Vehiculos.Add(vehiculoEntity);
                context.SaveChanges();
            }
        }

        public void DeleteVehiculo(long id)
        {
            using (var context = new DBContext())
            {
                var vehiculo = context.Vehiculos.Find(id);
                if (vehiculo != null)
                {
                    context.Vehiculos.Remove(vehiculo);
                    context.SaveChanges();
                }
            }
        }

        public Vehiculo GetVehiculo(long id)
        {
            using (var context = new DBContext())
            {
                var vehiculo = context.Vehiculos.Find(id);
                return vehiculo?.GetEntity();
            }
        }

        public List<Vehiculo> GetVehiculos()
        {
            using (var context = new DBContext())
            {
                return context.Vehiculos.Select(v => v.GetEntity()).ToList();
            }
        }

        public void UpdateVehiculo(Vehiculo vehiculo)
        {
            using (var context = new DBContext())
            {
                var existingVehiculo = context.Vehiculos.Find(vehiculo.Id);
                if (existingVehiculo != null)
                {
                    existingVehiculo.Marca = vehiculo.Marca;
                    existingVehiculo.Modelo = vehiculo.Modelo;
                    existingVehiculo.Matricula = vehiculo.Matricula;
                    existingVehiculo.PersonaId = vehiculo.PersonaId; // Actualización de PersonaId

                    context.SaveChanges();
                }
            }
        }
    }
}
