using System;

public class Cli
{
	public string? getStringCli(string message)
	{
		Console.Write(message + ": ");
		return Console.ReadLine();
	}

	public void run()
	{
	
	}
}
