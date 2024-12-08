namespace CS.RedeSocial.Domain;

public class ValidationException : Exception
{
    public ValidationException()
    {
        Errors = new List<string>();
    }

    public List<string> Errors { get; set; }

    public bool hasError => Errors.Any();
}
