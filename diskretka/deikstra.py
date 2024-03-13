gr = [(1, 2, 41), (1, 3, 80), (1, 4, 23), (1, 5, 32), (2, 1, 41), (2, 3, 45), (2, 4, 12), (2, 5, 37), (3, 1, 80),
      (3, 2, 45), (3, 4, 50), (3, 5, 64), (4, 1, 23), (4, 2, 12), (4, 3, 50), (4, 5, 67), (5, 1, 32), (5, 2, 37),
      (5, 3, 64), (5, 4, 67)]

inf = 10 ** 10
min_length = [inf, inf, inf, inf, inf]
min_targets = [inf, inf, inf, inf, inf]

start, end = 1, 5
current = start - 1
min_targets[current], min_length[current] = 0, 0

for i in range(len(min_length) - 1):
    for j in range(len(min_length)):
        if current+1 == j+1:
            continue  # петли не рассматриваем

        weight = [x for x in gr if x[0] == current+1 and x[1] == j+1]
        if weight:
            weight = weight[0][2]
            min_length[j] = min(min_length[j], min_targets[current] + weight)

    # ищем следующую вершину
    # минимальная длина для следующей вершины
    min_tar = min([min_length[i] for i, x in enumerate(min_targets) if x == inf])
    # вершина, для которой это выполняется
    current = [i for i, x in enumerate(min_length) if x == min_tar][0]
    # для нее путь уже кратчайший
    min_targets[current] = min_length[current]
    # если дошли до нужной, то заканчиваем

print(min_targets)
path_length = min_targets[end-1]
print("минимальный путь", path_length)

path = [end]
if path_length == inf:
    print("Пути нет")
    exit()


for i in range(5):
    for j in range(5):
        weights = [x for x in gr if x[0] == j+1 and x[1] == path[-1]]
        for fromV, toV, weight in weights:
            if min_targets[fromV-1] + weight == path_length:
                path_length -= weight
                path.append(fromV)

print("вершины перехода", list(reversed(path)))
