# modulo-exponentiation

So, unfortunately, I’m too stupid to solve math properly. In college, I wrote a naive algorithm to find the result of modular exponentiation - likely to save time and cheat a little, or perhaps as an assignment, I don't exactly remember. It worked only with small numbers and was actually completely incorrect for anything serious. It lacked any real mathematical logic, and the input code itself was written terribly!
To make things even worse, that original code even had a missing bracket and didn't even have proper project files.

Much time has passed since then, and I’ve finally rewritten this algorithm so that I wouldn't be embarrassed to reread it myself. **The code now works and demonstrates three different approaches: my old naive way, a new custom function based on _fast exponentiation by squaring_, and the standard system method.**

There is absolutely no reason to use this in production. For any real-world tasks, please use the built-in system function:
```C#
BigInteger.ModPow(baseNumber, exponent, modulus);
```