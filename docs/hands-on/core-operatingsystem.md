
## Context

> Heavily **Work in Progress**!!

-----

## Memory

### Scenario

- Too many prog need too many mem
- A program intentionally/or-not writes to a part memory that another program is using, cause unforeseeable outcome

### Issues summarized

- Need to manage more efficiently
- Need to avoid *prime to corruption*

### VM Comes to the Rescue

- An abstraction for the physical memory
- A suite of tools including hardware exceptions, hardware address translation, main memory, disk files and kernel software that provides each process with a large/uniform/private memory address space to resolve/help the issues mentioned above.

## Signal

> Sources: [*Signal Handling (The GNU C Library)*](https://www.gnu.org/software/libc/manual/html_node/Signal-Handling.html)

### What

- One of IPC (commu between processes)
- Listen up, if X happens, do Y
- Sys/Prog sends it, prog registers handler reacts

### Types

> scenarios=events, (program), handlers for the signal

- some scenarios, cannot proceed as usual, respective signal abort it
- some scenarios, could go on just fine, respective signal was ignored
- and you could make *child process telling parent it's done* to exit/sync/whatever
- Code examples in [***Python***](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/mock-signal.py) using `signal` [***C***](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/mock-signal.c) and [***C#***](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/mock-signal-with-event.cs)
