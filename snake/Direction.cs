namespace snake
{
    public class Direction
    {
public int RowOffset { get; }
public int ColOffset { get; }

private Direction(int rowOffset, int colOffset)
{
    RowOffset = rowOffset;
    ColOffset = colOffset;
}
    }

}