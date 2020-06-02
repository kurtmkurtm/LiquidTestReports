{%- assign passed = run.test_run_statistics.passed_count -%}
{%- assign failed = run.test_run_statistics.failed_count -%}
{%- assign skipped = run.test_run_statistics.skipped_count -%}
{%- assign total = run.test_run_statistics.executed_tests_count -%}
{%- assign pass_percentage = passed | divided_by: total | times: 100.0 | round: 2  *-%}
{%- assign failed_percentage = failed | divided_by: total | times: 100.0 | round: 2  *-%}
{%- assign skipped_percentage = skipped | divided_by: total | times: 100.0 | round: 2  *-%}
{%- assign information =  run.messages | where: "level", "Informational" -%}
{%- assign warnings =  run.messages | where: "level", "Warning" -%}
{%- assign errors =  run.messages | where: "level", "Error" -%}
{%- if passed == total -%}
{%- assign overall = "✔️ Pass" *-%}
{%- elsif failed == 0 -%}
{%- assign overall = "⚠️ Indeterminate" *-%}
{%- else -%}
{%- assign overall = "❌ Fail" *-%}
{%- endif -%}

# {{ library.parameters.Title }}
### Run Summary
**Overall Result:** {{overall}}
**Pass Rate:** {{pass_percentage}}%
**Run Duration:** {{ run.elapsed_time_in_running_tests | format_duration }}
**Date:** {{ run.started | local_time | date: '%Y-%m-%d %H:%M:%S' }} - {{ run.finished | local_time | date: '%Y-%m-%d %H:%M:%S' }}
**Framework:** {{ parameters.TargetFramework }}
**Total Tests:** {{total}}
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

### Result Sets
{%- for set in run.result_sets -%}
#### {{ set.source | path_split | last }} - {{set.passed_count | divided_by: set.executed_tests_count | times: 100.0 | round: 2 }}%
<details>
<summary>Full Results</summary>
<table>
<thead>
<tr>
<th>Result</th>
<th>Test</th>
<th>Duration</th>
</tr>
</thead>
{%- for result in set.results -%}
<tr>
<td> {% case result.outcome %} {% when 'Passed' %}✔️{% when 'Failed' %}❌{% else %}⚠️{% endcase %} {{ result.outcome }} </td>
<td> {{- result.test_case.display_name -}}
{%- if result.outcome == 'Failed' and library.parameters.IncludeMessages == true -%}
<blockquote><details>
<summary>Error Message</summary>
<pre><code>{{result.error_message}}</code></pre>
</details></blockquote>
{%- endif -%}
</td>
<td>{{ result.duration | format_duration }}</td>
</tr>
{%- endfor -%}
</tbody>
</table>
</details>
{%- endfor -%}
{%- if library.parameters.IncludeMessages == true -%}

### Run Messages
<details>
<summary>Informational</summary>
<pre><code>
{%- for message in information -%}
{{ message.message }}
{%- endfor -%}
</code></pre>
</details>

<details>
<summary>Warning</summary>
<pre><code>
{%- for message in warnings -%}
{{message.message}}
{%- endfor -%}
</code></pre>
</details>

<details>
<summary>Error</summary>
<pre><code>
{%- for message in errors -%}
{{message.message}}
{%- endfor -%}
</code></pre>
</details>

{%- endif -%}


----

[{{ library.text }}]({{ library.link }})