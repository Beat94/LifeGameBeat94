using System;

public class Cli
{
	Toolbox tb = new Toolbox();
	StandardJobsManager sjm = new StandardJobsManager();
	Person person = new Person("");
	Bank bank = new Bank("Public Bank", 1,1,1,1);

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

	public void menuBank()
	{
		string? menuSelectBank = string.Empty;

		List<(string, string)> menuBankDict = new List<(string, string)>
		{
			("Show Financial state","s"),
			("Account Menu","a"),
			("Mortgage Menu","m"),
			("Credit Menu", "c"),
			("Go to Day Menu", "q")
		};

		while(!menuSelectBank.Equals("q", StringComparison.CurrentCultureIgnoreCase))
		{
			menuSelectBank = tb.menuMulti(menuBankDict, "Menu Bank", "Bank");

			if(menuSelectBank.Equals("s",StringComparison.CurrentCultureIgnoreCase))
			{
				Console.WriteLine("Financial State");
				// List of Financial state
			}
			else if(menuSelectBank.Equals("s",StringComparison.CurrentCultureIgnoreCase))
			{
				//Console.WriteLine("Account Menu");
				menuBankAccount();
			}
			else if(menuSelectBank.Equals("m",StringComparison.CurrentCultureIgnoreCase))
			{
				//Console.WriteLine("Mortgage Menu");
				menuBankMortgage();
			}
			else if(menuSelectBank.Equals("c",StringComparison.CurrentCultureIgnoreCase))
			{
				//Console.WriteLine("Credit Menu");
				menuBankCredit();
			}
		}
	}

	public void menuBankAccount()
	{
		string? menuSelectBankAccount = string.Empty;

		List<(string, string)> menuBankAccount = new List<(string, string)>
		{
			("a","a")
		};

	}

	public void menuBankMortgage()
	{
		string? menuSelectBankMortgage = string.Empty;

		List<(string, string)> menuBankMortgage = new List<(string, string)>
		{
			("Show Mortgage Account","s"),
			("Create Bank Account","c"),
			("Choose Bank Account","w"),
			("Back to Bank Menu","q")
		};
	}

	public void menuBankCredit()
	{
		string? menuSelectBankCredit = string.Empty;

		List<(string, string)> menuBankCredit = new List<(string, string)>
		{
			("a","a")
		};
	}

	public void menuDay()
	{
		string? menuSelect2 = string.Empty;

		List<(string, string)> menuDayDict = new List<(string, string)>
		{
			// implement menu
			("Next Day", "n"),
			("Go to Bank", "b"),
			("Go to Standard Jobs", "j"),
			("Go to Main Menu", "q")
		};


		while(!menuSelect2.Equals("q", StringComparison.CurrentCultureIgnoreCase))
		{
			Console.WriteLine("Person stats:");
			tb.cliTable(person.getPersonStats(), 2);
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
				// Console.WriteLine("standard Job");
				menuJob();
			}
        }
	}

	public void menuJob()
	{
		string? menuSelectJob = string.Empty;

		List<(string, string)> menuJobDict = new List<(string, string)>
		{
			("get job", "g"),
			("leave jJob", "l"),
			("work","w"),
			("go back to day menu","q")
		};
		List<(string,string)> jobList = sjm.GetJobList();


		while (!menuSelectJob.Equals("q", StringComparison.CurrentCultureIgnoreCase))
		{
			Console.WriteLine($"Job Menu - current Job: {sjm.GetJobHired()}");
			menuSelectJob = tb.menuMulti(menuJobDict, "Job Menu", "Job");

			if (menuSelectJob.Equals("g", StringComparison.CurrentCultureIgnoreCase))
			{
				sjm.GetJob(Int32.Parse(tb.menuMulti(sjm.GetJobList(), "Get job - joblist:", "select Job")));
			}
			else if (menuSelectJob.Equals("l", StringComparison.CurrentCultureIgnoreCase))
			{
				sjm.LeaveJob();
			}
			else if (menuSelectJob.Equals("w", StringComparison.CurrentCultureIgnoreCase))
			{
				// add workpercentage question
				(Money salary, int sleepy) = sjm.Work(100);
				person.addMoney(salary);
				person.sleepyness = person.sleepyness - sleepy;
			}
		}
	}

	public void run()
	{
		Person person;
		string? menuSelect = "";
		while(!menuSelect.Equals("q"))
		{
			menuSelect = menuMain();
			if(menuSelect.Equals("n"))
			{
				// implement new person-workflow
				Console.WriteLine("New Game");
				string name = tb.getStringCli("Name");
				person = new Person(name);
				menuDay();
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
