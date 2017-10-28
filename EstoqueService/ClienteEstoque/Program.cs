using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Cliente1.EstoqueServico;

namespace Cliente1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");
            bool resposta = false;

            //Teste 1: Adicionar um produto
            Console.WriteLine("Teste 1: Adicionar um produto");
            ProdutoEstoque produto11 = new ProdutoEstoque();
            produto11.NumeroProduto = "11000";
            produto11.NomeProduto = "Produto 11";
            produto11.DescricaoProduto = "Este é o produto 11";
            produto11.EstoqueProduto = 110;
            resposta = proxy.IncluirProduto(produto11);
            if (resposta)
            {
                Console.WriteLine("O produto 11 foi adicionado");
            }
            else
            {
                Console.WriteLine("Não foi possível adicionar o produto 11");
            }
            Console.WriteLine();

            //Teste 2: Remover o produto 10
            Console.WriteLine("Teste 2: Remover o produto 10");
            resposta = proxy.RemoverProduto("10000");
            if (resposta)
            {
                Console.WriteLine("O produto 10 foi removido");
            }
            else
            {
                Console.WriteLine("Não foi possível remover o produto 10");
            }
            Console.WriteLine();

            //Teste 3: Listar todos os produtos
            Console.WriteLine("Teste 3: Listar todos os produtos");
            List<string> produtos = proxy.ListarProdutos().ToList();
            foreach (string p in produtos)
            {
                Console.WriteLine("Nome: {0}", p);
                Console.WriteLine();
            }

            //Teste 4: Verificar todas as informações do Produto 2
            Console.WriteLine("Teste 4: Verificar todas as informações do Produto 2");
            ProdutoEstoque produto2 = new ProdutoEstoque();
            produto2 = proxy.VerProduto("2000");
            Console.WriteLine("Numero do Produto: {0}", produto2.NumeroProduto);
            Console.WriteLine();
            Console.WriteLine("Nome do Produto: {0}", produto2.NomeProduto);
            Console.WriteLine();
            Console.WriteLine("Descrição do Produto: {0}", produto2.DescricaoProduto);
            Console.WriteLine();
            Console.WriteLine("Estoque do Produto: {0}", produto2.EstoqueProduto);
            Console.WriteLine();

            //Teste 5: Adicionar 10 unidades para este produto
            Console.WriteLine("Teste 5: Adicionar 10 unidades para este produto");
            resposta = proxy.AdicionarEstoque("2000", 10);
            if (resposta)
            {
                Console.WriteLine("Foi adicionado 10 unidades ao produto 2");
            }
            else
            {
                Console.WriteLine("Não foi possível adicionar unidades ao produto 2");
            }
            Console.WriteLine();

            //Teste 6: Verificar o estoque do Produto 2
            Console.WriteLine("Teste 6: Verificar o estoque do Produto 2");
            int estoqueProduto2 = proxy.ConsultarEstoque("2000");
            Console.WriteLine("Estoque atual do Produto 2: {0}", estoqueProduto2);
            Console.WriteLine();

            //Teste 7: Verificar o estoque atual do Produto 1
            Console.WriteLine("Teste 7: Verificar o estoque atual do Produto 1");
            int estoqueProduto1 = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque atual do Produto 1: {0}", estoqueProduto1);
            Console.WriteLine();

            //Teste 8: Remover 20 unidades para este produto
            Console.WriteLine("Teste 8: Remover 20 unidades para este produto");
            resposta = proxy.RemoverEstoque("1000", 20);
            if (resposta)
            {
                Console.WriteLine("Foi removido 20 unidades do produto 1");
            }
            else
            {
                Console.WriteLine("Não foi possível remover unidades do produto 1");
            }
            Console.WriteLine();

            //Teste 9:  Verificar o estoque do Produto 1 novamente
            Console.WriteLine("Teste 9:  Verificar o estoque do Produto 1 novamente");
            estoqueProduto1 = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque atual do Produto 1: {0}", estoqueProduto1);
            Console.WriteLine();

            //Teste 10: Verificar todas as informações do Produto 2
            Console.WriteLine("Teste 10: Verificar todas as informações do Produto 1");
            ProdutoEstoque produto1 = new ProdutoEstoque();
            produto1 = proxy.VerProduto("1000");
            Console.WriteLine("Numero do Produto: {0}", produto1.NumeroProduto);
            Console.WriteLine();
            Console.WriteLine("Nome do Produto: {0}", produto1.NomeProduto);
            Console.WriteLine();
            Console.WriteLine("Descrição do Produto: {0}", produto1.DescricaoProduto);
            Console.WriteLine();
            Console.WriteLine("Estoque do Produto: {0}", produto1.EstoqueProduto);
            Console.WriteLine();

            proxy.Close();
        }
    }
}
