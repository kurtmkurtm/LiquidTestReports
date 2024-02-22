# Locally build, install and run tool to test

dotnet tool uninstall LiquidTestReports.Cli -g # remove old version
dotnet pack ../src -o ./
dotnet tool install --global --add-source ./ LiquidTestReports.Cli --version 1.0.0 # must be specified for beta eg 1.3.5-beta

liquid `
--inputs "File=**/*sample.trx;Folder=../Test/LiquidTestReports.Cli.Tests/TrxTestInput" `
--output-file report.md

liquid `
--inputs "File=**/*sample.trx;Folder=../Test/LiquidTestReports.Cli.Tests/TrxTestInput;Format=Trx;RunId=123" `
--template "../Test/LiquidTestReports.Cli.Tests/TemplateTestInput/example.md" `
--parameters "Environment=UAT;TicketId=abc123" `
--output-file custom.md