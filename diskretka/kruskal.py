U = [(1, 2), (1, 5), (1, 4), (2, 3), (2, 4), (2, 5), (3, 5), (3, 6), (4, 5), (4, 7), (4, 8), (5, 6), (5, 8), (5, 9), (7, 8), (8, 9)]
w = [15, 14, 23, 19, 16, 15, 14, 26, 25, 23, 20, 24, 27, 18, 14, 18]

gr = [(y, x[0], x[1]) for x, y in zip(U, w)]
gr.sort(key=lambda x: x[0])

conns = []
sum_weight = 0
for weight, f, s in gr:

    # connected означает, что есть компонента в которой есть один из элементов
    connectedF = False
    connectedS = False
    # already означает, что они включены в одну компоненту
    already = False
    for conn in conns:
        if f in conn:
            connectedF = True
        if s in conn:
            connectedS = True

        if f in conn and s in conn:
            already = True

    if already:
        # если в одной компоненте, то пропускаем это ребро
        continue

    if connectedS and connectedF:
        # если оба в компонентах, но не в одной, то компоненты нужно сшить
        # выбираем все компоненты, в которых есть F
        # учитывая условия, она существует причем одна
        compF = [x for x in conns if f in x][0]
        # то же для s
        compS = [x for x in conns if s in x][0]
        # сшиваем две компоненты
        # переносим все из второй компоненты и удаляем ее
        compF += compS
        conns.remove(compS)

    # если f принадлежит компоненте, а s нет, то добавляем s в первую компоненту
    elif connectedF:
        compF = [x for x in conns if f in x][0]
        compF.append(s)

    # зеркально, если s в компоненте, то добавляем f туда же
    elif connectedS:
        compS = [x for x in conns if s in x][0]
        compS.append(f)

    #если оба не принадлежат компонентам, то создаем новую, в нее входят только эти два
    else:
        conns.append([f, s])

    sum_weight += weight

print(sum_weight)
