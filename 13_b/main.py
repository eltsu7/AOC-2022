lines = [x.strip() for x in open("input.txt").readlines() if x.strip() != ""]
lines.extend(["[[2]]", "[[6]]"])
packets = []
packets_orders = []


def check_packets(left, right):
    # print(f"L: {type(left)} - {left}\nR: {type(left)} -{right}")

    if type(left) == int and type(right) == int:
        return None if left == right else left < right

    if type(left) == list and type(right) == list:
        for i in range(min(len(left), len(right))):
            return_value = check_packets(left[i], right[i])
            # print(f" ^ {return_value}")
            if return_value != None:
                return return_value
        return None if len(left) == len(right) else len(left) < len(right)

    if type(left) == int:
        left = [left]

    if type(right) == int:
        right = [right]

    return check_packets(left, right)


while True:
    ordered = True
    for i in range(len(lines) - 1):
        left = lines[i]
        right = lines[i+1]
        if not check_packets(eval(left), eval(right)):
            ordered = False
            lines[i] = right
            lines[i+1] = left
    if ordered:
        break

# for line in lines:
#     print(line)

print((lines.index("[[2]]") + 1) * (lines.index("[[6]]") + 1))