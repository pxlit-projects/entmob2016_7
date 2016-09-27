# entmob2016_7
#Project Enterprise & Mobile: Fitness app

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

##Taak verdeling
Server side: Bert, Kim  
Client side: Daniël, Dries

Om de twee weken zal er gewisseld worden tussen server en client side programmeurs.

##Extra
<ul>
<li>Running modes. Jog sessie starten en stoppen.</li>
<li>Je behaalde “Health Points” vergelijken met vrienden.</li>
</ul>


