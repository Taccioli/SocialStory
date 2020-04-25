﻿using System;
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
        public static string nameFile = "Gioco.xml";

        // Questi sono i dialoghi del gioco, sono aggiornati quando viene avviato un nuovo gioco
        public static string title = null;
        public static string firstPrompt = null;
        public static string firstQuest = null;
        public static string afp, bfp, cfp = null;
        public static string oafp, obfp, ocfp = null;
        public static string secondPrompt = null;
        public static string secondQuest = null;
        public static string asp, bsp, csp = null;
        public static string oasp, obsp, ocsp = null;
        public static int ans1, ans2 = 0;

        public static int rewardAmount = 0;
        // background e avatar contengono il nome dei file di avatar e di sfondo
        // da caricare nel gioco
        // background e avatar non devono contenere l'estensione del file
        public static string background = "Park";
        public static string avatar = "";
        public static string story = "";

        // Variabile utile a memorizzare la pagina di storie visualizzata in seleziona storia
        public static int page = 1;

        // Timer necessario per evitare la pressione ravvicinata di due tasti 
        public static TimeSpan timeSpan = Const.TIMER;

        // Variabile utile a determinare quando ci si trova alla selezione di storia/avatar dopo lo START
        public static bool isStart = false;

    }
}

