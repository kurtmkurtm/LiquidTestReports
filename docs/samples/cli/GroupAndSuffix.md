# Test Run
### Run Summary

<p>
<strong>Overall Result:</strong> ❌ Fail <br />
<strong>Pass Rate:</strong> 33.33% <br />
<strong>Run Duration:</strong> < 1ms <br />
<strong>Date:</strong> 2021-04-02 08:50:23 - 2021-04-02 08:50:53 <br />
<strong>Total Tests:</strong> 12 <br />
</p>

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
<td>4</td>
<td>6</td>
<td>2</td>
</tr>
<tr>
<td>33.33%</td>
<td>50%</td>
<td>16.67%</td>
</tr>
</tbody>
</table>

---

#### Unit Tests
<strong>Group Result:</strong> ❌ Fail <br />
<strong>Pass Rate:</strong> 33.33% <br />
<strong>Tests:</strong> 12 <br />
<strong>Duration:</strong> < 1ms <br />
<details open>
<summary><strong>Results:</strong></summary>
<details>
<summary>✔️ Passed (4)</summary>
<table>
<thead>
<tr>
<th>Test</th>
<th>Duration</th>
</tr>
</thead>
<tbody>
<tr>
<td>
<details>
<summary>
✔️ SampleProject.xUnit.TestServiceTests.TestTheory(expected: True)
</summary>
Source:
<blockquote>SampleProject.xUnit.TestServiceTests.TestTheory</blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
<tr>
<td>
<details>
<summary>
✔️ SampleProject.xUnit.TestServiceTests.PassingTest
</summary>
Source:
<blockquote>SampleProject.xUnit.TestServiceTests.PassingTest</blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
<tr>
<td>
<details>
<summary>
✔️ SampleProject.xUnit.TestServiceTests.PassingTest(3.1)
</summary>
Source:
<blockquote>SampleProject.xUnit.TestServiceTests.PassingTest</blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
<tr>
<td>
<details>
<summary>
✔️ SampleProject.xUnit.TestServiceTests.TestTheory(expected: True)(3.1)
</summary>
Source:
<blockquote>SampleProject.xUnit.TestServiceTests.TestTheory</blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
</tbody>
</table>
</details>
<details>
<summary>❌ Failed (6)</summary>
<table>
<thead>
<tr>
<th>Test</th>
<th>Duration</th>
</tr>
</thead>
<tbody>
<tr>
<td>
<details>
<summary>
❌ SampleProject.xUnit.TestServiceTests.TestTheory(expected: False)
</summary>
Source:
<blockquote>SampleProject.xUnit.TestServiceTests.TestTheory</blockquote>
Message:
<blockquote>Assert.Equal() Failure
Expected: False
Actual:   True</blockquote>
Stack Trace:
<blockquote>   at SampleProject.xUnit.TestServiceTests.TestTheory(Boolean expected) in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.xUnit\TestServiceTests.cs:line 29<blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ SampleProject.xUnit.TestServiceTests.FailTest
</summary>
Source:
<blockquote>SampleProject.xUnit.TestServiceTests.FailTest</blockquote>
Message:
<blockquote>Assert.True() Failure
Expected: True
Actual:   False</blockquote>
Stack Trace:
<blockquote>   at SampleProject.xUnit.TestServiceTests.FailTest() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.xUnit\TestServiceTests.cs:line 65<blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ SampleProject.xUnit.TestServiceTests.TestThrowingException
</summary>
Source:
<blockquote>SampleProject.xUnit.TestServiceTests.TestThrowingException</blockquote>
Message:
<blockquote>System.Exception : Pretty good exception</blockquote>
Stack Trace:
<blockquote>   at SampleProject.TestService.GetException() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject\TestService.cs:line 19
   at SampleProject.xUnit.TestServiceTests.TestThrowingException() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.xUnit\TestServiceTests.cs:line 54<blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ SampleProject.xUnit.TestServiceTests.FailTest(3.1)
</summary>
Source:
<blockquote>SampleProject.xUnit.TestServiceTests.FailTest</blockquote>
Message:
<blockquote>Assert.True() Failure
Expected: True
Actual:   False</blockquote>
Stack Trace:
<blockquote>   at SampleProject.xUnit.TestServiceTests.FailTest() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.xUnit\TestServiceTests.cs:line 65<blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ SampleProject.xUnit.TestServiceTests.TestTheory(expected: False)(3.1)
</summary>
Source:
<blockquote>SampleProject.xUnit.TestServiceTests.TestTheory</blockquote>
Message:
<blockquote>Assert.Equal() Failure
Expected: False
Actual:   True</blockquote>
Stack Trace:
<blockquote>   at SampleProject.xUnit.TestServiceTests.TestTheory(Boolean expected) in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.xUnit\TestServiceTests.cs:line 29<blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ SampleProject.xUnit.TestServiceTests.TestThrowingException(3.1)
</summary>
Source:
<blockquote>SampleProject.xUnit.TestServiceTests.TestThrowingException</blockquote>
Message:
<blockquote>System.Exception : Pretty good exception</blockquote>
Stack Trace:
<blockquote>   at SampleProject.TestService.GetException() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject\TestService.cs:line 19
   at SampleProject.xUnit.TestServiceTests.TestThrowingException() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.xUnit\TestServiceTests.cs:line 54<blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
</tbody>
</table>
</details>
<details>
<summary>⚠️ Skipped (2)</summary>
<table>
<thead>
<tr>
<th>Test</th>
<th>Duration</th>
</tr>
</thead>
<tbody>
<tr>
<td>
<details>
<summary>
⚠️ SampleProject.xUnit.TestServiceTests.SkipTest
</summary>
Source:
<blockquote>SampleProject.xUnit.TestServiceTests.SkipTest</blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
<tr>
<td>
<details>
<summary>
⚠️ SampleProject.xUnit.TestServiceTests.SkipTest(3.1)
</summary>
Source:
<blockquote>SampleProject.xUnit.TestServiceTests.SkipTest</blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
</tbody>
</table>
</details>
</details>

---



[Created using Liquid Test Reports](https://github.com/kurtmkurtm/LiquidTestReports)