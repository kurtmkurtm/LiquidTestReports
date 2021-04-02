# Test Run
### Run Summary

<p>
<strong>Overall Result:</strong> ❌ Fail <br />
<strong>Pass Rate:</strong> 33.33% <br />
<strong>Run Duration:</strong> 920ms <br />
<strong>Date:</strong> 2021-04-02 08:50:23 - 2021-04-02 08:51:12 <br />
<strong>Total Tests:</strong> 36 <br />
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
<td>12</td>
<td>18</td>
<td>6</td>
</tr>
<tr>
<td>33.33%</td>
<td>50%</td>
<td>16.67%</td>
</tr>
</tbody>
</table>

---

#### SampleProject.MSTest.dll
<strong>Group Result:</strong> ❌ Fail <br />
<strong>Pass Rate:</strong> 33.33% <br />
<strong>Tests:</strong> 12 <br />
<strong>Duration:</strong> 705ms <br />
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
✔️ PassingTest
</summary>
Source:
<blockquote>SampleProject.MSTest.TestServiceTests.PassingTest</blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
<tr>
<td>
<details>
<summary>
✔️ TestTheory (True)
</summary>
Source:
<blockquote>SampleProject.MSTest.TestServiceTests.TestTheory</blockquote>
</details>
</td>
<td>279ms</td>
</tr>
<tr>
<td>
<details>
<summary>
✔️ TestTheory (True)
</summary>
Source:
<blockquote>SampleProject.MSTest.TestServiceTests.TestTheory</blockquote>
</details>
</td>
<td>68ms</td>
</tr>
<tr>
<td>
<details>
<summary>
✔️ PassingTest
</summary>
Source:
<blockquote>SampleProject.MSTest.TestServiceTests.PassingTest</blockquote>
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
❌ TestThrowingException
</summary>
Source:
<blockquote>SampleProject.MSTest.TestServiceTests.TestThrowingException</blockquote>
Message:
<blockquote>Test method SampleProject.MSTest.TestServiceTests.TestThrowingException threw exception: 
System.Exception: Pretty good exception</blockquote>
Stack Trace:
<blockquote>    at SampleProject.TestService.GetException() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject\TestService.cs:line 19
   at SampleProject.MSTest.TestServiceTests.TestThrowingException() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.MSTest\TestServiceTests.cs:line 60
<blockquote>
</details>
</td>
<td>3ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ FailTest
</summary>
Source:
<blockquote>SampleProject.MSTest.TestServiceTests.FailTest</blockquote>
Message:
<blockquote>Assert.IsTrue failed. </blockquote>
Stack Trace:
<blockquote>   at SampleProject.MSTest.TestServiceTests.FailTest() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.MSTest\TestServiceTests.cs:line 71
<blockquote>
</details>
</td>
<td>1ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ TestTheory (False)
</summary>
Source:
<blockquote>SampleProject.MSTest.TestServiceTests.TestTheory</blockquote>
Message:
<blockquote>Assert.AreEqual failed. Expected:<False>. Actual:<True>. </blockquote>
Stack Trace:
<blockquote>   at SampleProject.MSTest.TestServiceTests.TestTheory(Boolean expected) in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.MSTest\TestServiceTests.cs:line 35
<blockquote>
</details>
</td>
<td>279ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ TestTheory (False)
</summary>
Source:
<blockquote>SampleProject.MSTest.TestServiceTests.TestTheory</blockquote>
Message:
<blockquote>Assert.AreEqual failed. Expected:<False>. Actual:<True>. </blockquote>
Stack Trace:
<blockquote>   at SampleProject.MSTest.TestServiceTests.TestTheory(Boolean expected) in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.MSTest\TestServiceTests.cs:line 35
<blockquote>
</details>
</td>
<td>68ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ FailTest
</summary>
Source:
<blockquote>SampleProject.MSTest.TestServiceTests.FailTest</blockquote>
Message:
<blockquote>Assert.IsTrue failed. </blockquote>
Stack Trace:
<blockquote>   at SampleProject.MSTest.TestServiceTests.FailTest() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.MSTest\TestServiceTests.cs:line 71
<blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ TestThrowingException
</summary>
Source:
<blockquote>SampleProject.MSTest.TestServiceTests.TestThrowingException</blockquote>
Message:
<blockquote>Test method SampleProject.MSTest.TestServiceTests.TestThrowingException threw exception: 
System.Exception: Pretty good exception</blockquote>
Stack Trace:
<blockquote>    at SampleProject.TestService.GetException() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject\TestService.cs:line 19
   at SampleProject.MSTest.TestServiceTests.TestThrowingException() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.MSTest\TestServiceTests.cs:line 60
<blockquote>
</details>
</td>
<td>2ms</td>
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
⚠️ SkipTest
</summary>
Source:
<blockquote>SampleProject.MSTest.TestServiceTests.SkipTest</blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
<tr>
<td>
<details>
<summary>
⚠️ SkipTest
</summary>
Source:
<blockquote>SampleProject.MSTest.TestServiceTests.SkipTest</blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
</tbody>
</table>
</details>
</details>

