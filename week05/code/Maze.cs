
public class Maze
{
    public int Width { get; }
    public int Height { get; }

    public readonly int[] Data;

    public Maze(int width, int height, int[] data)
    {
        this.Width = width;
        this.Height = height;
        this.Data = data;
    }

   
    public bool IsEnd(int x, int y)
    {
        return Data[y * Height + x] == 2;
    }



    public bool IsValidMove(List<ValueTuple<int, int>> currPath, int x, int y)
    {
        if (x > Width - 1 || x < 0)
            return false;
        if (y > Height - 1 || y < 0)
            return false;
        if (Data[y * Height + x] == 0)
            return false;
        if (currPath.Contains((x, y)))
            return false;
        return true;
    }
}