using UnityEngine;
using UnityEngine.UI;
using System.Text;

// Small UI to step through a recipe
public class RecipePlayerUI : MonoBehaviour {
    public RecipeDatabase recipeDB;
    public Text titleText;
    public Text descriptionText;
    public Text stepsText;

    RecipeDef current;
    int stepIndex = 0;

    public void LoadRecipe(string recipeId) {
        if (recipeDB == null) recipeDB = RecipeDatabase.LoadFromResources();
        if (recipeDB == null) return;
        current = recipeDB.recipes.Find(r => r.id == recipeId);
        stepIndex = 0;
        RefreshUI();
    }

    public void NextStep() {
        if (current == null) return;
        stepIndex = Mathf.Min(current.steps.Count - 1, stepIndex + 1);
        RefreshUI();
    }

    public void PrevStep() {
        if (current == null) return;
        stepIndex = Mathf.Max(0, stepIndex - 1);
        RefreshUI();
    }

    void RefreshUI() {
        if (current == null) { titleText.text = ""; descriptionText.text = ""; stepsText.text = ""; return; }
        titleText.text = current.name;
        descriptionText.text = current.description;
        var sb = new StringBuilder();
        for (int i = 0; i < current.steps.Count; i++) {
            var s = current.steps[i];
            sb.AppendLine($"{(i==stepIndex?">":" ")}{s.stepNumber}. {s.description} [{s.stepType}] {(string.IsNullOrEmpty(s.requiredTool)?"":"(Tool: "+s.requiredTool+")")} {(string.IsNullOrEmpty(s.requiredMachine)?"":"(Machine: "+s.requiredMachine+")")} ");
        }
        stepsText.text = sb.ToString();
    }
}
