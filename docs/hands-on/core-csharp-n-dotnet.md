
Boxing v Unboxing, Value v Reference Type

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
    ⬇️             ⬆️
    +--------------+
           |
      Reference Types
```

Destructors

- `~ClassName { clean up }`
- `: IDisposable + public void Dispose` (== `using (..) {}`)
- `try .. catch .. finally ..`

const v readonly

- literally constant, limited val types
- Freer, all kinds of types

this v base

- base calls mother class’ thingy
- this calls current class’ methods/vars

generics v overload

- generics ensure uniformity
- overloading get you more than handling different types, but also methods with different length of parameters

List

- ICollection\<T\> ➡️ IList\<T\> ➡️ List
- Each with different set of methods impl_ed

Copy v Clone

- One is shallow, one is (usually) deep
- One gets a new obj that points to the same memory address of the object you are copying, one gets a completely new object, all built from scratch
- Customizing your DeepCopy would get you more flexibility than `IClonable` with `Clone`

Interface v Abstract Class

- interface defines contracts you need to fullfil, and there might be multiple of them
- interface has no fields
- abstract defines a common base class with potentially partial implementation
- abstract has fields as they are classes

ref v out

- ref variables along with ref would affect the original
- out pouring out a variable to the function-invocation scope
