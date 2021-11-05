using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace CodeBenchmarks
{
	public class TestCase0
	{
		private List<int> _numbers;

		[Params(100, 1000, 10000)]
		public int N;

		[GlobalSetup]
		public void Setup()
		{
			_numbers = new List<int>();

			for (int i = 0; i < N; i++)
			{
				_numbers.Add(i);
			}
		}

		[Benchmark]
		public int ForLoop()
		{
			int sum = 0;
			
			for (int i = 0; i < _numbers.Count; i++)
			{
				sum += _numbers[i];
			}

			return sum;
		}

		[Benchmark]
		public int ForeachLoop()
		{
			int sum = 0;

			foreach (int number in _numbers)
			{
				sum += number;
			}

			return sum;
		}

		[Benchmark]
		public int WhileLoop()
		{
			int sum = 0;
			int i = 0;

			while (i < _numbers.Count)
			{
				sum += _numbers[i++];
			}

			return sum;
		}

		[Benchmark]
		public int ListForeachLoop()
		{
			int sum = 0;
			
			_numbers.ForEach(x=>sum+=x);

			return sum;
		}
	}
}