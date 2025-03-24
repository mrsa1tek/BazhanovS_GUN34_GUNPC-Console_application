using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils
{
    public static class DungeonBuilder
    {
        public static DungeonRoom BuildDungeon(ChooseDifficulty difficulty)
        {
            var enter = new DungeonRoom("Enter");
            var safeRoom = new DungeonRoom("A quiet room");
            var trapRoom = new DungeonRoom("The Trap Room");

            var easyMonsterRoom = new DungeonRoom("Goblin Post", UnitFactoryDemo.CreateGoblinEnemy(ChooseDifficulty.Medium));
            var mediumMonsterRoom = new DungeonRoom("The Goblin Lair", UnitFactoryDemo.CreateGoblinEnemy(ChooseDifficulty.Medium));
            var bossRoom = new DungeonRoom("The Orc's Lair", UnitFactoryDemo.CreateGoblinEnemy(ChooseDifficulty.Hard));

            var emptyRoom = new DungeonRoom("Empty");
            var puzzleRoom = new DungeonRoom("The Riddle Room");

            var lootItemRoom = new DungeonRoom("Goblin Armory", new RangeWeapon(20, 20, "Crossbow"));
            var lootRoom = new DungeonRoom("The Forgotten Warehouse", new Gold());
            var lootStoneRoom = new DungeonRoom("Goblin Pass", new Grindstone("Stone"));
            var lootRoom1 = new DungeonRoom("A quiet room", new HealthPotion("Small Health Potion"));
            var lootRoom2 = new DungeonRoom("A pile of garbage", new Gold());


            var finalRoom = new DungeonRoom("Сокровищница", new Armour(25,40, "The Guardian's Armor"));


            if (difficulty == ChooseDifficulty.Easy)
            {
                enter.TrySetDirection(Direction.Forward, safeRoom);
                enter.TrySetDirection(Direction.Left, easyMonsterRoom);

                safeRoom.TrySetDirection(Direction.Forward, lootRoom1);
                safeRoom.TrySetDirection(Direction.Right, lootRoom2);

                easyMonsterRoom.TrySetDirection(Direction.Forward, lootRoom2);
                easyMonsterRoom.TrySetDirection(Direction.Left, finalRoom);

                lootRoom1.TrySetDirection(Direction.Forward, finalRoom);
                lootRoom2.TrySetDirection(Direction.Forward, finalRoom);
            }
            else if (difficulty == ChooseDifficulty.Medium)
            {
                enter.TrySetDirection(Direction.Forward, trapRoom);
                enter.TrySetDirection(Direction.Right, easyMonsterRoom);

                trapRoom.TrySetDirection(Direction.Forward, puzzleRoom);
                trapRoom.TrySetDirection(Direction.Left, lootStoneRoom);

                easyMonsterRoom.TrySetDirection(Direction.Forward, mediumMonsterRoom);
                easyMonsterRoom.TrySetDirection(Direction.Right, lootItemRoom);

                mediumMonsterRoom.TrySetDirection(Direction.Forward, bossRoom);
                mediumMonsterRoom.TrySetDirection(Direction.Left, lootRoom);

                puzzleRoom.TrySetDirection(Direction.Forward, finalRoom);
                puzzleRoom.TrySetDirection(Direction.Right, bossRoom);

                lootItemRoom.TrySetDirection(Direction.Forward, bossRoom);
                lootRoom.TrySetDirection(Direction.Forward, finalRoom);
                lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

                bossRoom.TrySetDirection(Direction.Forward, finalRoom);
            }

            else if (difficulty == ChooseDifficulty.Hard)
            {
                enter.TrySetDirection(Direction.Forward, trapRoom);
                enter.TrySetDirection(Direction.Right, mediumMonsterRoom);

                trapRoom.TrySetDirection(Direction.Forward, puzzleRoom);
                trapRoom.TrySetDirection(Direction.Left, lootStoneRoom);

                easyMonsterRoom.TrySetDirection(Direction.Forward, mediumMonsterRoom);
                easyMonsterRoom.TrySetDirection(Direction.Right, lootItemRoom);

                mediumMonsterRoom.TrySetDirection(Direction.Forward, bossRoom);
                mediumMonsterRoom.TrySetDirection(Direction.Left, lootRoom);

                puzzleRoom.TrySetDirection(Direction.Forward, finalRoom);
                puzzleRoom.TrySetDirection(Direction.Right, bossRoom);

                lootItemRoom.TrySetDirection(Direction.Forward, bossRoom);
                lootRoom.TrySetDirection(Direction.Forward, finalRoom);
                lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

                bossRoom.TrySetDirection(Direction.Forward, finalRoom);
            }

            return enter;
        }
    }
}
