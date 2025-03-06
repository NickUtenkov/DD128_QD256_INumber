using DD128Numeric;
using QD256Numeric;
using System;
using System.Diagnostics;
using System.Numerics;

namespace Test_INumber
{
	internal class Program
	{
		static void Main(string[] args)
		{
			testParse<DD128>(30);
			testParse<QD256>(62);
			testSqrt();
			testSin();
			testCos();
			testTan();
			testLog();
			testLog10();
			testASin();
			testACos();
			testATan();
		}

		static void testParse<T>(int nZeroes) where T : INumber<T>
		{
			T d1, d2;
			string s1, s2;

			Debug.WriteLine(string.Format("Parse {0}", typeof(T).Name));
			s1 = "1." + String.Empty.PadRight(nZeroes + 1, '0');
			d1 = T.Parse(s1, null);
			Debug.WriteLine(string.Format("{0} parsed to", s1));
			Debug.WriteLine(string.Format("{0}", d1));
			Debug.WriteLine("");

			s1 = "1." + String.Empty.PadRight(nZeroes, '0') + "1";
			s2 = "2." + String.Empty.PadRight(nZeroes, '0') + "2";

			d1 = T.Parse(s1, null);
			d2 = T.Parse(s2, null);
			Debug.WriteLine(string.Format("{0} parsed to", s1));
			Debug.WriteLine(string.Format("{0}", d1));
			Debug.WriteLine("");

			Debug.WriteLine(string.Format("{0} parsed to", s2));
			Debug.WriteLine(string.Format("{0}", d2));
			Debug.WriteLine("");

			Debug.WriteLine(string.Format("{0} subtract", d2));
			Debug.WriteLine(string.Format("{0} is", d1));
			Debug.WriteLine(string.Format("{0}", d2 - d1));
			Debug.WriteLine("");

			Debug.WriteLine(string.Format("{0} add", d2));
			Debug.WriteLine(string.Format("{0} is ", d1));
			Debug.WriteLine(string.Format("{0}", d2 + d1));
			Debug.WriteLine("");

			Debug.WriteLine(string.Format("{0} subtract", d2));
			Debug.WriteLine(string.Format("{0} subtract", d1));
			Debug.WriteLine(string.Format("1 is"));
			Debug.WriteLine(string.Format("{0}", d2 - d1 - T.One));
			Debug.WriteLine("");
		}

		static void testSqrt()
		{
			for (int i = 1; i < 10; i++)
			{
				DD128 dd = MathDD128.Sqrt(i);
				QD256 qd = MathQD256.Sqrt(i);
				Debug.WriteLine(string.Format("sqrt<DD128>({0})={1}", i, dd));
				Debug.WriteLine(string.Format("sqrt<QD256>({0})={1}", i, qd));
				Debug.WriteLine("");
			}
		}

		static void testSin()
		{
			double a, b, c;
			a = 1; b = 6; c = 2;
			Debug.WriteLine(trigStr<float>(float.Sin, (float)a, (float)b, (float)c));
			Debug.WriteLine(trigStr<double>(double.Sin, a, b, c));
			Debug.WriteLine(trigStr<DD128>(DD128.Sin, a, b, c));
			Debug.WriteLine(trigStr<QD256>(QD256.Sin, a, b, c));
			Debug.WriteLine("");

			a = 5; b = 6; c = 2;
			Debug.WriteLine(trigStr<double>(double.Sin, a, b, c));
			Debug.WriteLine(trigStr<DD128>(DD128.Sin, a, b, c));
			Debug.WriteLine(trigStr<QD256>(QD256.Sin, a, b, c));
			Debug.WriteLine("");

			a = 7; b = 6; c = 2;
			Debug.WriteLine(trigStr<double>(double.Sin, a, b, c));
			Debug.WriteLine(trigStr<DD128>(DD128.Sin, a, b, c));
			Debug.WriteLine(trigStr<QD256>(QD256.Sin, a, b, c));
			Debug.WriteLine("");

			a = 1; b = 4; c = 2;
			Debug.WriteLine(trigStr<double>(double.Sin, a, b, 2 / double.Sqrt(2)));
			Debug.WriteLine(trigStr<DD128>(DD128.Sin, a, b, 2 / DD128.Sqrt(2)));
			Debug.WriteLine(trigStr<QD256>(QD256.Sin, a, b, 2 / QD256.Sqrt(2)));
			Debug.WriteLine("");

			a = 1; b = 3; c = 2;
			Debug.WriteLine(trigStr<double>(double.Sin, a, b, 2 / double.Sqrt(3)));
			Debug.WriteLine(trigStr<DD128>(DD128.Sin, a, b, 2 / DD128.Sqrt(3)));
			Debug.WriteLine(trigStr<QD256>(QD256.Sin, a, b, 2 / QD256.Sqrt(3)));
			Debug.WriteLine("");
		}

