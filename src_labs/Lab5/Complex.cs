using System;

namespace ProjectProgram.src_labs.Lab5
{
	class Complex
	{
		private double Real, Imaginary;
		public double getReal()
		{
			return Real;
		}
		public double getImaginary()
		{
			return Imaginary;
		}

		public Complex(double Re = 0, double Im = 0)
		{
			if (double.IsNaN(Re) && double.IsNaN(Im))
			{
				Real = Re;
				Imaginary = Im;
			}
			else
			{
				throw new FieldValueExeption();
			}
		}

		Complex Computing(Complex a, Complex b)
		{
			return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
		}
		Complex Difference(Complex a, Complex b)
		{
			return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
		}
		Complex Product(Complex a, Complex b)
		{
			return new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);
		}
		public double Module()
		{
			return Math.Sqrt(Real * Real + Imaginary * Imaginary);
		}
		public override string ToString()
		{
			return Real.ToString() + " + " + Imaginary.ToString() + "i";
		}

		public static Complex operator +(Complex a, Complex b) => new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
		public static Complex operator -(Complex a, Complex b) => new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
		public static Complex operator *(Complex a, Complex b) => new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);

		public class FieldValueExeption : Exception
		{
			public FieldValueExeption(string message = "Field is NaN or Infinity") : base(message) { }
		}
	}
}
