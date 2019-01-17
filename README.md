Compare two objects: identical they or not.  
When found a difference, reports the place where the discrepancy is found.  
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
