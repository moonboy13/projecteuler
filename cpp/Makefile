CXXFLAGS=-Wall -O0 -fno-inline -g

all: utility.o probone probtwo probthree probfour probfive probsix probseven probeight probnine probten probtenb

clean:
	rm -f *.o


utility.o:
	g++ $(CXXFLAGS) -c utility/Utility.cpp

bignum.o:
	g++ $(CXXFLAGS) -c utility/BigNum.cpp

probone:
	g++ $(CXXFLAGS) -o probone.o problem1/problem1.cpp

probtwo:
	g++ $(CXXFLAGS) -o probtwo.o problem2/problem2.cpp

probthree: utility.o
	g++ $(CXXFLAGS) -o probthree.o problem3/problem3.cpp Utility.o

probfour:
	g++ $(CXXFLAGS) -o probfour.o problem4/problem4.cpp

probfive:
	g++ $(CXXFLAGS) -o probfive.o problem5/problem5.cpp

probsix:
	g++ $(CXXFLAGS) -o probsix.o problem6/problem6.cpp

probseven: utility.o
	g++ $(CXXFLAGS) -o probseven.o problem7/problem7.cpp Utility.o

probeight:
	g++ $(CXXFLAGS) -o probeight.o problem8/problem8.cpp

probnine:
	g++ $(CXXFLAGS) -o probnine.o problem9/problem9.cpp

probten: utility.o
	g++ $(CXXFLAGS) -o probten.o problem10/problem10.cpp Utility.o

probtenb: utility.o
	g++ $(CXXFLAGS) -o probtenb.o problem10/problem10_b.cpp Utility.o

probeleven:
	g++ $(CXXFLAGS) -o probeleven.o problem11/problem11.cpp

probtwelve:
	g++ $(CXXFLAGS) -o probtwelve.o problem12/problem12.cpp

probthirteen: bignum.o
	g++ $(CXXFLAGS) -o probthirteen.o problem13/problem13.cpp BigNum.o

probthirteenb:
	g++ $(CXXFLAGS) -o probthirteenboost.o problem13/problem13_boost.cpp

probfourteen:
	g++ $(CXXFLAGS) -o probfourteen.o problem14/problem14.cpp

probfifteen:
	g++ $(CXXFLAGS) -o probfifteen.o problem15/problem15.cpp

