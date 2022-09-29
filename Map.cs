using System.Drawing;
public class Map
{
    short width;
    short height;
    public int score = 0;
    public int bestScore = 0;
    public int attempt = 1;
    public Map(short width, short height) {
        this.width = width;
        this.height = height;
    }
    public void Draw(Point playerPos, List<Obstacle> obstacles) {
        if (playerPos.X >= width || playerPos.Y >= height || playerPos.X < 0 || playerPos.Y < 0) throw new OutOfBoundsException(playerPos);
        
        string map = "";
        //for (int i = 0; i < width*2-1; i++) {
        //    map += ("=");
        //}
        map += $"GAMEBALL 1990 ATTEMPT {attempt}\n";
        map += ($"RECORD: {bestScore} SCORE: {score}\n");
        for (int i = 0; i < width*2-1; i++) {
            map += ("=");
        }
        map += "\n";
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                bool drawSquare = true;
                if (playerPos.Equals(new(x, y))) {
                    map += "O ";
                    drawSquare = false;
                }
                foreach (Obstacle obstacle in obstacles) {
                    if (obstacle.X == x && obstacle.Y == y) {
                        map += "X ";
                        drawSquare = false;
                    }
                }
                if (drawSquare) map += ". ";
            }
            map += "\n";
        }
        //map += $"{playerPos.X}|{playerPos.Y} => ";
        //foreach(Obstacle o in obstacles) {
        //    map += ($"{o.X}|{o.Y} ");
        Console.Clear();
        
        System.Console.WriteLine(map);
    }
}
