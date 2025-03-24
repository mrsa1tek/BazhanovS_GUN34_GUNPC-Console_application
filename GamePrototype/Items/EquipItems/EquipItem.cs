using GamePrototype.Items.EconomicItems;
using GamePrototype.Utils;
using System.ComponentModel.Design;

namespace GamePrototype.Items.EquipItems
{
    public abstract class EquipItem : Item
    {
        private uint _durability;
        private uint _maxDurability;
        public uint Durability { get => _durability; protected set => _durability = value; }
        public override bool Stackable => false;

        public abstract EquipSlot Slot { get; }

        protected EquipItem(uint maxDurability, string name) : base(name)
        {
            _maxDurability = maxDurability;
            _durability = _maxDurability;
        }

        public void ReduceDurability(uint delta)
        {
            if (delta >= _durability)
                _durability = 0;
            else
                _durability -= delta;
        }

        public void Repair(uint delta)
        {
            _durability = Math.Min(_durability + delta, _maxDurability);
        }
    }
}
