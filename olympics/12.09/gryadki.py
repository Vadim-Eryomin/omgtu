k=int(input('k='))
l=int(input('l='))
m=int(input('m='))
n=int(input('n='))
s=0

for i in range(k):
	s += 2*(l+i*m+n+m)
print('cycle', s)

s=k*(2*(l+m+n)+m*(k-1))
print('formula', s)