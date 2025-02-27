using System.Text.RegularExpressions;

public class Email
{
    public string Value { get; private set; }

    private Email() { }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Email non valida");

        Value = value;
    }

    public override string ToString() => Value;
}
