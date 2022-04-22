```mermaid
gantt
    dateFormat  YYYY-MM-DD
    axisFormat  %b
    #todayMarker off
    title       System-Plan 2.0
    excludes    weekends

    section Administratve
    Project administration & paperwork                  :active, pw, 2022-01-10, 2022-06-15
    Visjondsokument                                     :active, vd, 2022-01-24, 2022-05-23
    Prosjekthåndbok                                     :active, ph, 2022-01-24, 2022-05-23
    Prosjektrapport                                     :active, pr, 2022-04-01, 2022-05-23

    OA-6 Visjonsdokument og prosjekthåndbok             :milestone, done, oa6, 2022-01-28
    OA-76 Statusmøte                                    :milestone, active, oa7, 2022-01-31
    OA-8-1 Metode                                       :milestone, oa81, 2022-02-13, 1d
    OA-8-2 Visjonsdokument og prosjekthåndbok           :milestone, oa82, 2022-02-25, 1d
    OA-9 Statusmøte                                     :milestone, oa9, 2022-02-28, 1d
    OA-10 Forprosjektrapport                            :milestone, oa10, 2022-03-11, 1d
    OA-11 Forprosjektrapport Presentasjon               :milestone, oa11, 2022-03-15, 1d
    OA-12 Prosjektstatus, prosjekthåndbok               :milestone, oa12, 2022-04-22, 1d
    OA-13-1 Utkast 1. Rapport                           :milestone, oa13-1, 2022-04-25, 1d
    OA-13-2 Utkast 2. Rapport                           :milestone, oa13-2, 2022-05-06, 1d
    OA-14 Endelig Rapport                               :milestone, oa14, 2022-05-23, 1d
    OA-15 Refleksjonsnotat                              :milestone, oa14, 2022-05-25, 1d

    section Core
    Create ScriptTemplates                              :done, st, 2022-01-03, 3d
    ScriptableObjectVariables                           :active, sv, 2022-01-01, 2022-02-10
    Finish Core 0.1.0                                   :milestone, m1, 2022-02-10, 1d

    section Systems
    Console                                             :active, co, 2022-01-10, 2022-02-15
    Character Ctrl.                                     :active, ch, 2022-01-17, 2022-02-15
    Input Ctrl.                                         :active, in, 2022-01-17, 2022-02-15
    Simulation                                          : si, 2022-02-01, 2022-03-15
    
    MainPanel                                           :active, mp, 2022-01-28, 2022-02-10
    PanelModule                                         : pm, 2022-02-01, 2022-02-10
    Valve                                               : va, 2022-02-05, 2022-02-15
    Gauge                                               : ga, 2022-02-05, 2022-02-15
    Finish local System 1.0.0                           :milestone, crit, m2, 2022-03-15, 1d
    
    Networking                                          : ne, 2022-03-01, 2022-04-01
    Instructor Interface                                : ii, 2022-03-15, 2022-04-01
    Finish Network-System 1.5.0                         :milestone, m3, 2022-04-26, 1d
    
    GUI                                                 : gu, 2022-03-01, 20d
    VoiceCommands                                       : gu, 2022-03-01, 20d
    Scenario,audio video                                : av, 2022-03-01, 40d
    Finish System 2.0.0                                 :milestone, crit, m4, 2022-05-06, 1d

    section Extra
    Other Features                                      : of, 2022-03-26, 2022-05-06
    Finish System 2.1.0                                 :milestone, me1, 2022-05-06, 1d
```



