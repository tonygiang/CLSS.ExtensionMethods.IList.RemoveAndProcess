# CLSS.ExtensionMethods.IList.RemoveAndProcess

### Problem

It's common to find situations where removing an object from a collection means you also want to do something with it, such as disposing of it. In a barebone .NET application, you can count on the .NET Garbage Collector to clean up the removed object, but in many domains, disposing of an unused object requires an additional manual call, as the framework still keep references to it. These 2 operations are each done in a separate line of code and therefore not very friendly to a functional syntax.

```csharp
DisposeObject(Objects[4]);
Objects.RemoveAt(4);
```

### Solution

`RemoveAndProcess` is an extension method for all `IList<T>` types that combines these 2 steps into 1 method.

```csharp
using CLSS;

Objects.RemoveAndProcess(4, DisposeObject);
// using a lambda expression
Objects.RemoveAndProcess(4, obj => { obj.Disable(); obj.Hide(); });
```

`RemoveAndProcess` takes the element it finds at that index number specified by the first argument, removes the element from the source collection and passes that element to the delegate in the second argument.

Non-void methods are also accepted as the second argument.

```csharp
using CLSS;

bool TryDispose(ResourceHandler handler) { ... };

var FileResources = new List<ResourceHandler>();
FileResources.RemoveAndProcess(4, TryDispose);
```

`RemoveAndProcess` returns the source `IList<T>` to be friendly to a functional-style call chain. The exact return type will be determined by the invocation syntax of `RemoveAndProcess`. With an implicit type invocation, it returns an `IList<T>`. With an explicit type invocation, it returns the original collection type.

```csharp
using CLSS;

var numbers = new int[] { 0, 1, 2, 3, 4 };
numbers.RemoveAndProcess(2, str => { ... }); // returns IList<int>
numbers.RemoveAndProcess<int[], int>(2, str => { ... }); // returns int[]
```

**Note**: `RemoveAndProcess` works on all types implementing the [`IList<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1) interface, *including raw C# array*.

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).