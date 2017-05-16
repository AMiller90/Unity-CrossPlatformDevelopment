
namespace Assets.ScriptableObject.Inventory
{
    using System.Collections.Generic;
    using System.Linq;

    using UnityEngine;

    /// <summary>
    /// The loot table class.
    /// </summary>
    [CreateAssetMenu(menuName = "LootTable")]
    public class LootTable : ScriptableObject
    {
        /// <summary>
        /// The drop table reference.
        /// Reference to the eligible item drops.
        /// </summary>
        public List<ItemDrop> DropTable = new List<ItemDrop>();

        /// <summary>
        /// The get item function.
        /// Returns the specified item from the drop table.
        /// </summary>
        /// <returns>
        /// The <see cref="Item"/>.
        /// </returns>
        public ItemDrop DropItem()
        {
            ItemDrop theItem = new ItemDrop();
            if (this.DropTable.Count > 0)
            {
                // Get last index of list
                int lastindex = this.DropTable.Count - 1;

                // Sort the list by ascending drop chance
                this.SortByDropChance();
                
                // Get the rand number
                float rand = Random.Range(1, 100);

                // Loop through the list
                foreach (ItemDrop drop in this.DropTable)
                {
                    // Found the right drop
                    if (rand <= drop.DropChance || rand >= this.DropTable[lastindex].DropChance)
                    { // Set the item then break loop
                        theItem = drop;
                        break;
                    }
                }
            }

            return theItem;
        }
        
        /// <summary>
        /// The sort by drop chance function.
        /// Sorts the list by drop chance ascending.
        /// </summary>
        private void SortByDropChance()
        {
            this.DropTable = this.DropTable.OrderBy(i => i.DropChance).ToList();
        }
    }
}
