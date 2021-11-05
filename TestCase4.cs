using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace CodeBenchmarks
{
	public class TestCase4
	{
		private List<Number> _numbersList;
		private IList<Number> _numbersIList;
		private ICollection<Number> _numbersICollection;
		private IEnumerable<Number> _numbersIEnumerable;

		[Params(1000)]
		public int N;

		[GlobalSetup]
		public void Setup()
		{
			_numbersList = new List<Number>();
			_numbersIList = new List<Number>();
			_numbersICollection = new List<Number>();

			for (int i = 0; i < N; i++)
			{
				_numbersList.Add(new Number(i));
				_numbersIList.Add(new Number(i));
				_numbersICollection.Add(new Number(i));
			}
			
			_numbersIEnumerable = new List<Number>(_numbersList);
		}

		[Benchmark]
		public int ForLoopList()
		{
			int sum = 0;
			
			for (int i = 0; i < _numbersList.Count; i++)
			{
				sum += _numbersList[i].Value;
			}

			return sum;
		}

		[Benchmark]
		public int ForLoopIList()
		{
			int sum = 0;
			
			for (int i = 0; i < _numbersIList.Count; i++)
			{
				sum += _numbersIList[i].Value;
			}

			return sum;
		}

		[Benchmark]
		public int ForLoopICollection()
		{
			int sum = 0;
			
			for (int i = 0; i < _numbersICollection.Count; i++)
			{
				sum += _numbersICollection.ElementAt(i).Value;
			}

			return sum;
		}
		
		[Benchmark]
		public int ForLoopIEnumerable()
		{
			int sum = 0;
			
			for (int i = 0; i < _numbersIEnumerable.Count(); i++)
			{
				sum += _numbersIEnumerable.ElementAt(i).Value;
			}

			return sum;
		}
		
		[Benchmark]
		public int ForeachLoopList()
		{
			int sum = 0;

			foreach (var number in _numbersList)
			{
				sum += number.Value;
			}

			return sum;
		}

		[Benchmark]
		public int ForeachLoopIList()
		{
			int sum = 0;
			
			foreach (var number in _numbersIList)
			{
				sum += number.Value;
			}

			return sum;
		}

		[Benchmark]
		public int ForeachLoopICollection()
		{
			int sum = 0;
			
			foreach (var number in _numbersICollection)
			{
				sum += number.Value;
			}

			return sum;
		}
		
		[Benchmark]
		public int ForeachLoopIEnumerable()
		{
			int sum = 0;
			
			foreach (var number in _numbersIEnumerable)
			{
				sum += number.Value;
			}

			return sum;
		}
	}
}