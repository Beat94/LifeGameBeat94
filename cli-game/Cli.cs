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
		string menuSelect;
		Console.WriteLine("Welcome to lifegame of Beat94");
		Console.WriteLine("Main menu:");
		Console.WriteLine("New game /t n");
		Console.WriteLine("Load game /t l");
		Console.WriteLine("Quit /t q");
		menuSelect = getStringCli("Menu");
	}
}
