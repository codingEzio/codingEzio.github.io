
## Context

> None yet

-----

## Signals

### Resources

- [Signal Handling (The GNU C Library)](https://www.gnu.org/software/libc/manual/html_node/Signal-Handling.html)

### Concepts Simplified

- A form of IPC (communicate between processes)
- A way to setup **listen up, X happens, do Y**
- A way to setup **if receives signal X, invoke function Y**
- A variety of types to for particular kind of events
  > Scenarios = events || (program) cannot/could X || handlers for the signal
    - some scenarios, cannot proceed as usual, respective signal abort it
    - some scenarios, could go on just fine, respective signal was ignored
    - and you could make *child process telling parent it's done* to exit/sync/whatever
- Here's how you setup one that reacts to events and gracefully exits the program

    - Code [example in Python](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/mock-signal.py) using `signal`
    - Code [example in C](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/mock-signal.c) using `signal`
    - Code [example in C#](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/mock-signal-with-event.cs) using *Events* to do similar things
