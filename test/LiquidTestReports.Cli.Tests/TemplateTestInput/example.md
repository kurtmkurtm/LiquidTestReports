{%- assign passed = run.test_run_statistics.passed_count -%}
{%- assign failed = run.test_run_statistics.failed_count -%}
{%- assign skipped = run.test_run_statistics.skipped_count -%}
{%- assign total = run.test_run_statistics.executed_tests_count -%}
{%- assign pass_percentage = passed | divided_by: total | times: 100.0 | round: 2  *-%}
{%- if passed == total -%}
{%- assign overall = '✔️ Pass' *-%}
{%- elsif failed == 0 -%}
{%- assign overall = '⚠️ Indeterminate' *-%}
{%- else -%}
{%- assign overall = '❌ Fail' *-%}
{%- endif -%}
# {{ library.parameters.Title }}
### Run Summary


- Test Environment: {{ parameters.Environment }}
- Ticket Reference: {{ parameters.TicketId }}
- Overall Result: {{overall}}
- Pass Rate: {{pass_percentage | as_percentage}}
- Total Tests: {{total}}


---

{%- for set in run.result_sets -%} {%- assign groups = set.results | group: 'outcome' *-%}
{%- assign group_total = set.results | size *-%}
{%- assign passed_total = groups.Passed | size *-%}
{%- assign failed_total = groups.Failed | size *-%}
{%- assign skipped_total = groups.Skipped | size *-%}

#### {{ set.source }}

Run Id: {{ set.parameters.RunId }}
Pass Rate: {{ passed_total | divide_by_decimal: group_total | times: 100.0 | round: 2 | as_percentage }}
Tests: {{ set.results | size }}

---

{%- endfor -%}


[{{ library.text }}]({{ library.link }})