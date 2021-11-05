using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace CodeBenchmarks
{
	public class A
	{
		public int DoStuff(int a, B b)
		{
			int second = int.Parse(b.NumberString);
			int sum = a + second;
			
			return sum;
		}
	}

	public class B
	{
		public string NumberString { get; set; }

		public B(string numberString)
		{
			NumberString = numberString;
		}
	}
	
	public class TestCase2
	{
		private List<A> _objects;
		
		[Params(100, 1000, 10000)]
		public int N;

		[GlobalSetup]
		public void Setup()
		{
			_objects = new List<A>();

			for (int i = 0; i < N; i++)
			{
				_objects.Add(new A());
			}
		}

		[Benchmark]
		public int ForLoop()
		{
			int sum = 0;
			
			for (int i = 0; i < _objects.Count; i++)
			{
				sum += _objects[i].DoStuff(i, new B("10"));
			}

			return sum;
		}

		[Benchmark]
		public int ForeachLoop()
		{
			int sum = 0;
			int i = 0;

			foreach (var number in _objects)
			{
				sum += number.DoStuff(i++, new B("10"));
			}

			return sum;
		}

		[Benchmark]
		public int WhileLoop()
		{
			int sum = 0;
			int i = 0;

			while (i < _objects.Count)
			{
				sum += _objects[i].DoStuff(i++, new B("10"));
			}

			return sum;
		}

		[Benchmark]
		public int ListForeachLoop()
		{
			int sum = 0;
			int i = 0;
			
			_objects.ForEach(x=>sum+=x.DoStuff(i++, new B("10")));

			return sum;
		}
	}
}