U = [(1, 2), (1, 5), (1, 4), (2, 3), (2, 4), (2, 5), (3, 5), (3, 6), (4, 5), (4, 7), (4, 8), (5, 6), (5, 8), (5, 9),
     (7, 8), (8, 9)]
w = [15, 14, 23, 19, 16, 15, 14, 26, 25, 23, 20, 24, 27, 18, 14, 18]

gr = [(y, x[0], x[1]) for x, y in zip(U, w)]
connected = {1}

# ищем связи, такие, что один из элементов есть, но не оба
def find_interesting_connections(conn):
    return [x for x in gr if (x[1] in conn or x[2] in conn) and not (x[1] in conn and x[2] in conn)]


weight = 0
# действуем "постоянно"
while True:
    # ищем интересующие
    maybe = find_interesting_connections(connected)
    # если таких нет, то все вершины уже связаны
    if len(maybe) == 0:
        break

    # отсортируем по весу
    maybe.sort(key=lambda x: x[0])
    # найдем интересующее ребро - самое короткое
    w, a, b = maybe[0]
    # прибавляем вес
    weight += w
    # прибавляем в список соединенных обе вершины
    # поскольку объект - множество, они не дублируются
    connected.add(a)
    connected.add(b)

# когда вышли, значит все соединено
# полученный вес - искомый
print(weight)
