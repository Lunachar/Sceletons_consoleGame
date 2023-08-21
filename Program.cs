using System;
using System.Collections.Generic;
using Skeletons;

namespace Skeletons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menuNumber = 0;
            while (menuNumber != 4)
            {
                Console.WriteLine("Welcome. \n Please,choose program and press Enter:\n" +
                                  " 1. Sceleton manager demonstration.\n" +
                                  " 2. Player vs. sceletons combat game.\n" +
                                  " 3. old (Player vs. sceletons combat game.(Significant refactoring is required)).\n" +
                                  " 4. Exit.");
                int.TryParse(Console.ReadLine(), out menuNumber);
                string separator = new string('=', 55);
                
                switch (menuNumber)
                {
                    case 1:
                        Console.WriteLine(separator);

                        var Sceletons = new Sceleton2Manager();
                        for (int i = 0; i < new Random().Next(2, 6); i++)
                        {
                            Sceletons._sceletons.Add(new Sceleton2(SettingRarity.Rarity()));
                        }

                        foreach (var sceleton in Sceletons)
                        {
                            Console.WriteLine(sceleton);
                            Console.WriteLine(separator);
                        }


                        Console.WriteLine($"SummaryDamage = {Sceletons.AllSceletonDamage()}\n" +
                                          $"Count: {Sceletons._sceletons.Count()}");
                        Sceletons.GetEnumerator().Reset();
                        
                        var enumerator = Sceletons.GetEnumerator();
                        enumerator.MoveNext();
                        var currentSceleton = enumerator.Current;
                        Console.WriteLine("\n Skeleton on first position");
                        Console.WriteLine(currentSceleton);
                        enumerator.MoveNext();
                        var currentSceleton2 = enumerator.Current;
                        Console.WriteLine("\n Skeleton on second position");
                        Console.WriteLine(currentSceleton2);
                        
                        Console.WriteLine("Reversing. Press Enter...");
                        Console.ReadLine();
                        Sceletons._sceletons.Reverse();
                        foreach (var sceleton in Sceletons)
                        {
                            Console.WriteLine(sceleton);
                            Console.WriteLine(separator);
                        }

                        Console.WriteLine("Inserting Legendary Sceleton in the 1 position. Press Enter...");
                        Console.ReadLine();
                        Sceletons._sceletons.Insert(0, new Sceleton2("legend"));
                        foreach (var sceleton in Sceletons)
                        {
                            Console.WriteLine(sceleton);
                            Console.WriteLine(separator);
                        }

                        Console.WriteLine("Count:" + Sceletons._sceletons.Count());
                        Console.WriteLine("Clear all. Press Enter...");
                        Console.ReadLine();
                        Sceletons._sceletons.Clear();
                        Console.WriteLine("Count:" + Sceletons._sceletons.Count());
                        break;

//////////////////////////////////////////////////////////////////////////////

                    case 2:
                        PlayerForGame SuperPlayer = new();
                        var SceletonsForGame = new Sceleton2Manager();
                        var random = new Random();
                        int turns = 1;
                        int bonusSelect = 0;
                        SuperPlayer.OnPlayerDeath += SuperPlayer.PlayerDeathDelegate;
                        
                       

                        for (int i = 0; i < random.Next(2, 6); i++)
                        {
                            SceletonsForGame._sceletons.Add(new Sceleton2(SettingRarity.Rarity()));
                        }

                       

                        while (SuperPlayer.Health > 0 && SceletonsForGame.Any())
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine(separator);
                            Console.WriteLine(SuperPlayer);
                            Console.ResetColor();
                            Console.WriteLine(separator);
                            Console.WriteLine();
                            Console.WriteLine(separator);
                            
                            foreach (var sceleton in SceletonsForGame)
                            {
                                sceleton.weapon = sceleton.GenerateWeapon();
                                if (sceleton.weapon is MagicWeapon magicWeapon)
                                {
                                    magicWeapon.ApplyHealthBonus(sceleton);
                                }
                                Console.WriteLine(sceleton);
                                Console.ResetColor();
                                Console.WriteLine(separator);
                                
                                sceleton.Health -= SuperPlayer.weapon.Damage;
                            }
                           
                            SuperPlayer.Health -= SceletonsForGame.AllSceletonDamage();
                            Console.WriteLine($"SummaryDamage = {SceletonsForGame.AllSceletonDamage()}\n" +
                                              $"Number of enemies: {SceletonsForGame._sceletons.Count}");
                            Console.WriteLine($" Turn: {turns}");
                            Console.WriteLine();
                            Console.WriteLine(BonusController.BonusUsed ? "Let`s test your luck! Press Enter." : BonusMenu.MenuDisplay(SuperPlayer));
                            if (bonusSelect==1)
                            {
                                SuperPlayer.ResetDamage();
                            }
                            if (!BonusController.BonusUsed)
                            {
                                int.TryParse(Console.ReadLine(), out bonusSelect);
                                BonusController.BonusSelect = bonusSelect;
                            }

                            GameLogic gameLogic = new GameLogic(SuperPlayer, SceletonsForGame, BonusController.BonusSelect);
                            
                            Console.ReadLine();
                            SceletonsForGame.RemoveSceleton();
                            turns++;
                        }
                        var endGameMessage = new EndGameConsoleMessage(SuperPlayer, SceletonsForGame, turns);

                        endGameMessage.ToString();
                        BonusController.BonusUsed = false;
                        break;

////////////////////////////////////////////////////////////////////////////

                    case 3:
                        Player player = new Player();

                        while (player.health > 0 && EnemyManager.Count() > 0)
                        {
                            player.Print();
                            Console.WriteLine($"Number of enemies: {EnemyManager.Count()}");

                            foreach (var enemy in EnemyManager.enemies)
                            {
                                EnemyManager.Print(enemy);
                            }

                            EnemyManager.SkeletonGetDamage(player.Damage());
                            player.PlayerGetDamage(EnemyManager.DoDamage());

                            Console.WriteLine($"All Enemy Damage: {EnemyManager.DoDamage()} \n" +
                                              $"Press Enter for next turn...");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        if (EnemyManager.Count() < 1 && player.health > 0)
                        {
                            Console.WriteLine($"-== Player health: {player.health} ==- \n");
                            Console.WriteLine($"Number of enemies: {EnemyManager.Count()} \n");
                            Console.WriteLine("Player win.");
                            Console.ReadLine();
                        }
                        else if (EnemyManager.Count() > 0 && player.health < 1)
                        {
                            Console.WriteLine($"-== Player health: {player.health} ==- \n");
                            Console.WriteLine($"Number of enemies: {EnemyManager.Count()} \n");
                            Console.WriteLine("Enemy win.");
                            Console.ReadLine();

                        }
                        else
                        {
                            Console.WriteLine($"-== Player health: {player.health} ==- \n");
                            Console.WriteLine($"Number of enemies: {EnemyManager.Count()} \n");
                            Console.WriteLine("Everybody died.");
                            Console.ReadLine();

                        }

                        break; 
                    
////////////////////////////////////////////////////////////////////////////

                    case 4:
                        Console.WriteLine("Finishing...");
                        break;
                    
                    default:
                        Console.WriteLine("You enter wrong data.");
                        break;
                }
            }
        }
    }
}