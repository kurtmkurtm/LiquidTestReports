{%- assign passed = run.test_run_statistics.passed_count -%}
{%- assign failed = run.test_run_statistics.failed_count -%}
{%- assign skipped = run.test_run_statistics.skipped_count -%}
{%- assign total = run.test_run_statistics.executed_tests_count -%}
{%- assign pass_percentage = passed | divided_by: total | as_percentage *-%}
{%- assign failed_percentage = failed | divided_by: total | as_percentage *-%}
{%- assign skipped_percentage = skipped | divided_by: total | as_percentage *-%}
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

<p>
<strong>Overall Result:</strong> {{overall}} <br />
<strong>Pass Rate:</strong> {{pass_percentage}} <br />
<strong>Run Duration:</strong> {{ run.elapsed_time_in_running_tests | format_duration }} <br />
<strong>Date:</strong> {{ run.started | local_time | date: '%Y-%m-%d %H:%M:%S' }} - {{ run.finished | local_time | date: '%Y-%m-%d %H:%M:%S' }} <br />
<strong>Framework:</strong> {{ parameters.TargetFramework }} <br />
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
<td>{{pass_percentage}}</td>
<td>{{failed_percentage}}</td>
<td>{{skipped_percentage}}</td>
</tr>
</tbody>
</table>

### Result Sets
{%- for set in run.result_sets -%}
#### {{ set.source | path_split | last }} - {{set.passed_count | divided_by: set.executed_tests_count | as_percentage }}
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
<summary>Error</summary>
<strong>Message:</strong>
<pre><code>{{result.error_message}}</code></pre>
<strong>Stack Trace:</strong>
<pre><code>{{result.error_stack_trace}}</code></pre>
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