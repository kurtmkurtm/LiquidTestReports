# TRX
dotnet test ../test/SampleProject/SampleProject.Tests.xUnit -l "trx;LogFileName=xUnit-net8.0-sample.trx" -f net8.0
dotnet test ../test/SampleProject/SampleProject.Tests.NUnit -l "trx;LogFileName=NUnit-net8.0-sample.trx" -f net8.0
dotnet test ../test/SampleProject/SampleProject.Tests.MSTest -l "trx;LogFileName=MSTest-net8.0-sample.trx" -f net8.0
dotnet test ../test/SampleProject/SampleProject.Tests.xUnit -l "trx;LogFileName=xUnit-net9.0-sample.trx" -f net9.0
dotnet test ../test/SampleProject/SampleProject.Tests.NUnit -l "trx;LogFileName=NUnit-net9.0-sample.trx" -f net9.0
dotnet test ../test/SampleProject/SampleProject.Tests.MSTest -l "trx;LogFileName=MSTest-net9.0-sample.trx" -f net9.0
Move-Item -Path ../test/SampleProject/SampleProject.Tests.xUnit/TestResults/*-sample.trx -Destination ../test/LiquidTestReports.Cli.Tests/TrxTestInput/  -force
Move-Item -Path ../test/SampleProject/SampleProject.Tests.MSTest/TestResults/*-sample.trx -Destination ../test/LiquidTestReports.Cli.Tests/TrxTestInput/  -force
Move-Item -Path ../test/SampleProject/SampleProject.Tests.NUnit/TestResults/*-sample.trx -Destination ../test/LiquidTestReports.Cli.Tests/TrxTestInput/  -force
