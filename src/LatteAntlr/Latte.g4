grammar Latte;

program
    : topDef+
    ;

topDef
    : type_ ID '(' arg? ')' block       # functionDef
    | 'class' ID ('extends' ID)? '{' fieldOrMethodDef* '}'      # classDef
    ;

fieldOrMethodDef
    : fieldDef ';'
    | methodDef
    ;

fieldDef
    : type_ ID ( ',' ID )*
    ;

methodDef
    : type_ ID '(' arg? ')' block
    ;

arg
    : type_ ID ( ',' type_ ID )*
    ;

block
    : '{' stmt* '}'
    ;

stmt
    : ';'                                # Empty
    | block                              # BlockStmt
    | type_ item ( ',' item )* ';'       # Decl
    | ID '=' expr ';'                    # Ass
    | expr '.' ID '=' expr ';'           # StructAss
    | expr '[' expr ']' '=' expr ';'     # ArrayAss
    | ID '++' ';'                        # Incr
    | ID '--' ';'                        # Decr
    | expr '.' ID '++' ';'               # StructIncr
    | expr '.' ID '--' ';'               # StructDecr
    | 'return' expr ';'                  # Ret
    | 'return' ';'                       # VRet
    | 'if' '(' expr ')' stmt             # Cond
    | 'if' '(' expr ')' stmt 'else' stmt # CondElse
    | 'while' '(' expr ')' stmt          # While
    | 'for' '(' type_ ID ':' expr ')' stmt #ForEach
    | expr ';'                           # SExp
    ;

type_
    : ID                                 # TTypeName
    | type_ '[' ']'                      # TArray
    ;

item
    : ID
    | ID '=' expr
    ;

expr
    : expr '.' ID '(' ( expr ( ',' expr )* )? ')' # EMethodCall
    | '(' type_ '!' ')' expr              # EForceCast
    | '(' type_ ')' expr                  # ECast
    | expr '.' ID                         # EObjectField
    | expr '[' expr ']'                   # EArrayAccess
    | 'new' type_ '[' expr ']'            # ENewArray
    | unOp expr                           # EUnOp
    | expr mulOp expr                     # EMulOp
    | expr addOp expr                     # EAddOp
    | expr relOp expr                     # ERelOp
    | <assoc=right> expr '&&' expr        # EAnd
    | <assoc=right> expr '||' expr        # EOr
    | ID                                  # EId
    | INT                                 # EInt
    | 'true'                              # ETrue
    | 'false'                             # EFalse
    | 'null'                              # ENull
    | 'new' type_                         # ENewObject
    | ID '(' ( expr ( ',' expr )* )? ')'  # EFunCall
    | STR                                 # EStr
    | '(' expr ')'                        # EParen
    ;

unOp
    : '-' # UnaryMinus
    | '!' # UnaryNeg
    ;

addOp
    : '+' # Plus
    | '-' # Minus
    ;

mulOp
    : '*' # Multiply
    | '/' # Divide
    | '%' # Modulo
    ;

relOp
    : '<'  # LessThan
    | '<=' # LessEquals
    | '>' # GreaterThan
    | '>=' # GreaterEquals
    | '==' # Equals
    | '!=' # NotEquals
    ;

COMMENT : ('#' ~[\r\n]* | '//' ~[\r\n]*) -> channel(HIDDEN);
MULTICOMMENT : '/*' .*? '*/' -> channel(HIDDEN);

fragment Letter  : Capital | Small ;
fragment Capital : [A-Z\u00C0-\u00D6\u00D8-\u00DE] ;
fragment Small   : [a-z\u00DF-\u00F6\u00F8-\u00FF] ;
fragment Digit : [0-9] ;

INT : Digit+ ;
fragment ID_First : Letter | '_';
ID : ID_First (ID_First | Digit)* ;

WS : (' ' | '\r' | '\t' | '\n')+ ->  skip;

STR
    :   '"' StringCharacters? '"'
    ;
fragment StringCharacters
    :   StringCharacter+
    ;
fragment
StringCharacter
    :   ~["\\]
    |   '\\' [tnr"\\]
    ;
