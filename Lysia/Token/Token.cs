namespace Lysia.Token;

public record Token(string Value, TokenType Type, int Line, int Column);