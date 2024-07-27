
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
