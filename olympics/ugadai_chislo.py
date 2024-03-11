f = open('a')
a = int(f.readline())
data = [f.readline() for x in range(a)]
number = [1, 0]

for i in data:
    spl = i.split(" ")
    op = spl[0]
    if 'x' in spl[1]:
        if op == '+':
            number[0] += 1
        if op == '-':
            number[0] -= 1
    else:
        num = int(spl[1])
        if op == '+':
            number[1] += num
        if op == '*':
            number[0] *= num
            number[1] *= num
        if op == '-':
            number[1] -= num
        if op == '/':
            number[0] /= num
            number[1] /= num

print(int((int(f.readline())-number[1])/number[0]))




