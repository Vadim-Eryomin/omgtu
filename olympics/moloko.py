with open('input1.txt') as f:
    n = int(f.readline())
    lines = [x for x in f]
    mols = []
    for line in lines:
        a1, b1, c1, a2, b2, c2, s1, s2 = [float(x) for x in line.split()]
        p1 = 2 * (a1 * b1 + b1 * c1 + a1 * c1)
        p2 = 2 * (a2 * b2 + b2 * c2 + a2 * c2)
        
        v1 = a1 * b1 * c1
        v2 = a2 * b2 * c2
        
        mol = round((s2 * p1 - s1 * p2) / (p1 * v2 - p2 * v1) * 1000, 2)
        mols.append(mol)
        
    min_cost = 0
    min_id = 0
    for i in range(len(mols)):
        if i == 0:
            min_cost = mols[i]
        if mols[i] < min_cost:
            min_id = i
            min_cost = mols[i]
    
    print(min_id + 1, end=" ")
    print('%.2f' % min_cost)
