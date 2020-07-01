using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lev_labs.Lab1
{
	static class Task4_1
	{
		static void Funci(double[] input_mas, out int zero_counter, out double sum, out double[] sorted_mas)
		{
			//Arrays. Of rank 1
			//TODO name
			var len = input_mas.Length;
			zero_counter = 0;
			int index_of_min_el = 0;
			sum = 0;
			for (int i = 0; i < len; i++)
			{
				if (input_mas[i] == 0) zero_counter++;
				if (input_mas[i] < input_mas[index_of_min_el]) index_of_min_el = i;
			}
			for (int i = index_of_min_el + 1; i < len; i++)
			{
				sum += input_mas[i];
			}
			for (int i = 0; i < len; i++)
			{
				for (int j = i; j < len; j++)
				{
					if (Math.Abs(input_mas[i]) > Math.Abs(input_mas[j]))
					{
						double tmp = input_mas[i];
						input_mas[i] = input_mas[j];
						input_mas[j] = tmp;
					}
				}
			}
			sorted_mas = input_mas;
		}
		internal static void Run()
		{
			Console.WriteLine("[x0, x1 ... xN]");
			UT.UserInput.EnterInteger("N", out int n);
			double[] mas = new double[n];
			for (int i = 0; i < n; i++)
			{
				UT.UserInput.EnterDouble("x"+i.ToString(), out mas[i]);
			}
			Funci(mas, out int zero_counter, out double sum, out double[] sorted_mas);
			Console.WriteLine("Zero elements: {0}", zero_counter);
			Console.WriteLine("Sum of elements resided after minimum element: {0}", sum);
			Console.WriteLine("Sord array by ascending modulo of the elements");
			for (int i = 0; i < sorted_mas.Length; i++)
			{
				Console.Write("{0} ", sorted_mas[i]);
			}

		}
	}
	class Task4_2
	{
		static void Funci(double[][] input_mas, out int rows_with_zeros, out int index_col_with_max_duplicates)
		{
			//Arrays. Of rank 2
			//TODO name
			bool has_zero(double[] row)
			{
				foreach (var i in row) if (i == 0) return true;
				return false;
			}
			int count_max_duplicates(double[] col)
			{
				int max = (col.Length == 0) ? 0 : 1;
				int now = max;
				for (int i = 1; i < col.Length; i++)
				{
					if (col[i] != col[i - 1]) { now = 1; }
					else { now++; if (now > max) max = now; }
				}
				return max;
			}

			rows_with_zeros = 0;
			index_col_with_max_duplicates = 0;
			if (input_mas.Length == 0) return;
			int rows = input_mas.Length;
			int columns = input_mas[0].Length;
			for (int i = 0; i < rows; i++)
			{
				if (has_zero(input_mas[i])) rows_with_zeros++;
			}
			double[] tmp = new double[rows];
			int[] max_dup_for_index_of_col = new int[columns];
			for (int num_of_col = 0; num_of_col < columns; num_of_col++)
			{
				for (int num_of_row = 0; num_of_row < rows; num_of_row++)
				{
					tmp[num_of_row] = input_mas[num_of_row][num_of_col];
				}
				max_dup_for_index_of_col[num_of_col] = count_max_duplicates(tmp);
				if (max_dup_for_index_of_col[num_of_col] > max_dup_for_index_of_col[index_col_with_max_duplicates]) index_col_with_max_duplicates = num_of_col;
			}
		}
		internal static void Run()
		{
			Console.WriteLine("[x0, x1 ... xN]");
			UT.UserInput.EnterInteger("columns", out int n);
			UT.UserInput.EnterInteger("rows", out int m);
			double[][] mas = new double[m][];
			for (int i = 0; i < m; i++)
			{
				mas[i] = new double[n];
			}

			for (int i = 0; i < m; i++)
			{
				for (int j = 0; j < n; j++) {

					UT.UserInput.EnterDouble("x[" + i.ToString() + "][" + j.ToString() + "]", out mas[i][j]);
				}
			}
			Funci(mas, out int rows_with_zeros, out int index_col_with_max_duplicates);
			Console.WriteLine("Rows having at least one zero element: {0}", rows_with_zeros);
			Console.WriteLine("Number of column having the longest sequence of identical elements: {0}", index_col_with_max_duplicates);
			}
	}
}
