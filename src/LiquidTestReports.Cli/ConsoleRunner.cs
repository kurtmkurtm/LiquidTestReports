﻿using DotLiquid;
using DotLiquid.Exceptions;
using LiquidTestReports.Cli.Resources;
using LiquidTestReports.Cli.Services;
using LiquidTestReports.Core;
using LiquidTestReports.Core.Drops;
using LiquidTestReports.Core.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;

namespace LiquidTestReports.Cli
{
    /// <summary>
    /// Runs report generation process with console output.
    /// </summary>
    internal class ConsoleRunner
    {
        private readonly IAnsiConsole _errorConsole;
        private readonly IAnsiConsole _standardConsole;
        private readonly ReportInput[] _inputs;
        private readonly FileInfo _outputFile;

        internal ConsoleRunner(ReportInput[] inputs, FileInfo outputFile)
        {
            _errorConsole = AnsiConsole.Create(new AnsiConsoleSettings { Out = Console.Error });
            _standardConsole = AnsiConsole.Create(new AnsiConsoleSettings { Out = Console.Out });
            _inputs = inputs;
            _outputFile = outputFile;
        }

        internal void Run(string title, string template)
        {
            WriteHeader(title);
            WriteInputTable();

            var report = GenerateReport(template, GenerateLibraryParameters(title));
            if (string.IsNullOrEmpty(report))
            {
                _errorConsole.WriteLine("Error, report generated no content");
                Environment.Exit((int)ExitCodes.ReportGenerationError);
            }

            var saved = SaveReport(report);
            if (!saved)
            {
                _errorConsole.WriteLine("Error, report unable to be saved");
                Environment.Exit((int)ExitCodes.ReportSaveError);
            }
        }

        private bool SaveReport(string report)
        {
            try
            {
                if (!_outputFile.Directory.Exists)
                {
                    _outputFile.Directory.Create();
                }

                File.WriteAllText(path: _outputFile.FullName, contents: report);

                if (_outputFile.Exists)
                {
                    _standardConsole.MarkupLine($"[green]Saved report to {_outputFile}[/]");
                    return true;
                }
            }
            catch (UnauthorizedAccessException e)
            {
                _errorConsole.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                _errorConsole.WriteLine($"Unexpected error occurred while saving report {e.Message}");
            }

            return false;
        }

        private string GenerateReport(string template, LibraryDrop libraryDrop)
        {
            var reportProcessor = new InputProcessingService(_inputs);
            TestRunDrop run;
            try
            {
                run = reportProcessor.Process();
            }
            catch (InvalidDataException e)
            {
                _errorConsole.WriteLine(e.Message);
                return null;
            }

            string report = null;

            _standardConsole.WriteLine();
            _standardConsole.MarkupLine("Generating report");

            try
            {
                var reportGenerator = new ReportGenerator(new LibraryTestRun { Run = run, Library = libraryDrop });
                report = reportGenerator.GenerateReport(template ?? Templates.MdMultiReport, out var errors);
                foreach (var error in errors)
                    _standardConsole.MarkupLine($"[orange1]{error.Message}[/]");
                _standardConsole.WriteLine();
                _standardConsole.MarkupLine("Finished generating report");
            }
            catch (SyntaxException e)
            {
                _errorConsole.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                _errorConsole.WriteLine($"Unexpected error occurred while generating report {e.Message}");
            }

            return report;
        }

        private void WriteInputTable()
        {
            var table = new Table()
                            .AddColumn(new TableColumn("File").Centered())
                            .AddColumn(new TableColumn("Group Title").Centered())
                            .AddColumn(new TableColumn("Test Suffix").Centered())
                            .AddColumn(new TableColumn("Exists").Centered())
                            .AddColumn(new TableColumn("Format").Centered())
                            .AddColumn(new TableColumn("Skipping").Centered());

            foreach (var input in _inputs)
            {
                table.AddRow(input.File.Name,
                    string.IsNullOrEmpty(input.GroupTitle) ? "default" : input.GroupTitle,
                    string.IsNullOrEmpty(input.TestSuffix) ? "n/a" : input.TestSuffix,
                    input.File.Exists.ToString(),
                    input.Format.ToString(),
                    (!input.File.Exists || input.Format == InputFormatType.Unknown).ToString());
            }

            _standardConsole.WriteLine();
            _standardConsole.Render(table);
        }

        private void WriteHeader(string title)
        {
            _standardConsole.WriteLine();
            _standardConsole.Render(new FigletText("Liquid Test Reports").Centered().Color(Color.Blue));
            _standardConsole.WriteLine();
            _standardConsole.Render(new FigletText("Cli Tool").Centered().Color(Color.White));
            _standardConsole.WriteLine();
            _standardConsole.WriteLine();
            _standardConsole.Render(new Rule(title).RuleStyle("grey").LeftAligned());
            _standardConsole.WriteLine();
        }

        private static LibraryDrop GenerateLibraryParameters(string title)
        {
            return new LibraryDrop
            {
                Parameters = new Dictionary<string, object>(Template.NamingConvention.StringComparer)
                {
                    { Constants.TitleKey, title }
                }
            };
        }
    }
}