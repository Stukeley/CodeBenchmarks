using System;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace CodeBenchmarks
{
	public class Program
	{
		public static void Main()
		{
			var exporter = new CsvExporter(
				CsvSeparator.CurrentCulture,
				new SummaryStyle(
					cultureInfo: System.Globalization.CultureInfo.CurrentCulture,
					printUnitsInHeader: true,
					printUnitsInContent: false,
					timeUnit: Perfolizer.Horology.TimeUnit.Microsecond,
					sizeUnit: SizeUnit.KB
				));
			
			var config = ManualConfig.CreateMinimumViable().AddExporter(exporter);

			// [TestCase 0]
			var summaryCase0 = BenchmarkRunner.Run(typeof(TestCase0).Assembly);

			// [TestCase 1]
			var summaryCase1 = BenchmarkRunner.Run(typeof(TestCase1).Assembly);

			// [TestCase 2]
			var summaryCase2 = BenchmarkRunner.Run(typeof(TestCase2).Assembly);
			
			// [TestCase 3]
			var summaryCase3 = BenchmarkRunner.Run(typeof(TestCase3).Assembly);
			
			// [TestCase 4]
			var summaryCase4 = BenchmarkRunner.Run(typeof(TestCase4).Assembly);
		}
	}
}