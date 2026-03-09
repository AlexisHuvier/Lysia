# Module - List

Provides functions for list operations

## Function - Create

Creates a new list

Symbol : list:create  
Parameters : Any number - Any type  
Parameters evaluated : Yes

Examples : 
- `(list:create 1 2 3)` => [1, 2, 3]

## Function - First

Returns the first element of a list

Symbol : list:first  
Parameters : 1 - list  
Parameters evaluated : Yes

Examples : 
- `(list:first [1 2 3])` => 1

## Function - Last

Returns the last element of a list

Symbol : list:last  
Parameters : 1 - list  
Parameters evaluated : Yes

Examples : 
- `(list:last [1 2 3])` => 3

## Function - Range

Creates a list of integers from start to end

Symbol : list:range  
Parameters : 2 - int, int  
Parameters evaluated : Yes

Examples : 
- `(list:range 1 5)` => [1, 2, 3, 4]

## Function - Get

Returns the element at the given index of a list

Symbol : list:get  
Parameters : 2 - list, int  
Parameters evaluated : Yes

Examples : 
- `(list:get [1 2 3] 1)` => 2

## Function - Len

Returns the length of a list

Symbol : list:len  
Parameters : 1 - list  
Parameters evaluated : Yes

Examples : 
- `(list:len [1 2 3])` => 3

## Function - Add

Adds an element to the end of a list

Symbol : list:add  
Parameters : 2 - list,   
Parameters evaluated : Yes

Examples : 
- `(list:add [1 2] 3)` => [1, 2, 3]

## Function - Remove

Removes an element from a list by index

Symbol : list:remove  
Parameters : 2 - list, int  
Parameters evaluated : Yes

Examples : 
- `(list:remove [1 2 3] 1)` => [1, 3]

## Function - In

Checks if an element is in a list

Symbol : list:in  
Parameters : 2 - list,   
Parameters evaluated : Yes

Examples : 
- `(list:in [1 2 3] 2)` => true

## Function - Insert

Inserts an element at a specific index in a list

Symbol : list:insert  
Parameters : 3 - list, int,   
Parameters evaluated : Yes

Examples : 
- `(list:insert [1 2 3] 1 4)` => [1, 4, 2, 3]

## Function - Replace

Replaces an element at a specific index in a list

Symbol : list:set  
Parameters : 3 - list, int,   
Parameters evaluated : Yes

Examples : 
- `(list:replace [1 2 3] 1 4)` => [1, 4, 3]

## Function - Clear

Clears a list

Symbol : list:clear  
Parameters : 1 - list  
Parameters evaluated : Yes

Examples : 
- `(list:clear [1 2 3])` => []

## Function - AddList

Adds two lists together

Symbol : list:+  
Parameters : 2 - list, list  
Parameters evaluated : Yes

Examples : 
- `(list:+ [1 2] [3 4])` => [1, 2, 3, 4]

