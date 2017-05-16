
namespace Assets.ScriptableObject.Inventory
{
    using UnityEngine;

    /// <summary>
    /// The item drop chance class.
    /// </summary>
    [System.Serializable]
    public class ItemDrop
    {
        /// <summary>
        /// The item to drop.
        /// </summary>
        public Item ItemToDrop;

        /// <summary>
        /// The drop chance.
        /// </summary>
        [Range(1, 100)]
        public float DropChance;
    }
}
