# DivingEd

<br><br><br><br><br><br>

## <center>Visjonsdokument</center>

<br><br><br><br>

### <center>Versjon 1.0</center>
			
<div style="page-break-after: always;"></div>

## INNHOLDSFORTEGNELSE 
1.	INNLEDNING
2.	SAMMENDRAG PROBLEM OG PRODUKT
	1.	PROBLEMSAMMENDRAG
	2.	PRODUKTSAMMENDRAG
3.	BESKRIVELSE AV INTERESSENTER OG BRUKERE
	1.	OPPSUMMERING INTERESSENTER
	2.	OPPSUMMERING BRUKERE
	3.	BRUKERMILJØET
	4.	SAMMENDRAG AV BRUKERNES BEHOV
	5.	ALTERNATIVER TIL VÅRT PRODUKT
4.	PRODUKTOVERSIKT
	1.	PRODUKTETS ROLLE I BRUKERMILJØET
	2.	FORUTSETNINGER OG AVHENGIGHETER
5.	PRODUKTETS FUNKSJONELLE EGENSKAPER
6.	IKKE-FUNKSJONELLE EGENSKAPER OG ANDRE KRAV
7.	REFERANSER

<br><br><br><br>

### REVISJONSHISTORIE

| Dato | Versjon | Beskrivelse | Forfatter |
| --- | --- | --- |  --- | 
| 25/01/2022 | 1.0 | Første utkast | Olav Pete |
| 01/03/2022 | 1.1 | Mer teknisk beskrivelse | Olav Pete |
			
<div style="page-break-after: always;"></div>

 
## 1	INNLEDNING

Prosjektet ble startet etter at vi ble invitert til Dykkerutdanningen på HVL for å diskutere mulighet for å utvikle en digital simulering av dykkerpost til bruk i utdanningen av dykkerledere. Problemstillingen vi diskuterer i dette dokumentet er rettet mot hva denne løsningen kan bidra med for dykkerutdanningen som ikke allerede eksisterer i markedet, og hvordan det kan påvirke sikkerheten for dykkerne.

## 2	SAMMENDRAG PROBLEM OG PRODUKT
### 2.1	Problemsammendrag

I dagens utdanning av Dykkerledere er det kun fysisk trening på dykkerpostene som er tilgjengelig, dette medfører at for å få trening med dykkerposten så er man nødt til å ha dykkere i vannet som da utsetter seg selv for potensielle farer (Det er selvfølgelig en del av dykkerutdanningen å utdanne dykkere også, men man kan ikke se bort ifra at det medfører en viss risiko). Hovedsakelig vil dette være en løsning for dykkerledere  til å kunne øve seg på å bruke panelet risikoene som medfølger dykking. Dette åpner opp for at flere kan ta utdanningen som dykkerleder, og at man kan øve på scenarioer som man ellers ikke kunne grunnet risikoen til dykkerne.

### 2.2	Produktsammendrag

For Dykkerutdanningen ved HVL som har et behov for dette programmet i utdanningen av dykkerledere, vil DivingEd være et godt system for å skille utdanningen av dykkerlederne fra risikoen det er å ha fysiske dykkere i vannet. I motsetning til [Systemet som eksisterer i dag (Australia)] har vårt produkt en mye lavere kostnad, er utviklet for å kunne adapteres i VR og for å utvikles til å kunne simulere alle aspekter ved dykker og dykkerleder-utdanning.

<div style="page-break-after: always;"></div>

## 3	BESKRIVELSE AV INTERESSENTER OG BRUKERE
### 3.1	Oppsummering interessenter

| Navn | Utdypende beskrivelse | Rolle under utviklingen |
| --- | --- | --- |
| Finn Hansen | Avdelingsleder, Dykkerutdanningen på HVL. | Oppdragsgiver |
| Johnny Jensen | Seniorkonsulent, Dykkerutdanningen på HVL | Kontaktperson for nødvendig informasjon fra dykkerutdanningen |

### 3.2	Oppsummering brukere

| Navn | Utdypende beskrivelse | Rolle under utviklingen | Representert av |
| --- | --- | --- | --- |
| Dykkerutdanningen ved HVL | Studenter og lærere ved Dykkerutdanningen på HVL | Systemtestere og kilde til nødvendig informasjon | Lærere og veiledere.

### 3.3	Brukermiljøet

Programmet skal brukes i dagens utdanning av Dykkerledere og brukes i undervisningen av lærerne og dykkerlederstudentene. Studentene skal kunne prøves i scenarioer som skal kunne lastes inn i programmet, programmet ta opp en logg av alle hendelser og kunne brukes til en debrief av dykkerlederen i etterkant av scenarioet. Lærerne vil i utgangspunktet kunne bruke ferdiglagde scenarioer til opplæring av studentene men vil også kunne lage egne scenarioer der det er behov. Scenarioene skal bestå av en kombinasjon av "fysisk" justering av ventiler, regulatorer med musepekeren og avlesning av målere og det vil også være avlytting av verbale kommandoer som skal være kommunikasjon til dykkerne.

### 3.4	Sammendrag av brukernes behov

| Behov | Prioritet | Påvirker | Dagens løsning | Foreslått løsning |		
| --- | --- | --- | --- | --- |
| Dykkerpost | 1 | Lærere og studenter | Fysisk dykkerpost | Modellere en relativt enkel modell av den fysiske dykkerposten |
| Debrief | 2 | Lærere og studenter | Verbal gjennomgang av sesjonen på dykkerpost | Logg etter endt scenario, mulighet for gjennomgang av alle detaljer og valg studenten gjorde |
| Dykkere i vannet | 3 | Dykkerne | Dykkere i vannet og standby | Simulere dybde og relativ posisjon i forhold til markører |
| Realistisk simulering av trykk og dybde | 4 | Lærere, studenter og dykkere | Sitte på fysisk dykkerpost med dykkere i vannet | Nodebasert simulering av trykk og dybde av dykkerpost og dykkere |
|  |  |  |  |  |

### 3.5	Alternativer til vårt produkt

Vi har fått informasjon om at det eksisterer en fysisk simulator i Australia (? må ha mer informasjon om dette fra dykkerutdanningen), dette systemet vet vi koster en god del penger.

<div style="page-break-after: always;"></div>

## 4	PRODUKTOVERSIKT
### 4.1	Produktets rolle i brukermiljøet

DivingEd skal brukes som utdanningsverktøy og gi dykkerlederene mulighet for mer tid fremfor dykkerposten for å øve på scenarioer i jobbmiljø eller farlige situasjoner der det vil utøve en risiko å øve med dykkere.

### 4.2	Forutsetninger og avhengigheter

- Brukertesting 
- Tidsklemme
- Endring av prosjektplan eller forventninger om produktet
- 

<div style="page-break-after: always;"></div>

## 5	PRODUKTETS FUNKSJONELLE EGENSKAPER

- Realistisk simulering av trykk og dybde, trenger teknisk informasjon for dykkerposten vi skal simulere korrekt, eventuelt bruk av kilder på nett til <cite>approksimering[1]<cite>.
- 

## 6	IKKE-FUNKSJONELLE EGENSKAPER OG ANDRE KRAV

- Unity 2020.3.25f1
	- URP


## 7	REFERANSER

[1] https://www.researchgate.net/publication/235125932_Gas_Flows_Supporting_Umbilical_Diving_-_Requirements_and_Measurements