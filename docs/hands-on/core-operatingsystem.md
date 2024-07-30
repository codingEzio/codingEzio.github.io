
## Context

> None yet

-----

## Signals

> Sources: [*Signal Handling (The GNU C Library)*](https://www.gnu.org/software/libc/manual/html_node/Signal-Handling.html)

### What

- One of IPC (commu between processes)
- Listen up, if X happens, do Y
- Sys/Prog sends it, prog registers handler reacts

### Types of Signals

> scenarios=events, (program), handlers for the signal

- some scenarios, cannot proceed as usual, respective signal abort it
- some scenarios, could go on just fine, respective signal was ignored
- and you could make *child process telling parent it's done* to exit/sync/whatever

### Get One that Reacts to Events

- Code [example in Python](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/mock-signal.py) using `signal`
- Code [example in C](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/mock-signal.c) using `signal`
- Code [example in C#](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/mock-signal-with-event.cs) using *Events* to do similar things

-----

- Life of 0s and 1s
  - Get from 0s and 1s to a code file
    - Zeros and ones represent binary data, which can be grouped into sets of eight bits called bytes.
    - Each byte, composed of zeros and ones, can be converted to a decimal value.
    - The decimal value corresponds to a specific character in the ASCII table, allowing us to map binary data to ASCII characters.
    - By repeating this process for each byte, we can transform multiple sets of zeros and ones into multiple ASCII characters.
    - These ASCII characters are then encoded and written into a file, creating a sequence of characters that can be interpreted by text-based applications.

  - 0s and 1s in Different Context <sup>[example](https://poe.com/s/JioudqEtMjMAKsu9BFa1)</sup>

```asciidoc
0101010101
    /           \
   /             \
  v               v
+-------+     +--------+
| ASCII |     | Binary |
+-------+     +--------+
    |             |
    v             v
+-------------------+
|    Code File      |
+-------------------+
```

- From hello.c to the executable ./hello
  - *Preprocessing Phase*: add/insert implicit imported code, like the import in Python, the \#include in C, in the end, produce a different file, typically ended with .i, a hello.i file.

  - *Compilation Phase*: translate C code into assembly instructions, which all non-assembly really are underneath 😉, normally ended with .s, aka. hello.s.

  - *Assembly Phase*: translate Assembly code into actual machine instructions (0s and 1s), though this time it was packaged in the form of *relocatable object program* (this time the context of those bytes were machine instructions instead of characters), typically ended with .o, aka. hello.o.

  - *Linking Phase*: the linker ld do the merging between the imported stuff (like the stdio.h for basic printing) and the previously generated hello.o, the eventual output is an executable object, i.e. ./hello.

- from *CPU Land*
  - Machine code are 0s and 1s
    - Machine code have both binary (0001) and hex formats (0xA3)
    - The machine codes in hex formats were individually mapped to Assembly instructions.

  - Different CPUs hold different architectures
  - Different architectures diff in the mappings between the hex (machine) code and (assembly) instructions.
  - Things like ADD, SUB were called as OPCODE

  - One CPU can only hold one architecture
  - One CPU can do emulation and/or translations more than the architecture of its own (like how you run x86 apps on Apple M3 machines via the *Rosetta 2* translation layers)

  - Machine instructions were loaded onto RAM
    - Machine instructions were ran via CPU executing instructions loaded onto RAM
    - Machine instructions can only be ran when loading onto RAM

  - RAM acts like a workspace for CPU, which holds data and instructions, ready for access
  - RAM is like a book with multiple pages, that you find data via something like *PageA :: LINE 19 :: POS 2:10*
