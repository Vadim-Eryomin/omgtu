from math import atan2, degrees, pi

def wall(x, y, z, a, b, c):
    if y == 0: return 1
    if y == b: return -1
    
    if x == 0: return -2
    if x == a: return 2
    
    if z == 0: return -3
    else: return 3
    
def sort(a, b):
    if a <= b:
        return (a, b)
    else: 
        return (b, a)
        

def angle(x1, y1, x2, y2):
    dx = x2 - x1
    dy = y2 - y1
    rads = atan2(-dy,dx)
    rads %= 2*pi
    return rads

with open('a') as f:
    a, b, c = [int(x) for x in f.readline().split()]
    sx, sy, sz = [int(x) for x in f.readline().split()]
    fx, fy, fz = [int(x) for x in f.readline().split()]
    
    sw = wall(sx, sy, sz, a, b, c)
    fw = wall(fx, fy, fz, a, b, c)
    
    if sw == fw or sw == -fw:
        d = ((fx - sx) ** 2 + (fy - sy) ** 2 + (fz - sw) ** 2) ** 0.5
    
    elif sw != -fw:
        tx, ty, tz = -1, -1, -1
        var = sort(sw, fw)
        
        if 3 in var: tz = c
        if -3 in var: tz = 0
        
        if 2 in var: tx = a
        if -2 in var: tx = 0
        
        if 1 in var: ty = 0
        if -1 in var: ty = b
            
        if tx == -1: tx = (fx + sx) / 2
        if ty == -1: ty = (fy + sy) / 2
        if tz == -1: tz = (fz + sz) / 2
    
        d1 = ((tx - sx) ** 2 + (ty - sy) ** 2 + (tz - sz) ** 2) ** 0.5
        d2 = ((tx - fx) ** 2 + (ty - fy) ** 2 + (tz - fz) ** 2) ** 0.5
        d = d1 + d2
    
    
    print(d)
    
    
    
    
    
