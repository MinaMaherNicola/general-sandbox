l = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]

h = [
  {'name': "mina", 'age': 500},
  {'name': "mina", 'age': 20}
]

l.sort(reverse=True);

print(l)


h.sort(key=lambda x: x['age'])
print(h)