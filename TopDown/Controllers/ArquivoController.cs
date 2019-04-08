using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DownloadUploadArquivo.Models;
using Dominio;
using Negoc;

namespace DownloadUploadArquivo.Controllers
{
    [Produces("application/json")]
    [Route("api/Arquivo")]                             
    public class ArquivoController : Controller
    {
        private readonly ArquivoContext _context;

        public ArquivoController(ArquivoContext context)
        {
            _context = context;
        }

        // GET: api/Arquivo
        [HttpGet]
        public IEnumerable<Arquivo> GetArquivo()
        {
            return _context.Arquivo;
        }

        // GET: api/Arquivo/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetArquivo([FromRoute] long id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var arquivo = await _context.Arquivo.SingleOrDefaultAsync(m => m.Id == id);

        //    if (arquivo == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(arquivo);
        //}

        // GET: api/Arquivo/1
        [HttpGet("{id}/{caminho}")]
        public async Task<IActionResult> GetArquivoUpload([FromRoute] long id,string caminho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ArquivoNegoc arquivoNegoc = new ArquivoNegoc();

                var arquivo = await _context.Arquivo.SingleOrDefaultAsync(m => m.Id == id);

                arquivoNegoc.SalvarArquivoUpload(arquivo, caminho);

                if (arquivo == null)
                {
                    return NotFound();
                }

                return Ok(arquivo);

            }
            catch (Exception ex)
            {

                throw ex;
            }
         
          
        }


        // PUT: api/Arquivos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArquivo([FromRoute] long id, [FromBody] Arquivo arquivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != arquivo.Id)
            {
                return BadRequest();
            }

            _context.Entry(arquivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArquivoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Arquivos
        [HttpPost]
        public async Task<IActionResult> PostArquivo([FromBody] Arquivo arquivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Arquivo.Add(arquivo);
            try
            {
                ArquivoNegoc arquivoNegoc = new ArquivoNegoc();
                arquivoNegoc.SalvarArquivo(arquivo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArquivoExists(arquivo.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArquivo", new { id = arquivo.Id }, arquivo);
        }

        // DELETE: api/Arquivos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArquivo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var arquivo = await _context.Arquivo.SingleOrDefaultAsync(m => m.Id == id);
            if (arquivo == null)
            {
                return NotFound();
            }

            _context.Arquivo.Remove(arquivo);
            await _context.SaveChangesAsync();

            return Ok(arquivo);
        }

        private bool ArquivoExists(long id)
        {
            return _context.Arquivo.Any(e => e.Id == id);
        }
    }
}