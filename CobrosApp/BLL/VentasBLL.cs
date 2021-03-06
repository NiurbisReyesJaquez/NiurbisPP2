﻿using CobrosApp.DAL;
using CobrosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CobrosApp.BLL
{
    public class VentasBLL
    {
        public static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Ventas.Any(a => a.VentaId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }

        public static bool Insertar(Ventas ventas)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Ventas.Add(ventas);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Ventas ventas)
        {

            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Entry(ventas).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Guardar(Ventas ventas)
        {
            if (!Existe(ventas.VentaId))
                return Insertar(ventas);
            else
                return Modificar(ventas);
        }

        public static bool Eliminar(int id)
        {

            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var encontrado = db.Ventas.Find(id);
                db.Ventas.Remove(encontrado);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Ventas Buscar(int id)
        {
            Contexto db = new Contexto();
            Ventas p = new Ventas();
            try
            {
                p = db.Ventas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return p;
        }

        public static List<Ventas> GetVentas()
        {
            Contexto contexto = new Contexto();
            List<Ventas> ventas = new List<Ventas>();
            try
            {
                ventas = contexto.Ventas.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ventas;
        }


    }
}
