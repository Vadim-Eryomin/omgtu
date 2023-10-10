def days_by_monthes(n):
    if (n == 1): return 31
    if (n == 2): return 28
    if (n == 3): return 31
    if (n == 4): return 30
    if (n == 5): return 31
    if (n == 6): return 30
    if (n == 7): return 31
    if (n == 8): return 31
    if (n == 9): return 30
    if (n == 10): return 31
    if (n == 11): return 30
    if (n == 12): return 31

d1, m1, y1 = [int(x) for x in input().split('.')]
d2, m2, y2 = [int(x) for x in input().split('.')]
p = int(input())

fd = (y1 - 1) * 365 + sum([days_by_monthes(x) for x in range(1, m1)]) + d1
sd = (y2 - 1) * 365 + sum([days_by_monthes(x) for x in range(1, m2)]) + d2

vis = len([x for x in range(y1, y2 + 1) if x % 4 == 0])
if (y1 % 4 == 0 and m1 > 2): vis -= 1
if (y2 % 4 == 0 and (m2 == 1 or (m2 == 2 and d2 <= 28))): vis -= 1
days = sd - fd + 1 + vis

print(int((2 * p + days - 1) / 2 * days))
