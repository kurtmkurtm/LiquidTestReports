# Template properties

Liquid Test Reports try to expose as much of the test data as possible, the following sections describe the properties available within the report context, all sample outputs will be generated from real test data.

- [run](#run)
- [parameters](#parameters)
- [library](#library)

### General 

Naming - As this library utilises dotliquid for liquid templates, the default ruby naming convention is used. This means all member names are in snake case, as shown below.

The only exception to this naming, is with dictionary keys, the retain the original casing as shown below.

```
*{{parameters['TargetFramework']}}*
*{{parameters.TargetFramework}}*
```

## Run

### test_run_statistics

Gets the number of tests per outcome in the test run

**Input**

```
{% raw %}
None: {{ run.test_run_statistics.none_count }}
Passed: {{ run.test_run_statistics.passed_count }}
Failed: {{ run.test_run_statistics.failed_count }}
Skipped: {{ run.test_run_statistics.skipped_count }}
Not Found: {{ run.test_run_statistics.not_found_count }}
Total: {{ run.test_run_statistics.executed_tests_count }}
{% endraw %}
```

**Output**

```
None: {{ run.test_run_statistics.none_count }}
Passed: {{ run.test_run_statistics.passed_count }}
Failed: {{ run.test_run_statistics.failed_count }}
Skipped: {{ run.test_run_statistics.skipped_count }}
Not Found: {{ run.test_run_statistics.not_found_count }}
Total: {{ run.test_run_statistics.executed_tests_count }}
```


###  is_canceled
Specifies whether the test run is canceled

**Input**
```
{% raw %}
Is Cancelled: {{ run.is_canceled }}
{% endraw %}
```

**Output**

```
Is Cancelled: {{ run.is_canceled }}
```

### is_aborted
Specifies whether the test run is aborted
**Input**

```
{% raw %}
Is Aborted: {{ run.is_aborted }}
{% endraw %}
```

**Output**
```
Is Aborted: {{ run.is_aborted }}
```

### error
Gets the error encountered during the execution of the test run. Null if there is no error.
**Input**

```
{% raw %}
Error: {{ run.error }}
{% endraw %}
```

**Output**
```
Error: {{ run.error }}
```

### attachment_sets
Gets the attachment sets associated with the test run.

**Input**
```
{% raw %}
Attachment Set URI: {{run.attachment_sets[0].uri}}
Attachment Set Display Name: {{run.attachment_sets[0].display_name}}

{% assign first_attachment_item =  first_attachment_set.attachments | first %}
Attachment Item: {{attachment_sets[0].attachments[0].description}}
Attachment Item Uri: {{attachment_sets[0].attachments[0].uri}}

{% endraw %}
```

**Output**
```
{% assign first_attachment_set =  run.attachment_sets | first %}
Attachment Set URI: {{first_attachment_set.uri}}
Attachment Set Display Name: {{first_attachment_set.display_name}}

{% assign first_attachment_item =  first_attachment_set.attachments | first %}
Attachment Item: {{first_attachment_item.description}}
Attachment Item Uri: {{first_attachment_item.uri}}
```

### elapsed_time_in_running_tests
Gets the time elapsed in just running the tests.
*Value is set to TimeSpan.Zero in case of any error.*
**Input**

```
{% raw %}
Time Running: {{ run.elapsed_time_in_running_tests }}
{% endraw %}
```

**Output**
```
Time Running: {{ run.elapsed_time_in_running_tests }}
```

### messages
Gets output from the test run, entries contain a message and level.

**Message** contains the message
**Level** of the message, expressed by it’s string value

- Informational 
- Warning
- Error

**Input**

```
{% raw %}
Message: {{ run.messages[0].message }}
Level: {{ run.messages[0].message }}
{% endraw %}
```

**Output**

```
Message: {{ run.messages[0].message }}
Level: {{ run.messages[0].message }}
```

### result_sets
Possibly the only property you want, this contains the test results, for convince, it is grouped by the source. 

**result** sets is an array, each set contains

- **source** - Test container source from which the test is discovered
- **duration** - Total run duration for set
- **executed_tests_count** - Total number of total tests executed in set
- **none_count** - Count of tests with outcome None
- **passed_count** - Count of tests with outcome Passed 
- **failed_count** - Count of tests with outcome Failed 
- **skipped_count** - Count of tests with outcome Skipped 
- **not_found_count**  - Count of tests with outcome NotFound  
- **Results** - an array of test result
  - **outcome** - string outcome from the following
    - None
    - Passed
    - Failed
    - Skipped
    - NotFound 
  - **error_message** - exception message
  - **error_stack_trace** - exception stack trace
  - **display_name** - TestResult Display name
  - **messages** - an array of messages from the test
  	- **message** - log message from test
    - **level** - string log level for message
      - Informational 
      - Warning
      - Error 
  - **computer_name** - name of test computer ran on
  - **duration** - time test took
  - **start_time** - time test started
  - **end_time** - time test completed
  - **test_case** - test case that this result is for array
    - **id** - the id of the test case.
    - **fully_qualified_name** -  fully qualified name of the test case
    - **display_name** - test display name
    - **executor_uri** - uri of test executor
    - **source** - test container source
    - **code_file_path** code file containing test
    - **line_number** - line number of the test
    - **traits** - dictionary of traits on test case

**Input**

```
{% raw %}

{% assign first_set =  run.result_sets | first %}
Duration: {{first_set.duration}}
Source: {{first_set.source}}
Executed Tests Count: {{ first_set.executed_tests_count }}
None Count: {{ first_set.none_count }}
Passed Count: {{ first_set.passed_count }}
Failed Count: {{ first_set.failed_count }}
Skipped Count: {{ first_set.skipped_count }}
Not Found Count: {{ first_set.not_found_count }}

{% assign first_result =  first_set.results | first %}
Display: {{first_result.display_name}}
Outcome: {{first_result.outcome}}
Error Message: {{first_result.error_message}}
Error Stack: {{first_result.error_stack_trace}}
ComputerName: {{first_result.computer_name}}
Duration: {{first_set.duration}}
StartTime: {{first_result.start_time}}
EndTime: {{first_result.end_time}}
Traits : {{first_result.traits | first}}
Result Message Text: {{first_result.messages[0].text}}
Result Message Category: {{first_result.messages[0].category}}

{% assign test_case =  first_result.test_case %}
Id: {{test_case.id}}
FQN: {{test_case.fully_qualified_name}}
Display Name: {{test_case.display_name}}
Executor URI: {{test_case.executor_uri}}
Source: {{test_case.source}}
Code File Path: {{test_case.code_file_path}}
Line Number: {{test_case.line_number}}
Traits: 
{%- for trait in test_case.traits -%}
[{{ trait.Name }} : {{ trait.Value }}]</br>
{%- endfor -%}

{% endraw %}
```

**Output**

```
{% assign first_set =  run.result_sets | first %}
Duration: {{first_set.duration}}
Source: {{first_set.source}}
Executed Tests Count: {{ first_set.executed_tests_count }}
None Count: {{ first_set.none_count }}
Passed Count: {{ first_set.passed_count }}
Failed Count: {{ first_set.failed_count }}
Skipped Count: {{ first_set.skipped_count }}
Not Found Count: {{ first_set.not_found_count }}

{% assign first_result =  first_set.results | first %}
Display: {{first_result.display_name}}
Outcome: {{first_result.outcome}}
Error Message: {{first_result.error_message}}
Error Stack: {{first_result.error_stack_trace}}
ComputerName: {{first_result.computer_name}}
Duration: {{first_set.duration}}
StartTime: {{first_result.start_time}}
EndTime: {{first_result.end_time}}
Traits : {{first_result.traits | first}}
Result Message Text: {{first_result.messages[0].text}}
Result Message Category: {{first_result.messages[0].category}}

{% assign test_case =  first_result.test_case %}
Id: {{test_case.id}}
FQN: {{test_case.fully_qualified_name}}
Display Name: {{test_case.display_name}}
Executor URI: {{test_case.executor_uri}}
Source: {{test_case.source}}
Code File Path: {{test_case.code_file_path}}
Line Number: {{test_case.line_number}}
Traits: 
{%- for trait in test_case.traits -%}
[{{ trait.Name }} : {{ trait.Value }}]</br>
{%- endfor -%}
```



## Parameters

A dictionary of strings generated by vstest and includes user input passed in via the vstest command line. 

For example this input:

`dotnet vstest test.dll --logger:"liquid.user;Environment=Dev”`

Would be accessible to use in a template with

`{% raw %}{{ parameters[‘Environment’] }}{% endraw %} `or`{% raw %}{{ parameters.Environment}}{% endraw %}`

**Input**

```
{% raw %}
{{ parameters['TestRunDirectory'] }}
{{ parameters['TargetFramework'] }}
{% endraw %}
```

**Output**

```
{{ parameters['TestRunDirectory'] }}
{{ parameters['TargetFramework'] }}
```

## Library
The library properties provide project links and an extension point

- **text**  - hardcoded text label to use with project links
- **link** - hardcoded link to connect back to the project
- **parameters** - this dictionary is an extension point  for implementations of `LiquidTestReports.Core` to add their own items via `LibraryParameters`. This can be used in templates for purposes such as transformations on test attachments

```
{% raw %}
{{ library.text }}
{{ library.link }}
{% endraw %}
```

**Output**

```
{{ library.text }}
{{ library.link }}
```