using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Baking/RecipeDatabase", fileName = "RecipeDatabase")]
public class RecipeDatabase : ScriptableObject {
    public List<RecipeDef> recipes = new List<RecipeDef>();

    public static RecipeDatabase LoadFromResources(string path = "Data/master_recipes") {
        var ta = Resources.Load<TextAsset>(path);
        if (ta == null) return null;
        var wrapper = JsonUtility.FromJson<RecipeDefListWrapper>(ta.text);
        var db = CreateInstance<RecipeDatabase>();
        db.recipes = wrapper.recipes;
        return db;
    }
}

[System.Serializable]
public class RecipeDefListWrapper { public List<RecipeDef> recipes; }

[System.Serializable]
public class RecipeIngredientReq {
    public string id;
    public float qty; // grams or units (game-defined)
}

[System.Serializable]
public class RecipeStep {
    public int stepNumber;
    public string stepType; // action / machine / tool
    public string description;
    public string requiredTool; // optional tool id
    public string requiredMachine; // optional machine id
    public float durationSeconds; // expected duration
}

[System.Serializable]
public class RecipeDef {
    public string id;
    public string name;
    public string description;
    public string cuisine;
    public string difficulty;
    public int servings;
    public List<string> requiredTools;
    public List<RecipeIngredientReq> ingredients;
    public List<RecipeStep> steps;
    public bool unlocked = true; // recipe bool: whether available
}
