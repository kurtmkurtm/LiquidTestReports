## Additional Cli Samples



**File glob pattern relative to current directory**

```bash
liquid --inputs "File=**/*sample.trx" --output-file report.md  
```

**File glob pattern using specific directory**
```bash
liquid --inputs "File=**/*sample.trx;Folder=C:\MyTestFolder" --output-file report.md 
```

**Report from single input, with a custom title** - [Sample Output](./samples/cli/CustomTitle.md)

``` bash
liquid --inputs "File=xUnit-net461-sample.trx" --output-file CustomTitle.md --title "Test Run 2021"
```

**Report from two inputs** - [Sample Output](./samples/cli/TwoInputs.md)

``` bash
liquid --inputs "File=xUnit-net461-sample.trx" "File=xUnit-netcoreapp3.1-sample.trx" --output-file TwoInputs.md 
```

 **Grouped results** - [Sample Output](./samples/cli/GroupUnitTests.md)
 Report with two inputs, and results grouped under the same section "Unit Tests": 

``` bash
liquid --inputs "File=xUnit-net461-sample.trx;GroupTitle=Unit Tests" "File=xUnit-netcoreapp3.1-sample.trx;GroupTitle=Unit Tests" --output-file GroupUnitTests.md 
```

**Grouped results with test name suffix** - [Sample Output](./samples/cli/GroupAndSuffix.md)

Report from two inputs, grouped under the same section "Unit Tests", with the tests from `xUnit-netcoreapp3.1-sample.trx` having (3.1) appended to the test names
 eg `SampleProject.xUnit.TestServiceTests` becomes `SampleProject.xUnit.TestServiceTests.PassingTest(3.1)`

``` bash
liquid --inputs "File=xUnit-net461-sample.trx;GroupTitle=Unit Tests" "File=xUnit-netcoreapp3.1-sample.trx;GroupTitle=Unit Tests;TestSuffix=(3.1)" --output-file GroupAndSuffix.md 
```

**Custom template and parameter**- [Sample Input](./samples/cli/InputTemplate.md) [Sample_Output](./samples/cli/CustomParameters.md)

```bash
liquid --inputs "File=**/*sample.trx;Format=Trx;RunId=123" --template="InputTemplate.md" --parameters="Environment=UAT;TicketId=abc123" --output-file CustomParameters.md 
```