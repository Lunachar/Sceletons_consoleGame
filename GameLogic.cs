namespace Skeletons;

public class GameLogic  // contains the logic for applying game bonuses to the player
                        // and skeletons
{

    public GameLogic(PlayerForGame superPlayer, Sceleton2Manager sceletons, int bonus)
    {
        if (bonus == 1 && !BonusController.BonusUsed)
        {
            superPlayer.weapon.Damage *= 2;
            BonusController.BonusUsed = true;
        }
        else if (bonus == 2 && !BonusController.BonusUsed)
        {
            int maxHealth = 0;
            Sceleton2 maxSceletonHealth = null;
            
            foreach (var scel in sceletons)
            {
                if (scel.Health > maxHealth)
                {
                    maxHealth = scel.Health;
                    maxSceletonHealth = scel;
                }
            }

            if (maxSceletonHealth != null)
            {
                maxSceletonHealth.Health /= 2;
            }
            BonusController.BonusUsed = true;
        }
        else if (bonus == 3 && !BonusController.BonusUsed)
        {
            superPlayer.Health += 100;
            BonusController.BonusUsed = true;
        }
        else if (bonus == 0)
        {
            superPlayer.ResetDamage();
        }
    }
}