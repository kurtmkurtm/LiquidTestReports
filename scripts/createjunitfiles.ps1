dotnet test ../test/SampleProject/SampleProject.Tests.xUnit -l "junit;LogFilePath=TestResults/xUnit-netcoreapp3.1-junit-sample.xml" -f netcoreapp3.1
dotnet test ../test/SampleProject/SampleProject.Tests.NUnit -l "junit;LogFilePath=TestResults/NUnit-netcoreapp3.1-junit-sample.xml" -f netcoreapp3.1
dotnet test ../test/SampleProject/SampleProject.Tests.MSTest -l "junit;LogFilePath=TestResults/MSTest-netcoreapp3.1-junit-sample.xml" -f netcoreapp3.1
dotnet test ../test/SampleProject/SampleProject.Tests.xUnit -l "junit;LogFilePath=TestResults/xUnit-net461-junit-sample.xml" -f net461
dotnet test ../test/SampleProject/SampleProject.Tests.NUnit -l "junit;LogFilePath=TestResults/NUnit-net461-junit-sample.xml" -f net461
dotnet test ../test/SampleProject/SampleProject.Tests.MSTest -l "junit;LogFilePath=TestResults/MSTest-net461-junit-sample.xml" -f net461
Move-Item -Path ../test/SampleProject/SampleProject.Tests.xUnit/TestResults/*-junit-sample.xml -Destination ../test/LiquidTestReports.Cli.Tests/JUnitTestInput/  -force
Move-Item -Path ../test/SampleProject/SampleProject.Tests.MSTest/TestResults/*-junit-sample.xml -Destination ../test/LiquidTestReports.Cli.Tests/JUnitTestInput/  -force
Move-Item -Path ../test/SampleProject/SampleProject.Tests.NUnit/TestResults/*-junit-sample.xml -Destination ../test/LiquidTestReports.Cli.Tests/JUnitTestInput/  -force