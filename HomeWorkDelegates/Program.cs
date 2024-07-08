using static HomeWorkDelegates.Stopwatch;

namespace HomeWorkDelegates
{
	public class Program
	{
		public delegate int Operation(int x, int y);

		public delegate T GenericDelegate<K, T>(K val);
		static void Main(string[] args)
		{
			//Generic int
			GenericDelegate<int, int> squareDelegate = Square;
			int result1 = squareDelegate(5);
			Console.WriteLine($"Квадрат 5: {result1}");

			//Generic string
			GenericDelegate<string, int> stringLengthDelegate = GetStringLength;
			int result2 = stringLengthDelegate("Hello");
			Console.WriteLine($"Длина строки 'Hello': {result2}");
			Console.WriteLine();


			//объединение делегатов
			Console.WriteLine("объединение делегатов");
			Message mes1 = Hello;
			Message mes2 = HowAreYou;
			Message mes3 = mes1 + mes2;
			mes3();
			Console.WriteLine();


			//вызов делегата в методе
			Console.WriteLine("вызов делегата в методе");
			ShowOperation("sum", 1,2, Sum);
			ShowOperation("minus", 5, 2, Minus);

			Console.WriteLine();
			Operation operation = Sum;
			int result = operation(1, 2);
			Console.WriteLine($"Sum: {result}");
			operation += Minus;//добавили к делегату ещё один метод
			result = operation(5, 4);
			Console.WriteLine($"Minus: {result}");


			Thread.Sleep(10000);
			Console.Clear();

			Stopwatch stopwatch = new();
			stopwatch.TimeChangeHandler = ShowTime;
			stopwatch.Start();
			
		}
		// Метод, соответствующий делегату (возводит число в квадрат)
		public static int Square(int x)
		{
			return x * x;
		}

		// Метод, соответствующий делегату (возвращает длину строки)
		public static int GetStringLength(string str)
		{
			return str.Length;
		}
		public static void Hello() => Console.WriteLine("Hello");
		public static void HowAreYou() => Console.WriteLine("How are you?");
		public static void ShowTime(int time)
		{
			Console.WriteLine(time);
		}
		public static void ShowOperation(string operation,int a, int b, Operation op)
		{
			Console.WriteLine($"{operation}: { op(a, b)}");
		}

		public static int Sum(int x,int y)
		{
			return x + y;
		}

		public static int Minus(int x, int y)
		{
			return x - y;
		}

		
	}
}