```mermaid
gantt
    dateFormat  YYYY-MM-DD
    axisFormat  %b
    #todayMarker off
    title       System-Plan 1.0
    excludes    weekends

    section Administratve
    AO [4-5-6-7]                        :done, ao, 2022-01-10, 16d
    Visjondsokument                     :active, vd, 2022-01-24, 2022-05-31
    Prosjekthåndbok                     :active, ph, 2022-01-24, 2022-05-31
    Project administration & paperwork  :active, pw, 2022-01-10, 2022-05-31
    OA-6 visjondok, prosjekthand        :milestone, active, oa6, 2022-01-28
    OA-8-2 visjondok, prosjekthand      :milestone, active, oa82, 2022-02-27

    section Core
    Create ScriptTemplates              :done, st, 2022-01-03, 3d
    ScriptableObjectVariables           :active, sv, 2022-01-01, 2022-02-10
    Finish Core 0.1.0                   :milestone, m1, 2022-02-10, 1d

    section Systems
    Console                             :active, co, 2022-01-10, 2022-02-15
    Character Ctrl.                     :active, ch, 2022-01-17, 10d
    Input Ctrl.                         :active, in, 2022-01-17, 10d
    Simulation                          : si, 2022-02-01, 2022-03-15
    
    MainPanel                           :active, mp, 2022-01-28, 2022-02-10
    PanelModule                         : pm, 2022-02-01, 10d
    Valve                               : va, 2022-02-11, 20d
    Gauge                               : ga, 2022-02-11, 20d
    Finish local System 1.0.0           :milestone, crit, m2, 2022-03-15, 1d
    
    Networking                          : ne, 2022-03-01, 40d
    Instructor Interface                : ii, 2022-03-01, 40d
    Finish Network-System 1.5.0         :milestone, m3, 2022-04-26, 1d
    
    GUI                                 : gu, 2022-03-01, 20d
    Scenario,audio video                : av, 2022-03-01, 40d
    Finish System 2.0.0                 :milestone, crit, m3, 2022-05-01, 1d

    section Extra
    Other Features                      : of, 2022-03-26, 30d
    Finish System 2.1.0                 :milestone, m4, 2022-05-30, 1d
```



