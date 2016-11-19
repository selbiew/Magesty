def addEle(eleList,ele):
    for i in xrange(0, len(eleList)):
        if eleList[i] == ele:
            return i
    eleList.append(ele)
    return len(eleList)-1

def createList():
    num_elements = input("Number of base elements: ")
    elementList = []
    for i in xrange(0,num_elements):
        elementList.append(raw_input("Enter element " + str(i) + ": "))
    combos = [[-1 for j in xrange(0,num_elements)] for k in xrange(0,num_elements)]
    new_elements = num_elements
    while new_elements > 0:
        new_elements = 0
        for i in xrange(0, num_elements):
            for j in xrange(i, num_elements):
                if i == j:
                    combos[i][j] = i
                elif combos[i][j] == -1:
                    new_name = raw_input("How does " + elementList[i] + " combine with " + elementList[j] + "? ")
                    if new_name is not "":
                        current_length = len(elementList)
                        ind = addEle(elementList,new_name)
                        if ind is current_length:
                            new_elements = new_elements + 1
                        combos[i][j] = ind
                        combos[j][i] = ind
                    else:
                        combos[i][j] = -2
                        combos[j][i] = -2
        num_elements = num_elements + new_elements
        for i in xrange(0,len(combos)):
            for j in xrange(0,new_elements):
                combos[i].append(-1)
        for i in xrange(0,new_elements):
            combos.append([-1 for j in xrange(0,num_elements)])
    writeFile("elements.txt",elementList,combos)

def writeFile(filename,elementList,combos):
    f = open(filename,'w')
    num_elements = len(elementList)
    for i in xrange(0,num_elements):
        if i is not 0:
            f.write("|")
        f.write(elementList[i])
    for i in xrange(0,num_elements):
        f.write("\n")
        for j in xrange(0,num_elements):
            if j is not 0:
                f.write("\t")
            if combos[i][j] is not -2:
                f.write(str(combos[i][j]))
            else:
                f.write("-")
    f.close()
        
def editList(filename):
    f = open(filename,'r')
    data = f.read().splitlines()
    f.close()
    elementList = data[0].split('|')
    num_elements = len(elementList)
    combos = [[-1 for j in xrange(0,num_elements)] for k in xrange(0,num_elements)]
    data = [line.split() for line in data[1:]]
    i = 0
    for line in data:
        j = 0
        for ele in line:
            if ele == "-":
                combos[i][j] = -2
            else:
                combos[i][j] = int(ele)
            j = j+1
        i = i+1
    new_elements = 0
    while raw_input("would you like to add an element (y for yes, anything else for no)? ")=="y":
        new_element = raw_input("Enter element " + str(num_elements) + ": ")
        if new_element not in elementList:
            elementList.append(new_element)
            num_elements = num_elements + 1
            new_elements = new_elements + 1
        else:
            print new_element + " is already in the list!"
    for i in xrange(0,len(combos)):
        for j in xrange(0,new_elements):
            combos[i].append(-1)
    for i in xrange(0,new_elements):
        combos.append([-1 for j in xrange(0,num_elements)])
    while new_elements > 0:
        new_elements = 0
        for i in xrange(0, num_elements):
            for j in xrange(i, num_elements):
                if i == j:
                    combos[i][j] = i
                elif combos[i][j] == -1:
                    new_name = raw_input("How does " + elementList[i] + " combine with " + elementList[j] + "? ")
                    if new_name is not "":
                        current_length = len(elementList)
                        ind = addEle(elementList,new_name)
                        if ind is current_length:
                            new_elements = new_elements + 1
                        combos[i][j] = ind
                        combos[j][i] = ind
                    else:
                        combos[i][j] = -2
                        combos[j][i] = -2
        num_elements = num_elements + new_elements
        for i in xrange(0,len(combos)):
            for j in xrange(0,new_elements):
                combos[i].append(-1)
        for i in xrange(0,new_elements):
            combos.append([-1 for j in xrange(0,num_elements)])
        
        
    writeFile(filename,elementList,combos)
