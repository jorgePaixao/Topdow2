using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio
{
    public class Arquivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string NomeArquivo { get; set; }
        public string Caminho { get; set; }
        public byte[] ArquivoBytes { get; set; }
        public DateTime DataUpload { get; set; }

    }
}
