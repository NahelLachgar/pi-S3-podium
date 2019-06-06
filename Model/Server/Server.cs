﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Model
{
    public class Server
    {
        public Game _game;
        internal static Thread _ListenTh;
        internal static bool _isListening = true;
       // internal UdpClient _server;


        public Server(Game game)
        {
            _game = game;
            //_server = new UdpClient(5035);

        }

        internal void StartServer()
        {
            //Préparation et démarrage du thread en charge d'écouter.
            _ListenTh = new Thread(new ThreadStart(Listen));
            _ListenTh.Start();
        }

        internal void Listen()
        {
            UdpClient _server = new UdpClient(5035);

            //Création d'une boucle infinie qui aura pour tâche d'écouter.
            while (_isListening)
            {
                //On crée le serveur en lui spécifiant le port sur lequel il devra écouter.

                //Création d'un objet IPEndPoint qui recevra les données du Socket distant.
                IPEndPoint client = null;
                //On écoute jusqu'à recevoir un message.
                byte[] data = _server.Receive(ref client);
               string key = Encoding.Default.GetString(data);
                Send(key);
            }
        }
        internal void Send(string key)
        {
            _game._controls.Update(key);
            Thread.Sleep(1);
            Console.WriteLine(key);
        }
    }
}