internal class Dice
{
    private readonly Random roll;
    private int faceValue;

    public Dice()
    {
        roll = new();
        faceValue = 6;
    }

    public int Roll()
    {
        faceValue = roll.Next(1, 6);
        return faceValue;
    }
}