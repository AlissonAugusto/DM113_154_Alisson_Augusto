using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente2.EstoqueServico;

namespace Cliente2
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("WS2007HttpBinding_IServicoEstoque");
            bool resposta = false;

            //Teste 1: Verificar o estoque atual do Produto 1
            Console.WriteLine("Teste 1: Verificar o estoque atual do Produto 1");
            int estoqueProduto1 = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque atual do Produto 1: {0}", estoqueProduto1);
            Console.WriteLine();

            //Teste 2: Adicionar 20 unidades para este produto
            Console.WriteLine("Teste 2: Adicionar 20 unidades para este produto");
            resposta = proxy.AdicionarEstoque("1000", 20);
            if (resposta)
            {
                Console.WriteLine("Foi adicionado 20 unidades ao produto 1");
            }
            else
            {
                Console.WriteLine("Não foi possível adicionar unidades ao produto 1");
            }
            Console.WriteLine();

            //Teste 3: Verificar o estoque do Produto 1 novamente
            Console.WriteLine("Teste 3: Verificar o estoque do Produto 1 novamente");
            estoqueProduto1 = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque atual do Produto 1: {0}", estoqueProduto1);
            Console.WriteLine();

            //Teste 4: Verificar o estoque atual do Produto 5
            Console.WriteLine("Teste 4: Verificar o estoque atual do Produto 5");
            int estoqueProduto5 = proxy.ConsultarEstoque("5000");
            Console.WriteLine("Estoque atual do Produto 5: {0}", estoqueProduto5);
            Console.WriteLine();

            //Teste 5: Remover 10 unidades para este produto
            Console.WriteLine("Teste 5: Remover 10 unidades para este produto");
            resposta = proxy.RemoverEstoque("5000", 10);
            if (resposta)
            {
                Console.WriteLine("Foi removido 10 unidades do produto 5");
            }
            else
            {
                Console.WriteLine("Não foi possível remover unidades do produto 5");
            }
            Console.WriteLine();

            //Teste 6: Verificar o estoque do Produto 5 novamente
            Console.WriteLine("Teste 6: Verificar o estoque do Produto 5 novamente");
            estoqueProduto5 = proxy.ConsultarEstoque("5000");
            Console.WriteLine("Estoque atual do Produto 5: {0}", estoqueProduto5);
            Console.WriteLine();
        }
    }
}
