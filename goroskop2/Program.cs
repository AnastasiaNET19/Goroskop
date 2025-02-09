using System;
using System.Linq;
using System.Collections.Generic;


internal class Program
{
	public static void Main(string[] args)
	{
		bool repeat = true;

		while (repeat)//цикл для повторного запуска кода
		{
			Console.WriteLine("Привет, мой друг!");//Приветсвие
			Console.WriteLine("Ай-на-нэ, сейчас всю правду расскажу тебе (Нажми ввод!)");
			Console.ReadLine();
			string username = GetValidUserName();
			Console.WriteLine();
			Console.WriteLine($"Привет,{username}");		
			Console.WriteLine();
			Console.WriteLine($"Ой, {username}, позолотишь ручку ,а? (Да/Нет)");//придурошный диалог
			string datgold = GetGold();//вызов метода для операций с придурошным диалогом
			Console.WriteLine(datgold);
			Console.WriteLine();
			Console.WriteLine(username + ", приступим к гороскопу! Введи дату своего рождения!");//Запрос даты рождения
			DateTime dateOfBirth  =  GetDateOfBirth();
			Console.WriteLine();
			string ZnakZodiac = GetZnakZodiac(dateOfBirth);//метод, определяющий знак зодиака
			string dayOfWeek = dateOfBirth.DayOfWeek.ToString();//определение дня недели
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"Твой знак зодиака: {ZnakZodiac}");
			Console.WriteLine();
			Console.WriteLine($"День недели твоего рождения: {dayOfWeek}");
			Console.ResetColor();
			Console.WriteLine();
			List<string> list1 = new List<string> { "Дружелюбный", "Открытый и добродушный", "Стремится к высоким достижениям", "Ответственный"};
			List<string> list2 = new List<string> { "Творческий", "Полон новых идей и вдохновения", "Целеустремленный", "Настойчиво добивается своих целей" };
			List<string> list3 = new List<string> { "Жизнерадостный", "Всегда в хорошем настроении", "Мудрый", "Обладает глубокими знаниями и опытом" };
			List<string> list4 = new List<string> { "Честный", "Всегда говорит правду и не обманывает", "Смелый", "Не боится новых вызовов", "Сочувствующий", "Готов помочь и поддержать других" };
			var randomValues = GetRandomValues(list1, list2, list3, list4);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"Качества характера, соответствующие дате твоего рождения: \n {randomValues.Item1},\n {randomValues.Item2}, \n {randomValues.Item3}, \n {randomValues.Item4}");
			Console.ResetColor();
			Console.WriteLine();
			Console.WriteLine($"{username}, оцени, насколько точно гороскоп определил твои качества характера"); //оценить гороскоп
			string ocenkagoroskopa = GetOcenka();//метод вычисления оценки 
			Console.WriteLine(ocenkagoroskopa); 
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Хотите попробовать еще раз? (Да/Нет)");//запрос на репит кода
			string useranswer = Console.ReadLine().ToLower();

			if (useranswer == "да")
			{
				repeat = true;
			}
			else
			{
				repeat = false;
			}
        }
		Console.WriteLine("Гороскоп завершен! До встречи!");
	}
	public static string GetZnakZodiac(DateTime dateznak)
	{
		int day = dateznak.Day;
		int month = dateznak.Month;

		if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
			return "Водолей";
		if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
			return "Рыбы";
		if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
			return "Овен";
		if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
			return "Телец";
		if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
			return "Близнецы";
		if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
			return "Рак";
		if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
			return "Лев";
		if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
			return "Дева";
		if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
			return "Весы";
		if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
			return "Скорпион";
		if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
			return "Стрелец";
		if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
			return "Козерог";
		else return "Вы ввели некорректный запрос, попробуйте в другой раз!!";
	}
	public static string GetOcenka()
	{
		int OcenkaUsera;
		do
		{
			Console.WriteLine("Введите число от 1 до 5");
			OcenkaUsera = int.Parse(Console.ReadLine());
		} 
        while (OcenkaUsera < 1 || OcenkaUsera > 5);

		if (OcenkaUsera >= 1 && OcenkaUsera <= 4)
			return "Надеюсь, в следующий раз будет лучше! ;)";
		else 
			return "Здорово, рады помочь!";
	}
	public static string GetGold()
	{
		string gold = Console.ReadLine().ToLower();

		if (gold == "да")
        {
            return "Ну ты и Бусечка!!!";
        }

		if (gold == "нет")
        {
            return "Бууу, ну и ладно. Все равно помогу :)";
        }
		else
        {
            return "Непанимать тебя, погнали дальше!";
        }
	}
	static string GetValidUserName()
	{
		string userName;

		do
		{
			Console.WriteLine("Как тебя зовут?");
			userName = Console.ReadLine();

			if (!IsNameValid(userName))
			{
				Console.WriteLine("Некорректное имя. Пожалуйста, введите снова.");
			}

		} 
        while (!IsNameValid(userName));

		return userName;
	}
	public static bool IsNameValid(string userName)
	{
		// Проверка, чтобы строка содержала только буквы (латинские или кириллические)
		return !string.IsNullOrWhiteSpace(userName) && userName.All(char.IsLetter);
	}
	public static DateTime GetDateOfBirth()
	{
		int day_of_birth;
		int month_of_birth;
		int year_of_birth;
		bool isValidDate = false;

		do
		{
			Console.WriteLine("Начнем с числа рождения. Введи число");

			while (!int.TryParse(Console.ReadLine(), out day_of_birth) || day_of_birth < 1 || day_of_birth > 31)
			{
				Console.WriteLine("Неверный ввод. Пожалуйста, введите корректный день (1-31):");
			}
			Console.WriteLine("Введи месяц рождения:");

			while (!int.TryParse(Console.ReadLine(), out month_of_birth) || month_of_birth < 1 || month_of_birth > 12)
			{
				Console.WriteLine("Неверный ввод. Пожалуйста, введите корректный месяц (1-12):");
			}

			Console.WriteLine("Введи год рождения:");

			while (!int.TryParse(Console.ReadLine(), out year_of_birth) || year_of_birth < 1920 || year_of_birth > DateTime.Now.Year)
			{
				Console.WriteLine("Неверный ввод. Пожалуйста, введите корректный год:");
			}

			isValidDate = IsValidDate(day_of_birth, month_of_birth, year_of_birth);

			if (!isValidDate)
			{
				Console.WriteLine("Неверная дата. Пожалуйста, попробуйте снова.");
			}

		} 
        while (!isValidDate);

		DateTime dateOfBirth = new DateTime(year_of_birth, month_of_birth, day_of_birth); // сбор введенных данных в дату

		Console.WriteLine();

		Console.WriteLine("Твоя дата рождения: " + dateOfBirth.ToString("dd-MM-yyyy"));// преобразование в строку

		return dateOfBirth;
	}
	public static bool IsValidDate(int day, int month, int year)
	{
		if (month == 2)
		{
			if (DateTime.IsLeapYear(year))
			{
				return day <= 29;
			}
			return day <= 28;
		}

		if (month == 4 || month == 6 || month == 9 || month == 11)
		{
			return day <= 30;
		}

		return day <= 31;
	}
	static (string, string, string, string) GetRandomValues(List<string> list1, List<string> list2, List<string> list3, List<string> list4)
	{
		Random random = new Random();

		string value1 = list1[random.Next(list1.Count)];
		string value2 = list2[random.Next(list2.Count)];
		string value3 = list3[random.Next(list3.Count)];
		string value4 = list4[random.Next(list4.Count)];

		return (value1, value2, value3, value4);
	}
}