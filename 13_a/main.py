lines = open("input.txt").readlines()

packets = []

packets_orders = []

# If both values are integers, the lower integer should come first. 
# If the left integer is lower than the right integer, the inputs are in the right order. 
# If the left integer is higher than the right integer, the inputs are not in the right order. 
# Otherwise, the inputs are the same integer; continue checking the next part of the input.


# If both values are lists, compare the first value of each list, then the second value, and so on. 
# If the left list runs out of items first, the inputs are in the right order. 
# If the right list runs out of items first, the inputs are not in the right order. 
# If the lists are the same length and no comparison makes a decision about the order, continue checking the next part of the input.


# If exactly one value is an integer, convert the integer to a list which contains that integer as its only value, then retry the comparison. 
# For example, if comparing [0,0,0] and 2, convert the right value to [2] (a list containing 2); the result is then found by instead comparing [0,0,0] and [2].


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