		static void testCos()
		{
			double a, b, c;
			a = 1; b = 3; c = 2;
			Debug.WriteLine(trigStr<double>(double.Cos, a, b, c));
			Debug.WriteLine(trigStr<DD128>(DD128.Cos, a, b, c));
			Debug.WriteLine(trigStr<QD256>(QD256.Cos, a, b, c));
			Debug.WriteLine("");

			a = 5; b = 3; c = 2;
			Debug.WriteLine(trigStr<double>(double.Cos, a, b, c));
			Debug.WriteLine(trigStr<DD128>(DD128.Cos, a, b, c));
			Debug.WriteLine(trigStr<QD256>(QD256.Cos, a, b, c));
			Debug.WriteLine("");

			a = 1; b = 6;
			Debug.WriteLine(trigStr<double>(double.Cos, a, b, 2 / double.Sqrt(3)));
			Debug.WriteLine(trigStr<DD128>(DD128.Cos, a, b, 2 / DD128.Sqrt(3)));
			Debug.WriteLine(trigStr<QD256>(QD256.Cos, a, b, 2 / QD256.Sqrt(3)));
			Debug.WriteLine("");

			a = 1; b = 4;
			Debug.WriteLine(trigStr<double>(double.Cos, a, b, 2 / double.Sqrt(2)));
			Debug.WriteLine(trigStr<DD128>(DD128.Cos, a, b, 2 / DD128.Sqrt(2)));
			Debug.WriteLine(trigStr<QD256>(QD256.Cos, a, b, 2 / QD256.Sqrt(2)));
			Debug.WriteLine("");
		}

		static void testTan()
		{
			double a, b, c;
			a = 1; b = 4; c = 1;
			Debug.WriteLine(trigStr<double>(double.Tan, a, b, c));
			Debug.WriteLine(trigStr<DD128>(DD128.Tan, a, b, c));
			Debug.WriteLine(trigStr<QD256>(QD256.Tan, a, b, c));
			Debug.WriteLine("");

			a = 3; b = 4; c = 1;
			Debug.WriteLine(trigStr<double>(double.Tan, a, b, c));
			Debug.WriteLine(trigStr<DD128>(DD128.Tan, a, b, c));
			Debug.WriteLine(trigStr<QD256>(QD256.Tan, a, b, c));
			Debug.WriteLine("");

			a = 1; b = 6;
			Debug.WriteLine(trigStr<double>(double.Tan, a, b, 3 / double.Sqrt(3)));
			Debug.WriteLine(trigStr<DD128>(DD128.Tan, a, b, 3 / DD128.Sqrt(3)));
			Debug.WriteLine(trigStr<QD256>(QD256.Tan, a, b, 3 / QD256.Sqrt(3)));
			Debug.WriteLine("");

			a = 1; b = 3;
			Debug.WriteLine(trigStr<double>(double.Tan, a, b, 1 / double.Sqrt(3)));
			Debug.WriteLine(trigStr<DD128>(DD128.Tan, a, b, 1 / DD128.Sqrt(3)));
			Debug.WriteLine(trigStr<QD256>(QD256.Tan, a, b, 1 / QD256.Sqrt(3)));
			Debug.WriteLine("");
		}

