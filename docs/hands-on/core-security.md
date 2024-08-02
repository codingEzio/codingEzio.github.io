
## Context

> None yet

-----

## CSRF

- Cross-site Request Forgery
- X makes unintentional request that were set to be made by the attacker, usually happens in the context of submitting forms, we generate a token along with the form data when submitting, we differ the user making genuine request from the malicious request the attacker set up that were to be executed when the user’s in the context via HTTP attribute Origin.

## DNS

### Attack

> I didn't set up a realistic attack lab for this for actually seeing the effects of the attacks locally. IMO, for this kind of concepts that were quite easy to understand, I'm leaning more to practice directly based on the real-world attacking scripts (just like [thesc1entist](https://github.com/thesc1entist)'s script below). Also, I might need to learn about [Wireshark](https://www.wireshark.org/download.html) to see the processes in real-time.
>> Also, there were even more types, more attack vectors of DNS attacks. Not going to cover them here, yet.

#### Types

- CC Attack: 🛍️🏃🏃🏃 ⛔
- SYN Flood: 🤝✋ ⏳⏳⏳
- DNS Amplification: 😈🗣️👶 📢📢📢

#### To Learn

- [ ] [CC Attack](https://github.com/Leeon123/CC-attack/tree/master) <sup>Python</sup>
- [ ] [DNS Amplification](https://github.com/thesc1entist/j0lt/tree/main) <sup>C</sup>
- [ ] [synflood.c](https://github.com/Hypro999/synflood.c) <sup>C</sup>
