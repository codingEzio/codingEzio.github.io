
## Context

- I want to explain all the concepts in an ultra-clear-n-simple way
- All the sample code along with these were standalone runnable C# script

-----

## Boxing v Unboxing

> also, Value v Reference Type

- Conversion between value type and reference types, boxing bridging them together to provide a uniform type system that were all derived from Object.
- Sometimes we store value type within reference type variables, we need boxing to put it in, and unboxing it when in need of accessing it.
Value of value type copies over value itself on the stack. Whereas reference types were stored on the heap.
- If we were to use Generics, explicitly declaring the types being stored, we no longer need the boxing/unboxing.

```txt
       Value Types
           |
    +--------------+
    |              |
 Boxing         Unboxing
    |              |
    ⬇️              ⬆️
    +--------------+
           |
      Reference Types
```

## Destructors

> **WIP** [sample code](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/type-destructor.cs)

### `~ClassName { clean up }`

- Finalizers are NOT guaranteed to be called
- It’s implementation-specific (quote)
- For my case? It means that I won’t get the debugging output from customized finalizers.
- For production? We’ll do more testing then

- References
    - [observations made on this](https://github.com/dotnet/csharpstandard/issues/291)
    - [wording changes](https://github.com/dotnet/csharpstandard/pull/309)
    - [detailed back-n-forth discussions](https://github.com/dotnet/docs/issues/17463)

### `: IDisposable + public void Dispose`

> == `using (..) {}`

- `using` is a syntactic sugar for `try .. finally ..`
- `Dispose` is a method that cleans up the resources
- `IDisposable` is an interface that defines the `Dispose` method

### `try .. catch .. finally ..`

- `catch` acts as built-in exception handling in comparison to others
- `finally` block could do the same thing but might not be universal/organized

## `const` v `readonly`

- literally constant, limited val types
- Freer, all kinds of types

## `this` v `base`

> [sample code](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/comparison-base-v-this.cs)

- base calls mother class’ thingy
- this calls current class’ methods/vars

## Generics v Overload

- generics ensure uniformity
- overloading get you more than handling different types, but also methods with different length of parameters

## `List`

> **WIP**

- ICollection<T> ➡️ IList<T> ➡️ List
- Each with different set of methods impl_ed

## Copy v Clone

> [sample code](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/comparison-copy-shallow-v-deep.cs)

- One is shallow, one is (usually) deep
- One gets a new obj that points to the same memory address of the object you are copying, one gets a completely new object, all built from scratch
- Customizing your DeepCopy would get you more flexibility than `IClonable` with `Clone`

## Interface v Abstract Class

> [sample code](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/comparison-interface-v-abstract-class.cs)

- interface defines contracts you need to fullfil, and there might be multiple of them
- interface has no fields
- abstract defines a common base class with potentially partial implementation
- abstract has fields as they are classes

## `ref` v `out`

> [sample code](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/comparison-ref-v-out.cs)

- ref variables along with ref would affect the original
- out pouring out a variable to the function-invocation scope

## Extension Method

> [sample code](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/thing-extension-method.cs)

- `this TypeName obj` is all that matters, anything else were just conventions
- Loosely attaching customized methods to existing classes
    - Built-in types? Yeah!
    - Custom classes? Sure!
- On projects and scripts
    - Gotta use the `public static class XyzExtensions { .. }`
    - Just `public static void MethodName(this ClassName obj) { .. }` for scripts

## Partial n Sealed Class

> [sample code](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/comparison-partial-n-sealed-class.cs)

- partial class allow classes be written in seperate places, even files
- partial class's implementations were merged at compile time
- sealed class prevents inheritance (the )

## Indexer

> [sample code](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/thing-indexer.cs)

- syntax sugar for easier accessing/manipulating elements
- cleaner implementation for getting/setting elements in a class

## Multicast Delegates

> [sample code](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/thing-multicast-delegates.cs)

- concat function executions
- one piece of params to >= 0 functions
- functions that tied to must be of same signature
