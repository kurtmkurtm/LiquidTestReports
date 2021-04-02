![](assets/fish_logo.png)

Liquid Test Reports are logger extensions for the [Visual Studio Test Platform](https://gtihub.com/microsoft/vstest) that provide flexible test report generation using liquid templates. This project contains an extensible core for code based extension, a custom logger for providing your own templates without code, and a Markdown implementation.

## Changelog

### Latest:

#### 1.0.9

**Changed**

- [All] Revert target framework from .NET standard 2.1 back to .NET standard 2.0 for broader compatibility
  - For use with .NET Core 2.x, see [Compatibility](#Compatibility)

[Previous changes](./docs/Changelog.md)


## LiquidTestReports.Cli (Beta):
[![NuGet Badge](https://buildstats.info/nuget/LiquidTestReports.Cli?includePreReleases=true)](https://www.nuget.org/packages/LiquidTestReports.Cli) 

 Generate Markdown or Custom Test Reports from existing TRX files

#### Installation

```bash
dotnet tool install --global LiquidTestReports.Cli --version 1.1.1-beta
```

#### Usage

```bash
liquid [options]
```

 **Options:**

 **--inputs <inputs>** Array of formatted configuration strings for test report inputs, with configurations separated by a semicolon
 - **File=file-name;** The path of the input file.
 - **GroupTitle=group-title;** Optional title to group reports under, test runs with the same group title will be merged.
 - **TestPrefix=test-prefix;** Optional test suffix, if provided test origination for the provided report will have the suffix appended to its name.

**--output-file <output-file>** Path to save test report to.
**--title <title>** Optional overall report title displayed in default report template. Defaults to "Test Run"
**--template <template>** Optional user defined liquid template. Defaults to the multi report markdown template is used. 
**--version** Show version information
**-?, -h, --help** Show help and usage information



#### Examples

 **Report from single input** - [Sample Output](docs/samples/cli/SingleInput.md)

``` bash
liquid --inputs "File=xUnit-net461-sample.trx" --output-file SingleInput.md 
```

**Report from single input, with a custom title** - [Sample Output](docs/samples/cli/CustomTitle.md)

``` bash
liquid --inputs "File=xUnit-net461-sample.trx" --output-file CustomTitle.md --title "Test Run 2021"
```

**Report from two inputs** - [Sample Output](docs/samples/cli/TwoInputs.md)

``` bash
liquid --inputs "File=xUnit-net461-sample.trx" "File=xUnit-netcoreapp3.1-sample.trx" --output-file TwoInputs.md 
```

 **Grouped results** - [Sample Output](docs/samples/cli/GroupUnitTests.md)
 Report with two inputs, and results grouped under the same section "Unit Tests": 

``` bash
liquid --inputs "File=xUnit-net461-sample.trx;GroupTitle=Unit Tests" "File=xUnit-netcoreapp3.1-sample.trx;GroupTitle=Unit Tests" --output-file GroupUnitTests.md 
```

**Grouped results with test name suffix** - [Sample Output](docs/samples/cli/GroupAndSuffix.md)

Report from two inputs, grouped under the same section "Unit Tests", with the tests from `xUnit-netcoreapp3.1-sample.trx` having (3.1) appended to the test names
 eg `SampleProject.xUnit.TestServiceTests` becomes `SampleProject.xUnit.TestServiceTests.PassingTest(3.1)`

``` bash
liquid --inputs "File=xUnit-net461-sample.trx;GroupTitle=Unit Tests" "File=xUnit-netcoreapp3.1-sample.trx;GroupTitle=Unit Tests;TestSuffix=(3.1)" --output-file GroupAndSuffix.md 
```

#### Removal

**Global tool removal:** 

```bash
dotnet tool uninstall LiquidTestReports.Cli -g
```

## LiquidTestReports.Markdown
[![NuGet Badge](https://buildstats.info/nuget/LiquidTestReports.Markdown?includePreReleases=true)](https://www.nuget.org/packages/LiquidTestReports.Markdown) 

The Markdown logger package is a ready to use  implementation of the test logger that generates Markdown format reports. 

[Sample Report](docs/samples/xUnit.md)

**How to use**:

1. Install the markdown logger to your test project by running the following command
	`dotnet add package LiquidTestReports.Markdown`
	
2. Run the tests using the supplied logger
	`dotnet test --logger "liquid.md"`
	
3. Report will be generated in the test results folder


See also: [Testing .NET Core Apps with GitHub Actions](https://dev.to/kurtmkurtm/testing-net-core-apps-with-github-actions-3i76)


## LiquidTestReports.Custom
[![NuGet Badge](https://buildstats.info/nuget/LiquidTestReports.Custom?includePreReleases=true)](https://www.nuget.org/packages/LiquidTestReports.Custom)

The custom logger package allows you to create your own reports simply by passing the file path of the template to the test logger. The list of template properties are available [here](docs/Properties.md). 

[Sample Report](docs/samples/xUnit.txt) (using example template below)

**How to use:**

1. Install the core logger to your test project either using the nuget or by running the following command
	
	`dotnet add package LiquidTestReports.Custom`

2. Add a new text file to your test project, and set `Copy to Output Directory` as`Copy always`, below is a starting sample template

  ```TemplateExample.txt
  Test Statistics:
  
  None: {{ run.test_run_statistics.none_count }}
  Passed: {{ run.test_run_statistics.passed_count }}
  Failed: {{ run.test_run_statistics.failed_count }}
  Skipped: {{ run.test_run_statistics.skipped_count }}
  Not Found: {{ run.test_run_statistics.not_found_count }}
  Total: {{ run.test_run_statistics.executed_tests_count }}
  
  ```

3. Run the tests using the supplied logger

	`dotnet test --logger "liquid.custom;TemplateExample.txt"`

4. Report will be generated in the test results folder



For a more detailed example, take a look at included [Markdown template](.\src\LiquidTestReports.Markdown\Resources\MdReport.md).

*More liquid template and syntax documentation is available on the [Shopify Github](https://shopify.github.io/liquid/basics/introduction/).*

## LiquidTestReports.Core
[![NuGet Badge](https://buildstats.info/nuget/LiquidTestReports.Core?includePreReleases=true)](https://www.nuget.org/packages/LiquidTestReports.Core)

The core project is utilised by the above two loggers and can be used to implement your own, however, this is yet to be documented. The custom and markdown implementations provide an guide of how to implement this.

**How to install**:

1. Install the core logger to your test project either using the nuget or by running the following command

	`dotnet add package LiquidTestReports.Core`


## Compatibility 

**.NET 4.5.1+ and .NET Core 3.0+**

No additional configuration is required.

**.NET Core 2.1 - 2.2**

By default, the logger will not be copied to the output folder, and will not be discovered. 
To use with these versions, include `CopyLocalLockFileAssemblies` in your test project. This will copy the logger to your output folder.  

``` xml
<PropertyGroup>
  <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
</PropertyGroup>
```

*Note: this will also copy other NuGet dependencies into your output folder*

**.NET Core 2.0**

Issues appear to be present in testing with .NET Core 2.0, as this target is no longer supported, it is recommended to update to supported version of .NET Core. 


## License

**LiquidTestReports** is under [BSD 2-Clause License.](https://github.com/kurtmkurtm/LiquidTestReports/blob/master/LICENSE)

This library utilises the following libraries under the Apache 2.0 license

- **DotLiquid** - https://github.com/dotliquid/dotliquid/blob/master/LICENSE.txt

This library utilises the following libraries under the MIT License

- **Microsoft - VSTest** - https://github.com/microsoft/vstest/blob/master/LICENSE

