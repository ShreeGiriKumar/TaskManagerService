# TaskManager.PerfTest.TaskManagerPerfTester+AddTask_Throughput_IterationMode
_16-08-2018 16:41:54_
### System Info
```ini
NBench=NBench, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
OS=Microsoft Windows NT 6.2.9200.0
ProcessorCount=3
CLR=4.0.30319.42000,IsMono=False,MaxGcGeneration=2
```

### NBench Settings
```ini
RunMode=Throughput, TestMode=Test
SkipWarmups=True
NumberOfIterations=5, MaximumRunTime=00:00:01
Concurrent=False
Tracing=False
```

## Data
-------------------

### Totals
|          Metric |           Units |             Max |         Average |             Min |          StdDev |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |        2,465.00 |        2,002.40 |        1,713.00 |          309.92 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |        1,000.12 |          999.93 |          999.78 |            0.12 |

### Raw Data
#### Elapsed Time
|           Run # |              ms |          ms / s |         ns / ms |
|---------------- |---------------- |---------------- |---------------- |
|               1 |        1,713.00 |          999.78 |    10,00,216.40 |
|               2 |        1,751.00 |          999.93 |    10,00,066.19 |
|               3 |        1,941.00 |        1,000.12 |     9,99,875.73 |
|               4 |        2,142.00 |          999.88 |    10,00,116.11 |
|               5 |        2,465.00 |          999.93 |    10,00,072.01 |


## Benchmark Assertions

* [PASS] Expected Elapsed Time to must be between 1,000.00 and 10,000.00 ms; actual value was 2,002.40 ms.

