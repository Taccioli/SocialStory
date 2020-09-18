# SocialGames
## Introduzione all’applicazione
SocialGames è una applicazione sviluppata con l’obiettivo di digitalizzare e rendere più interattivo l’insegnamento attraverso le storie sociali.

Le storie sociali sono un metodo di insegnamento utilizzato principalmente per insegnare a persone affette da disturbo dello spettro autistico come comportarsi in determinate situazioni più o meno comuni, attraverso l’utilizzo di brevi storie in cui il protagonista spiega le emozioni che si possono provare in una determinata situazione e come poterle gestire per avere un comportamento socialmente accettabile. Queste storie vengono lette o fatte leggere numerose volte affinché la persona possa memorizzare come comportarsi.

L’applicazione riporta al suo interno dodici di queste brevi storie, aggiungendo inoltre un elemento interattivo: è infatti possibile “partecipare” alla storia scegliendo le azioni che sembrano più opportune e venire premiati se si sceglie la risposta esatta.

## Funzionamento
Il funzionamento dell’applicazione è semplice: all’apertura si apre un menù (Fig.1) in cui è possibile avviare una partita, selezionare una storia o un avatar con cui giocare o modificare le impostazioni del gioco.

![Fig1](images/Fig1.png?raw=true "Fig1")
*Figura 1 - Menù Generale*

Nel caso in cui si cliccasse su “IMPOSTAZIONI” si aprirebbe il relativo menu (Fig.2), in cui è possibile selezionare:

-	Il tempo di gioco (10, 20 o 30 minuti), allo scadere del quale l’applicazione viene bloccata ed è richiesto di uscire
-	La possibilità di mostrare le scritte del gioco in caratteri maiuscoli o minuscoli, per facilitare la lettura a chi non fosse in grado di leggere le scritte in caratteri minuscoli
-	La possibilità di utilizzare colori più tenui in tutte le schermate, perché alcune persone affette da disturbo dello spettro autistico possono avere problemi a visualizzare colori troppo accesi

![Fig2](images/Fig1.png?raw=true "Fig2")
*Figura 2 - Menù impostazioni*

Nel caso in cui si cliccasse il tasto “START” e non fossero ancora stati scelti storia e avatar, si verrebbe reindirizzati alla selezione dell’avatar (Fig.3) e successivamente alla selezione del gioco (Fig.4), prima di avviare la storia. Questi due menu sono raggiungibili anche cliccando direttamente i tasti “SCEGLI IL GIOCO” e “SELEZIONA AVATAR” nel menu principale. In tal caso, cliccando sul tasto “START” dopo le selezioni, il giocatore verrebbe reindirizzato subito all’esperienza di gioco.

![Fig3](images/Fig1.png?raw=true "Fig3")
*Figura 3 - Menù selezione avatar*

![Fig4](images/Fig1.png?raw=true "Fig4")
*Figura 4 - Menù selezione storia da giocare*

Una volta avviata la storia si aprirà una schermata di gioco (Fig.5), in cui a sinistra possiamo notare il personaggio e, davanti a questo, un riquadro in cui viene riportato il titolo e narrata una parte della vicenda. A destra abbiamo la domanda su che azione dovrebbe compiere il giocatore e sotto le risposte (le possibili azioni) che questo può dare. In alto a destra è mostrato il numero di risposte corrette date nella sessione di gioco.

![Fig5](images/Fig1.png?raw=true "Fig5")
*Figura 5 - Schermata di gioco*

A seguito della risposta data dal giocatore l’emozione mostrata dal personaggio cambierà, e in caso venga data una risposta corretta il personaggio mostrerà una espressione felice.

Inoltre, indipendentemente dalla correttezza della risposta, viene mostrato un piccolo suggerimento (Fig.6) spesso scritto in prima persona, dato al giocatore a rinforzo della risposta corretta oppure, nel caso avesse sbagliato, che possa portarlo a correggersi.

![Fig6](images/Fig1.png?raw=true "Fig6")
*Figura 5 - Schermata di gioco*

Se il giocatore dà la risposta corretta gli verrà poi mostrata la seconda parte della storia, in alternativa gli verrà mostrata nuovamente la prima parte.

Le storie sono composte da due parti e al completamento di queste viene chiesto all’utente se vuole tornare al menù principale o continuare a giocare, cambiando la storia.

## Implementazione per Android
Il gioco è stato inoltre implementato per funzionare anche su dispositivi con sistema operativo Android (minimo versione 8.1), per poter permettere una maggiore utilizzabilità.

L’aspetto del gioco è tuttavia rimasto invariato per mantenerne la semplicità di visualizzazione, per questo è consigliato l’utilizzo su tablet, invece che su telefono.

## Aspetti tecnici
### Struttura del codice
Il codice è stato scritto per implementare una macchina a stati, utilizzata per gestire tutte le schermate di cui è composto il gioco. È infatti presente una classe State, utilizzata come classe astratta base contenente i metodi di Draw(), Update() e PostUpdate() necessari al funzionamento della macchina a stati.

### Game1
Nella classe Game1 abbiamo la gestione della macchina a stati: viene inizializzato il primo stato (MenuState) nel metodo LoadContent(), in Update() viene aggiornato lo stato della macchina e successivamente richiamato il metodo Update() di questo ed infine nel metodo Draw() viene richiamato l’omonimo metodo dello stato attuale. Nel metodo Draw() è anche gestita l’applicazione del filtro per rendere i colori più tenui.

### States
Nella cartella States sono contenute la classe State citata precedentemente e le sette classi che compongono i vari stati del gioco:

