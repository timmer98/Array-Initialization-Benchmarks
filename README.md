# Benchmarks array initialization in C#
This project shows simple benchmarks for different ways to initialize arrays with a constant value. I concentrated on the standard way by looping over the array and setting the value in comparison to using `Enumberable.Repeat(...)`. To get an insight about the performance downfalls we compare those methods against the standard initialization (with the default value). To benchmark scaling effects arrays with a size of 500.000 and 1.000.000 elements are tested.

The following hardware and software configuration was used during the benchmarks:

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT


```

## Initializing a boolean array
While it is probably not the best idea to initialize a large boolean array with true instead of false in a performance critical environment here are the result of the benchmark.

|           Method | ArraySize |       Mean |     Error |    StdDev |
|----------------- |---------- |-----------:|----------:|----------:|
|         **OnlyInit** |    **500000** |   **9.928 μs** | **0.1491 μs** | **0.1322 μs** |
|         LoopInit |    500000 | 241.319 μs | 0.8288 μs | 0.7753 μs |
| EnumerableRepeat |    500000 | 139.600 μs | 0.3225 μs | 0.2693 μs |
|         **OnlyInit** |   **1000000** |  **17.363 μs** | **0.1747 μs** | **0.1634 μs** |
|         LoopInit |   1000000 | 483.097 μs | 0.9057 μs | 0.8028 μs |
| EnumerableRepeat |   1000000 | 278.215 μs | 0.7084 μs | 0.6280 μs | 

As you already may have guessed the result shows that both initialization methods are far slower than then just leaving the default values. Still in case of the boolean array the  `Enumerable.Repeat(...)` method is much faster than the initialization by `for` loop. The benchmark results show, that `Enumerable.Repeat(...)` takes more than 40% less time. 

## Initializing an integer array
The following table shows the measurements for the initialization of an integer array with a specific value. The software versions, platform etc. were the same as the above mentioned.

|           Method | ArraySize |        Mean |     Error |    StdDev |
|----------------- |---------- |------------:|----------:|----------:|
|         **OnlyInit** |    **500000** |    **32.52 μs** |  **0.504 μs** |  **0.447 μs** |
|         LoopInit |    500000 |   595.06 μs |  9.491 μs |  8.878 μs |
| EnumerableRepeat |    500000 |   546.58 μs |  9.259 μs |  8.661 μs |
|         **OnlyInit** |   **1000000** |    **63.49 μs** |  **0.915 μs** |  **0.855 μs** |
|         LoopInit |   1000000 | 1,196.73 μs | 16.099 μs | 15.059 μs |
| EnumerableRepeat |   1000000 | 1,082.61 μs | 18.495 μs | 17.300 μs |

As you can see also for integer the `Enumerable.Repeat(...)` method appears to be faster. This time the performance benefit is much less than in the boolean case above, but it is still around 10 - 15 % faster than the for loop.