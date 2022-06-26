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
        public bool AddProdutos(ProdutoModel produto)
        {


            string comandAddProduto = $"INSERT INTO produtos VALUES (" +
                $"{produto.Codigo}," +
                $"'{produto.Nome}'," +
                $"{produto.QuantidadeCX},"+
                $"{produto.QuantidadeUN}," +
                $"{produto.QuantidadeKG},"+
                $"{produto.ValorTotalCx},"+
                $"{produto.ValorUnitatiro}," +
                $"'{produto.Porcetagem}'," +
                $"{produto.PrecoFinal})" 
                /*$"{DateTime.Now});"*/;
            
            try
            {

                ConnectedMysql connected = new ConnectedMysql();
                var banco = connected.Open();
                MySqlCommand cmd = new MySqlCommand(comandAddProduto, banco);
                cmd.ExecuteReader();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}
