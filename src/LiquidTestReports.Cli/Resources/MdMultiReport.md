{%- assign passed = run.test_run_statistics.passed_count -%}
{%- assign failed = run.test_run_statistics.failed_count -%}
{%- assign skipped = run.test_run_statistics.skipped_count -%}
{%- assign total = run.test_run_statistics.executed_tests_count -%}
{%- assign pass_percentage = passed | divided_by: total | times: 100.0 | round: 2  *-%}
{%- assign failed_percentage = failed | divided_by: total | times: 100.0 | round: 2  *-%}
{%- assign skipped_percentage = skipped | divided_by: total | times: 100.0 | round: 2  *-%}
{%- assign information =  run.messages | where: 'level', 'Informational' -%}
{%- assign warnings =  run.messages | where: 'level', 'Warning' -%}
{%- assign errors =  run.messages | where: 'level', 'Error' -%}
{%- if passed == total -%}
{%- assign overall = '✔️ Pass' *-%}
{%- elsif failed == 0 -%}
{%- assign overall = '⚠️ Indeterminate' *-%}
{%- else -%}
{%- assign overall = '❌ Fail' *-%}
{%- endif -%}
# {{ library.parameters.Title }}
### Run Summary

<p>
<strong>Overall Result:</strong> {{overall}} <br />
<strong>Pass Rate:</strong> {{pass_percentage}}% <br />
<strong>Run Duration:</strong> {{ run.elapsed_time_in_running_tests | format_duration }} <br />
<strong>Date:</strong> {{ run.started | local_time | date: '%Y-%m-%d %H:%M:%S' }} - {{ run.finished | local_time | date: '%Y-%m-%d %H:%M:%S' }} <br />
<strong>Total Tests:</strong> {{total}} <br />
</p>

<table>
<thead>
<tr>
<th>✔️ Passed</th>
<th>❌ Failed</th>
<th>⚠️ Skipped</th>
</tr>
</thead>
<tbody>
<tr>
<td>{{passed}}</td>
<td>{{failed}}</td>
<td>{{skipped}}</td>
</tr>
<tr>
<td>{{pass_percentage}}%</td>
<td>{{failed_percentage}}%</td>
<td>{{skipped_percentage}}%</td>
</tr>
</tbody>
</table>

---

{%- for set in run.result_sets -%} {%- assign groups = set.results | group: 'outcome' *-%}
{%- assign group_total = set.results | size *-%}
{%- assign passed_total = groups.Passed | size *-%}
{%- assign failed_total = groups.Failed | size *-%}
{%- assign skipped_total = groups.Skipped | size *-%}
{%- if group_total == passed_total -%}
{%- assign set_outcome = '✔️ Pass' *-%}
{%- elsif failed_total == 0 -%}
{%- assign set_outcome = '⚠️ Indeterminate' *-%}
{%- else -%}
{%- assign set_outcome = '❌ Fail' *-%}
{%- endif -%}
#### {{ set.source }}
<strong>Group Result:</strong> {{set_outcome}} <br />
<strong>Pass Rate:</strong> {{ passed_total | divide_by_decimal: group_total | times: 100.0 | round: 2 }}% <br />
<strong>Tests:</strong> {{ set.results | size }} <br />
<strong>Duration:</strong> {{ set.duration | format_duration }} <br />
<details open>
<summary><strong>Results:</strong></summary>
{%- if passed_total > 0 -%}
<details>
<summary>✔️ Passed ({{ passed_total }})</summary>
<table>
<thead>
<tr>
<th>Test</th>
<th>Duration</th>
</tr>
</thead>
<tbody>
{%- for result in groups.Passed -%}
<tr>
<td>
<details>
<summary>
✔️ {{ result.test_case.display_name }}
</summary>
Source:
<blockquote>{{- result.test_case.fully_qualified_name -}}</blockquote>
</details>
</td>
<td>{{ result.duration | format_duration }}</td>
</tr>
{%- endfor -%}
</tbody>
</table>
</details>
{%- endif -%}
{%- if failed_total > 0 -%}
<details>
<summary>❌ Failed ({{ failed_total }})</summary>
<table>
<thead>
<tr>
<th>Test</th>
<th>Duration</th>
</tr>
</thead>
<tbody>
{%- for result in groups.Failed -%}
<tr>
<td>
<details>
<summary>
❌ {{ result.test_case.display_name }}
</summary>
Source:
<blockquote>{{- result.test_case.fully_qualified_name -}}</blockquote>
Message:
<blockquote>{{result.error_message}}</blockquote>
Stack Trace:
<blockquote>{{result.error_stack_trace}}<blockquote>
</details>
</td>
<td>{{ result.duration | format_duration }}</td>
</tr>
{%- endfor -%}
</tbody>
</table>
</details>
{%- endif -%}
{%- if skipped_total > 0 -%}
<details>
<summary>⚠️ Skipped ({{ skipped_total }})</summary>
<table>
<thead>
<tr>
<th>Test</th>
<th>Duration</th>
</tr>
</thead>
<tbody>
{%- for result in groups.Skipped -%}
<tr>
<td>
<details>
<summary>
⚠️ {{ result.test_case.display_name }}
</summary>
Source:
<blockquote>{{- result.test_case.fully_qualified_name -}}</blockquote>
</details>
</td>
<td>{{ result.duration | format_duration }}</td>
</tr>
{%- endfor -%}
</tbody>
</table>
</details>
{%- endif -%}
</details>

---

{%- endfor -%}


[{{ library.text }}]({{ library.link }})