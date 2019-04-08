using System;
using System.Collections.Generic;
using System.Text;
using Dominio;

namespace Repositorio
{
    public class ArquivoRepositorio
    {
        private readonly ArquivoContext _context;

        public ArquivoRepositorio(ArquivoContext context)
        {
            _context = context;
        }


        public async Task<Arquivo> Buscar( long id)
        {       

            var arquivo = await _context.Arquivo.SingleOrDefaultAsync(m => m.Id == id);

           
            return arquivo;
        }
    }
}