---

#### SampleProject.NUnit.dll
<strong>Group Result:</strong> ❌ Fail <br />
<strong>Pass Rate:</strong> 33.33% <br />
<strong>Tests:</strong> 12 <br />
<strong>Duration:</strong> 215ms <br />
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
✔️ TestTheory(True)
</summary>
Source:
<blockquote>SampleProject.NUnit.TestServiceTests.TestTheory(True)</blockquote>
</details>
</td>
<td>17ms</td>
</tr>
<tr>
<td>
<details>
<summary>
✔️ PassingTest
</summary>
Source:
<blockquote>SampleProject.NUnit.TestServiceTests.PassingTest</blockquote>
</details>
</td>
<td>2ms</td>
</tr>
<tr>
<td>
<details>
<summary>
✔️ TestTheory(True)
</summary>
Source:
<blockquote>SampleProject.NUnit.TestServiceTests.TestTheory(True)</blockquote>
</details>
</td>
<td>11ms</td>
</tr>
<tr>
<td>
<details>
<summary>
✔️ PassingTest
</summary>
Source:
<blockquote>SampleProject.NUnit.TestServiceTests.PassingTest</blockquote>
</details>
</td>
<td>1ms</td>
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
❌ TestTheory(False)
</summary>
Source:
<blockquote>SampleProject.NUnit.TestServiceTests.TestTheory(False)</blockquote>
Message:
<blockquote>  Expected: False
  But was:  True
</blockquote>
Stack Trace:
<blockquote>   at SampleProject.NUnit.TestServiceTests.TestTheory(Boolean expected) in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.NUnit\TestServiceTests.cs:line 25
<blockquote>
</details>
</td>
<td>2ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ TestThrowingException
</summary>
Source:
<blockquote>SampleProject.NUnit.TestServiceTests.TestThrowingException</blockquote>
Message:
<blockquote>System.Exception : Pretty good exception</blockquote>
Stack Trace:
<blockquote>   at SampleProject.TestService.GetException() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject\TestService.cs:line 19
   at SampleProject.NUnit.TestServiceTests.TestThrowingException() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.NUnit\TestServiceTests.cs:line 50<blockquote>
</details>
</td>
<td>6ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ FailTest
</summary>
Source:
<blockquote>SampleProject.NUnit.TestServiceTests.FailTest</blockquote>
Message:
<blockquote>  Expected: True
  But was:  False
</blockquote>
Stack Trace:
<blockquote>   at SampleProject.NUnit.TestServiceTests.FailTest() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.NUnit\TestServiceTests.cs:line 61
<blockquote>
</details>
</td>
<td>110ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ FailTest
</summary>
Source:
<blockquote>SampleProject.NUnit.TestServiceTests.FailTest</blockquote>
Message:
<blockquote>  Expected: True
  But was:  False
</blockquote>
Stack Trace:
<blockquote>   at SampleProject.NUnit.TestServiceTests.FailTest() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.NUnit\TestServiceTests.cs:line 61
<blockquote>
</details>
</td>
<td>59ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ TestThrowingException
</summary>
Source:
<blockquote>SampleProject.NUnit.TestServiceTests.TestThrowingException</blockquote>
Message:
<blockquote>System.Exception : Pretty good exception</blockquote>
Stack Trace:
<blockquote>   at SampleProject.TestService.GetException() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject\TestService.cs:line 19
   at SampleProject.NUnit.TestServiceTests.TestThrowingException() in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.NUnit\TestServiceTests.cs:line 50<blockquote>
</details>
</td>
<td>3ms</td>
</tr>
<tr>
<td>
<details>
<summary>
❌ TestTheory(False)
</summary>
Source:
<blockquote>SampleProject.NUnit.TestServiceTests.TestTheory(False)</blockquote>
Message:
<blockquote>  Expected: False
  But was:  True
</blockquote>
Stack Trace:
<blockquote>   at SampleProject.NUnit.TestServiceTests.TestTheory(Boolean expected) in C:\Dev\LiquidTestReports\test\SampleProject\SampleProject.Tests.NUnit\TestServiceTests.cs:line 25
<blockquote>
</details>
</td>
<td>1ms</td>
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
⚠️ SkipTest
</summary>
Source:
<blockquote>SampleProject.NUnit.TestServiceTests.SkipTest</blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
<tr>
<td>
<details>
<summary>
⚠️ SkipTest
</summary>
Source:
<blockquote>SampleProject.NUnit.TestServiceTests.SkipTest</blockquote>
</details>
</td>
<td>< 1ms</td>
</tr>
</tbody>
</table>
</details>
</details>

---

#### SampleProject.xUnit.dll
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
✔️ SampleProject.xUnit.TestServiceTests.TestTheory(expected: True)
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
⚠️ SampleProject.xUnit.TestServiceTests.SkipTest
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