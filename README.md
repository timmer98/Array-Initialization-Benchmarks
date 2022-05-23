# Benchmarks array initialization in C#
This project shows simple benchmarks for different ways to initialize arrays with a constant value. I concentrated on the standard way by looping over the array and setting the value in comparison to using `Enumberable.Repeat(...)`. To get an insight about the performance downfalls we compare those methods against the standard initialization (with the default value). To benchmark scaling effects arrays with a size of 500.000 and 1.000.000 elements are tested.

## Initializing a boolean array
While it is probably not the best idea to initialize a large boolean array with true instead of false in a performance critical environment here are the result of the benchmark.

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT


```
|           Method | ArraySize |       Mean |     Error |    StdDev |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|----------------- |---------- |-----------:|----------:|----------:|---------:|---------:|---------:|----------:|
|         **OnlyInit** |    **500000** |   **9.928 μs** | **0.1491 μs** | **0.1322 μs** | **142.8528** | **142.8528** | **142.8528** |    **488 KB** |
|         LoopInit |    500000 | 241.319 μs | 0.8288 μs | 0.7753 μs | 142.8223 | 142.8223 | 142.8223 |    488 KB |
| EnumerableRepeat |    500000 | 139.600 μs | 0.3225 μs | 0.2693 μs | 142.8223 | 142.8223 | 142.8223 |    488 KB |
|         **OnlyInit** |   **1000000** |  **17.363 μs** | **0.1747 μs** | **0.1634 μs** | **249.9695** | **249.9695** | **249.9695** |    **977 KB** |
|         LoopInit |   1000000 | 483.097 μs | 0.9057 μs | 0.8028 μs | 249.5117 | 249.5117 | 249.5117 |    977 KB |
| EnumerableRepeat |   1000000 | 278.215 μs | 0.7084 μs | 0.6280 μs | 249.5117 | 249.5117 | 249.5117 |    977 KB |

As you already may have guessed the result shows that both initialization methods are far slower than then just leaving the default values. Still in case of the boolean array the  `Enumerable.Repeat(...)` method is much faster than the initialization by `for` loop. The benchmark results show, that `Enumerable.Repeat(...)` takes more than 40% less time. 
