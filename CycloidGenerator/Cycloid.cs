using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator
{
    public class Cycloid
    {
    }



    /*
     #!/usr/bin/python

"""Hypocycloid cam generator
Generate dxfs of hypocycloid cams for cycloid drives

Copyright 	2009, Alex Lait
Version 	v0.2 (09/13/09)
License 	GPL
Homepage 	http://www.zincland.com/hypocycloid

Credit to:
	Formulas to describe a hypocycloid cam
	http://gears.ru/transmis/zaprogramata/2.139.pdf

	Insperational thread on CNCzone
	http://www.cnczone.com/forums/showthread.php?t=72261

	Documenting and updating the sdxf library
	http://www.kellbot.com/sdxf-python-library-for-dxf/

	Formulas for calculating the pressure angle and finding the limit circles
	http://imtuoradea.ro/auo.fmte/files-2007/MECATRONICA_files/Anamaria_Dascalescu_1.pdf

Notes:
	Does not currently do ANY checking for sane input values and it
	is possible to create un-machinable cams, use at your own risk

	Suggestions:
	- Eccentricity should not be more than the roller radius
	- Has not been tested with negative values, may have interesting results :)
"""

import getopt
import sys
import sdxf
import math

def usage():
	print "Usage:"	
	print "-p = Tooth Pitch              (float)"
	print "-b = Pin bolt circle diameter (float)"
	print "     -b overrides -p"
	print "-d = Roller Diameter          (float)"
	print "-e = Eccentricity             (float)"
	print "-a = Pressure angle limit     (float)"
	print "-c = offset in pressure angle (float)"
	print "-n = Number of Teeth in Cam   (integer)"
	print "-s = Line segements in dxf    (integer)"
	print "-f = output filename          (string)"
	print "-h = this help"
	print "\nExample: hypocycloid.py -p 0.08 -d 0.15 -e 0.05 -a 50.0 -c 0.01 -n 10 -s 400 -f foo.dxf"

def toPolar(x, y):
        return (x**2 + y**2)**0.5, math.atan2(y, x)

def toRect(r, a):
        return r*math.cos(a), r*math.sin(a)       

def calcyp(a,e,n):
	return math.atan(math.sin(n*a)/(math.cos(n*a)+(n*p)/(e*(n+1))))

def calcX(p,d,e,n,a):
	return (n*p)*math.cos(a)+e*math.cos((n+1)*a)-d/2*math.cos(calcyp(a,e,n)+a)

def calcY(p,d,e,n,a):
	return (n*p)*math.sin(a)+e*math.sin((n+1)*a)-d/2*math.sin(calcyp(a,e,n)+a)

def calcPressureAngle(p,d,n,a):
        ex = 2**0.5
        r3 = p*n
        rg = r3/ex
        pp = rg * (ex**2 + 1 - 2*ex*math.cos(a))**0.5 - d/2
        return math.asin( (r3*math.cos(a)-rg)/(pp+d/2))*180/math.pi

def calcPressureLimit(p,d,e,n,a):
        ex = 2**0.5
        r3 = p*n
        rg = r3/ex
        q = (r3**2 + rg**2 - 2*r3*rg*math.cos(a))**0.5
        x = rg - e + (q-d/2)*(r3*math.cos(a)-rg)/q
        y = (q-d/2)*r3*math.sin(a)/q
        return (x**2 + y**2)**0.5

def checkLimit(x,y,maxrad,minrad,offset):
        r, a = toPolar(x, y)
        if (r > maxrad) or (r < minrad):
                r = r - offset
                x, y = toRect(r, a)
        return x, y

try:
   opts, args = getopt.getopt(sys.argv[1:], "p:b:d:e:n:a:c:s:f:h")
except getopt.GetoptError, err:
   print str(err)
   usage()
   sys.exit(2)

p = 0.00
d = 0.00
e = 0.00
n = 0.00
s = 0.00
b =-1.00
f = "xxx"
ang = 50.0
c = 0.00
x = 0.00
y = 0.00
i = 0

try:
	for o, a in opts:
	   if o in ("-p", "-P"):
		p = float(a)
	   elif o in ("-b", "-B"):
		b = float(a)
	   elif o in ("-d", "-D"):
		d = float(a)
	   elif o in ("-e", "-E"):
		e = float(a)
	   elif o in ("-n", "-N"):
		n = int(a)
	   elif o in ("-s", "-S"):
		s = int(a)
	   elif o in ("-a", "-A"):
		ang = float(a)
	   elif o in ("-c", "-C"):
		c = float(a)
	   elif o in ("-f", "-F"):
		f = a
	   elif o in ("-h", "-H"):
		usage()
		sys.exit(0)
	   else:
		assert False, "unhandled option"
		sys.exit(2)
except:
	usage()
	sys.exit(2)

#if -o was specifed, calculate the tooth pitch for use in cam generation
if b > 0:
	p = b/n

q=2*math.pi/float(s)

dxf=sdxf.Drawing()

dxf.layers.append(sdxf.Layer(name="text", color=2) )	#yellow text layer
dxf.layers.append(sdxf.Layer(name="cam", color=1) ) 	#red cam layer
dxf.layers.append(sdxf.Layer(name="roller", color=5) )	#blue roller layer
dxf.layers.append(sdxf.Layer(name="pressure", color=3) )	#pressure angle limit layer

# Add text to discribe the cam - autodocument
dxf.append( sdxf.Text( "pitch="       +str(p), point=(p*n+d, 0.7), layer="text", height=0.1) )
dxf.append( sdxf.Text( "pin diameter="+str(d), point=(p*n+d, 0.5), layer="text", height=0.1) )
dxf.append( sdxf.Text( "eccentricity="+str(e), point=(p*n+d, 0.3), layer="text", height=0.1) )
dxf.append( sdxf.Text( "# of teeth="  +str(n), point=(p*n+d, 0.1), layer="text", height=0.1) )
dxf.append( sdxf.Text( "pressure angle limit="  +str(ang), point=(p*n+d,-0.1), layer="text", height=0.1) )
dxf.append( sdxf.Text( "pressure angle offset="  +str(c), point=(p*n+d,-0.3), layer="text", height=0.1) )

# Find the pressure angle limit circles
minAngle = -1.0
maxAngle = -1.0
for i in range(0, 180):
        x = calcPressureAngle(p,d,n,float(i)*math.pi/180)
        if (x < ang) and (minAngle < 0):
                minAngle = float(i)
        if (x < -ang) and (maxAngle < 0):
                maxAngle = float(i-1)
dxf.append( sdxf.Text( "min angle="  +str(minAngle), point=(p*n+d,-0.5), layer="text", height=0.1) )
dxf.append( sdxf.Text( "max angle="  +str(maxAngle), point=(p*n+d,-0.7), layer="text", height=0.1) )
minRadius = calcPressureLimit(p,d,e,n,minAngle*math.pi/180)
maxRadius = calcPressureLimit(p,d,e,n,maxAngle*math.pi/180)
dxf.append( sdxf.Circle(center=(-e, 0), radius=minRadius, layer="pressure") )
dxf.append( sdxf.Circle(center=(-e, 0), radius=maxRadius, layer="pressure") )

#generate the cam profile - note: shifted in -x by eccentricicy amount
i=0
x1 = calcX(p,d,e,n,q*i)
y1 = calcY(p,d,e,n,q*i)
x1, y1 = checkLimit(x1,y1,maxRadius, minRadius, c)
for i in range(0, s):
        x2 = calcX(p,d,e,n,q*(i+1))
        y2 = calcY(p,d,e,n,q*(i+1))
        x2, y2 = checkLimit(x2,y2,maxRadius, minRadius, c)
	dxf.append( sdxf.Line(points=[(x1-e,y1),  (x2-e,y2)], layer="cam" ) )
        x1 = x2
        y1 = y2

#add a circle in the center of the cam
dxf.append( sdxf.Circle(center=(-e, 0), radius=d/2, layer="cam") )

#generate the pin locations
for i in range(0, n+1):
	x = p*n*math.cos(2*math.pi/(n+1)*i)
	y = p*n*math.sin(2*math.pi/(n+1)*i)
	dxf.append( sdxf.Circle(center=(x,y), radius=d/2, layer="roller") )
#add a circle in the center of the pins
dxf.append( sdxf.Circle(center=(0, 0), radius=d/2, layer="roller") )


try:
	dxf.saveas(f)
except:
	print("Problem saving file")
	sys.exit(2)



     */
}
