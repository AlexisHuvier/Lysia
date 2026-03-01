using JetBrains.Annotations;

namespace Lysia.Token;

public record Token(string Value, TokenType Type, [UsedImplicitly] int Line, [UsedImplicitly] int Column);