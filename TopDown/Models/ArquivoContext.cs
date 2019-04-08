using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Dominio;

namespace DownloadUploadArquivo.Models
{
    public partial class ArquivoContext : DbContext
    {
        public virtual DbSet<Arquivo> Arquivo { get; set; }

        public ArquivoContext(DbContextOptions<ArquivoContext> options) : base(options) { }        
    }
}