		static void testASin()
		{
			double a, b, c;
			a = 1; b = 2; c = 6;
			Debug.WriteLine(atrigStr<double>(double.Asin, a, b, c));
			Debug.WriteLine(atrigStr<DD128>(DD128.Asin, a, b, c));
			Debug.WriteLine(atrigStr<QD256>(QD256.Asin, a, b, c));
			Debug.WriteLine("");
		}

		static void testACos()
		{
			double a, b, c;
			a = 1; b = 2; c = 3;
			Debug.WriteLine(atrigStr<double>(double.Acos, a, b, c));
			Debug.WriteLine(atrigStr<DD128>(DD128.Acos, a, b, c));
			Debug.WriteLine(atrigStr<QD256>(QD256.Acos, a, b, c));
			Debug.WriteLine("");
		}

		static void testATan()
		{
			double b, c;
			b = 3; c = 6;
			Debug.WriteLine(atrigStr<double>(double.Atan, double.Sqrt(3), b, c));
			Debug.WriteLine(atrigStr<DD128>(DD128.Atan, DD128.Sqrt(3), b, c));
			Debug.WriteLine(atrigStr<QD256>(QD256.Atan, QD256.Sqrt(3), b, c));
			Debug.WriteLine("");

			b = 1; c = 3;
			Debug.WriteLine(atrigStr<double>(double.Atan, double.Sqrt(3), b, c));
			Debug.WriteLine(atrigStr<DD128>(DD128.Atan, DD128.Sqrt(3), b, c));
			Debug.WriteLine(atrigStr<QD256>(QD256.Atan, QD256.Sqrt(3), b, c));
			Debug.WriteLine("");
		}

		static void testLog()
		{
			DD128 ldd = DD128.Log(DD128.E);
			QD256 lqd = QD256.Log(QD256.E);
			Debug.WriteLine(string.Format("Ln(E)     dd={0}", ldd));
			Debug.WriteLine(string.Format("Ln(E)     qd={0}", lqd));
		}

		static void testLog10()
		{
			DD128 ldd = DD128.Log10(10);
			QD256 lqd = QD256.Log10(10);
			Debug.WriteLine(string.Format("Log₁₀(10) dd={0}", ldd));
			Debug.WriteLine(string.Format("Log₁₀(10) qd={0}", lqd));
			Debug.WriteLine("");
		}

		static T trig<T>(Func<T, T> func,T a, T b, T c) where T : INumber<T>, ITrigonometricFunctions<T>
		{
			return func(a * T.Pi / b) * c;
		}

		static string trigStr<T>(Func<T, T> func, T a, T b, T c) where T : INumber<T>, ITrigonometricFunctions<T>
		{
			double da = double.CreateTruncating(a);
			double db = double.CreateTruncating(b);
			double dc = double.CreateTruncating(c);
			string strType = typeof(T).Name;
			strType = strType.PadRight(6, ' ');
			string str = string.Format("{0}<{1}>({2} * π / {3}) * {4:F7}... = {5}", func.Method.Name, strType, da, db, dc, trig<T>(func, a, b, c));
			return str;
		}

		static T atrig<T>(Func<T, T> func, T a, T b, T c) where T : INumber<T>, ITrigonometricFunctions<T>
		{
			return func(a / b) * c / T.Pi;
		}

		static string atrigStr<T>(Func<T, T> func, T a, T b, T c) where T : INumber<T>, ITrigonometricFunctions<T>
		{
			double da = double.CreateTruncating(a);
			double db = double.CreateTruncating(b);
			double dc = double.CreateTruncating(c);
			string strType = typeof(T).Name;
			strType = strType.PadRight(6, ' ');
			string str = string.Format("{0}<{1}>({2} / {3}) * {4} / π = {5}", func.Method.Name, strType, da, db, dc, atrig<T>(func, a, b, c));
			return str;
		}
	}
}
