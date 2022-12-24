public static class MyExtension
{
    public static bool IsBalanced(this int[] arr)
    {
        return (arr[0] ^ arr[1] ^ arr[2]) == 0;
    }
    
    public static bool IsEmpty(this int[] arr)
    {
        return arr.Sum() == 0;
    }

    public static int MaxNumIdx(this int[] arr)
    {
        int maxNum = 0;
        int maxIdx = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if(arr[i] == 0) continue;
            
            if (maxNum < arr[i])
            {
                maxNum = arr[i];
                maxIdx = i;
            }
        }
        
        Console.WriteLine(maxIdx);

        return maxIdx;
    }

    public static int[] MaxToMinIdx(this int[] arr)
    {
        var seqDict = new List<ValIdxVo>();

        for (var i = 0; i < arr.Length; i++)
        { 
            seqDict.Add(new ValIdxVo {val = arr[i], idx = i});
        }
        
        return seqDict.AsQueryable().OrderByDescending(a => a.val).Select(a => a.idx).ToArray();
    }
    
    

    public static void PrintScreen(this int[] arr)
    {
        Console.WriteLine($"当前数量: [{arr[0]},{arr[1]},{arr[2]}]");
    }
}

public class ValIdxVo
{
    public int val { get; set; }
        
    public int idx { get; set; }
}