using UnityEngine;
using System.Collections;

public class CuttingBoardMachine : KitchenMachine {
    bool busy = false;

    public override bool IsBusy => busy;

    public override void StartProcess(KitchenItem item, RecipeStep step) {
        if (busy) return;
        busy = true;
        StartCoroutine(CutCoroutine(item, step));
    }

    IEnumerator CutCoroutine(KitchenItem item, RecipeStep step) {
        float elapsed = 0f;
        float dur = Mathf.Max(0.5f, step.durationSeconds);
        while (elapsed < dur) {
            elapsed += Time.deltaTime;
            yield return null;
        }
        busy = false;
    }

    public override void StopProcess() {
        StopAllCoroutines();
        busy = false;
    }
}
