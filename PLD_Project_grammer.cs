
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF          =  0, // (EOF)
        SYMBOL_ERROR        =  1, // (Error)
        SYMBOL_WHITESPACE   =  2, // Whitespace
        SYMBOL_MINUS        =  3, // '-'
        SYMBOL_EXCLAMEQ     =  4, // '!='
        SYMBOL_PERCENT      =  5, // '%'
        SYMBOL_LPAREN       =  6, // '('
        SYMBOL_RPAREN       =  7, // ')'
        SYMBOL_TIMES        =  8, // '*'
        SYMBOL_TIMESTIMES   =  9, // '**'
        SYMBOL_COMMA        = 10, // ','
        SYMBOL_DIV          = 11, // '/'
        SYMBOL_COLON        = 12, // ':'
        SYMBOL_LBRACKET     = 13, // '['
        SYMBOL_RBRACKET     = 14, // ']'
        SYMBOL__            = 15, // '_'
        SYMBOL_PLUS         = 16, // '+'
        SYMBOL_PLUSEQ       = 17, // '+='
        SYMBOL_LT           = 18, // '<'
        SYMBOL_LTEQ         = 19, // '<='
        SYMBOL_EQ           = 20, // '='
        SYMBOL_MINUSEQ      = 21, // '-='
        SYMBOL_EQEQ         = 22, // '=='
        SYMBOL_GT           = 23, // '>'
        SYMBOL_GTEQ         = 24, // '>='
        SYMBOL_CASE         = 25, // case
        SYMBOL_DIGIT        = 26, // Digit
        SYMBOL_DO           = 27, // do
        SYMBOL_ELSE         = 28, // else
        SYMBOL_END          = 29, // End
        SYMBOL_FOR          = 30, // for
        SYMBOL_ID           = 31, // ID
        SYMBOL_IF           = 32, // if
        SYMBOL_IN           = 33, // in
        SYMBOL_MATCH        = 34, // match
        SYMBOL_START        = 35, // Start
        SYMBOL_WHILE        = 36, // while
        SYMBOL_ARR_ITEM     = 37, // <arr_item>
        SYMBOL_ARRAY        = 38, // <array>
        SYMBOL_ASSIGN       = 39, // <assign>
        SYMBOL_CASE_BLOCK   = 40, // <case_block>
        SYMBOL_CASE_STMT    = 41, // <case_stmt>
        SYMBOL_CONCEPT      = 42, // <concept>
        SYMBOL_CONDITION    = 43, // <condition>
        SYMBOL_DEFAULT_CASE = 44, // <default_case>
        SYMBOL_DIGIT2       = 45, // <digit>
        SYMBOL_DO_WHILE     = 46, // <do_while>
        SYMBOL_ELEMENT      = 47, // <element>
        SYMBOL_ELEMENTS     = 48, // <elements>
        SYMBOL_EMPTY        = 49, // <empty>
        SYMBOL_EX           = 50, // <ex>
        SYMBOL_EXPR         = 51, // <expr>
        SYMBOL_FACTOR       = 52, // <factor>
        SYMBOL_FOR2         = 53, // <for>
        SYMBOL_ID2          = 54, // <id>
        SYMBOL_IF2          = 55, // <if>
        SYMBOL_MATCH_STMT   = 56, // <match_stmt>
        SYMBOL_OP           = 57, // <op>
        SYMBOL_PROGRAM      = 58, // <program>
        SYMBOL_STAT_LIST    = 59, // <stat_list>
        SYMBOL_STEP         = 60, // <step>
        SYMBOL_TERM         = 61, // <term>
        SYMBOL_WHILE2       = 62  // <while>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END         =  0, // <program> ::= Start <stat_list> End
        RULE_STAT_LIST                 =  1, // <stat_list> ::= <concept> <stat_list>
        RULE_STAT_LIST2                =  2, // <stat_list> ::= <empty>
        RULE_CONCEPT                   =  3, // <concept> ::= <assign>
        RULE_CONCEPT2                  =  4, // <concept> ::= <if>
        RULE_CONCEPT3                  =  5, // <concept> ::= <for>
        RULE_CONCEPT4                  =  6, // <concept> ::= <while>
        RULE_CONCEPT5                  =  7, // <concept> ::= <match_stmt>
        RULE_CONCEPT6                  =  8, // <concept> ::= <do_while>
        RULE_ASSIGN_EQ                 =  9, // <assign> ::= <id> '=' <expr>
        RULE_ID_ID                     = 10, // <id> ::= ID
        RULE_EXPR_PLUS                 = 11, // <expr> ::= <expr> '+' <expr>
        RULE_EXPR_MINUS                = 12, // <expr> ::= <expr> '-' <expr>
        RULE_EXPR                      = 13, // <expr> ::= <term>
        RULE_TERM_TIMES                = 14, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                  = 15, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT              = 16, // <term> ::= <term> '%' <factor>
        RULE_TERM                      = 17, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES         = 18, // <factor> ::= <factor> '**' <ex>
        RULE_FACTOR                    = 19, // <factor> ::= <ex>
        RULE_EX_LPAREN_RPAREN          = 20, // <ex> ::= '(' <expr> ')'
        RULE_EX                        = 21, // <ex> ::= <id>
        RULE_EX2                       = 22, // <ex> ::= <digit>
        RULE_DIGIT_DIGIT               = 23, // <digit> ::= Digit
        RULE_EMPTY                     = 24, // <empty> ::= 
        RULE_IF_IF_COLON               = 25, // <if> ::= if <condition> ':' <stat_list>
        RULE_IF_IF_COLON_ELSE          = 26, // <if> ::= if <condition> ':' <stat_list> else <stat_list>
        RULE_CONDITION                 = 27, // <condition> ::= <expr> <op> <expr>
        RULE_OP_LT                     = 28, // <op> ::= '<'
        RULE_OP_GT                     = 29, // <op> ::= '>'
        RULE_OP_EQEQ                   = 30, // <op> ::= '=='
        RULE_OP_EXCLAMEQ               = 31, // <op> ::= '!='
        RULE_OP_LTEQ                   = 32, // <op> ::= '<='
        RULE_OP_GTEQ                   = 33, // <op> ::= '>='
        RULE_MATCH_STMT_MATCH_COLON    = 34, // <match_stmt> ::= match <id> ':' <case_block>
        RULE_CASE_BLOCK                = 35, // <case_block> ::= <case_stmt> <case_block>
        RULE_CASE_BLOCK2               = 36, // <case_block> ::= <default_case>
        RULE_CASE_STMT_CASE_COLON      = 37, // <case_stmt> ::= case <digit> ':' <stat_list>
        RULE_DEFAULT_CASE_CASE___COLON = 38, // <default_case> ::= case '_' ':' <stat_list>
        RULE_FOR_FOR_IN_COLON          = 39, // <for> ::= for <id> in <arr_item> ':' <stat_list>
        RULE_ARR_ITEM                  = 40, // <arr_item> ::= <array>
        RULE_ARR_ITEM2                 = 41, // <arr_item> ::= <id>
        RULE_ARRAY_LBRACKET_RBRACKET   = 42, // <array> ::= '[' <elements> ']'
        RULE_ARRAY_LBRACKET_RBRACKET2  = 43, // <array> ::= '[' ']'
        RULE_ELEMENTS_COMMA            = 44, // <elements> ::= <element> ',' <elements>
        RULE_ELEMENTS                  = 45, // <elements> ::= <element>
        RULE_ELEMENT                   = 46, // <element> ::= <id>
        RULE_ELEMENT2                  = 47, // <element> ::= <digit>
        RULE_WHILE_WHILE_COLON         = 48, // <while> ::= while <condition> ':' <stat_list>
        RULE_WHILE_WHILE_COLON2        = 49, // <while> ::= while <condition> ':' <stat_list> <step>
        RULE_STEP_EQ_PLUS              = 50, // <step> ::= <id> '=' <id> '+' <digit>
        RULE_STEP_EQ_MINUS             = 51, // <step> ::= <id> '=' <id> '-' <digit>
        RULE_STEP_PLUSEQ               = 52, // <step> ::= <id> '+=' <digit>
        RULE_STEP_MINUSEQ              = 53, // <step> ::= <id> '-=' <digit>
        RULE_DO_WHILE_DO_COLON_WHILE   = 54  // <do_while> ::= do ':' <stat_list> while <condition>
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL__ :
                //'_'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSEQ :
                //'+='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSEQ :
                //'-='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //End
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //ID
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MATCH :
                //match
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //Start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARR_ITEM :
                //<arr_item>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARRAY :
                //<array>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE_BLOCK :
                //<case_block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE_STMT :
                //<case_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITION :
                //<condition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT_CASE :
                //<default_case>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO_WHILE :
                //<do_while>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELEMENT :
                //<element>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELEMENTS :
                //<elements>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EMPTY :
                //<empty>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EX :
                //<ex>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR2 :
                //<for>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF2 :
                //<if>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MATCH_STMT :
                //<match_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STAT_LIST :
                //<stat_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE2 :
                //<while>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<program> ::= Start <stat_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STAT_LIST :
                //<stat_list> ::= <concept> <stat_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STAT_LIST2 :
                //<stat_list> ::= <empty>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <if>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <for>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <while>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT5 :
                //<concept> ::= <match_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT6 :
                //<concept> ::= <do_while>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ :
                //<assign> ::= <id> '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= ID
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <ex>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <ex>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EX_LPAREN_RPAREN :
                //<ex> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EX :
                //<ex> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EX2 :
                //<ex> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EMPTY :
                //<empty> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_IF_COLON :
                //<if> ::= if <condition> ':' <stat_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_IF_COLON_ELSE :
                //<if> ::= if <condition> ':' <stat_list> else <stat_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION :
                //<condition> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LTEQ :
                //<op> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GTEQ :
                //<op> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MATCH_STMT_MATCH_COLON :
                //<match_stmt> ::= match <id> ':' <case_block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_BLOCK :
                //<case_block> ::= <case_stmt> <case_block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_BLOCK2 :
                //<case_block> ::= <default_case>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_STMT_CASE_COLON :
                //<case_stmt> ::= case <digit> ':' <stat_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEFAULT_CASE_CASE___COLON :
                //<default_case> ::= case '_' ':' <stat_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_FOR_IN_COLON :
                //<for> ::= for <id> in <arr_item> ':' <stat_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARR_ITEM :
                //<arr_item> ::= <array>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARR_ITEM2 :
                //<arr_item> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARRAY_LBRACKET_RBRACKET :
                //<array> ::= '[' <elements> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARRAY_LBRACKET_RBRACKET2 :
                //<array> ::= '[' ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELEMENTS_COMMA :
                //<elements> ::= <element> ',' <elements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELEMENTS :
                //<elements> ::= <element>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELEMENT :
                //<element> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELEMENT2 :
                //<element> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_WHILE_COLON :
                //<while> ::= while <condition> ':' <stat_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_WHILE_COLON2 :
                //<while> ::= while <condition> ':' <stat_list> <step>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_EQ_PLUS :
                //<step> ::= <id> '=' <id> '+' <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_EQ_MINUS :
                //<step> ::= <id> '=' <id> '-' <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSEQ :
                //<step> ::= <id> '+=' <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSEQ :
                //<step> ::= <id> '-=' <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DO_WHILE_DO_COLON_WHILE :
                //<do_while> ::= do ':' <stat_list> while <condition>
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
