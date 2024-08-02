
## Context

- It was fun

-----

## Cookie v Session

### Cookie

- stored in the browser
- got check via `document.cookie` in the browser console
- types allowed: text only (key value pairs)
- limited size, commonly less than [4093 bytes](https://stackoverflow.com/a/4604212/6273859) **under a domain**
- limited number of cookies per domain, [ranged from 60 to 600](https://docs.devexpress.com/AspNet/11912/common-concepts/cookies-support) (data might be stable, as I had NOT tested it myself)
- the spec [*HTTP State Management Mechanism*](https://www.ietf.org/rfc/rfc2109.txt) did NOT specify the size limit <sup>search for `6.3`</sup>
- the exact size limit is implementation-specific, test your own [here](http://browsercookielimits.iain.guru/)

- in practice, different types of the cookie simply differs in different keys

```js
// Session Cookie
document.cookie = "sessionToken=ABC123; path=/; SameSite=Lax";

// Persistent Cookie for 7 days
var date = new Date();
date.setTime(date.getTime() + (7*24*60*60*1000)); // 7 days from now
var expires = "expires=" + date.toUTCString();
document.cookie = "persistentToken=XYZ456; path=/; " + expires + "; SameSite=Lax";

// Secure Cookie
document.cookie = "secureToken=DEF789; path=/; Secure; SameSite=Lax";

// HttpOnly Cookie (must be set via server)

// SameSite Cookies
document.cookie = "sameSiteToken=LaxValue; path=/; SameSite=Lax";
document.cookie = "sameSiteToken2=StrictValue; path=/; SameSite=Strict";
document.cookie = "sameSiteToken3=NoneValue; path=/; SameSite=None; Secure";

// Viewing all cookies
console.log(document.cookie);
```

- categorized by expiration time, *session cookie* n *persistent cookie* (physically exists)
- categorized by origin, *first-party cookie* n *third-party cookie*
- categorized by feature
    - *essential* (like products in cart)
    - *analytics* (like Google Analytics or ADs)
    - *functional* (like language choice)

### Session

- stored in the server
- gotta have your own way to see the session data
- types allowed: any types, any ways you wanna save (depends on the language)
- "unlimited" size
    - think of it as putting a small box in a warehouse
    - it could fill up, but normally it wouldn't be the one that fills up
- in practice, sessions were stored and interpreted however you want

    > After all, it's just a way for you to identify the user with handful of stuff in the data

- categorize by storage type
    - server-side session (client's cookie got a session ID matching with server)
    - client-side session (you can do it via cookie/LocalStorage, but that defeats the entire purpose of sessions)
- categorize by implementation
    - via cookie: a session ID in the cookie matching with the server-side session
    - via URL: `https://example.com/login?sessionId=ABC123` (~= *via cookie*)
    - via database: almost the same thing as *via cookie*, but being persisted
