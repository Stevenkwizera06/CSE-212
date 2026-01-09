using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(3, 5) will result in: {3, 6, 9, 12, 15}.  The number of multiples to calculate is the 'length'.
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Initialize a new double array of size 'length' to store the results.
        // 2. Use a for loop to iterate 'length' times (from index 0 to length - 1).
        // 3. Inside the loop, calculate the multiple by multiplying 'number' by (index + 1).
        // 4. Store the calculated multiple in the array at the current index.
        // 5. After the loop finishes, return the array containing the multiples.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 5 then the list after the function runs should be 
    /// List<int>{5, 6, 7, 8, 9, 1, 2, 3, 4}.
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Calculate the effective rotation amount by taking 'amount modulo data.Count'.
        //    This handles cases where the rotation amount is greater than the list size.
        // 2. If the effective amount is 0 or the list is too small (e.g. less than 2 elements), 
        //    no rotation is needed, so return.
        // 3. Determine the split point index: 'data.Count - effectiveAmount'.
        //    The elements starting from this index to the end are the ones that will move to the front.
        // 4. Extract the slice of elements to move: use 'GetRange' from splitIndex with count 'effectiveAmount'.
        // 5. Extract the slice of remaining elements: use 'GetRange' from index 0 to 'splitIndex'.
        // 6. Clear the original 'data' list.
        // 7. Add the extracted 'back part' (from step 4) to 'data' first.
        // 8. Add the extracted 'front part' (from step 5) to 'data' next.

        if (data.Count < 2) return;
        int effectiveAmount = amount % data.Count;
        if (effectiveAmount == 0) return;

        int splitIndex = data.Count - effectiveAmount;
        List<int> backPart = data.GetRange(splitIndex, effectiveAmount);
        List<int> frontPart = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(backPart);
        data.AddRange(frontPart);
    }
}
