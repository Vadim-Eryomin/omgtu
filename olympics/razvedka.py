arr = [0, 0, 0, 1]
f = int(open('input.txt').readline())
for i in range(4, f + 1):
    arr.append(arr[(i + 1) // 2] + arr[i // 2])
print(arr[f])
