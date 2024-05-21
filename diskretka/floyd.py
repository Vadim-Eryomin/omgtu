import math

gr = [
    (1, 2, 7),
    (1, 8, 15),
    (2, 8, 15),
    (8, 7, 11),
    (7, 6, 7),
    (7, 5, 4),
    (6, 5, 20),
    (5, 4, 10),
    (8, 4, 10),
    (8, 3, 20),
    (3, 4, 17),
]

vertices = max([max(x[0], x[1]) for x in gr])
mt = [[math.inf for x in range(vertices)] for y in range(vertices)]
for e in gr:
    if e[2] < 0 or not e[0] or not e[1] or not e[2]:
        print("Некорректные данные")
    else:
        mt[e[0] - 1][e[1] - 1] = e[2]
        mt[e[1] - 1][e[0] - 1] = e[2]
for i in range(vertices):
    mt[i][i] = 0

# d(i, j) = min(d(i,j), d(i,k) + d(k, j))
for k in range(vertices):
    for i in range(vertices):
        for j in range(vertices):
            mt[i][j] = min(mt[i][j], mt[i][k] + mt[k][j])

while True:
    match int(input("Выберите пункт: 1 - расчеты, 2 - об авторе, 3 - задача, 4 - выход: ")):
        case 1:
            for i in range(vertices):
                for j in range(vertices):
                    if i != j:
                        print("Шанс утечки при передаче из пункта", i + 1, "в пункт", j + 1, "равен", mt[i][j])
        case 2:
            print("Автор программы: студент ФИТ-232 Ерёмин Вадим Сергеевич")
        case 3:
            print("Задача состоит в следующем: ")
            print("На графе изображена система связи предприятий. \nВероятность утечки информации при передаче (в процентах)\nсоответствуетвесу рij ребра (xi, xj). Найти минимальную величину\nутечки информации при ее передаче между всеми предприятиями")
        case 4:
            break
    input("\nНажмите для продолжения...")
