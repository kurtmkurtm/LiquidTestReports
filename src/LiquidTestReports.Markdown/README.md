## LiquidTestReports.Markdown

LiquidTestReports.Markdown is a ready to use VSTest Markdown logger that generates GitHub friendly markdown reports from your test results.
The output will look like this [Sample Report](https://github.com/kurtmkurtm/LiquidTestReports/blob/master/docs/samples/xUnit.md).

**How to use:**
1. Install the markdown logger to your test project by running the following command
- `dotnet add package LiquidTestReports.Markdown`
2. Run the tests using the supplied logger
- `dotnet test -l liquid.md`
3. Report will be generated in the test results folder