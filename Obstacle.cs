public class Obstacle {
    public int X;
    public int Y;
    private Random random = new();
    public Obstacle(int x, int y) {
        X = x;
        Y = y;
    }
    public void MoveAtRandom() {
    switch(random.Next(1,5)) {
        case 1:
            X += 1;
            break;
        case 2:
            X -= 1;
            break;
        case 3:
            Y += 1;
            break;
        case 4:
            Y -= 1;
            break;
        }
    }
}