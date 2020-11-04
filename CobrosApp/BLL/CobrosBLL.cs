using CobrosApp.DAL;
using CobrosApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CobrosApp.BLL
{
    public class CobrosBLL
    {
        public static bool Guardar(Cobros cobros)
        {
            if (!Existe(cobros.CobrosId))
                return Insertar(cobros);
            else
                return Modificar(cobros);
        }

        public static bool Insertar(Cobros cobros)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Cobros.Add(cobros);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Cobros cobros)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            var anterior = Buscar(cobros.CobrosId);

            try
            {

                foreach (var item in anterior.CobrosApp)
                {
                    if (!cobros.CobrosApp.Exists(o => o.Id == item.Id))
                    {
                        contexto.Entry(item).State = EntityState.Deleted;
                    }

                }

                foreach (var item in cobros.CobrosApp)
                {
                    if (item.Id == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                    }
                    else
                    {
                        contexto.Entry(item).State = EntityState.Modified;
                    }
                }
                contexto.Entry(cobros).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var cobros = contexto.Cobros.Find(id);

                if (cobros != null)
                {
                    contexto.Cobros.Remove(cobros);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Cobros Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Cobros cobros;

            try
            {
               cobros = contexto.Cobros
                    .Where(e => e.CobrosId == id)
                    .Include(e => e.CobrosApp)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return cobros;
        }

        public static List<Cobros> GetList(Expression<Func<Cobros, bool>> criterio)
        {
            List<Cobros> lista = new List<Cobros>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Cobros.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Cobros.Any(e => e.CobrosId== id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Cobros> GetCobros()
        {
            List<Cobros> lista = new List<Cobros>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Cobros.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }


    }
}
