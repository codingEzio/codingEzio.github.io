def count7From0ToN(n):
    occurence_of_7 = 0

    for num in range(0, n + 1):
        for digit in str(num):
            if digit == "7":
                occurence_of_7 += 1

    return occurence_of_7


assert count7From0ToN(10000) == 4000
