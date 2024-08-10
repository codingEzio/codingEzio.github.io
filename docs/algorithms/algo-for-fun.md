
## 0 到 9999 之间有多少个 7

> [source code](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/algorithm-fun-count-7s.py)

```python
def count7(n):
    return sum(1 for i in range(n) if i % 7 == 0)
```
