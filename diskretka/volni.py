from math import inf


def around(x, y):
    var_list = []
    if x != 1:
        if y != 1:
            var_list.append(a[x - 2][y - 2])
        if y != m:
            var_list.append(a[x - 2][y])
        var_list.append(a[x - 2][y - 1])
    if x != n:
        if y != 1:
            var_list.append(a[x][y - 2])
        if y != m:
            var_list.append(a[x][y])
        var_list.append(a[x][y - 1])
    if y != 1:
        var_list.append(a[x - 1][y - 2])
    if y != m:
        var_list.append(a[x - 1][y])

    return min([x + 1 for x in var_list if x != -1] + [a[x - 1][y - 1]])


n, m = 11, 7
stX, stY = 4, 1
finX, finY = 11, 7
a = [[inf for _ in range(m)] for x in range(n)]
a[stX - 1][stY - 1] = 0
cannot = [(9, 2), (10, 2), (11, 2), (3, 3), (4, 3), (5, 3), (6, 3), (2, 5), (3, 5), (4, 5), (8, 5), (8, 6), (8, 7)]
for x, y in cannot:
    a[x - 1][y - 1] = -1

for it in range(n * m):
    already = False
    prevA = a[::]
    for x in range(1, n + 1):
        for y in range(1, m + 1):
            a[x - 1][y - 1] = around(x, y)

for i in a:
    print(i)

length = a[finX - 1][finY - 1]
path = [(finX, finY)]

print()
print(length)

x = finX
y = finY
while not (x == stX and y == stY):
    for dx in range(-1, 2):
        for dy in range(-1, 2):
            if x + dx - 1 < 0 or y + dy - 1 < 0:
                continue
            if a[x + dx - 1][y + dy - 1] == length - 1:
                path.append((x + dx, y + dy))
                x += dx
                y += dy
                length -= 1

print(list(reversed(path)))
