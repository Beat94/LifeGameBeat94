using System;

public class Cli
{
	public string? getStringCli(string message)
	{
		Console.Write(message + ": ");
		return Console.ReadLine();
	}

	public string? menu()
	{
		bool rightChoice = false;
		string? menuSelect = null;
		while(rightChoice == false)
		{
			Console.WriteLine("Welcome to lifegame of Beat94");
			Console.WriteLine("Main menu:");
			Console.WriteLine("New game /t n");
			Console.WriteLine("Load game /t l");
			Console.WriteLine("Save game /t s");
			Console.WriteLine("Quit /t q");
			menuSelect = getStringCli("Menu").ToLower();
			if(menuSelect.Equals("n") || menuSelect.Equals("l") || menuSelect.Equals("q") || menuSelect.Equals("s"))
			{
				rightChoice = true;
			}
		}

		return menuSelect;
	}

	public void run()
	{
		string? menuSelect = null;
		while(!menuSelect.Equals("q"))
		{
			menuSelect = menu();
			if(menuSelect.Equals("n"))
			{
				// implement new person-workflow
			}
			else if(menuSelect.Equals("s"))
			{
				// implement save-workflow
			}
			else if(menuSelect.Equals("l"))
			{
				// implement load-workflow
			}
		}
	}
}
