using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EstoqueEntityModel;
using System.ServiceModel.Activation;
using EstoqueLibrary;

namespace Estoque
{
    // WCF service that implements the service contract
    // This implementation performs minimal error checking and exception handling
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicoEstoque : IServicoEstoque, IServicoEstoqueV2
    {
        public bool AdicionarEstoque(string NumeroProduto, int Quantidade)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = new ProdutoEstoque();
                    produtoEstoque = database.ProdutosEstoque.First(p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);

                    produtoEstoque.EstoqueProduto += Quantidade;

                    database.ProdutosEstoque.Remove(produtoEstoque);
                    database.SaveChanges();

                    database.ProdutosEstoque.Add(produtoEstoque);
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }


        public int ConsultarEstoque(string NumeroProduto)
        {
            int quantidadeTotal = 0;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    quantidadeTotal = (from s in database.ProdutosEstoque
                                       join p in database.ProdutosEstoque on s.NumeroProduto equals p.NumeroProduto
                                       where String.Compare(p.NumeroProduto, NumeroProduto) == 0
                                       select (int)s.EstoqueProduto).Sum();
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            return quantidadeTotal;
        }

        public bool IncluirProduto(ProdutoEstoque Produto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    database.ProdutosEstoque.Add(Produto);

                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<string> ListarProdutos()
        {
            List<string> listaProdutos = new List<string>();
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    List<string> nomesProdutos = (from ProdutoEstoques in database.ProdutosEstoque select ProdutoEstoques.NomeProduto).ToList();
                    foreach (string nomeProduto in nomesProdutos)
                    {
                        listaProdutos.Add(nomeProduto);
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            return listaProdutos;
        }

        public bool RemoverEstoque(string NumeroProduto, int Quantidade)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = new ProdutoEstoque();
                    produtoEstoque = database.ProdutosEstoque.First(p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);
                    produtoEstoque.EstoqueProduto -= Quantidade;

                    database.ProdutosEstoque.Remove(produtoEstoque);
                    database.SaveChanges();

                    database.ProdutosEstoque.Add(produtoEstoque);
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool RemoverProduto(string NumeroProduto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = new ProdutoEstoque();
                    produtoEstoque = database.ProdutosEstoque.First(p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);
                    database.ProdutosEstoque.Remove(produtoEstoque);

                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public ProdutoEstoque VerProduto(string NumeroProduto)
        {
            ProdutoEstoque dadosProduto = null;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produto = database.ProdutosEstoque.First(p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);
                    dadosProduto = new ProdutoEstoque()
                    {
                        NumeroProduto = produto.NumeroProduto,
                        NomeProduto = produto.NomeProduto,
                        DescricaoProduto = produto.DescricaoProduto,
                        EstoqueProduto = produto.EstoqueProduto
                    };
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            return dadosProduto;
        }
    }

}

