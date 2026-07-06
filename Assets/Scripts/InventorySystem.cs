using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour {
    public int capacity = 60;
    public List<string> items = new List<string>(); // simple list of item ids

    public bool AddItem(string id) {
        if (items.Count >= capacity) return false;
        items.Add(id);
        return true;
    }

    public bool RemoveItem(string id) {
        return items.Remove(id);
    }

    public int Count(string id) {
        int c = 0;
        foreach (var i in items) if (i == id) c++;
        return c;
    }

    public void Clear() { items.Clear(); }
}
