using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Dominio;

namespace Negoc
{
    public class ArquivoNegoc
    {
        public void SalvarArquivo(Arquivo _arquivo)
        {
            try
            {

                if (MimeTypes.GetMimeType(_arquivo.ArquivoBytes).Equals("application/x-msdownload"))
                {
                    throw new Exception("Tipo de arquivo não permitido.");
                }
                else if (_arquivo.ArquivoBytes.Length > 1048576)
                {
                    throw new Exception("Arquivo maior que 10 mb.");
                }
                else
                {
                    File.WriteAllBytes(_arquivo.Caminho, _arquivo.ArquivoBytes);
                }
                
            }
            catch (Exception ex )
            {
                throw ex;
            }            
        }


        public void SalvarArquivoUpload(Arquivo _arquivo,string _caminho)
        {
            try
            {
                File.WriteAllBytes(_caminho, _arquivo.ArquivoBytes);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
