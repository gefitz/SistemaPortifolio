using Infraestrutura;
using Infraestrutura.Model;
using MercadoFitz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Xml;

namespace MercadoFitz.Controllers
{
    public class NotaXmlController : Controller
    {
        private readonly ILogger<NotaXmlController> _logger;
        private IHostingEnvironment _appEnvironment;

        public NotaXmlController(ILogger<NotaXmlController> logger, IHostingEnvironment env)
        {
            _logger = logger;
            _appEnvironment = env;
        }
        public IActionResult CalcularXml()
        {
            XmlModel model = new XmlModel();
            return View(model);
        }
        /*metodo para carregar o xml para pagina*/
        [HttpPost]
        public async Task<IActionResult> CalcularXml(List<IFormFile> arquivos)
        {
            LerXml ler = new LerXml();
            XmlModel model = new XmlModel();
            // caminho completo do arquivo na localização temporária
            var caminhoArquivo = Path.GetTempFileName();

            // processa os arquivo enviados
            //percorre a lista de arquivos selecionados
            foreach (var arquivo in arquivos)
            {


                //< obtém o caminho físico da pasta wwwroot >
                string caminho_WebRoot = _appEnvironment.ContentRootPath;
                // incluir a pasta Recebidos e o nome do arquivo enviado : 
                // ~\wwwroot\Arquivos\Arquivos_Usuario\Recebidos\
                string caminhoDestinoArquivoOriginal = caminho_WebRoot + "\\Notas Xml\\" + arquivo.FileName;
                //copia o arquivo para o local de destino original
                using (var stream = new FileStream(caminhoDestinoArquivoOriginal, FileMode.Create))
                {
                    await arquivo.CopyToAsync(stream);
                }
                ler.AbrirXMl(caminhoDestinoArquivoOriginal);
                for (int i = 0; i < ler.nomeProdList.Count; i++)
                {
                    model.Nome.Add(ler.nomeProdList[i].InnerText);
                    model.QuantidadeCX.Add(XmlConvert.ToDouble(ler.quantidadeList[i].InnerText));
                    model.ValorTotalCx.Add(XmlConvert.ToDouble(ler.valortotalList[i].InnerText));
                    model.ValorUnitatiro.Add(XmlConvert.ToDouble(ler.unitarioList[i].InnerText));
                    model.TipoItem.Add(ler.tipoItemList[i].InnerText);
                }
            }
            //retorna a viewdata
            return View(model);

        }
        public void SalvarProduto(ProductModel model)
        {
            SalvarProduto salvar = new SalvarProduto();
            ProdutoModel produto = ConvertModel(model);
            salvar.AddProdutos(produto);
        }
        public ProdutoModel ConvertModel(ProductModel model)
        {
          ProdutoModel produto = new ProdutoModel
            {
                Codigo = model.Codigo,
                Nome = model.Nome,
                ValorUnitatiro = model.ValorUnitario,
                ValorTotalCx = model.ValorTotalCx,
                QuantidadeUN = model.QuantidadeUN,
                QuantidadeKG = model.QuantidadeKG,
                QuantidadeCX = model.QuantidadeCX,
                Porcetagem = model.Porcetagem,
                PrecoFinal = model.PrecoFinal,

            };
            return produto;
        }
    }
}
