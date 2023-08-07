using System;

public class Cli
{
	Toolbox tb = new Toolbox();
	
	public string? menuMain()
	{
		List<(string, string)> menuDict = new List<(string,string)>
		{
			("New game", "n"),
			("Load game", "l"),
			("Save game", "s"),
			("Quit", "q")
		};
		
		Console.WriteLine("Welcome to Life-Game");
		string? menuSelect = tb.menuMulti(menuDict, "Main Menu", "Menu");

		return menuSelect;
	}

	public void menuDay(Person person)
	{
		string? menuSelect2 = null;

		List<(string, string)> menuDayDict = new List<(string, string)>
		{
			// implement menu
			("Next Day", "n"),
			("Go to Bank", "b"),
			("Go to standard Jobs", "j"),
			("Go to Main Menu", "q")
		};

		while(!menuSelect2.Equals("q", StringComparison.CurrentCultureIgnoreCase))
		{

			
			bool rightChoice = false;

            // Create a check algorithm based on additional menu-data
			while(rightChoice == false)
			{
				Console.WriteLine($"Day Menu Day {person.dayCount}");
				tb.cliTable(menuDayDict, 2);

				menuSelect2 = tb.getStringCli("Day Menu").ToLower();
				if(menuSelect2.Equals("n") || menuSelect2.Equals("b") || menuSelect2.Equals("j") || menuSelect2.Equals("q"))
				{
					rightChoice = true;
				}
			}

			if(menuSelect2.Equals("n"))
			{

			}
        }
	}

	public void run()
	{
		Person person;
		string menuSelect = "";
		while(!menuSelect.Equals("q"))
		{
			menuSelect = menuMain();
			if(menuSelect.Equals("n"))
			{
				// implement new person-workflow
				Console.WriteLine("New Game");
				string name = tb.getStringCli("Name");
				person = new Person(name);
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
