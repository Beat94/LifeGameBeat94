using System.Collections;

public class Toolbox
{
    private int sizeComparer(int size, string inputStr)
    {
        if(size < inputStr.Length)
        {
            size = inputStr.Length;
        }

        return size;
    }
    
    public void cliTable(List<(string s1, string s2)> dict)
    {
        int strSize1 = 0;
        int strSize2 = 0;
        
        foreach((string string1,string string2) in dict)
        {
            strSize1 = sizeComparer(strSize1, string1);
            strSize2 = sizeComparer(strSize2, string2);
        }

        // hier noch den String bauen

        Console.WriteLine($"Max Grösse Spalte 1 {strSize1}");
        Console.WriteLine($"Max Grösse Spalte 2 {strSize2}");
    }
}