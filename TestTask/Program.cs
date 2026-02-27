using System;
using System.Collections.Generic;
using TestTask.Enums;
using TestTask.Helpers;
using TestTask.Streams;
using TestTask.Streams.Interfaces;
using TestTask.Structs;

namespace TestTask
{
	public class Program
	{
		/// <summary>
		/// Программа принимает на входе 2 пути до файлов.
		/// Анализирует в первом файле кол-во вхождений каждой буквы (регистрозависимо). Например А, б, Б, Г и т.д.
		/// Анализирует во втором файле кол-во вхождений парных букв (не регистрозависимо). Например АА, Оо, еЕ, тт и т.д.
		/// По окончанию работы - выводит данную статистику на экран.
		/// </summary>
		/// <param name="args">Первый параметр - путь до первого файла.
		/// Второй параметр - путь до второго файла.</param>
		private static void Main(string[] args)
		{
			try
			{
				if (args.Length != 2)
				{
					throw new ArgumentException("Входных аргументов должно быть два ", nameof(args));
				}

				Dictionary<char, LetterStats> singleLetterStats = null;
				Dictionary<char, LetterStats> doubleLetterStats = null;

				using (IReadOnlyStream inputStream1 = new ReadOnlyStream(args[0]))
				{
					singleLetterStats = FillLetterStatsHelper.FillSingleLetterStats(inputStream1);
				}
				using (IReadOnlyStream inputStream2 = new ReadOnlyStream(args[1]))
				{
					doubleLetterStats = FillLetterStatsHelper.FillDoubleLetterStats(inputStream2);
				}

				//RemoveCharStatsByType(singleLetterStats, CharType.Vowel);
				//RemoveCharStatsByType(doubleLetterStats, CharType.Consonants);

				//PrintStatistic(singleLetterStats);
				//PrintStatistic(doubleLetterStats);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.ReadKey();
			}
		}

		/// <summary>
		/// Ф-ция перебирает все найденные буквы/парные буквы, содержащие в себе только гласные или согласные буквы.
		/// (Тип букв для перебора определяется параметром charType)
		/// Все найденные буквы/пары соответствующие параметру поиска - удаляются из переданной коллекции статистик.
		/// </summary>
		/// <param name="letters">Коллекция со статистиками вхождения букв/пар</param>
		/// <param name="charType">Тип букв для анализа</param>
		private static void RemoveCharStatsByType(IList<LetterStats> letters, CharType charType)
		{
			// TODO : Удалить статистику по запрошенному типу букв.
			switch (charType)
			{
				case CharType.Consonants:
					break;

				case CharType.Vowel:
					break;
			}
		}

		/// <summary>
		/// Ф-ция выводит на экран полученную статистику в формате "{Буква} : {Кол-во}"
		/// Каждая буква - с новой строки.
		/// Выводить на экран необходимо предварительно отсортировав набор по алфавиту.
		/// В конце отдельная строчка с ИТОГО, содержащая в себе общее кол-во найденных букв/пар
		/// </summary>
		/// <param name="letters">Коллекция со статистикой</param>
		private static void PrintStatistic(IEnumerable<LetterStats> letters)
		{
			// TODO : Выводить на экран статистику. Выводить предварительно отсортировав по алфавиту!
			throw new NotImplementedException();
		}
	}
}