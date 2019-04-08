using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DownloadUploadArquivo.Models;
using Dominio;


namespace ArquivoTeste
{
    [TestClass]
    public class ArquivoTest
    {
        ArquivoContext _context;

        public void Integracao()
        {
            var serviceProvider = new ServiceCollection()
           .AddEntityFrameworkSqlServer()
           .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ArquivoContext>();

            builder.UseSqlServer("Data Source=DESKTOP-IQECTBL\\SQLEXPRESS;Initial Catalog=TopDown;Integrated Security=True;")
                    .UseInternalServiceProvider(serviceProvider);

            _context = new ArquivoContext(builder.Options);
            _context.Database.Migrate();
        }


        [TestMethod]
        public void TesteArquivoDownload()
        {

            Integracao();

            Arquivo arquivo = new Arquivo();

            byte[] arquivobyte = File.ReadAllBytes(@"C:\Dados\Teste.txt");

            arquivo.ArquivoBytes = arquivobyte;
            arquivo.Caminho = @"C:\DadosSalvos\Teste.txt";
            arquivo.NomeArquivo = "Teste.txt";
            arquivo.DataUpload = DateTime.Now;

            File.WriteAllBytes(@"C:\DadosSalvos\Teste.txt", arquivobyte);

            _context.Add(arquivo);
            _context.SaveChangesAsync();

        }

        [TestMethod]
        public async System.Threading.Tasks.Task TesteArquivoUploadAsync()
        {

            Integracao();

            //Arquivo arquivo = new Arquivo();

            var arquivo = await _context.Arquivo.SingleOrDefaultAsync(m => m.Id == 1);

            byte[] arquivobyte = arquivo.ArquivoBytes;


            File.WriteAllBytes(@"C:\DadosUpload\Teste.txt", arquivobyte);

           

        }
    }
}
