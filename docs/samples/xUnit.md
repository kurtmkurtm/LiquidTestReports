# Test Run Details
**Started:** 2020-05-10 12:29:52

**Finished:** 2020-05-10 12:29:53

**Framework**: .NETCoreApp,Version=v3.1

### Total Tests
**6**

### Pass Percentage
**33.33 %**

### Run Duration
**1s 200ms**

| Passed | Failed | Skipped |
| :------ | :------ | :------ |
|2|3|1|

## Results

### SampleProject.xUnit.dll

##### ✔️ Passed - SampleProject.xUnit.TestServiceTests.TestTheory(expected: True) - 6ms

##### ❌ Failed - SampleProject.xUnit.TestServiceTests.TestTheory(expected: False) - 4ms
 
> Assert.Equal() Failure
Expected: False
Actual:   True
##### ⚠️ Skipped - SampleProject.xUnit.TestServiceTests.SkipTest - 1ms

##### ❌ Failed - SampleProject.xUnit.TestServiceTests.TestThrowingException - < 1ms
 
> System.Exception : Pretty good exception
##### ✔️ Passed - SampleProject.xUnit.TestServiceTests.PassingTest - < 1ms

##### ❌ Failed - SampleProject.xUnit.TestServiceTests.FailTest - < 1ms
 
> Assert.True() Failure
Expected: True
Actual:   False

----
## Run Messages
### Informational 
> Informational - [xUnit.net 00:00:00.00] xUnit.net VSTest Adapter v2.4.1 (64-bit .NET Core 3.1.3)
Informational - [xUnit.net 00:00:00.34]   Discovering: SampleProject.xUnit
Informational - [xUnit.net 00:00:00.42]   Discovered:  SampleProject.xUnit
Informational - [xUnit.net 00:00:00.42]   Starting:    SampleProject.xUnit
Informational - [xUnit.net 00:00:00.53]       Assert.Equal() Failure
Informational - [xUnit.net 00:00:00.53]       Expected: False
Informational - [xUnit.net 00:00:00.53]       Actual:   True
Informational - [xUnit.net 00:00:00.53]       Stack Trace:
Informational - [xUnit.net 00:00:00.53]         C:\Users\kurt\source\repos\github\LiquidTestReports\test\SampleProject\SampleProject.Tests.xUnit\TestServiceTests.cs(29,0): at SampleProject.xUnit.TestServiceTests.TestTheory(Boolean expected)
Informational - [xUnit.net 00:00:00.53]       Output:
Informational - [xUnit.net 00:00:00.53]         Running SampleProject.Tests.xUnit tests
Informational - [xUnit.net 00:00:00.53]       Skipped
Informational - [xUnit.net 00:00:00.53]       System.Exception : Pretty good exception
Informational - [xUnit.net 00:00:00.53]       Stack Trace:
Informational - [xUnit.net 00:00:00.53]         C:\Users\kurt\source\repos\github\LiquidTestReports\test\SampleProject\SampleProject\TestService.cs(19,0): at SampleProject.TestService.GetException()
Informational - [xUnit.net 00:00:00.53]         C:\Users\kurt\source\repos\github\LiquidTestReports\test\SampleProject\SampleProject.Tests.xUnit\TestServiceTests.cs(54,0): at SampleProject.xUnit.TestServiceTests.TestThrowingException()
Informational - [xUnit.net 00:00:00.53]       Output:
Informational - [xUnit.net 00:00:00.53]         Running SampleProject.Tests.xUnit tests
Informational - [xUnit.net 00:00:00.53]       Assert.True() Failure
Informational - [xUnit.net 00:00:00.53]       Expected: True
Informational - [xUnit.net 00:00:00.53]       Actual:   False
Informational - [xUnit.net 00:00:00.53]       Stack Trace:
Informational - [xUnit.net 00:00:00.53]         C:\Users\kurt\source\repos\github\LiquidTestReports\test\SampleProject\SampleProject.Tests.xUnit\TestServiceTests.cs(65,0): at SampleProject.xUnit.TestServiceTests.FailTest()
Informational - [xUnit.net 00:00:00.53]       Output:
Informational - [xUnit.net 00:00:00.53]         Running SampleProject.Tests.xUnit tests
Informational - [xUnit.net 00:00:00.53]         This test will fail
Informational - [xUnit.net 00:00:00.53]   Finished:    SampleProject.xUnit


### Warning & Error 
> Error - [xUnit.net 00:00:00.53]     SampleProject.xUnit.TestServiceTests.TestTheory(expected: False) [FAIL]
Warning - [xUnit.net 00:00:00.53]     SampleProject.xUnit.TestServiceTests.SkipTest [SKIP]
Error - [xUnit.net 00:00:00.53]     SampleProject.xUnit.TestServiceTests.TestThrowingException [FAIL]
Error - [xUnit.net 00:00:00.53]     SampleProject.xUnit.TestServiceTests.FailTest [FAIL]

----
[Created using Liquid Test Reports](https://github.com/kurtmkurtm/LiquidTestReports)