using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SocialGames
{
    public class GameData : Game1
    {
        // nameFile è utilizzato per contenere il nome del file di gioco da caricare per i dialoghi
        // Deve contenere anche l'estensione del file
        public static string nameFile = "";

        // Questi sono i dialoghi del gioco, sono aggiornati quando viene avviato un nuovo gioco
        public static string title = null;
        public static string firstPrompt = null;
        public static string firstQuest = null;
        public static string initEmotion = null;
        public static Answer afp = new Answer();
        public static Answer bfp = new Answer();
        public static Answer cfp = new Answer();
        public static string secondPrompt = null;
        public static string secondQuest = null;
        public static Answer asp = new Answer();
        public static Answer bsp = new Answer();
        public static Answer csp = new Answer();

        public static int rewardAmount = 0;
        // background e avatar contengono il nome dei file di avatar e di sfondo
        // da caricare nel gioco
        // background e avatar non devono contenere l'estensione del file
        public static string background = "Park";
        public static string avatar = "";
        public static bool isCapital = false;
        public static bool isSaturated = true;

        // Variabile utile a memorizzare la pagina di storie visualizzata in seleziona storia
        public static int page = 1;

        // Timer necessario per evitare la pressione ravvicinata di due tasti 
        public static TimeSpan timeSpan = Const.TIMER;
        // Timer di interruzione del gioco, settabile dall'utente
        public static Timer timer;
        // Variabile utile a determinare quando ci si trova alla selezione di storia/avatar dopo lo START
        public static bool isStart = false;
        // Variabile utile a distinguere se il background "class" si riferisce a "Rispondere sbagliato" o "Alzare la mano"
        public static bool isAlzare = false;
        // Variabile utile a gestire la storia "Fidanzamento"
        public static bool isFidanz = false;
        // Variabile utile a conoscere il sesso dell'avatar
        public static bool isMale = false;
    }
}

