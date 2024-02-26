class Operation:
    def __init__(self, text) -> None:
        self.done = False
        self.text = text
        self.operated = ""

    def operate(self, operations):
        type = self.text[0]
        op = ""
        # mix water dust fire

        for i in self.text[1:]:
            if i.isnumeric():
                b = int(i)
                op += operations[b].__str__()
            else:
                op += i

        if type == "MIX": return "MX" + op + "XM"
        if type == "WATER": return "WT" + op + "TW"
        if type == "FIRE": return "FR" + op + "RF"
        if type == "DUST": return "DT" + op + "TD"

    def __str__(self) -> str:
        return self.operate(operations)

for fi in range(1, 11):
    with open('Зельеварение/input'+str(fi)+'.txt') as f:
        operations = {}
        for i, line in enumerate(f):
            line = line.strip().split(" ")
            operations[i + 1] = Operation(line)

        print(operations[i+1])
        print("Тест №" + str(fi) + ": " + str(operations[i+1].__str__() == open('Зельеварение/output'+str(fi)+'.txt').readline().strip()))

