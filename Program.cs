using System.Drawing;
public class Program
{
    public static void Main(string[] args)
    {
        //Console.SetWindowSize(-1, -1);
        Console.SetWindowSize(32, 18);
        Map map = new(14, 12);
        while (true) {
        try {
        int x = 7;
        int y = 6;
        List<Obstacle> obstacles = new();
        obstacles.Add(new(8,8));
        obstacles.Add(new(4,4));
        obstacles.Add(new(4,8));
        obstacles.Add(new(8,4));
        Random random = new();
        while (true) {
            map.Draw(new Point(x, y), obstacles);
            map.score++;
            Thread.Sleep(300);
            switch(random.Next(1,5)) {
                case 1:
                    x += 1;
                    break;
                case 2:
                    x -= 1;
                    break;
                case 3:
                    y += 1;
                    break;
                case 4:
                    y -= 1;
                    break;
            }
            foreach (Obstacle obstacle in obstacles) {
            if (obstacle.X == x && obstacle.Y == y) throw new PlayerHitException(new(x, y));
        }   
            foreach (Obstacle obstacle in obstacles) {
                obstacle.MoveAtRandom();
            }
        }
        }
        catch (OutOfBoundsException e) {
            //Console.ForegroundColor = ConsoleColor.DarkRed;
            //System.Console.WriteLine(e.Message);
            //System.Console.WriteLine($"You lost! Final Score: {map.score}");
            //Console.ResetColor();
        }
        catch (PlayerHitException e) {
            //Console.ForegroundColor = ConsoleColor.DarkRed;
            //System.Console.WriteLine(e.Message);
            //System.Console.WriteLine($"You lost! Final Score: {map.score}");
            //Console.ResetColor();
        }
        if (map.score > map.bestScore) map.bestScore = map.score;
        map.score = 0;
        map.attempt ++;
        }
    }
    public static void GetPrimes()
    {
        int start = 2;
        int end = 10000000;
        int startSecond = DateTime.Now.Second-1;
        int temp = DateTime.Now.Second-1;
        int primesFound = 0;
        DateTime now = DateTime.Now;
        List<int> primes = new List<int>();
        for (int i = start; i < end; i++)
        {
            bool isPrime = true;
            //for (int j = 2; j<i/2; j++)
            foreach (int j in primes)
            {
                if (j*100/i > 50) break;
                if (i % j == 0) {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime) {
                primes.Add(i);
                primesFound++;
                if (DateTime.Now.Second != temp) {
                    Console.WriteLine($"[{DateTime.Now}] {i} is a prime. {primesFound} primes found. {Math.Floor(primesFound/(DateTime.Now-now).TotalSeconds)} pps, {Math.Floor((i-2)/(DateTime.Now-now).TotalSeconds)} cps.");
                    //if (DateTime.Now.Second == startSecond) Console.WriteLine("1 Minute passed.");
                }
                temp = DateTime.Now.Second;
            } 
        }
    }
}