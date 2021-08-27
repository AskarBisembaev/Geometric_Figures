using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
// Задача программы: вычислить периметр и площадь геометрической фигуры
// Программа дает возможность польщователю выбрать геометрическию фигуру и ввести длины сторон
// Буква P означает периметр 
// Буква S означает площадь
// Маленькая буква после P или S означает вид фигуры
namespace Geometric_figures
{
	class Program
	{
		#region Переменные
		private static string CurFigure;
		private static double SideA;
		private static double SideB;
		private static double SideD;
		private static double SideH;
		private static double Pi = 3.14;

		#endregion
		static void Main(string[] args)
		{
			#region Начало программы

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Программа для вычисления периметра и площади разных геом. фигур\n");
			Console.ResetColor();
			Console.WriteLine("Выберите геометрическую фигуру\n");

			#endregion

			#region Выбор фигуры

			GetFigures();
			ShowFigures(CurFigure);

			#endregion

			#region Конец программы

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Нажмите лубую кнопку чтобы закрыть программу");
			Console.ReadLine();

			#endregion
		}

		#region Выбор фигуры

		/// <summary>
		/// выводит на экран информацию о фигуре которую выберет пользователь
		/// </summary>
		/// <param name="CurFigure"></param>
		private static void ShowFigures(string CurFigure)
		{
			switch (CurFigure)
			{
				case "1":
					Square();
					break;
				case "2":
					Rectangle();
					break;
				case "3":
					Triangle();
					break;
				case "4":
					Circle();
					break;
				case "5":
					Trapezoid();
					break;
				case "6":
					Parallelogram();
					break;
			}
		}

		/// <summary>
		/// функция получает строку, проверяет условие на истинность и в зависимости от результата сохраняет строку или дает пользователю заново ввести строку 
		/// </summary>
		private static void GetFigures()
		{
			Console.WriteLine("1 - Квадрат. 2 - Прямоугольник. 3 - Треугольник. 4 - Окружность. 5 - Трапеция. 6 - Параллелограмм.");
			CurFigure = Console.ReadLine();

			if (CurFigure != "1" && CurFigure != "2" && CurFigure != "3" && CurFigure != "4" && CurFigure != "5" && CurFigure != "6")
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Такой фигуры нет");
				Console.ResetColor();
				Console.WriteLine("Нажмите <Enter> чтобы продолжить");
				Console.ReadLine();
				GetFigures();
			}
		}

		#endregion

		#region Квадрат

		/// <summary>
		/// Функция дает пользователю ввести длину стороны квадрата и вичисляет периметр и площадь квадрата
		/// </summary>
		private static void Square()
		{
			Console.WriteLine("Введите длину стороны квадрата");
			SideA = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("");
			double Ps = SideA * 4; 
			double Ss = SideA * SideA;  
			Console.WriteLine($"Периметр квадрата = {Ps}");
			Console.WriteLine($"Площадь квадрата = {Ss}");
			Console.WriteLine("");
		}

		#endregion

		#region Прямоугольник

		/// <summary>
		///  Функция дает пользователю ввести длину сторон прямоугольника и вичисляет периметр и площадь прямоугольника
		/// </summary>
		private static void Rectangle()
		{
			Console.WriteLine("Введите сторону A");
			SideA = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите сторону B");
			SideB = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("");
			double Pr = (SideA + SideB) * 2; // периметр прямоугольника
			double Sr = SideA * SideB; // площадь прямоугольника
			Console.WriteLine($"Периметр прямоугольника = {Pr}");
			Console.WriteLine($"Площадь прямоугольника = {Sr}");
			Console.WriteLine("");
		}

		#endregion

		#region Треугольник

		/// <summary>
		/// функция дает пользователю выбрать вид треугольника
		/// </summary>
		private static void Triangle()
		{
			Console.WriteLine("");
			Console.WriteLine("Какой у вас треугольник?");
			Console.WriteLine("1 - Равносторонний");
			Console.WriteLine("2 - Равнобедренный");
			Console.WriteLine("3 - Разносторонний");
			string Tt = Console.ReadLine();
			if (Tt == "1")
			{
				Equilateral();
			}
			else if (Tt == "2")
			{
				Isosceles();
			}
			else if (Tt == "3")
			{
				Versatile();
			}
		}

		/// <summary>
		/// функция получает длину стороны и высоту треуголька
		/// вычисляет периметр и площадь для равностороннего треугольника
		/// </summary>
		private static void Equilateral()
		{
			Console.WriteLine("Введите длину стороны треугольника");
			SideA = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите высоту треугольника H");
			SideH = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("");
			double Pt = SideA * 3;
			double St = 0.5 * SideA * SideH;
			Console.WriteLine($"Периметр треугольника = {Pt}");
			Console.WriteLine($"Площадь треугольника = {St}");
		}

		/// <summary>
		///  функция получает длину сторон и высоту треуголька
		/// вычисляет периметр и площадь для равнобедренного треугольника
		/// </summary>
		private static void Isosceles()
		{
			Console.WriteLine("Введите длину стороны треугольника А");
			SideA = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите длину сторон треугольника В");
			SideB = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите высоту треугольника H");
			SideH = Convert.ToDouble(Console.ReadLine());
			double Pt = 2 * SideB + SideA;
			double St = 0.5 * SideA * SideH;
			Console.WriteLine($"Периметр треугольника = {Pt}");
			Console.WriteLine($"Площадь треугольника = {St}");
		}

