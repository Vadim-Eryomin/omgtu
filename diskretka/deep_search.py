gr = [(1, 2), (2, 3), (1, 4), (4, 5), (3, 5), (2, 5), (5, 6), (6, 7), (6, 8), (9, 10), (9, 11), (10, 11)]
white = list(range(1, 12))


def flatten(arr):
    array = []
    for i in arr:
        if isinstance(i, int):
            array.append(i)
        if isinstance(i, list):
            array += flatten(i)
    return sorted(array)


def find_deep(now):
    # вершины, смежные с данной, но вторая вершина еще не серая
    global white
    interest = [x for x in gr if (now == x[0] and x[1] in white) or (now == x[1] and x[0] in white)]
    for i in interest:
        if i[0] in white:
            white.remove(i[0])
        if i[1] in white:
            white.remove(i[1])
    a = [now]
    for i in [find_deep(x[0] if x[1] == now else x[1]) for x in interest]:
        a.append(i)

    return flatten(a)


while True:
    if len(white) == 0:
        break
    print(find_deep(white[0]))
