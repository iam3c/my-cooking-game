using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Baking/IngredientDatabase", fileName = "IngredientDatabase")]
public class IngredientDatabase : ScriptableObject {
    public List<IngredientDef> ingredients = new List<IngredientDef>();

    // load from JSON at runtime if needed
    public static IngredientDatabase LoadFromResources(string path = "Data/master_ingredients") {
        var ta = Resources.Load<TextAsset>(path);
        if (ta == null) return null;
        var wrapper = JsonUtility.FromJson<IngredientDefListWrapper>(ta.text);
        var db = CreateInstance<IngredientDatabase>();
        db.ingredients = wrapper.ingredients;
        return db;
    }
}

[System.Serializable]
public class IngredientDefListWrapper { public List<IngredientDef> ingredients; }

[System.Serializable]
public class IngredientDef {
    public string id;
    public string displayName;
    public string category;
    public string storage; // pantry/fridge/freezer/counter
    public string description;
    public int maxStack = 99;
    public string iconPath; // optional
}
