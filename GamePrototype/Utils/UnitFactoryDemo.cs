using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public class UnitFactoryDemo
    {
        public static Unit CreatePlayer(string name)
        {
            var player = new Player(name, 35, 35, 8);
            player.AddItemToInventory(new Weapon(10, 15, "Sword"));
            player.AddItemToInventory(new Armour(30, 15, "Armour"));
            player.AddItemToInventory(new HealthPotion("Potion"));
            player.AddItemToInventory(new Grindstone("Stone"));
            return player;
        }


        public static Unit CreateGoblinEnemy(ChooseDifficulty difficulty)
        {
            return difficulty switch
            {
                ChooseDifficulty.Easy => CreateEasyGoblinEnemy(),
                ChooseDifficulty.Medium => CreateMediumGoblinEnemy(),
                ChooseDifficulty.Hard => CreateHardGoblinEnemy(),
            };
        }
        private static Unit CreateEasyGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 3);
        private static Unit CreateMediumGoblinEnemy() => new Goblin(GameConstants.Goblin, 24, 24, 10);
        private static Unit CreateHardGoblinEnemy() => new Goblin(GameConstants.Goblin, 31, 31, 15);

    }
}
