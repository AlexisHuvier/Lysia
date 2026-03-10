# Module - Dict

Provides functions for dictionary operations

## Function - Create

Creates a new dict

Symbol : dict:create  
Parameters : 2 - list, list  
Parameters evaluated : Yes

Examples : 
- `(dict:create (list:create 1 2 3) (list:create 1 1 1))` => { 1 => 1, 2 => 1, 3 => 1 }

## Function - Get

Gets the value of a key in a dict

Symbol : dict:get  
Parameters : 2 - dict,   
Parameters evaluated : Yes

Examples : 
- `(dict:get (dict:create (list:create 1 2 3) (list:create 1 1 1)) 2)` => 1

## Function - Set

Sets the value of a key in a dict

Symbol : dict:set  
Parameters : 3 - dict, ,   
Parameters evaluated : Yes

Examples : 
- `(dict:set (dict:create (list:create 1 2 3) (list:create 1 1 1)) 2 3)` => { 1 => 1, 2 => 3, 3 => 1 }

## Function - HasKey

Checks if a dict has a key

Symbol : dict:haskey  
Parameters : 2 - dict,   
Parameters evaluated : Yes

Examples : 
- `(dict:has-key (dict:create (list:create 1 2 3) (list:create 1 1 1)) 2)` => true

## Function - HasValue

Checks if a dict has a value

Symbol : dict:hasvalue  
Parameters : 2 - dict,   
Parameters evaluated : Yes

Examples : 
- `(dict:has-value (dict:create (list:create 1 2 3) (list:create 1 1 1)) 1)` => true

## Function - Keys

Gets the keys of a dict

Symbol : dict:keys  
Parameters : 1 - dict  
Parameters evaluated : Yes

Examples : 
- `(dict:keys (dict:create (list:create 1 2 3) (list:create 1 1 1)))` => [1, 2, 3]

## Function - Values

Gets the values of a dict

Symbol : dict:values  
Parameters : 1 - dict  
Parameters evaluated : Yes

Examples : 
- `(dict:values (dict:create (list:create 1 2 3) (list:create 1 1 1)))` => [1, 1, 1]

