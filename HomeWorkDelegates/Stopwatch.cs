using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HomeWorkDelegates.Program;

namespace HomeWorkDelegates
{
	public delegate void Message();
	public class Stopwatch
	{
		
		public delegate void TimeChange(int time);
		
		public TimeChange? TimeChangeHandler { get; set; } //Свойство типа TimeChange для хранения ссылки на метод

		public void Start()
		{
			int currentTime = 1;
			while (true)
			{
				Message message = ShowMessage;
				message();

				TimeChangeHandler?.Invoke(currentTime++);

				Thread.Sleep(1000);
				Console.Clear();
			}
			
		}
		public void ShowMessage()
		{
			Console.WriteLine("StopWatch:");
		}
		
	}
}
