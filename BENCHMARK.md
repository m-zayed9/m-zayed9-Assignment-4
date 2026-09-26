# Benchmark Results — `string` vs `StringBuilder`

**Runtime:** .NET 8.0.31, X64 RyuJIT AVX2
**Tool:** BenchmarkDotNet v0.14.0 with `[MemoryDiagnoser]`

## Raw Results Table

| Method                     | Iterations |                Mean |             Error |              StdDev |          Gen0 |          Gen1 |          Gen2 |      Allocated |
| -------------------------- | ---------- | ------------------: | ----------------: | ------------------: | ------------: | ------------: | ------------: | -------------: |
| StringConcatenation        | 100        |          8,901.9 ns |          70.23 ns |            58.65 ns |       39.3677 |             - |             - |      120.66 KB |
| StringBuilderConcatenation | 100        |            806.6 ns |          15.39 ns |            18.32 ns |        2.2621 |             - |             - |        6.93 KB |
| StringConcatenation        | 1000       |        825,505.0 ns |       6,695.93 ns |         5,591.40 ns |     3823.2422 |             - |             - |    11753.86 KB |
| StringBuilderConcatenation | 1000       |          5,303.8 ns |          37.44 ns |            35.02 ns |       18.1808 |             - |             - |       55.86 KB |
| StringConcatenation        | 10000      |    162,794,443.3 ns |   1,086,672.19 ns |     1,016,473.84 ns |   371500.0000 |   324500.0000 |   324500.0000 |  1172333.09 KB |
| StringBuilderConcatenation | 10000      |        189,977.4 ns |       1,034.57 ns |           967.74 ns |       71.2891 |       71.2891 |       71.2891 |      470.86 KB |
| StringConcatenation        | 100000     | 36,139,480,683.0 ns | 674,388,991.31 ns | 1,407,701,066.48 ns | 20520000.0000 | 20426000.0000 | 20426000.0000 | 117197190.2 KB |
| StringBuilderConcatenation | 100000     |      2,349,218.8 ns |      46,207.49 ns |        75,920.23 ns |      769.5313 |      750.0000 |      378.9063 |     4701.87 KB |

## Same Numbers, Easier to Read

| Iterations |     string (time) | StringBuilder (time) | string (memory) | StringBuilder (memory) |
| ---------: | ----------------: | -------------------: | --------------: | ---------------------: |
|        100 |         ~0.009 ms |           ~0.0008 ms |       120.66 KB |                6.93 KB |
|      1,000 |          ~0.83 ms |            ~0.005 ms |       ~11.75 MB |               55.86 KB |
|     10,000 |           ~163 ms |             ~0.19 ms |        ~1.12 GB |              470.86 KB |
|    100,000 | **~36.1 seconds** |             ~2.35 ms |   **~111.8 GB** |                 4.6 MB |

---

## Questions

### 1. Which was faster with 100 iterations?

`StringBuilder`.

Both are fast, but `StringBuilder` was about 11x faster in this benchmark.

### 2. Which was faster with 100,000 iterations?

`StringBuilder` by a large margin.

* `string`: ~36 seconds
* `StringBuilder`: ~2.35 ms

### 3. Which allocated more memory?

`string` concatenation.

At 100,000 iterations:

* `string`: ~111.8 GB
* `StringBuilder`: ~4.6 MB

### 4. What happens as the loop gets larger?

`string` concatenation becomes much slower as the string grows.

`StringBuilder` scales much better because it reuses its internal buffer.

### 5. Why does repeated string concatenation create more allocations?

`string` is **immutable**.

When you do:

```csharp
result += "text";
```

a new string must be created.

The process is roughly:

1. Allocate a new string.
2. Copy the existing content.
3. Add the new text.
4. The old string becomes eligible for garbage collection.

Repeating this many times creates many temporary strings.

### 6. Why does `StringBuilder` perform better?

`StringBuilder` uses a growable internal buffer.

When there is enough space, new text is added to the existing buffer instead of creating a new string every time.

It only needs to allocate a larger buffer when the current one is full.

### 7. Is `StringBuilder` always better?

No.

For a small number of concatenations, normal `string` operations are usually simpler and fast enough.
