﻿using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public sealed class Weapon : EquipItem
    {
        public Weapon(uint damage, uint maxDurability, string name) : base(maxDurability, name) => Damage = damage;

        public uint Damage { get; }

        public override EquipSlot Slot => EquipSlot.Weapon;
    }
}
