using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public Vector2 inventoryStartPoint;
    public static InventoryManager instance;
    Queue<InventoryObject> unusedObjs = new Queue<InventoryObject>();
    List<InventoryObject> activeOjbs = new List<InventoryObject>();
    public void AddUnused(InventoryObject obj) 
    {
        if (activeOjbs.Contains(obj)) 
        {
            activeOjbs.Remove(obj);
        }

        unusedObjs.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }

    public bool CreateInventoryItem(List<int> mix, int quality) 
    {
        if (unusedObjs.Count > 0) 
        { 
            InventoryObject cur = unusedObjs.Dequeue();
            cur.SetInvObj(mix, quality, inventoryStartPoint);

            return true;
        }

        return false;
    }
}
