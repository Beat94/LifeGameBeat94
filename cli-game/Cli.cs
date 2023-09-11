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
				float valuePlayer = bank.getMoneySumFloatByType(null);
				valuePlayer += person.money.getValueFloat();

				Console.WriteLine("\nFinancial State");
				// List of Financial state
				List<(string, string)> accountSaldoList = bank.getBankAccountSaldoListByType(null);
				accountSaldoList.Add(("Total value", valuePlayer.ToString()));
				tb.cliTable(accountSaldoList, 2);
			}
			else if(menuSelectBank.Equals("a",StringComparison.CurrentCultureIgnoreCase))
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
		string menuSelectBankAccount = "";

		List<(string, string)> menuBankAccount = new List<(string, string)>
		{
			("Create Account", "c"),
			("Remove Account", "r"),
			("Deposit Money","d"),
			("Payout Money","p"),
			("Back to Bank Menu","q")
		};


		while(!menuSelectBankAccount.Equals("q", StringComparison.InvariantCultureIgnoreCase))
		{
			menuSelectBankAccount = tb.menuMulti(menuBankAccount, "Bank Account Menu", "option");

			if(menuSelectBankAccount.Equals("c", StringComparison.InvariantCultureIgnoreCase))
			{
				string accountName = tb.getStringCli("Bankaccount name");
				bank.addBankAccount(accountName,new Money(0), BankAccountType.account);
			}
			else if(menuSelectBankAccount.Equals("r", StringComparison.InvariantCultureIgnoreCase))
			{
				throw new NotImplementedException();
			}
			else if(menuSelectBankAccount.Equals("d", StringComparison.InvariantCultureIgnoreCase))
			{
				List<(string, string)> AccountList = bank.getBankAccountListMenuByType(BankAccountType.account);
				int? bankAccountIndex = null;
				float? moneyAmount = null;
				bool inputTrue = false;

				while(!inputTrue)
				{
					string? bankAccountChoose = tb.menuMulti(AccountList, "BankAccount Deposit", "Bank Account");
					string? moneyAmountString = tb.getStringCli("Money Amount");

					if(!String.IsNullOrEmpty(bankAccountChoose) && !String.IsNullOrEmpty(moneyAmountString))
					{
						try
						{
							bankAccountIndex = Int32.Parse(bankAccountChoose);
						}
						catch(Exception e)
						{
							Console.WriteLine($"please write a number BankAccountIndex now: {bankAccountChoose}");
							Console.Write(e);
							continue;
						}

						try
						{
							moneyAmount = float.Parse(moneyAmountString);
						}
						catch(Exception e)
						{
							Console.WriteLine($"please write an amount for BankAccount - now: {moneyAmountString}");
							Console.Write(e);
							continue;
						}
					}

					if(bankAccountIndex != null && moneyAmount != null)
					{
						inputTrue = true;
					}
				}

				// calling bankaccount and choosing value
				int finalBankAccountIndex = (int)bankAccountIndex;
				decimal money = (decimal)(moneyAmount*1000);
				person.money.giveMoney(money);
				bank.BankAccountList[finalBankAccountIndex].amount.addValue(money);
			}
			else if(menuSelectBankAccount.Equals("p", StringComparison.InvariantCultureIgnoreCase))
			{
				List<(string, string)> AccountList = bank.getBankAccountListMenuByType(BankAccountType.account);
				int? bankAccountIndex = null;
				float? moneyAmount = null;
				bool inputTrue = false;

				while(!inputTrue)
				{
					string? bankAccountChoose = tb.menuMulti(AccountList, "BankAccount Deposit", "Bank Account");
					string? moneyAmountString = tb.getStringCli("Money Amount");

					if(!String.IsNullOrEmpty(bankAccountChoose) && !String.IsNullOrEmpty(moneyAmountString))
					{
						try
						{
							bankAccountIndex = Int32.Parse(bankAccountChoose);
						}
						catch(Exception e)
						{
							Console.WriteLine($"please write a number BankAccountIndex now: {bankAccountChoose}");
							continue;
						}

						try
						{
							moneyAmount = float.Parse(moneyAmountString);
						}
						catch(Exception e)
						{
							Console.WriteLine($"please write an amount for BankAccount - now: {moneyAmountString}");
							continue;
						}
					}

					if(bankAccountIndex != null && moneyAmount != null)
					{
						inputTrue = true;
					}
				}

				// calling bankaccount and choosing value
				int finalBankAccountIndex = (int)bankAccountIndex;
				decimal money = (decimal)(moneyAmount*1000);
				person.addMoney(bank.BankAccountList[finalBankAccountIndex].amount.giveMoney(money));
			}
		}

	}

	public void menuBankMortgage()
	{
		string? menuSelectBankMortgage = string.Empty;

		// Choose Bankaccount is to choose mortgage and pay this 
		List<(string, string)> menuBankMortgageDict = new List<(string, string)>
		{
			("Show Mortgage Account","s"),
			("Create Mortgage","c"),
			("Choose Mortgage Account","w"),
			("Back to Bank Menu","q")
		};

		while(!menuSelectBankMortgage.Equals("q", StringComparison.CurrentCultureIgnoreCase))
		{
			menuSelectBankMortgage = tb.menuMulti(menuBankMortgageDict, "Menu Bank Mortgage", "Bank");

			if(menuSelectBankMortgage.Equals("s", StringComparison.CurrentCultureIgnoreCase))
			{
				//bank.getBankAccountListMenuByType()
				List<(string accountName, string accountSaldo)>? bankAccountList = bank.getBankAccountSaldoListByType(BankAccountType.mortage);

				if(bankAccountList != null)
				{
					tb.cliTable(bankAccountList, 2);
				}
			}
			else if(menuSelectBankMortgage.Equals("c", StringComparison.CurrentCultureIgnoreCase))
			{
				string? accountName = null; 
				while(accountName == null)
				{
					accountName = tb.getStringCli("Account Name");
				}
				
				(Money moneyWork, int sleepyness) = sjm.Work(100);
				float income = moneyWork.getValueFloat();

				// Check and max amount 
				(decimal money, bool possible) = bank.getMaxMortgageValue(income, bank.getMoneySumFloatByType(null));
				float maxMoney = (float)(money/1000);
				float choosenValue = -1;
				bool rightValue = false;

				while(rightValue == false)
				{
					string valueString = tb.getStringCli($"Please choose your mortgage. Maximum possible mortgage: {maxMoney} > ");
					try
					{
						choosenValue = float.Parse(valueString);
					}
					catch(Exception ex)
					{
						// ist machbar?
						Console.Write(ex);
						continue;
					}

					if(choosenValue <= maxMoney)
					{
						rightValue = true;
					}
				}

				decimal amount = 0;
				bank.addBankAccount((string)accountName, new Money((decimal) choosenValue*1000), BankAccountType.mortage);
			}
			else if(menuSelectBankMortgage.Equals("w", StringComparison.CurrentCultureIgnoreCase))
			{
				// List of Bankaccounts
				List<(string,string)> BankAccountList = bank.getBankAccountListMenuByType(BankAccountType.mortage);
				List<(string,string)> BankAccountMenu = new List<(string,string)>
				{
					("Deposit Account","d"),
                    ("Go to Menu Bank","q")
                };

				int choosenAccountInt = 99999;
				string choosenAccount = "";
				bool rightChoice = false;

				while(rightChoice == false)
				{
					choosenAccount = tb.menuMulti(BankAccountList, "Choose Bankaccount", "Bankaccount");

					try
					{
						choosenAccountInt = Int32.Parse(choosenAccount);
					}
					catch(FormatException ex)
					{
						Console.WriteLine(ex.Message);
						continue;
					}

					rightChoice = (choosenAccountInt < BankAccountList.Count) ? true : false;
				}

				string choosenMortgageMenu = tb.menuMulti(BankAccountMenu, bank.BankAccountList[choosenAccountInt].accountName, "Choose");

				if (choosenMortgageMenu.Equals("d", StringComparison.InvariantCultureIgnoreCase))
				{ 
					// choose amount to pay into negative account
					string amountStr = "";
					bool filledAndTrue = false;
					float amount = 0;
					decimal amountD = 0;

					while(filledAndTrue == false)
					{
						amountStr = tb.getStringCli("Choose amount to pay back");

						try
						{
							amount = float.Parse(amountStr);
						}
						catch (FormatException ex)
						{
                            Console.Write(ex);
                            continue;
                        }

						if (amount <= bank.BankAccountList[choosenAccountInt].amount.getValueFloat() && amount <= person.money.getValueFloat())
						{
							filledAndTrue = true;
							amountD = (decimal)(amount * 1000);
                        }
					}

					person.money.giveMoney(amountD);
                    bank.BankAccountList[choosenAccountInt].amount.giveMoney(amountD);
                }
			}
		}
	}

	public void menuBankCredit()
	{
		string? menuSelectBankCredit = string.Empty;

		List<(string, string)> menuBankCredit = new List<(string, string)>
		{
			("Back to Bank Menu","q")
		};
	}

	public void menuDay()
	{
		string menuSelect2 = "";

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
				//Console.WriteLine("Bank");
				menuBank();
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
			("leave job", "l"),
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
				// implement save-workflow todo
				Console.WriteLine("Save Game");
			}
			else if(menuSelect.Equals("l"))
			{
				// implement load-workflow todo
				Console.WriteLine("Load Game");
			}
		}
	}
}
