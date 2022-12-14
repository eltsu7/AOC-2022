lines = open("input.txt").readlines()
packets = []
packets_orders = []


def check_packets(left, right):
    # print(f"L: {left}\nR: {right}")

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


for i in range(len(lines)):
    line: str = lines[i].strip()
    if not line:
        continue

    packets.append(line)

    if len(packets) == 2:
        packets_orders.append(check_packets(eval(packets[0]), eval(packets[1])))
        packets = []


print(sum([i+1 for i, x in enumerate(packets_orders) if x]))