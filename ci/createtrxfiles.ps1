dotnet test ../test/SampleProject/SampleProject.Tests.xUnit -l "trx;LogFileName=xUnit-netcoreapp3.1-sample.trx" -f netcoreapp3.1
dotnet test ../test/SampleProject/SampleProject.Tests.NUnit -l "trx;LogFileName=NUnit-netcoreapp3.1-sample.trx" -f netcoreapp3.1
dotnet test ../test/SampleProject/SampleProject.Tests.MSTest -l "trx;LogFileName=MSTest-netcoreapp3.1-sample.trx" -f netcoreapp3.1
dotnet test ../test/SampleProject/SampleProject.Tests.xUnit -l "trx;LogFileName=xUnit-net461-sample.trx" -f net461
dotnet test ../test/SampleProject/SampleProject.Tests.NUnit -l "trx;LogFileName=NUnit-net461-sample.trx" -f net461
dotnet test ../test/SampleProject/SampleProject.Tests.MSTest -l "trx;LogFileName=MSTest-net461-sample.trx" -f net461
Move-Item -Path ../test/SampleProject/SampleProject.Tests.xUnit/TestResults/*-sample.trx -Destination ../test/LiquidTestReports.Cli.Tests/TrxTestInput/  -force
Move-Item -Path ../test/SampleProject/SampleProject.Tests.MSTest/TestResults/*-sample.trx -Destination ../test/LiquidTestReports.Cli.Tests/TrxTestInput/  -force
Move-Item -Path ../test/SampleProject/SampleProject.Tests.NUnit/TestResults/*-sample.trx -Destination ../test/LiquidTestReports.Cli.Tests/TrxTestInput/  -force

