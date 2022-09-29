public class OutOfBoundsException : Exception
{
    public OutOfBoundsException(System.Drawing.Point position) : base($"{position.X}|{position.Y} is out of bounds!") {   
    }
}

public class PlayerHitException : Exception
{
    public PlayerHitException(System.Drawing.Point position) : base($"{position.X}|{position.Y} touched an enemy!") {   
    }
}