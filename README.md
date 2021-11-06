# CodeBenchmarks
Several benchmarks testing the performance of different methods of iterating different collections.

See my blog post on this topic for more information: https://stukeleyak.wordpress.com/2021/11/06/most-optimal-methods-to-perform-actions-on-a-collection-in-c/

## Benchmarks
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1288 (20H2/October2020Update)  
AMD Ryzen 5 3600X, 1 CPU, 12 logical and 6 physical cores  
.NET SDK=5.0.301  
  [Host]     : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT  [AttachedDebugger]  
  DefaultJob : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT  
  
### Test Case 0
|          Method |     N |        Mean |     Error |    StdDev |
|---------------- |------ |------------:|----------:|----------:|
|         **ForLoop** |   **100** |    **116.4 ns** |   **2.26 ns** |   **2.01 ns** |
|     ForeachLoop |   100 |    229.1 ns |   4.60 ns |   5.48 ns |
|       WhileLoop |   100 |    113.7 ns |   2.29 ns |   3.77 ns |
| ListForeachLoop |   100 |    228.7 ns |   4.04 ns |   4.96 ns |
|         **ForLoop** |  **1000** |  **1,059.6 ns** |  **17.22 ns** |  **15.27 ns** |
|     ForeachLoop |  1000 |  2,259.3 ns |  44.91 ns |  55.15 ns |
|       WhileLoop |  1000 |  1,061.8 ns |  20.61 ns |  26.80 ns |
| ListForeachLoop |  1000 |  2,106.0 ns |  40.63 ns |  74.30 ns |
|         **ForLoop** | **10000** | **10,790.7 ns** | **211.85 ns** | **442.21 ns** |
|     ForeachLoop | 10000 | 22,587.8 ns | 449.14 ns | 762.68 ns |
|       WhileLoop | 10000 | 10,903.7 ns | 212.13 ns | 275.83 ns |
| ListForeachLoop | 10000 | 20,616.0 ns | 411.96 ns | 688.29 ns |

### Test Case 1
|          Method |     N |         Mean |       Error |      StdDev |
|---------------- |------ |-------------:|------------:|------------:|
|         **ForLoop** |   **100** |     **146.2 ns** |     **2.79 ns** |     **2.61 ns** |
|     ForeachLoop |   100 |     428.8 ns |     8.45 ns |    11.85 ns |
|       WhileLoop |   100 |     148.3 ns |     2.96 ns |     3.53 ns |
| ListForeachLoop |   100 |     240.8 ns |     4.83 ns |     5.94 ns |
|   LinqSelectSum |   100 |   1,149.6 ns |    23.01 ns |    30.72 ns |
|         **ForLoop** |  **1000** |   **1,415.3 ns** |    **27.56 ns** |    **41.25 ns** |
|     ForeachLoop |  1000 |   4,132.4 ns |    82.22 ns |   106.91 ns |
|       WhileLoop |  1000 |   1,470.8 ns |    29.07 ns |    63.20 ns |
| ListForeachLoop |  1000 |   2,293.1 ns |    45.79 ns |    80.19 ns |
|   LinqSelectSum |  1000 |  11,372.9 ns |   225.30 ns |   556.89 ns |
|         **ForLoop** | **10000** |  **13,956.1 ns** |   **266.91 ns** |   **236.61 ns** |
|     ForeachLoop | 10000 |  41,255.0 ns |   795.60 ns |   851.28 ns |
|       WhileLoop | 10000 |  14,627.7 ns |   292.05 ns |   347.66 ns |
| ListForeachLoop | 10000 |  22,496.6 ns |   448.30 ns |   697.95 ns |
|   LinqSelectSum | 10000 | 108,693.4 ns | 2,095.96 ns | 3,005.96 ns |

