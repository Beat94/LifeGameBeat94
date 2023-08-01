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
		List<(string, string)> menuDict = new List<(string,string)>();
		bool rightChoice = false;
		string? menuSelect = null;
		Toolbox tb = new Toolbox();
		
		menuDict.Add(("New game", "n"));
		menuDict.Add(("Load game", "l"));
		menuDict.Add(("Save game", "s"));
		menuDict.Add(("Quit", "q"));

		while(rightChoice == false)
		{
			Console.WriteLine("Welcome to lifegame of Beat94");
			Console.WriteLine("Main menu:");
			tb.cliTable(menuDict, 2);
			// Hier noch das Menü einbauen		

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
		string menuSelect = "";
		while(!menuSelect.Equals("q"))
		{
			menuSelect = menu();
			if(menuSelect.Equals("n"))
			{
				// implement new person-workflow
				Console.WriteLine("New Game");
				string name = getStringCli("Name");
				Person person = new Person(name);
			}
			else if(menuSelect.Equals("s"))
			{
				// implement save-workflow
				Console.WriteLine("Save Game");
			}
			else if(menuSelect.Equals("l"))
			{
				// implement load-workflow
				Console.WriteLine("Load Game");
			}
		}
	}
}
