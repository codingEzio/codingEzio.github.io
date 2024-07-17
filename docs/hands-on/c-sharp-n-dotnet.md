
### Boxing v Unboxing, Value v Reference Type

- Conversion between value type and reference types, boxing bridging them together to provide a uniform type system that were all derived from Object.
- Sometimes we store value type within reference type variables, we need boxing to put it in, and unboxing it when in need of accessing it.
- Value of value type copies over value itself on the stack. Whereas reference types were stored on the heap.
- If we were to use Generics, explicitly declaring the types being stored, we no longer need the boxing/unboxing.

```txt
       Value Types
           |
    +--------------+
    |              |
 Boxing         Unboxing
    |              |
    ⬇️             ⬆️
    +--------------+
           |
      Reference Types
```

### Constructors v Destructors

- Finalizing
  - `~ClassName { clean up }`
  - `: IDisposable + public void Dispose`
  - `using (..) {}  // auto clean up`
  - `try .. catch .. finally ..`

  - And
    > using == IDisposable with Dispose

### Overload v Override

- Overload adds more param choices
- Override replace/customize sub impl
