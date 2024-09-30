fac = 1
n = 100

for i in range(2, n+1):
    fac *= i

fac = str(fac)
res = 0
for s in fac:
    res+= int(s)

print(res)
