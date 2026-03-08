# Module - core

This module contains all the core functions of Lysia. You can use it without importations.

## Function - Cast

Converts the given value to the specified type

Symbol : cast  
Parameters : 2 - Any type  
Parameters evaluated : No

Examples : 
- `(cast 1 float)` => 1.0

## Function - Comment

Adds a comment to the code

Symbol : #  
Parameters : Any number - Any type  
Parameters evaluated : No

Examples : 
- `(# This is a comment)` => 

## Function - Def

Defines a new variable with the given name and value

Symbol : def  
Parameters : 2 - Any type  
Parameters evaluated : No

Examples : 
- `(def x 2)` => 2

## Function - Del

Deletes the variable with the given name

Symbol : del  
Parameters : 1 - Any type  
Parameters evaluated : No

Examples : 
- `(del x)` => 

## Function - For

Iterates over a range of values

Symbol : for  
Parameters : 3 - Any type  
Parameters evaluated : No

Examples : 
- `(for i (0 10 1) (io:display i))` => 0 1 2 3 4 5 6 7 8 9

## Function - Func

Defines a new function with the given name and body

Symbol : func  
Parameters : 2 - Any type  
Parameters evaluated : No

Examples : 
- `(func (x y) (ret (+ x y)))` => Function which adds two numbers

## Function - Import

Imports a module or file

Symbol : import  
Parameters : 1 - Any type  
Parameters evaluated : No

Examples : 
- `(import io)` => 
- `(import externModule)` => 
- `(import file.lysia)` => 

## Function - Ret

Returns a value from a function

Symbol : ret  
Parameters : 1 - Any type  
Parameters evaluated : Yes

Examples : 
- `(ret 42)` => 42

## Function - TypeOf

Returns the type of a value

Symbol : typeof  
Parameters : 1 - Any type  
Parameters evaluated : Yes

Examples : 
- `(typeof 42)` => int

## Function - While

Executes the given code while the condition is true

Symbol : while  
Parameters : 2 - Any type  
Parameters evaluated : No

Examples : 
- `(while (!= 1 1) (io:display true))` => 

## Function - If

Executes the given code if the condition is true, otherwise executes the given code

Symbol : if  
Parameters : 3 - Any type  
Parameters evaluated : No

Examples : 
- `(if (== 1 1) (io:display true) (io:display false))` => true

## Function - Add

Adds all the given values together

Symbol : +  
Parameters : Any number - int, float, string  
Parameters evaluated : Yes

Examples : 
- `(+ 1 2 3)` => 6

## Function - Div

Divides all the given values

Symbol : /  
Parameters : Any number - int, float  
Parameters evaluated : Yes

Examples : 
- `(/ 2 2 2)` => 0.5

## Function - Mod

Returns the remainder of the division of all the given values

Symbol : %  
Parameters : Any number - int, float  
Parameters evaluated : Yes

Examples : 
- `(% 2 2 2)` => 0

## Function - Mul

Multiplies all the given values

Symbol : *  
Parameters : Any number - int, float  
Parameters evaluated : Yes

Examples : 
- `(* 2 2 2)` => 8

## Function - Sub

Subtracts all the given values

Symbol : -  
Parameters : Any number - int, float  
Parameters evaluated : Yes

Examples : 
- `(- 2 2 3)` => -3
- `(- 2)` => -2

## Function - And

Returns true if both values are true

Symbol : &&  
Parameters : 2 - bool, bool  
Parameters evaluated : Yes

Examples : 
- `(&& true true)` => true

## Function - Equals

Returns true if both values are equal

Symbol : ==  
Parameters : 2 - Any type  
Parameters evaluated : Yes

Examples : 
- `(== 42 42)` => true

## Function - Greater

Returns true if the first value is greater than the second

Symbol : >  
Parameters : 2 - Any type  
Parameters evaluated : Yes

Examples : 
- `(> 42 41)` => true

## Function - GreaterOrEquals

Returns true if the first value is greater than or equal to the second

Symbol : >=  
Parameters : 2 - Any type  
Parameters evaluated : Yes

Examples : 
- `(>= 42 42)` => true

## Function - Less

Returns true if the first value is less than the second

Symbol : <  
Parameters : 2 - Any type  
Parameters evaluated : Yes

Examples : 
- `(< 42 43)` => true

## Function - LessOrEquals

Returns true if the first value is less than or equal to the second

Symbol : <=  
Parameters : 2 - Any type  
Parameters evaluated : Yes

Examples : 
- `(<= 42 42)` => true

## Function - NotEquals

Returns true if the first value is not equal to the second

Symbol : !=  
Parameters : 2 - Any type  
Parameters evaluated : Yes

Examples : 
- `(!= 42 43)` => true

## Function - Or

Returns true if either value is true

Symbol : ||  
Parameters : 2 - bool, bool  
Parameters evaluated : Yes

Examples : 
- `(|| true false)` => true

## Function - Not

Returns the opposite of the value

Symbol : !  
Parameters : 1 - bool  
Parameters evaluated : Yes

Examples : 
- `(! true)` => false

## Variable - true

Value : True

## Variable - false

Value : False

