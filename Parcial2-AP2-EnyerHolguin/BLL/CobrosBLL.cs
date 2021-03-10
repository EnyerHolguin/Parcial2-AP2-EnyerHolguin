using Microsoft.EntityFrameworkCore;
using Parcial2_AP2_EnyerHolguin.DAL;
using Parcial2_AP2_EnyerHolguin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Parcial2_AP2_EnyerHolguin.BLL
{
    public class CobrosBLL
    {
        private Contexto _contexto { get; set; }

        public CobrosBLL(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<bool> Guardar(Cobros cobro)
        {
            bool ok = false;

            try
            {
                if (!await _contexto.Cobro.AnyAsync(c => c.CobroId == cobro.CobroId))
                {
                    _contexto.Entry(cobro.Cliente).State = EntityState.Modified;
                    _contexto.Cobro.Add(cobro);
                    ok = await _contexto.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        public async Task<Cobros> Buscar(int id)
        {
            Cobros cobro;

            try
            {
                cobro = await _contexto.Cobro
                    .Where(c => c.CobroId == id)
                    .Include(c => c.Cliente)
                    .Include(c => c.CobrosDetalle)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();

                var entidad = _contexto
                .Set<Cobros>()
                .Local.SingleOrDefault(c => c.CobroId == id);

                if (entidad != null)
                {
                    _contexto.Entry(entidad).State = EntityState.Detached;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return cobro;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool ok = false;

            try
            {
                var registro = await Buscar(id);
                if (registro != null)
                {
                    _contexto.Cobro.Remove(registro);
                    ok = await _contexto.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }


        public async Task<List<Cobros>> GetCobros(Expression<Func<Cobros, bool>> criterio)
        {
            List<Cobros> lista = new List<Cobros>();

            try
            {
                lista = await _contexto.Cobro.Where(criterio).Include(c => c.Cliente).Include(c => c.CobrosDetalle).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }
    }
}
