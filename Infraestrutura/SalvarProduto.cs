using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestrutura.Model;
using MySql.Data.MySqlClient;

namespace Infraestrutura
{
    public class SalvarProduto
    {
        /*Metodo para cadastrar produtos novos*/
        public void AddProdutos(ProdutoModel produto)
        {


            string comandAddProduto = $"use fitz;insert into produtos value (" +
                $"{produto.Codigo}," +
                $"{produto.Nome}," +
                $"{produto.QuantidadeUN}," +
                $"{produto.ValorUnitatiro}," +
                $"{produto.Porcetagem}," +
                $"{produto.PrecoFinal}," +
                $"{DateTime.Now});";
            
            try
            {

                ConnectedMysql connected = new ConnectedMysql();
                var banco = connected.Open();
                MySqlCommand cmd = new MySqlCommand(comandAddProduto, banco);
                cmd.ExecuteReader(); 
            }catch(Exception e)
            {

            }
        }
    }
}
