$naamfile = import-csv .\data.txt

foreach($person in $naamfile)
{
	echo "Uw Naam" +$person.naam
	echo "Uw Achternaam" +$person.achternaam
}