### Test Case 2
|          Method |     N |       Mean |     Error |    StdDev |
|---------------- |------ |-----------:|----------:|----------:|
|         **ForLoop** |   **100** |   **1.625 μs** | **0.0322 μs** | **0.0520 μs** |
|     ForeachLoop |   100 |   1.821 μs | 0.0357 μs | 0.0652 μs |
|       WhileLoop |   100 |   1.615 μs | 0.0318 μs | 0.0466 μs |
| ListForeachLoop |   100 |   1.908 μs | 0.0376 μs | 0.0526 μs |
|         **ForLoop** |  **1000** |  **15.920 μs** | **0.3027 μs** | **0.3486 μs** |
|     ForeachLoop |  1000 |  17.389 μs | 0.3364 μs | 0.5035 μs |
|       WhileLoop |  1000 |  15.260 μs | 0.3049 μs | 0.4274 μs |
| ListForeachLoop |  1000 |  19.081 μs | 0.3724 μs | 0.6119 μs |
|         **ForLoop** | **10000** | **157.794 μs** | **3.1168 μs** | **6.2247 μs** |
|     ForeachLoop | 10000 | 189.955 μs | 3.7830 μs | 7.1055 μs |
|       WhileLoop | 10000 | 161.149 μs | 3.0990 μs | 3.4445 μs |
| ListForeachLoop | 10000 | 187.175 μs | 3.6184 μs | 4.1669 μs |

### Test Case 3
|          Method |     N |        Mean |       Error |      StdDev |
|---------------- |------ |------------:|------------:|------------:|
|      **LinqSelect** |   **100** |    **363.4 ns** |     **7.31 ns** |    **19.26 ns** |
|         ForLoop |   100 |    459.1 ns |     9.16 ns |    20.86 ns |
|     ForeachLoop |   100 |    683.1 ns |    13.23 ns |    17.20 ns |
|       WhileLoop |   100 |    451.6 ns |     8.81 ns |    12.06 ns |
| ListForeachLoop |   100 |    686.3 ns |     8.13 ns |     6.79 ns |
|      **LinqSelect** |  **1000** |  **3,259.2 ns** |    **57.01 ns** |    **53.32 ns** |
|         ForLoop |  1000 |  3,436.0 ns |    67.95 ns |   135.71 ns |
|     ForeachLoop |  1000 |  5,321.1 ns |   106.04 ns |   161.93 ns |
|       WhileLoop |  1000 |  3,330.0 ns |    65.22 ns |    69.78 ns |
| ListForeachLoop |  1000 |  5,731.7 ns |    25.79 ns |    21.53 ns |
|      **LinqSelect** | **10000** | **31,551.0 ns** |   **519.70 ns** |   **638.24 ns** |
|         ForLoop | 10000 | 36,029.5 ns |   717.81 ns | 1,545.17 ns |
|     ForeachLoop | 10000 | 60,127.5 ns |   881.20 ns |   687.98 ns |
|       WhileLoop | 10000 | 35,637.4 ns |   709.30 ns | 1,104.29 ns |
| ListForeachLoop | 10000 | 44,316.6 ns | 1,136.92 ns | 3,352.25 ns |

### Test Case 4
|                 Method |    N |      Mean |     Error |    StdDev |
|----------------------- |----- |----------:|----------:|----------:|
|            ForLoopList | 1000 |  1.389 μs | 0.0275 μs | 0.0715 μs |
|           ForLoopIList | 1000 |  4.140 μs | 0.0783 μs | 0.0769 μs |
|     ForLoopICollection | 1000 | 11.695 μs | 0.2311 μs | 0.3239 μs |
|     ForLoopIEnumerable | 1000 | 14.629 μs | 0.2835 μs | 0.3375 μs |
|        ForeachLoopList | 1000 |  3.954 μs | 0.0655 μs | 0.0581 μs |
|       ForeachLoopIList | 1000 |  8.810 μs | 0.1549 μs | 0.2672 μs |
| ForeachLoopICollection | 1000 |  8.869 μs | 0.1473 μs | 0.1150 μs |
| ForeachLoopIEnumerable | 1000 |  9.140 μs | 0.1574 μs | 0.1396 μs |
