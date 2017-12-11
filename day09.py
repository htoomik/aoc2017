def process (s):
    print ("---------")
    chars = list(s)

    groups = 0
    nesting = 0
    score = 0
    garbs = 0
    garbage = False
    negate = False
    
    for i in range(0, len(chars)):
        c = chars[i]
        dp (c)
        
        if negate:
            negate = False
            continue

        if garbage:
            if c == ">":
                dp ("end of garbage")
                garbage = False
            elif c == "!":
                dp ("negate next char")
                negate = True
            else:
                dp ("garbage")
                garbs += 1
        else:
            if c == "{":
                dp ("start of group")
                groups += 1
                nesting += 1
            elif c == "}":
                score += nesting
                dp ("end of group - adding {0} to score for a total of {1}".format(nesting, score))
                nesting -= 1
            elif c == "<":
                dp ("start of garbage")
                garbage = True
            else:
                dp ("")

    print ("Groups: ", groups)
    print ("Score: ", score)
    print ("Total garbage found: ", garbs)

    return score

def dp (s):
    #print (s)
    return
        
d0 = "{}"
d1 = "{{{}}}"
d2 = "{{},{}}"
d3 = "{{{},{},{{}}}}"
d4 = "{<a>,<a>,<a>,<a>}"
d5 = "{{<ab>},{<ab>},{<ab>},{<ab>}}"
d6 = "{{<!!>},{<!!>},{<!!>},{<!!>}}"
d7 = "{{<a!>},{<a!>},{<a!>},{<ab>}}"

#print("d0: ", process(d0))
#print("d1: ", process(d1))
#print("d2: ", process(d2))
#print("d3: ", process(d3))
#print("d4: ", process(d4))
#print("d5: ", process(d5))
#print("d6: ", process(d6))
#print("d7: ", process(d7))

with open ("/Users/helen/Code/aoc 2017 d9.txt", "r") as f:
    data = f.read()
process (data)
