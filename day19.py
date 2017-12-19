def process (lines):
    ary = list(map(toChars, lines))
    start = ary[0].index("|")
    c = start
    r = 0
    dc = 0
    dr = 1
    passed = ""
    dummy = 0
    steps = 0
    
    while True:
        #print("at", r, c)
        char = ary[r][c]
        if char == "+":
            #print(r, c, "corner")
            newDirection = turnCorner(ary, r, c, dr, dc)
            dr = newDirection[0]
            dc = newDirection[1]
            #print("new direction: ", dr, dc)
        elif char == "|":
            if dc != 0:
                dummy = 0
                #print(r, c, "crossing")
            # continue walking
        elif char == "-":
            if dr != 0:
                dummy = 0
                #print(r, c, "crossing")
            # continue walking
        elif char == " ":
            dummy = 0
            #print(r, c, "end")
            break
        else:
            passed = passed + char
        r = r + dr
        c = c + dc
        steps = steps + 1
    
    return (passed, steps)

def toChars (s):
    return list(s)

def turnCorner (ary, r, c, dr, dc):
    if dr != 0:
        #print ("currently moving vertically, will be moving horizontally")
        if c > 0 and ary[r][c - 1] != " ":
            return (0, -1)
        if c < len(ary[0]) and ary[r][c + 1] != " ":
            return (0, 1)
    if dc != 0:
        #print ("currently moving horizontally, will be moving vertically")
        if r > 0 and ary[r - 1][c] != " ":
            return (-1, 0)
        if r < len(ary) and ary[r + 1][c] != " ":
            return (1, 0) 
        
testData = [
"     |          ",
"     |  +--+    ",
"     A  |  C    ",
" F---|----E|--+ ",
"     |  |  |  D ",
"     +B-+  +--+ "]

print (process (testData))

with open("/Users/helen/Code/aoc 2017 d19.txt") as f:
    lines = f.readlines()
print (process (lines))
