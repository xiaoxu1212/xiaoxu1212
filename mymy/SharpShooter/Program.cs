using System;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using SharpShooter.Champions;

namespace SharpShooter
{
    internal class Program
    {
        private static readonly string[] Champions = new[] { "Vayne" };

        private static void Main(string[] args)
        {
            GameEvent.OnGameLoad += OnGameLoad;
        }

        private static void OnGameLoad()
        {
            // do your auth before script load first
            // or check champion support or not 

            // example:

            // for single champion check
            //if (GameObjects.Player.CharacterName != "aaa") return;

            // for Aio check
            //string[] yourAiosupport = new[] {"aa", "bb", "cc"};
            //if (!yourAiosupport.Contains(GameObjects.Player.CharacterName)) return;

            // in here i wont be add more auth or any check logic in here
            // if you want to find a simple auth system
            // just try to use https://auth.gg/

            string ChampionName = GameObjects.Player.CharacterName;

            // not support
            if (!Champions.Contains(ChampionName))
            {
                return;
            }

            bool isLoad = true;

            // Load champion script
            switch (ChampionName)
            {
                case "Vayne":
                    new Vayne();
                    break;
                default:
                    isLoad = false;
                    break;
            }

            // Pring load successful message in game and console
            if (isLoad)
            {
                Console.WriteLine($"[SharpShooter]: {ChampionName} Load Successful! Made By NightMoon");
                Game.Print("<font size='26'><font color='#9999CC'>SharpShooter</font></font> <font color='#FF5640'> Load Successful! Made By NightMoon</font>");
            }
        }
    }
}