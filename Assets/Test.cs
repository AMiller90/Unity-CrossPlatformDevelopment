using System.Collections;
using System.Collections.Generic;

using Assets.ScriptableObject.Inventory;

using UnityEditor;

using UnityEngine;

public class Test : MonoBehaviour
{
    public LootTable table;
    [Tooltip("The items that have been dropped")]
    public List<Item> AllItemsDropped = new List<Item>();
}

#if UNITY_EDITOR
[CustomEditor(typeof(Test))]
public class InspectorTest : Editor
{
    private Test testobject;

    public override void OnInspectorGUI()
    {
        GUILayoutOption[] Options = new GUILayoutOption[1];
        Options[0] = GUILayout.ExpandWidth(false);

        if (GUILayout.Button("Drop Item", Options))
        {
            this.testobject = target as Test;
            var newItem = this.testobject.table.DropItem();
            this.testobject.AllItemsDropped.Add(newItem.ItemToDrop);
        }
        if (GUILayout.Button("Clear Items", Options))
        {
            this.testobject = target as Test;
            this.testobject.AllItemsDropped.Clear();
        }

        base.OnInspectorGUI();
    }
#endif
}
