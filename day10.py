import sys

enc = "ascii"

# Note: ugly globals! Don't run multiple examples together, they will mess up each other.
pos = 0
skip = 0

def process(indata):
    global pos, skip

    pos = 0
    skip = 0
    
    state = list(range(256))
    dp("Starting state: {0}".format(state))

    bs = adjust(indata)

    for i in range (0, 64):
        oneRound(state, bs, False)

    dp("sparse hash: {0}".format(state))
    dense = densify(state)
    dp("dense hash: {0}".format(dense))
    result = list(map(myHex, dense))
    dp("result: {0}".format(result))
    
    return "".join(result)

def adjust(indata):
    dp("Raw indata: '{0}'".format(list(indata)))
    bs = bytearray(indata, enc)
    dp("As byte array: {0}".format(list(bs)))
    
    bs.extend([17, 31, 73, 47, 23])
    dp("Adjusted indata: {0}".format(list(bs)))

    return bs
    
def myHex(number):
    h = format(number, "02x")
    #dp("h: {0}".format(h))
    return h

def toBytes(char):
    return chr(char)
    
def oneRound(state, indata, reset):
    global pos, skip
    if reset:
        pos = 0
        skip = 0
    
    for v in indata:
        #dp("instruction: {0}".format(v))
        #dp("swapping {0} values starting at {1}".format(v, pos))
        for i in range(0, v // 2):
            si = pos + i
            sj = pos + v - 1 - i
            #dp("swap values at {0} and {1}".format(si, sj))
            swap(state, si, sj)
        pos += v + skip
        skip += 1
        #dp(state)

    # return value not used in step 2, this is only for checking step 1    
    return state[0] * state[1]

def swap(ary, i, j):
    #dp("swapping values in positions {0} and {1}".format(i, j))
    ri = i % len(ary)
    rj = j % len(ary)
    x = ary[ri]
    ary[ri] = ary[rj]
    ary[rj] = x

def densify(ary):
    r = []
    for i in range (0, 16):
        start = i * 16
        x = densifyBlock(ary, start)
        r.append(x)
    return r

def densifyBlock(ary, i):
    x = ary[i]
    for j in range(1, 16):
        x = x ^ ary[i + j]
    return x
              
def dp (s):
    #print (s)
    return

#adj = "1,2,3"
#print("adjust example: ", list(adjust(adj)))

#ba = bytearray([65, 27, 9, 1, 4, 3, 40, 50, 91, 7, 6, 0, 2, 5, 68, 22])
#print("densify example: ", densifyBlock(ba, 0))

#print("myHex 0x40: ", myHex(0x40))
#print("myHex 0x07: ", myHex(0x07))

ex1Data = [3, 4, 1, 5]
ex1Start = [0, 1, 2, 3, 4]
print ("step 1 example: ", oneRound(ex1Start, ex1Data, True))

d1 = ""
d2 = "AoC 2017"
d3 = "1,2,3"
d4 = "1,2,4"
              
print("Example 1: '{0}' -".format(d1), process(d1))
print("Example 2: '{0}' -".format(d2), process(d2))
print("Example 3: '{0}' -".format(d3), process(d3))
print("Example 4: '{0}' -".format(d4), process(d4))

with open("/Users/helen/Code/aoc 2017 d10.txt", "r") as f:
    data = f.read().strip()

step1Start = list(range(0, 256))
step1Data = map(int, data.split(","))
print("Step 1: ", oneRound(step1Start, step1Data, True))

print("Step 2: ", process(data))
