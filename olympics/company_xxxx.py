from typing import List

ids = []


class Employee:

    def __init__(self, id, name) -> None:
        self.name = name
        self.id = id
        self.connections: List[Employee] = []

    def __str__(self) -> str:
        return f"'{self.id}, {self.name}', [{[str(e) for e in self.connections]}]"


emp_ids = {}

with open('a') as f:
    lines = [line for line in f.readlines()]
    for line in lines:
        if "END" in line:
            break

        data = line.strip().split(" ")
        id = data[0]
        name = " ".join(data[1:])

        if not name:
            if id not in emp_ids:
                emp_ids[id] = "Unknown Name"
        else:
            emp_ids[id] = name

bet_emp = [Employee(id, emp_ids[id]) for id in emp_ids]

i = 0
nach = ""
for line in lines:
    if "END" in line:
        break
    id = line.split(" ")[0].strip()


    if i % 2 == 0:
        nach = id
    else:
        [e for e in bet_emp if e.id == nach][0].connections.append([e for e in bet_emp if e.id == id][0])

    i += 1

find = lines[-1]
emp = [e for e in bet_emp if find in e.id or find in e.name][0]
ans = [emp]

for e in ans:
    for c in e.connections:
        ans.append(c)

print('\n'.join(sorted([f"{e.id} {e.name}" for e in ans[1:]])))
