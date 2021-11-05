using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace CodeBenchmarks
{
	public class C
	{
		public float FloatingPoint { get; set; }

		public C(float floatingPoint)
		{
			FloatingPoint = floatingPoint;
		}
	}
	
	public class TestCase3
	{
		private List<C> _floatingNumbers;
		
		[Params(100, 1000, 10000)]
		public int N;

		[GlobalSetup]
		public void Setup()
		{
			_floatingNumbers = new List<C>();

			for (int i = 0; i < N; i++)
			{
				_floatingNumbers.Add(new C(i + 0.1f));
			}
		}

		[Benchmark]
		public List<float> LinqSelect()
		{
			var floats = _floatingNumbers.Select(x => x.FloatingPoint);

			return floats.ToList();
		}

		[Benchmark]
		public List<float> ForLoop()
		{
			var floats = new List<float>();
			
			for (int i = 0; i < _floatingNumbers.Count; i++)
			{
				floats.Add(_floatingNumbers[i].FloatingPoint);
			}

			return floats;
		}

		[Benchmark]
		public List<float> ForeachLoop()
		{
			var floats = new List<float>();

			foreach (var number in _floatingNumbers)
			{
				floats.Add(number.FloatingPoint);
			}

			return floats;
		}

		[Benchmark]
		public List<float> WhileLoop()
		{
			var floats = new List<float>();
			int i = 0;
			
			while (i < _floatingNumbers.Count)
			{
				floats.Add(_floatingNumbers[i++].FloatingPoint);
			}

			return floats;
		}

		[Benchmark]
		public List<float> ListForeachLoop()
		{
			var floats = new List<float>();
			
			_floatingNumbers.ForEach(x=>floats.Add(x.FloatingPoint));

			return floats;
		}
	}
}