		/// <summary>
		/// функция получает длину сторон треуголька
		/// вычисляет периметр и площадь для разностороннего треугольника
		/// </summary>
		private static void Versatile()
		{
			Console.WriteLine("Введите длину стороны треугольника А");
			SideA = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите длину сторон треугольника В");
			SideB = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите длину сторон треугольника D");
			SideD = Convert.ToDouble(Console.ReadLine());
			double Pt = SideA + SideB + SideD;
			double p = (SideA + SideB + SideD) / 2; // полупериметр
			double St = p * (p - SideA) * (p - SideB) * (p - SideD); 
			St = Math.Sqrt(St);
			Console.WriteLine($"Периметр треугольника = {Pt}");
			Console.WriteLine($"Площадь треугольника = {St}");
		}

		#endregion

		#region окружность

		/// <summary>
		/// функция получает радиус окружности и вычисляет длину и площадь окружности
		/// </summary>
		private static void Circle()
		{
			Console.WriteLine("Введите радиус R окружности");
			Console.WriteLine("Введите R");
			double r = Convert.ToDouble(Console.ReadLine());
			double Pc = 2 * Pi * r;
			double Sc = Pi * (r * 2);
			Console.WriteLine($"Длина окружности = {Pc}");
			Console.WriteLine($"Площадь окружности = {Pc}");
			Console.WriteLine("");
		}

		#endregion

		#region Трапеция

		/// <summary>
		/// функция дает пользователю выбрать способ вычисления площади трапеции
		/// </summary>
		private static void Trapezoid()
		{
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Как найти площадь?\n");
			Console.ResetColor();
			Console.WriteLine("1 - Через основание и высоту");
			Console.WriteLine("2 - Через среднюю линию и высоту");
			string TR = Console.ReadLine();
			if (TR == "1")
			{
				Trapezium_BaseAndHeight();
			}
			else if (TR == "2")
			{
				Trapezium_MidlineAndHeight();
			}
		}

		/// <summary>
		/// функция получает длину сторон и высоту трапеции 
		/// вычисляет площадь трапеции
		/// </summary>
		private static void Trapezium_BaseAndHeight()
		{
			Console.WriteLine("");
			Console.WriteLine("Введите длину основания A");
			double A = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите длину основания B");
			double B = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите длину высоты H");
			double H = Convert.ToDouble(Console.ReadLine());
			double St = 0.5 * H * (A + B);
			Console.WriteLine($"Площадь трапеции = {St}");
		}

		/// <summary>
		/// Функция получает длину средней линии и высоту
		/// вычисляет площадь трапеции
		/// </summary>
		private static void Trapezium_MidlineAndHeight()
		{
			Console.WriteLine("");
			Console.WriteLine("Введите длину средней линии");
			double M = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите длину высоты");
			double H = Convert.ToDouble(Console.ReadLine());
			double St = M * H;
			Console.WriteLine($"Площадь трапеции = {St}");

		}



		#endregion

		#region Параллелограмм

		/// <summary>
		/// функция дает пользователю выбрать способ вычисления площади параллелограмма
		/// </summary>
		/// <param name="CurA"></param>
		private static void Parallelogram()
		{
			Console.WriteLine("");
			Parallelogram_Perimeter();
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Как найти площадь?\n");
			Console.ResetColor();
			Console.WriteLine("1 - Через основание и высоту");
			Console.WriteLine("2 - Через две стороны и угол между ними");
			string TR = Console.ReadLine();
			if (TR == "1")
			{
				Parallelogram_BaseAndHeight();
			}
			else if (TR == "2")
			{
				Parallelogram_SideAndAngle();
			}

		}

		/// <summary>
		/// функция получает длину сторон параллелограмма и вычисляет периметр
		/// </summary>
		private static void Parallelogram_Perimeter()
		{
			Console.WriteLine("Введите длину стороны А");
			SideA = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите длину стороны B");
			SideB = Convert.ToDouble(Console.ReadLine());
			double Pp = 2 * (SideA + SideB);
			Console.WriteLine($"Периметр параллелограмма = {Pp}");
		}

		/// <summary>
		/// функция получает длину основания и высоты параллелограмма 
		/// вычисляет площадь
		/// </summary>
		private static void Parallelogram_BaseAndHeight()
		{
			Console.WriteLine("");
			Console.WriteLine($"Длина основания A = {SideA}");
			Console.WriteLine("Введите длину высоты H");
			double H = Convert.ToDouble(Console.ReadLine());
			double Sp = SideA * H;
			Console.WriteLine($"Площадь параллелограмма = {Sp}");
		}

		/// <summary>
		/// функция получает длину сторон и угол между сторонами
		/// вычисляет площадь
		/// </summary>
		private static void Parallelogram_SideAndAngle()
		{
			Console.WriteLine("");
			Console.WriteLine($"Длина стороны А = {SideA}");
			Console.WriteLine($"Длина стороны B = {SideB}");
			Console.WriteLine("Введите угол (a)");
			double a = Convert.ToDouble(Console.ReadLine());
			a = Math.Sin(a);
			double Sp = SideA * SideB * a;
			Console.WriteLine($"Площадь параллелограмма = {Sp}");
		}

		#endregion
	}
}

