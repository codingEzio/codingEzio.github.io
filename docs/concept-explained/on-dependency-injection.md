
## Context

> It sounds so fun!

-----

## Dependency Injection

> Derive from the first principle and iterating from that, much easier to remember as it originates from YOUR OWN intuition

### Two starting points

- Name: injecting X’s dependency to X
- Why: cleaner code, easy refactorization

### Breaking down

- Not all functionality has to be directly in the class (whether it’s the features you haven’t implemented yet, or the afterthought that you wanna make it easy to replace/interpolate some of the actions/features of the class)
- Therefore, you gotta pass in the dependency in some way or another (that’s why we have more than one way to do DI, more on this later)

### Plus

- Proper DI (class and the one providing additional features for the class) ensures complete de-coupling between the two (hell yeah)
- Proper DI for easier testing since they two (object itself and the dependency) were decoupled, you could just make some mock data (or a mock DB) without non-DI solution which might have to write extra code to override the default behaviors of the class
- Related concept is IoC (Inversion of Control) Container which handles a lot of things like object creation, Dependency Injection is of course under its jurisdiction as well
- For frameworks that have IoC container implemented, you gotta register the dependency somewhere for the frameworks to manage the lifecycle of the object on behalf of you (your implementation of the class)

### Quote

- https://www.jamesshore.com/v2/blog/2006/dependency-injection-demystified
    - 25-dollar term for a 5-cent concept (lol)
    - Dependency injection ~= passing in an instance variable
- https://docs.spring.io/spring-framework/reference/core/beans/dependencies/factory-collaborators.html
    - Dependency injection (DI) is a process whereby objects define their dependencies (that is, the other objects with which they work) only through constructor arguments, arguments to a factory method, or properties that are set on the object instance after it is constructed or returned from a factory method.

### Type
- (class) Constructor Injection
- (class instance) Property Injection
- (class instance) Method (load as needed) Injection
