using UnityEngine;
using System.Collections;

public class OvenMachine : KitchenMachine {
    public float currentTemp = 0f;
    public float targetTemp = 200f;
    public bool steamOn = false;
    bool busy = false;

    public override bool IsBusy => busy;

    public override void StartProcess(KitchenItem item, RecipeStep step) {
        if (busy) return;
        busy = true;
        StartCoroutine(BakeCoroutine(item, step));
    }

    IEnumerator BakeCoroutine(KitchenItem item, RecipeStep step) {
        float elapsed = 0f;
        float dur = Mathf.Max(1f, step.durationSeconds);
        // simple temperature ramp
        while (elapsed < dur) {
            elapsed += Time.deltaTime;
            currentTemp = Mathf.MoveTowards(currentTemp, targetTemp, Time.deltaTime * 50f);
            yield return null;
        }
        // after baking, you could modify the item (mark as baked)
        busy = false;
    }

    public override void StopProcess() {
        StopAllCoroutines();
        busy = false;
    }
}
