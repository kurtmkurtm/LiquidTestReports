## LiquidTestReports.Cli

LiquidTestReports.Cli Generates Markdown and Custom Test Reports from TRX and or JUnit test files.
The output will look like this [Sample Report](https://github.com/kurtmkurtm/LiquidTestReports/blob/master/docs/samples/cli/SingleInput.md).

**How to use:**

1. Install the global tool

- `dotnet tool install --global LiquidTestReports.Cli --version 'latest-beta'`

2. Run the tests using the cli tool

- JUnit to Markdown: `liquid --inputs "File=xUnit-net6.0-junit-sample.xml;Format=JUnit" --output-file report.md`
- TRX to Markdown: `liquid --inputs "File=xUnit-net6.0-sample.trx;Format=Trx" --output-file SingleInput.md`
- Multi Report: `liquid --inputs "File=**/*.trx;GroupTitle=Unit Tests" "File=**/*.xml;Format=JUnit;GroupTitle=Integration Tests" --output-file report.md`

3. Report will be generated to the output file