-	EndGameState, che gestisce la schermata che compare al termine di una partita
-	EndTimeState, che gestisce la schermata che compare allo scadere del tempo limite di gioco
-	GameState, che gestisce 
-	MenuState, che è il menù iniziale
-	SelAvatarState, che gestisce il menù di selezione dell’avatar
-	SelStoryState, che gestisce il menù di selezione della storia da giocare
-	SettingsState, da cui è possibile cambiare le impostazioni

### MenuState
Questo stato si riferisce al menu che viene visualizzato all’avvio del gioco. Ciascun bottone presente nella schermata è associato ad un oggetto della classe MenuButton, all’interno della quale sono contenuti i metodi Draw() e Update() (utilizzati nel Draw() e nell’Update() dello stato), i quali gestiscono, rispettivamente, la visualizzazione sullo schermo del bottone stesso e il passaggio allo state a cui fa riferimento.

### GameState
Quando viene chiamato questo stato, viene preso dalla memoria il file formato .xml corrispondente alla storia precedentemente selezionata e viene letto (metodo Read()) nelle sue parti per gestire i vari dialoghi e risposte, oltre alle emozioni che dovrà mostrare l’avatar. Successivamente sono state implementati due metodi (AdaptiveText() e WrapText()) che hanno gestito sia il wrapping del testo di modo che potesse essere contenuto dentro un riquadro, sia un possibile ridimensionamento dei caratteri se la stringa da scrivere dentro il rettangolo fosse troppo lunga.

Per rendere più veloce il metodo Draw() si è deciso di evitare degli switch case all’interno di questo.

### SettingsState
In questo stato è possibile impostare dopo quanto il gioco obbligherà il giocatore a chiudere l’applicazione (andando a modificare la variabile GameData.timer.remainingDelay), se le scritte mostrate durante il gioco debbano essere maiuscole o meno (modificando la variabile GameData.isCapital) e se i colori debbano essere tenui o meno (GameData.isSaturated).

### SelAvatarState
All’interno di questo stato è possibile scegliere l’avatar che andrà a “rappresentare” il giocatore nell’esperienza di gioco. Ciascun avatar fa riferimento ad un oggetto della classe SelAvatarButton, all’interno della quale sono implementati i metodi SelAvatarButton.Draw() e SelAvatarButton.Update(). In quest’ultimo, grazie ad uno switch, viene riconosciuto l’avatar selezionato dall’utente ed in base a questo viene modificata la variabile GameData.avatar con il nome corrispondente (Boy1, Girl1…) e la variabile GameData.isMale con true o false.

### SelStoryState
Questo è lo stato nel quale l’utente ha la possibilità di selezionare la storia da giocare. Ciascuna storia selezionabile è rappresentata da un’istanza della classe SelStoryButton, nella quale, equivalentemente a SelAvatarButton, è implementato all’interno del metodo SelStoryButton.Update() uno switch utile a modificare, in base alla selezione dell’utente, le variabili GameData.background e GameData.nameFile. Queste memorizzano, rispettivamente, l’immagine utilizzata come sfondo nell’esperienza di gioco e il nome del file xml a cui la storia selezionata fa riferimento.

### Commands
Nella cartella Commands si può trovare la classe astratta Component, utilizzata come classe base per tutte le classi atte a gestire i pulsanti del gioco.

Ogni pulsante basa il suo funzionamento sull’individuazione della posizione del cursore nello schermo e successivamente calcolare se questo stia entro i limiti della sprite che lo raffigura.

È stato implementato inoltre per ogni pulsante un effetto grafico che ne simulasse la pressione quando il mouse è posizionato sopra di questo, per aiutare i giocatori a comprendere cosa stanno per cliccare.

### Data
La cartella Data contiene invece, come suggerisce il nome, le classi con tutti i dati necessari al funzionamento corretto del gioco:

-	Const contiene dei dati che non cambiano durante il funzionamento dell’applicazione
-	GameData contiene invece i dati necessari al funzionamento dello stato GameState, come il nome della storia o i vari dialoghi
-	Reward contiene il valore attuale del numero di risposte corrette date nella partita e gestisce il disegno durante il GameState di questo
-	Timer contiene il dato inerente al tempo massimo di gioco e assicura che questo non venga sforato

## Versione Android
L’implementazione per Android ha richiesto due cambiamenti principali: la gestione del touchscreen al posto del mouse come input da parte dell’utente e la possibilità di riadattare i contenuti a schermi di diverse risoluzioni e dimensioni.

### Gestione del touchscreen
Per gestire il touchscreen sono state in parte riscritte tutte le classi della cartella Commands: al posto di controllare posizione e click del mouse, si è dovuto verificare se ci fossero tocchi sulla zona dei vari pulsanti e successivamente se il tocco venisse rilasciato.

In questa implementazione dell’applicazione, se un pulsante viene premuto, e per tutta la durata della pressione, mostra la sua sprite da “premuto” per aiutare graficamente il giocatore a capire cosa ha premuto. Successivamente, se il dito non viene trascinato fuori dalla zona del pulsante, appena si rilascia il tocco il pulsante attiva la sua azione, gestita normalmente dal codice dello stato.

### Riadattamento dimensioni
Essendo gli schermi dei tablet molto diversi tra loro in proporzioni e risoluzione, è stato necessario gestire questa diversità implementando un’interfaccia grafica che permettesse di mantenere la funzionalità e l’aspetto di tutte le componenti mostrate sullo schermo.

Per fare ciò, si è deciso di utilizzare un’interfaccia “base” con risoluzione 1920x1080 pixel e successivamente creare una matrice di scalamento che, data la risoluzione dello schermo del dispositivo su cui gira il gioco, permette di effettuare un’operazione di trasformazione dell’immagine mostrata attraverso il parametro transformMatrix nel metodo Draw() chiamato nella classe Game1.




