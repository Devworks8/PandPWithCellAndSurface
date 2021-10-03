using Psim.Particles;
using Psim.Geometry2D;
using Psim.ModelComponents;
using System;

namespace Psim
{
	class Program
	{
		static void Main(string[] args)
		{

			Cell c = new Cell(10, 10);

			c.AddPhonon(new Phonon(1));
			c.AddIncPhonon(new Phonon(1));

            Console.WriteLine(c);

            Console.ReadKey(true);
		}
	}
}
