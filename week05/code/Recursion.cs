using System.Collections;

public static class Recursion
{
    
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        
        return n * n + SumSquaresRecursive(n - 1);
    }

    
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }
        
        for (int i = 0; i < letters.Length; i++)
        {
            char currentLetter = letters[i];
            
            string remainingLetters = letters.Remove(i, 1);
            
            PermutationsChoose(results, remainingLetters, size, word + currentLetter);
        }
    }

    
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        if (remember == null)
            remember = new Dictionary<int, decimal>();
        
        if (remember.ContainsKey(s))
            return remember[s];

        // Solve using recursion with memoization
        decimal ways = CountWaysToClimb(s - 1, remember) + 
                       CountWaysToClimb(s - 2, remember) + 
                       CountWaysToClimb(s - 3, remember);
        
        // Store the result in the memoization dictionary
        remember[s] = ways;
        
        return ways;
    }

   
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Base case: if there are no wildcards, add the pattern to results
        int wildcardIndex = pattern.IndexOf('*');
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }
        
        // Recursive case: replace the first wildcard with 0 and 1
        // Replace with '0'
        string pattern0 = pattern[..wildcardIndex] + '0' + pattern[(wildcardIndex + 1)..];
        WildcardBinary(pattern0, results);
        
        // Replace with '1'
        string pattern1 = pattern[..wildcardIndex] + '1' + pattern[(wildcardIndex + 1)..];
        WildcardBinary(pattern1, results);
    }


    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
    
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        currPath.Add((x, y));
        
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            
            if (maze.IsValidMove(currPath, x + 1, y))
            {
                SolveMaze(results, maze, x + 1, y, new List<ValueTuple<int, int>>(currPath));
            }
            
            if (maze.IsValidMove(currPath, x, y + 1))
            {
                SolveMaze(results, maze, x, y + 1, new List<ValueTuple<int, int>>(currPath));
            }
            
            if (maze.IsValidMove(currPath, x - 1, y))
            {
                SolveMaze(results, maze, x - 1, y, new List<ValueTuple<int, int>>(currPath));
            }
            
            if (maze.IsValidMove(currPath, x, y - 1))
            {
                SolveMaze(results, maze, x, y - 1, new List<ValueTuple<int, int>>(currPath));
            }
        }
    }
}