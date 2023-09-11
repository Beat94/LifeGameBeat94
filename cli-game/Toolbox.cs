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
    
    public void cliTable(List<(string s1, string s2)> dict, int distance)
    {
        int strSize1 = 0;
        int strSize2 = 0;
        int strMaxSize = 0;
        string strOut1 = string.Empty;
        string strOut2 = string.Empty;
        
        foreach((string string1,string string2) in dict)
        {
            strSize1 = sizeComparer(strSize1, string1);
            strSize2 = sizeComparer(strSize2, string2);
        }

        strSize1 += distance;
        strSize2 += distance;
        if(strSize1 < strSize2)
        {
            strMaxSize = strSize2;
        }
        else
        {
            strMaxSize = strSize1;
        }

        // hier noch den String bauen
        foreach((string string1,string string2) in dict)
        {
            strOut1 = string1;
            strOut2 = string2;

            // Leerzeichen einfügen
            for(int i = 0; i < strMaxSize; i++)
            {
                if(i < (strSize1 - string1.Length))
                {
                    strOut1 += " ";
                }

                if(i < (strSize2 - string2.Length))
                {
                    strOut2 += " ";
                }
            }

            Console.WriteLine(strOut1 + strOut2);
        }
    }

    // for input in cli
    public string getStringCli(string message)
	{
		Console.Write(message + ": ");
        string output = "";
        while(output.Equals(""))
        {
            output = Console.ReadLine();
        }
		return output;
	}


    public string menuMulti(List<(string menuName, string menuCommand)> menuList, string name, string nameShort)
	{
		bool rightChoice = false;
		string? menuSelect = null;

		while(rightChoice == false)
		{
			Console.WriteLine("\n" + name);
			cliTable(menuList, 2);
			menuSelect = getStringCli(nameShort).ToLower();

			for(int i = 0; i < menuList.Count; i++)
			{
				if(menuSelect.Equals(menuList[i].menuCommand, StringComparison.CurrentCultureIgnoreCase))
				{
					rightChoice = true;
				}
			}
		}

		return menuSelect;
	}
}