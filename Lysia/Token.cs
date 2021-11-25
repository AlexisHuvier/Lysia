namespace Lysia
{
    enum TokenType
    {
        OPEN_PAREN,
        CLOSE_PAREN,
        IDENTIFIER,
        INTEGER,
        FLOAT,
        STRING,
        UNKOWN
    }

    class Token
    {
        public string value = "";
        public TokenType type = TokenType.UNKOWN;
        public int line = 0;
        public int column = 0;

        public Token(string value, TokenType type, int line, int column)
        {
            this.value = value;
            this.type = type;
            this.line = line;
            this.column = column;
        }

        public override string ToString()
        {
            return $"Token(value={value}, type={type}, line={line}, column={column})";
        }
    }
}
