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
    public class VentasBLL
    {
        private Contexto _contexto { get; set; }

        public VentasBLL(Contexto contexto)
        {
            this._contexto = contexto;
        }


        public async Task<bool> Guardar(Ventas venta)
        {
            if (!await Existe(venta.VentaId))
                return await Insertar(venta);
            else
                return await Modificar(venta);
        }

        private async Task<bool> Existe(int id)
        {
            bool ok = false;

            try
            {
                ok = await _contexto.Venta.AnyAsync(p => p.VentaId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        private async Task<bool> Insertar(Ventas venta)
        {
            bool ok = false;

            try
            {
                await _contexto.Venta.AddAsync(venta);
                ok = await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        private async Task<bool> Modificar(Ventas venta)
        {
            bool ok = false;

            try
            {
                Detached(venta.VentaId);
                _contexto.Entry(venta).State = EntityState.Modified;
                ok = await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return ok;

        }

        public async Task<Ventas> Buscar(int id)
        {
            Ventas venta;

            try
            {
                venta = await _contexto.Venta
                    .Where(s => s.VentaId == id)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return venta;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool ok = false;
            try
            {
                var registro = await _contexto.Venta.FindAsync(id);
                if (registro != null)
                {
                    _contexto.Entry(registro).State = EntityState.Deleted;
                    ok = await _contexto.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        public async Task<List<Ventas>> GetSuplidores(Expression<Func<Ventas, bool>> criterio)
        {
            List<Ventas> lista = new List<Ventas>();

            try
            {
                lista = await _contexto.Venta.Where(criterio).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }

        private void Detached(int VentasId)
        {
            var aux = _contexto
                .Set<Ventas>()
                .Local
                .FirstOrDefault(p => p.VentaId == VentasId);

            if (aux != null)
                _contexto.Entry(aux).State = EntityState.Detached;
        }
    }
}
