using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon)
            {
                weapon.ReduceDurability(3);
                Console.WriteLine($"The strength of the weapon at the moment {weapon.Durability}");
                if (weapon.Durability <= 0)
                {
                    _equipment.Remove(EquipSlot.Weapon);
                    Inventory.TryRemove(weapon);
                }
                return BaseDamage + weapon.Damage;
            }
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item2) && item is RangeWeapon rangeWeapon)
            {
                rangeWeapon.ReduceDurability(3);
                Console.WriteLine($"The strength of the weapon at the moment {rangeWeapon.Durability}");
                if (rangeWeapon.Durability <= 0)
                {
                    _equipment.Remove(EquipSlot.Weapon);
                    Inventory.TryRemove(rangeWeapon);
                }
                return BaseDamage + rangeWeapon.Damage;
            }
            return BaseDamage;
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] is EconomicItem economicItem)
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem && _equipment.TryAdd(equipItem.Slot, equipItem))
            {
                // Item was equipped
                return;
            }
            else if (item is EquipItem equipItem1 && !_equipment.TryAdd(equipItem1.Slot, equipItem1))
            {
                Console.WriteLine($"Enter yes if you want to replace the current weapon with {equipItem1.Name}, otherwise write whatever");
                string choice = Console.ReadLine();
                if (choice == "Yes")
                    ChangeEquipItem(equipItem1);
            }
            base.AddItemToInventory(item);
        }

        private void ChangeEquipItem(EquipItem equipItem)
        {
            _equipment.Remove(equipItem.Slot);
            _equipment.TryAdd(equipItem.Slot, equipItem);
            Console.WriteLine($"Your current weapon {equipItem.Name}");
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion)
            {
                Health += healthPotion.HealthRestore;
            }
            if (economicItem is Grindstone grindStone)
            {
                if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon)
                {
                    weapon.Repair(grindStone.DurabilityBoost);
                    Console.WriteLine($"You have used a grindstone, now the durability of your weapon has been increased {weapon.Durability}");
                }

            }
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            _equipment.TryGetValue(EquipSlot.Armour, out var item);
            _equipment.TryGetValue(EquipSlot.Helmet, out var item2);

            if (item is Armour armour && item2 is Helmet helmet)
            {
                damage -= (uint)(damage * MathF.Min(1f, (armour.Defence + helmet.Defence) / 100f));
                armour.ReduceDurability(2);
                helmet.ReduceDurability(3);
            }
            else if (item is Armour onlyArmour)
            {
                damage -= (uint)(damage * MathF.Min(1f, onlyArmour.Defence / 100f));
            }
            else if (item is Helmet onlyHelmet)
            {
                damage -= (uint)(damage * MathF.Min(1f, onlyHelmet.Defence / 100f));
            }

            return damage;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++)
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
    }
}
