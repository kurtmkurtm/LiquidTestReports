# dotnet tool install --global dotnet-xscgen
xscgen -n =LiquidTestReports.Core.JUnit ..\src\LiquidTestReports.Core\Resources\jenkins-junit.xsd -o ..\src\LiquidTestReports.Core\Resources\
xscgen ..\src\LiquidTestReports.Core\Resources\vstst.xsd -o ..\src\LiquidTestReports.Core\Resources\
