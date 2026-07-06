using UnityEngine;

// Base class for kitchen machines (stove, oven, cutting board, mixer station)
public abstract class KitchenMachine : MonoBehaviour {
    public string machineId = "machine";
    public string displayName = "Kitchen Machine";

    // Called to start the machine process
    public abstract void StartProcess(KitchenItem item, RecipeStep step);
    public abstract void StopProcess();
    public abstract bool IsBusy { get; }
}

public class KitchenItem : MonoBehaviour {
    // wrapper component for in-world items representing ingredients, tools or prepared dishes
    public string itemId;
    public string displayName;
}
