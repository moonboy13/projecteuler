namespace Solutions;

/**
* The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
* There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
* How many circular primes are there below one million?
*
* Plan:
* - Refactor the RotateRight method from Problem32 into an extension function for integers.
* - Pair this with the IsPrime method.
* ToDo:
* - Fix the problem noted below.
* - Need to answer whether 197, 971, and 719 count as 1 or 3? Algorithm below says 3.
**/
public static class Problem35 {
    public static int Solve(int limit){
        int totalCircles = 0;
        for(int i=2; i<= limit; i++) {
            // Need a check for 101 -> 011 (becomes 11). Never exits the inner loop.
            Console.WriteLine($"Processing number {i}");
            if(i.IsPrime()){
                bool countIt = true;
                int rot = i.RotateRight();
                while(i != rot){
                    if (!rot.IsPrime()){
                        countIt = false;
                    }
                    rot = rot.RotateRight();
                }

                if(countIt){totalCircles++;}
            }
        }

        return totalCircles;
    }
}