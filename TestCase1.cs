using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace CodeBenchmarks
{
	public class Number
	{
		public int Value { get; set; }

		public Number(int value)
		{
			Value = value;
		}
	}
	
	public class TestCase1
	{
		private List<Number> _numbers;
		
		[Params(100, 1000, 10000)]
		public int N;

		[GlobalSetup]
		public void Setup()
		{
			_numbers = new List<Number>();

			for (int i = 0; i < N; i++)
			{
				_numbers.Add(new Number(i));
			}
		}

		[Benchmark]
		public int ForLoop()
		{
			int sum = 0;
			
			for (int i = 0; i < _numbers.Count; i++)
			{
				sum += _numbers[i].Value;
			}

			return sum;
		}

		[Benchmark]
		public int ForeachLoop()
		{
			int sum = 0;

			foreach (var number in _numbers)
			{
				sum += number.Value;
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
				sum += _numbers[i++].Value;
			}

			return sum;
		}

		[Benchmark]
		public int ListForeachLoop()
		{
			int sum = 0;
			
			_numbers.ForEach(x=>sum+=x.Value);

			return sum;
		}
		
		[Benchmark]
		public int LinqSelectSum()
		{
			int sum = _numbers.Select(x => x.Value).Sum();

			return sum;
		}
	}
}