# entmob2016_7
#Project Enterprise & Mobile: Fitsense

##Probleemstelling
Bewegen is een belangrijk onderdeel in gezond leven, maar we doen het niet allemaal even regelmatig. Wij willen ze daar mee helpen. Omdat mensen tegenwoordig altijd hun smartphone bij de hand hebben, willen we dit gebruiken om de beweging te monitoren en mensen er regelmatig aan te herinneren dat ze moeten bewegen.

##Stappenplan
1. Data van de Sensortag naar de mobile app sturen via Bluetooth
2. Data opslagen in SQLite database op het mobile device met de mobile app
3. Data lezen van de SQLite database via de mobile app
4. Data naar de server side (spring) sturen via rest
5. data naar de database sturen via spring
6. data lezen uit de database via spring
7. data opvragen naar de UWP app via een REST call naar spring (server side)

##Doelstelling
###De sensorTag
De sensor tag zal meten hoeveel de gebruiker gaat bewegen aan de hand van de bewegingssensoren. Hiermee kunnen we bepalen hoeveel de gebruiker nog extra moet bewegen om aan zijn doel te geraken. De sensor zal ook gebruikt worden bij de extra oefeningen om te meten dat deze juist uitgevoerd worden. Een voorbeel van een idee om te oefenen was pong. Hier zouden we dan een linkerafstand en rechterafstand afbakenen. In deze afstand kon je dan bewegen met de sensor om in de app te bewegen en de bal te kaatsen. Hoe realistisch dit is aan de hand van update tijd valt nog te zien. Het idee is dus om beweging te meten met de tag en aan de hand hiervan een score op te maken. De sensor die dus het meeste gebruikt zal worden is de accelometer.

###De Xamarin app
Onze applicatie zal data verzamelen over de gebruiker tijdens zijn dagelijkse activiteiten en zal de gebruiker helpen om actiever bezig te zijn. Aanvullend op de gewone dagactiviteiten van de gebruiker kan de gebruiker extra “health points” verdienen. Dit doen we door middel van kleine games of oefeningen aan de gebruiker te geven. Per beweging kan hij/zij “health points” verzamelen. Er wordt dagelijks gekeken hoeveel “health points” de gebruiker verzamelt. Achteraf kan alle verzamelde data geanalyseerd worden.
Ook zal het mogelijk zijn om in de Xamarin app een beperkte geschiedenis van de gegevens/grafieken met de bewegingsdata op te vragen.

###De UWP applicatie
De UWP applicatie biedt een uitgebreidere weergave van alle gegevens. Dit zal gebeuren aan de hand van grafieken. Wekelijks gemiddelde (health points, verticaal bewegen, horizontaal bewegen), dagelijkse gemiddeldes, grafiek met verschillen ten opzichte van de vorige dag (vooruitgang of achteruitgang is hier zichtbaar)

##Data
Temperatuur + Vochtigheid + barometer : We zullen deze gegevens bijhouden om de weerscondities bij te houden gedurende de dag en tijdens de oefeningen. Zo kunnen we afleiden of bepaalde handelingen zwaarder waren vanwegen de warmte of lage luchtvochtigheid.
Accelerometer + Altimeter + gyroscoop : Worden gebruikt voor het bepalen van de beweging van de persoon. Deze data wordt niet "raw" bijgehouden in de database maar worden gebruikt bij het afleiden van de "health points".

##Architectuur
![alt text](https://github.com/pxlit-projects/entmob2016_7/blob/master/Architecture%20design.PNG "Architectuur")

1. Data van de bewegingssensoren (accelerometer,...). Zo weten we hoeveel de gebruiker gaat bewegen
2. Json data met de verwerkte data van de bewegingssensoren (verwerkt in de app), bijvoorbeeld afgelegde afstand, hoogtemeters...
3. Json data met de verwerkte data uit de database: de verwerkte data opvragen om dan in een mooier formaat weer te geven


We hebben gekozen om de sensorTag te laten communiceren met de Xamarin app, om één grote reden, bereik. De sensorTag kan enkel communiceren via Bluetooth, wat maakt dat het device waarmee gecommuniceerd moet worden nooit ver weg mag zijn. Omdat een smartphone tegenwoordig niet meer weg te denken is in het dagelijks leven, is een app op de smartphone (geschreven in Xamarin) ideaal. 
Vervolgens is er besloten om de Xamarin app te laten communiceren met de Spring Webhost. Deze keuze werd gemaakt omdat er meerdere applicaties gebruik moeten kunnen maken van de data. Een 'dedicated' webhost die alle communicatie regelt met de database is dus aangewezen. De communicatie van de Xamarin app en de webhost verloopt dubbelzijdig. Dit omdat de Xamarin app zowel data zal aanleveren aan de serverside, als data zal opvragen.
Als laatste communiceert de serverside nog met de UWP applicatie (desktop) om meer gegevens te kunnen tonen die in de Xamarin app kunnen worden weergegeven. Ook deze communicatie zal dubbelzijdig verlopen.

##Taak verdeling
Server side: Bert, Kim  
Client side: Daniël, Dries

Om de twee weken zal er gewisseld worden tussen server en client side programmeurs.

##Extra
<ul>
<li>Running modes. Jog sessie starten en stoppen.</li>
<li>Je behaalde “Health Points” vergelijken met vrienden.</li>
</ul>

SQL server settings:
	ip address: 84.195.1.59
	user: user		
	password: pass


