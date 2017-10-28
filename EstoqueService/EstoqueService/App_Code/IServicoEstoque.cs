using EstoqueEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EstoqueLibrary
{
    [DataContract]
    public class Produto
    {
        [DataMember]
        private string NumeroProduto { get; set; }

        [DataMember]
        private string NomeProduto { get; set; }

        [DataMember]
        private string DescricaoProduto { get; set; }

        [DataMember]
        private int EstoqueProduto { get; set; }
    }

    [ServiceContract/*(Namespace = "http://projetoavaliativo.dm113/01", Name = "IServicoEstoque")*/]
    public interface IServicoEstoque
    {
        [OperationContract]
        List<string> ListarProdutos();

        [OperationContract]
        bool IncluirProduto(ProdutoEstoque Produto);

        [OperationContract]
        bool RemoverProduto(string NumeroProduto);

        [OperationContract]
        int ConsultarEstoque(string NumeroProduto);

        [OperationContract]
        bool AdicionarEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        bool RemoverEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        ProdutoEstoque VerProduto(string NumeroProduto);
    }

    [ServiceContract/*(Namespace = "http://projetoavaliativo.dm113/02", Name = "IServicoEstoqueV2")*/]
    public interface IServicoEstoqueV2
    {
        [OperationContract]
        bool AdicionarEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        bool RemoverEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        int ConsultarEstoque(string NumeroProduto);
    }
}

