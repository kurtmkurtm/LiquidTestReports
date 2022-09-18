## LiquidTestReports.Custom

LiquidTestReports.Custom The custom logger package allows you to create your own reports simply by passing the file path of the template to the test logger.
The output will look like this [Sample Report](https://github.com/kurtmkurtm/LiquidTestReports/blob/master/docs/samples/xUnit.txt).

**How to use:**
1. Install the core logger to your test project either using the nuget or by running the following command
- `dotnet add package LiquidTestReports.Custom`
2. Add a new text file to your test project, and set `Copy to Output Directory` as `Copy always`, below is a starting sample template.
```
Test Statistics:

None: {{ run.test_run_statistics.none_count }}
Passed: {{ run.test_run_statistics.passed_count }}
Failed: {{ run.test_run_statistics.failed_count }}
Skipped: {{ run.test_run_statistics.skipped_count }}
Not Found: {{ run.test_run_statistics.not_found_count }}
Total: {{ run.test_run_statistics.executed_tests_count }}
```
3. Run the tests using the supplied logger
- `dotnet test --logger "liquid.custom;TemplateExample.txt"`
4. Report will be generated in the test results folder