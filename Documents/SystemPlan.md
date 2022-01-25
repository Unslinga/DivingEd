```mermaid
gantt
    dateFormat  YYYY-MM-DD
    axisFormat  %b
    todayMarker off
    title       System-Plan
    excludes    weekends

    section Core
    Create ScriptTemplates      :done, st, 2022-01-03, 3d
    ScriptableObjectVariables   :active, sv, 2022-01-03, 2022-01-31
    Finish Core                 :milestone, m1, 2022-02-01, 1d

    section Systems
    Character                   :active, ch, 2022-01-10, 40d
    Console                     :active, co, 2022-01-10, 40d
    Gauge                       :active, ga, 2022-01-10, 40d
    Input                       :active, in, 2022-01-10, 40d
    PanelModule                 :active, pm, 2022-01-10, 40d
    Networking                  :active, ne, 2022-01-10, 40d
    Panel                       :active, pa, 2022-01-10, 40d
    Valve                       :active, va, 2022-01-10, 40d
    Finish System               :milestone, m2, 2022-05-30, 1d
```