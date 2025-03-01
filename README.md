Deze repository bevat code om te laten zien hoe snel GPU's kunnen zijn ten opzichte van CPU's. Dit is wel een erg optimaal voorbeeld, want in een echt scenario moet er nog rekening worden gehouden met de tijd om data heen en weer te kopiëren bijvoorbeeld. Toch geeft dit wel een goede indicatie.

* CPU.cs is de code die draait op de CPU.
* GPU.cs is de code die draait op de CPU, maar instructies geeft aan de GPU.
* SineCompute.compute is de code die daadwerkelijk op de GPU draait en dezelfde berekeningen uitvoert als CPU.cs.
