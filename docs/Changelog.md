## Changelog

#### 1.1.1 beta

- [Cli] 
  - Add new .NET Tool for report generation with TRX support
  - Add new markdown report template
- [Core] 
  - Refactor drop model mapping
  - Add TRX mapping
  - Move template error logging from report generator into base test logger

#### 1.0.9

**Changed**

- [All] Revert target framework from .NET standard 2.1 back to .NET standard 2.0 for broader compatibility
  - For use with .NET Core 2.x, see [Compatibility](#Compatibility)

#### 1.0.1

**Changed**

- Remove pre-release tags 🎉

**Fixed**

- Create drop for test result messages, and replace URIs with strings

#### 0.2.4 

**Added**

- [Markdown] Add optional user configurable report titles, usable by setting the title parameter `Title=My test report;`
- [Markdown] Include error stack trace

**Changed**

- [Markdown] Redesign markdown report for better formatting in GitHub
- [Markdown] Use tables for results
- [Markdown] Use detail elements for content result sets
- [Markdown] Add pass rate per container
- [Markdown] Add overall result and percentages to summary

**Fixed**

- [Markdown] Fix path splitting for container name on non windows machines

#### v0.1.4

**Added**

- [Markdown] Option to exclude run messages from test report enabled through parameter
  `IncludeMessages=false;`

**Changed**

- [All] Update targets to .NET standard 2.1 / .NET framework 4.5.1+