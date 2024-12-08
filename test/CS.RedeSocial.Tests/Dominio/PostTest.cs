using System.Runtime;
using CS.RedeSocial.Domain;

namespace CS.RedeSocial.Dominio.Tests;

[TestClass]
public class PostTest
{
    #region Mensagens
    private string IdObrigatorio = Mensagem.ID_OGRIGATORIO;
    private string DescricaoObrigatorio = Mensagem.DESCRICAO_OGRIGATORIO;
    private string DescricaoTamanhoMaximo = Mensagem.DESCRICAO_TAMANHO_MAXIMO;
    #endregion

    Guid Id = Guid.NewGuid();
    string Descricao = "Descrição post";

    [TestMethod]
    public void TestPostDeveRetornarErroIdObrigatorio()
    {
        //arrange
        Id = Guid.Empty;

        //act
        var exceptionErrors = Assert.ThrowsException<ValidationException>(
            () => new Post(Id, Descricao)
        );

        //assert
        Assert.IsTrue(exceptionErrors.Errors.Contains(IdObrigatorio));
        Assert.IsFalse(exceptionErrors.Errors.Contains(DescricaoObrigatorio));
    }

    [TestMethod]
    public void TestPostDeveRetornarErroDescricaoObrigatorio()
    {
        //arrange
        Descricao = string.Empty;

        //act
        var exceptionErrors = Assert.ThrowsException<ValidationException>(
            () => new Post(Id, Descricao)
        );

        //assert
        Assert.IsFalse(exceptionErrors.Errors.Contains(IdObrigatorio));
        Assert.IsTrue(exceptionErrors.Errors.Contains(DescricaoObrigatorio));
    }

    [TestMethod]
    public void TestPostDeveRetornarErroDescricaoTamanhoExcedido()
    {
        //arrange
        Descricao =
            "Em um mundo onde a tecnologia avança rapidamente, a inovação se torna essencial. Empresas buscam soluções criativas para se destacar, enquanto consumidores exigem produtos de alta qualidade e eficiência.";

        //act
        var exceptionErrors = Assert.ThrowsException<ValidationException>(
            () => new Post(Id, Descricao)
        );

        //assert
        Assert.IsFalse(exceptionErrors.Errors.Contains(IdObrigatorio));
        Assert.IsFalse(exceptionErrors.Errors.Contains(DescricaoObrigatorio));
        Assert.IsTrue(exceptionErrors.Errors.Contains(DescricaoTamanhoMaximo));
    }

    [TestMethod]
    public void TestPostDeveRetornarPostOk()
    {
        //arrange & act
        var post = new Post(Id, Descricao);

        //assert
        Assert.AreEqual(Id, post.Id);
        Assert.AreEqual(Descricao, post.Descricao);
    }
}
