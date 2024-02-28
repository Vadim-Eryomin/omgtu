gr = [(1, 2), (2, 3), (1, 4), (4, 5), (3, 5), (2, 5), (5, 6), (6, 7), (6, 8), (9, 10), (9, 11), (10, 11)]
white = list(range(1, 12))


def broad_search(now):
    global white
    comp = {now}
    black = []
    while True:
        interest = [x for x in gr if (now == x[0] and x[1] in white) or (now == x[1] and x[0] in white)]
        for i in interest:
            comp.add(i[0])
            comp.add(i[1])

            if i[0] in white:
                white.remove(i[0])
            if i[1] in white:
                white.remove(i[1])

        black.append(now)
        could_next = [x for x in comp if x not in black]
        if len(could_next) == 0:
            return list(comp)

        now = could_next[0]


while True:
    if len(white) == 0:
        break
    print(broad_search(white[0]))
