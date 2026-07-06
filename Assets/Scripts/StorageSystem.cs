using System.Collections.Generic;
using UnityEngine;

public class StorageSystem : MonoBehaviour {
    public string storageId = "chest";
    public string displayName = "Storage";
    public string storageType = "pantry"; // pantry/fridge/freezer
    public List<string> storedItems = new List<string>();

    public bool Store(string itemId) {
        storedItems.Add(itemId);
        return true;
    }

    public bool Remove(string itemId) {
        return storedItems.Remove(itemId);
    }
}
