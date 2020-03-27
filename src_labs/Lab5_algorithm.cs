using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP1.src_labs.Lab5
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
			Real = Re;
			Imaginary = Im;
		}
		
		public Complex Computing(Complex a, Complex b) {
			return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
		}
		public Complex Difference(Complex a, Complex b) {
			return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
		}
		public Complex Product(Complex a, Complex b) {
			return new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);
		}
		public double Module(Complex a) {
			return Math.Sqrt(a.Real * a.Real + a.Imaginary * a.Imaginary);
		}
		public override string ToString() {
			return Real.ToString() + " + " + Imaginary.ToString() + "i";
		}

		public static Complex operator +(Complex a, Complex b) => new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
		public static Complex operator -(Complex a, Complex b) => new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
		public static Complex operator *(Complex a, Complex b) => new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);

	}
}
