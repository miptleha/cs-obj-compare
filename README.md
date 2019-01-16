Compare two objects: identical they or not.  
Not just say, that xml are equal or different, but say where is difference.
Performs a deep comparison of nested properties and data, including arrays, lists, dictionaries, primitive types, etc.  

## How to use
```csharp
var res = Comparer.Compare(new { Amount = 108, Message = "Hello" }, new { Amount = 108, Message = "Hello2" });
if (res != null)
    Console.WriteLine("objects are different: " + res);
else
    Console.WriteLine("objects are the same");
```
 
For more samples, see [Program.cs](Program.cs)
