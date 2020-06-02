
# Test Run
### Run Summary
**Overall Result:** ❌ Fail
**Pass Rate:** 33.33%
**Run Duration:** 2s 667ms
**Date:** 2020-06-03 07:59:50 - 2020-06-03 07:59:52
**Framework:** .NETCoreApp,Version=v3.1
**Total Tests:** 6
<table>
<thead>
<tr>
<th>✔️ Passed</th>
<th>❌ Failed</th>
<th>⚠️ Skipped</th>
</tr>
</thead>
<tbody>
<tr>
<td>2</td>
<td>3</td>
<td>1</td>
</tr>
<tr>
<td>33.33%</td>
<td>50%</td>
<td>16.67%</td>
</tr>
</tbody>
</table>

### Result Sets
#### SampleProject.xUnit.dll - 33.33%
<details>
<summary>Full Results</summary>
<table>
<thead>
<tr>
<th>Result</th>
<th>Test</th>
<th>Duration</th>
</tr>
</thead>
<tr>
<td> ✔️ Passed </td>
<td>SampleProject.xUnit.TestServiceTests.TestTheory(expected: True)</td>
<td>9ms</td>
</tr>
<tr>
<td> ❌ Failed </td>
<td>SampleProject.xUnit.TestServiceTests.TestTheory(expected: False)<blockquote><details>
<summary>Error Message</summary>
<pre><code>Assert.Equal() Failure
Expected: False
Actual:   True</code></pre>
</details></blockquote>
</td>
<td>7ms</td>
</tr>
<tr>
<td> ⚠️ Skipped </td>
<td>SampleProject.xUnit.TestServiceTests.SkipTest</td>
<td>1ms</td>
</tr>
<tr>
<td> ❌ Failed </td>
<td>SampleProject.xUnit.TestServiceTests.TestThrowingException<blockquote><details>
<summary>Error Message</summary>
<pre><code>System.Exception : Pretty good exception</code></pre>
</details></blockquote>
</td>
<td>< 1ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>SampleProject.xUnit.TestServiceTests.PassingTest</td>
<td>< 1ms</td>
</tr>
<tr>
<td> ❌ Failed </td>
<td>SampleProject.xUnit.TestServiceTests.FailTest<blockquote><details>
<summary>Error Message</summary>
<pre><code>Assert.True() Failure
Expected: True
Actual:   False</code></pre>
</details></blockquote>
</td>
<td>< 1ms</td>
</tr>
</tbody>
</table>
</details>

### Run Messages
<details>
<summary>Informational</summary>
<pre><code>
[xUnit.net 00:00:00.00] xUnit.net VSTest Adapter v2.4.1 (64-bit .NET Core 3.1.3)
[xUnit.net 00:00:00.89]   Discovering: SampleProject.xUnit
[xUnit.net 00:00:00.97]   Discovered:  SampleProject.xUnit
[xUnit.net 00:00:00.98]   Starting:    SampleProject.xUnit
[xUnit.net 00:00:01.13]       Assert.Equal() Failure
[xUnit.net 00:00:01.13]       Expected: False
[xUnit.net 00:00:01.13]       Actual:   True
[xUnit.net 00:00:01.13]       Stack Trace:
[xUnit.net 00:00:01.13]         C:\github\LiquidTestReports\test\SampleProject\SampleProject.Tests.xUnit\TestServiceTests.cs(29,0): at SampleProject.xUnit.TestServiceTests.TestTheory(Boolean expected)
[xUnit.net 00:00:01.13]       Output:
[xUnit.net 00:00:01.14]         Running SampleProject.Tests.xUnit tests
[xUnit.net 00:00:01.14]       Skipped
[xUnit.net 00:00:01.14]       System.Exception : Pretty good exception
[xUnit.net 00:00:01.14]       Stack Trace:
[xUnit.net 00:00:01.14]         C:\github\LiquidTestReports\test\SampleProject\SampleProject\TestService.cs(19,0): at SampleProject.TestService.GetException()
[xUnit.net 00:00:01.14]         C:\github\LiquidTestReports\test\SampleProject\SampleProject.Tests.xUnit\TestServiceTests.cs(54,0): at SampleProject.xUnit.TestServiceTests.TestThrowingException()
[xUnit.net 00:00:01.14]       Output:
[xUnit.net 00:00:01.14]         Running SampleProject.Tests.xUnit tests
[xUnit.net 00:00:01.14]       Assert.True() Failure
[xUnit.net 00:00:01.14]       Expected: True
[xUnit.net 00:00:01.14]       Actual:   False
[xUnit.net 00:00:01.14]       Stack Trace:
[xUnit.net 00:00:01.14]         C:\github\LiquidTestReports\test\SampleProject\SampleProject.Tests.xUnit\TestServiceTests.cs(65,0): at SampleProject.xUnit.TestServiceTests.FailTest()
[xUnit.net 00:00:01.14]       Output:
[xUnit.net 00:00:01.14]         Running SampleProject.Tests.xUnit tests
[xUnit.net 00:00:01.14]         This test will fail
[xUnit.net 00:00:01.15]   Finished:    SampleProject.xUnit
</code></pre>
</details>

<details>
<summary>Warning</summary>
<pre><code>
[xUnit.net 00:00:01.14]     SampleProject.xUnit.TestServiceTests.SkipTest [SKIP]
</code></pre>
</details>

<details>
<summary>Error</summary>
<pre><code>
[xUnit.net 00:00:01.13]     SampleProject.xUnit.TestServiceTests.TestTheory(expected: False) [FAIL]
[xUnit.net 00:00:01.14]     SampleProject.xUnit.TestServiceTests.TestThrowingException [FAIL]
[xUnit.net 00:00:01.14]     SampleProject.xUnit.TestServiceTests.FailTest [FAIL]
</code></pre>
</details>


----

[Created using Liquid Test Reports](https://github.com/kurtmkurtm/LiquidTestReports)