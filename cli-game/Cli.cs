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
		string? menuSelect2 = string.Empty;

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
			Console.WriteLine($"Day Menu Day {person.DayCount}");
			menuSelect2 = tb.menuMulti(menuDayDict, "Day menu", "Day");

			if(menuSelect2.Equals("n", StringComparison.CurrentCultureIgnoreCase))
			{
				Console.WriteLine("Next Day");
				person.newDay();
			}
			else if(menuSelect2.Equals("b", StringComparison.CurrentCultureIgnoreCase))
			{
				Console.WriteLine("Bank");
			}
			else if(menuSelect2.Equals("j", StringComparison.CurrentCultureIgnoreCase))
			{
				Console.WriteLine("standard Job");
			}
        }
	}

	public Person menuJob(Person Person)
	{
		string? menuSelectJob = string.Empty;
		StandardJobsManager sjm = new StandardJobsManager();

		List<(string, string)> menuJobDict = new List<(string, string)>
		{
			("get job", "g"),
			("leave jJob", "l"),
			("work","w"),
			("go back to day menu","q")
		};
		List<(string,string)> jobList = sjm.GetJobList();


		while(!menuSelectJob.Equals("q",StringComparison.CurrentCultureIgnoreCase))
		{
			Console.WriteLine($"Job Menu - current Job: {sjm.GetJobHired()}");
			menuSelectJob = tb.menuMulti(menuJobDict, "Job Menu", "Job");

			if(menuSelectJob.Equals("g", StringComparison.CurrentCultureIgnoreCase))
			{

			}
			else if(menuSelectJob.Equals("l", StringComparison.CurrentCultureIgnoreCase))
			{
				
			}
			else if(menuSelectJob.Equals("w", StringComparison.CurrentCultureIgnoreCase))
			{
				
			}
		}
		
		return Person;
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
				menuDay(person);
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
