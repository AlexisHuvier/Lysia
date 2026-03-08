# Module - IO:File

Provides functions for file operations

## Function - Create

Creates a new file

Symbol : io:file:create  
Parameters : 1 - string  
Parameters evaluated : Yes

Examples : 
- `(io:file:create test.txt)` => file stream

## Function - Delete

Deletes a file

Symbol : io:file:delete  
Parameters : 1 - string  
Parameters evaluated : Yes

Examples : 
- `(io:file:delete test.txt)` => true

## Function - Exists

Checks if a file exists

Symbol : io:file:exists  
Parameters : 1 - string  
Parameters evaluated : Yes

Examples : 
- `(io:file:exists test.txt)` => true

## Function - Read

Reads the contents of a file

Symbol : io:file:read  
Parameters : 1 - string  
Parameters evaluated : Yes

Examples : 
- `(io:file:read test.txt)` => file contents

## Function - ReadLines

Reads the contents of a file as a list of lines

Symbol : io:file:readlines  
Parameters : 1 - string  
Parameters evaluated : Yes

Examples : 
- `(io:file:readlines test.txt)` => list of file lines

## Function - Write

Writes content to a file

Symbol : io:file:write  
Parameters : 2 - string, string  
Parameters evaluated : Yes

Examples : 
- `(io:file:write test.txt "Hello, World!")` => true

## Function - WriteLines

Writes a list of lines to a file

Symbol : io:file:writelines  
Parameters : 2 - string, string  
Parameters evaluated : Yes

Examples : 
- `(io:file:writelines target.txt (io:file:readlines source.txt))` => true

