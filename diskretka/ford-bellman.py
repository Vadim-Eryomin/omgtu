import math

gr = [(1, 2, 1), (2, 3, 8), (3, 4, 1), (4, 3, 2), (2, 4, 7), (3, 5, -5), (5, 4, 4), (1, 5, 3), (2, 5, 1)]
inf = math.inf
start = 1
number_of_vertices = 5


class Matrix:
    def __init__(self, number_of_vert):
        self.array = []
        for i in range(number_of_vert):
            ar = [inf for _ in range(number_of_vert)]
            for line in [x for x in gr if x[0] == i + 1]:
                ar[line[1] - 1] = line[2]
            self.array.append(ar)

    def __str__(self):
        return str("\n".join([str(x) for x in self.array]))

    def get_column(self, index):
        return [x[index] for x in self.array]


matrix = Matrix(number_of_vertices)
start -= 1  # сдвиг для индексов
lam = [0 if i == start else inf for i in range(number_of_vertices)]

for i in range(number_of_vertices):
    lam_before = lam[:]
    for k in range(number_of_vertices):
        lam[k] = min(lam[k], min([lam_before[x] + matrix.get_column(k)[x] for x in range(number_of_vertices)]))
    if all([lam[x] == lam_before[x] for x in range(number_of_vertices)]):
        break

for i in range(number_of_vertices):
    path = [i]
    if i != start:
        length = lam[i]
        while length != 0:
            for j in range(number_of_vertices):
                if lam[j] + matrix.get_column(path[-1])[j] == length:
                    length -= matrix.get_column(path[-1])[j]
                    path.append(j)
                    break

    print("to", i + 1, ", len =", lam[i], ", through", list(reversed([x + 1 for x in path])))
