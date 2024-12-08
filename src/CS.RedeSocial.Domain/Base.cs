namespace CS.RedeSocial.Domain;

public class Base
{
    public Base()
    {
        validationException = new ValidationException();
    }

    public ValidationException validationException { get; set; }

    public Guid Id { get; protected set; }
}
