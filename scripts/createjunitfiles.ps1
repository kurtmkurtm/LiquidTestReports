dotnet test ../test/SampleProject/SampleProject.Tests.xUnit -l "junit;LogFilePath=TestResults/xUnit-net8.0-junit-sample.xml" -f net8.0
dotnet test ../test/SampleProject/SampleProject.Tests.NUnit -l "junit;LogFilePath=TestResults/NUnit-net8.0-junit-sample.xml" -f net8.0
dotnet test ../test/SampleProject/SampleProject.Tests.MSTest -l "junit;LogFilePath=TestResults/MSTest-net8.0-junit-sample.xml" -f net8.0
dotnet test ../test/SampleProject/SampleProject.Tests.xUnit -l "junit;LogFilePath=TestResults/xUnit-net9.0-junit-sample.xml" -f net9.0
dotnet test ../test/SampleProject/SampleProject.Tests.NUnit -l "junit;LogFilePath=TestResults/NUnit-net9.0-junit-sample.xml" -f net9.0
dotnet test ../test/SampleProject/SampleProject.Tests.MSTest -l "junit;LogFilePath=TestResults/MSTest-net9.0-junit-sample.xml" -f net9.0
Move-Item -Path ../test/SampleProject/SampleProject.Tests.xUnit/TestResults/*-junit-sample.xml -Destination ../test/LiquidTestReports.Cli.Tests/JUnitTestInput/  -force
Move-Item -Path ../test/SampleProject/SampleProject.Tests.MSTest/TestResults/*-junit-sample.xml -Destination ../test/LiquidTestReports.Cli.Tests/JUnitTestInput/  -force
Move-Item -Path ../test/SampleProject/SampleProject.Tests.NUnit/TestResults/*-junit-sample.xml -Destination ../test/LiquidTestReports.Cli.Tests/JUnitTestInput/  -force