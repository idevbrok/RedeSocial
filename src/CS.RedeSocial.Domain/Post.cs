namespace CS.RedeSocial.Domain;

public class Post : Base
{
    private readonly int maxLength = 200;

    public Post(Guid id, string descricao)
    {
        if (id == Guid.Empty)
            validationException.Errors.Add(Mensagem.ID_OGRIGATORIO);

        if (string.IsNullOrEmpty(descricao))
            validationException.Errors.Add(Mensagem.DESCRICAO_OGRIGATORIO);

        if (descricao.Length > maxLength)
            validationException.Errors.Add(Mensagem.DESCRICAO_TAMANHO_MAXIMO);

        if (validationException.hasError)
            throw validationException;

        this.Id = id;
        this.Descricao = descricao;
    }

    public string Descricao { get; private set; }
}
