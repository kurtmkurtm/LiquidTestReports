# Test Run Details
**Started:** {{ run.started | local_time | date: '%Y-%m-%d %H:%M:%S' }}

**Finished:** {{ run.finished | local_time | date: '%Y-%m-%d %H:%M:%S' }}

**Framework:** {{ parameters.TargetFramework }}

### Total Tests
**{{ run.test_run_statistics.executed_tests_count }}**

### Pass Percentage
**{{ run.test_run_statistics.passed_count | divided_by: run.test_run_statistics.executed_tests_count | times: 100.0 | round: 2 }} %**

### Run Duration
**{{ run.elapsed_time_in_running_tests | format_duration }}**

| Passed | Failed | Skipped |
| :------ | :------ | :------ |
|{{ run.test_run_statistics.passed_count }}|{{ run.test_run_statistics.failed_count }}|{{ run.test_run_statistics.skipped_count }}|

## Results
{% for set in run.result_sets %}
### {{ set.source | split: '\' | last }}
{% for result in set.results %}
##### {% case result.outcome %} - {% when 'Passed' %}✔️{% when 'Failed' %}❌{% else %}⚠️{% endcase %} {{ result.outcome }} - {{ result.test_case.display_name }} - {{ result.duration | format_duration }}
{% if result.outcome == 'Failed' %} 
> {{ result.error_message }}{% endif -%}
{% endfor %}
{% endfor %}
----
## Run Messages
### Informational {% assign information =  run.messages | where: "level", "Informational" %}
> {% for message in information %}{{ message.level }} - {{message.message}}
{% endfor %}

### Warning & Error {% assign warnings_errors =  run.messages | where: "level", "Warning|Error" %}
> {% for message in warnings_errors %}{{ message.level }} - {{message.message}}
{% endfor %}

----
[{{ library.text }}]({{ library.link }})