
## Big *O*

### Type

- Time Complexity
- Space Complexity

### Examples

#### Time

> 找主要增长项

```python
# O(1)
def get_first_beer(fridge):
    return fridge[0]


# O(log n)
def find_specific_brand(sorted_fridge_by_name, brand_name):
    CHECK middle n FOUND it
        COOL    # Gotcha
        LOWER   # CHECK middle in RIGHT half
        HIGHER  # CHECK middle in LEFT half
    ELSE
        return None


# O(n)
def find_expired_beer(fridge):
    for beer in fridge:
        if beer.is_expired():
            return beer  # Gotta check 'em all!


# O(n log n)
def find_expired_beer_in_specific_brand(fridge):
    CHECK middle n FOUND it
        COOL    # Gotcha
        LOWER   # CHECK middle in RIGHT half
        HIGHER  # CHECK middle in LEFT half

    for beer in FOUND_BRAND:
        if beer.is_expired():
            return beer  # Gotta check 'em all!


# O(n^2)
def find_perfect_beer_combo(fridge):
    for A in fridge:
        for B in fridge:
            if taste(A, B) is GOOD:
                return A, B


# O(n!)
def find_shortest_route(places):
    # [A]---[B]
    #  |\   /|
    #  | \ / |
    #  | / \ |
    #  |/   \|
    # [C]---[D]

    # [Pub A]    [Pub B]    [Pub C]    [Pub D]
    # 1. A -> B -> C -> D -> A (dist = ?)
    # 2. A -> C -> B -> D -> A (dist = ?)
    # 3. A -> D -> B -> C -> A (dist = ?)
    #    ...
    # at worst, need to check N! times to know the shortest

```

#### Space

> 找最大分配量

```python

```

### Identification

- x
- x

## 0 到 9999 之间有多少个 7

> [source code](https://github.com/codingEzio/codingezio.github.io/blob/master/hands-on/algo-fun-count-7s.py)

1. List all the numbers
2. Check each digits one by one
3. If the digit equals to `7`, add up
