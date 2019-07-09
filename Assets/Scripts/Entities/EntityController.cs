using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour {
    // Use this for initialization
    public float speed;


    private int patternIndex;
    private Vector3[] patterns { get; set; }
    private PatternStates state;


    public virtual void Update() {
        switch (state) {
            case PatternStates.WORKING: {
                ExecutePatterns();
                break;
            }
            case PatternStates.FINISH: {
                PatternFinished();
                state = PatternStates.END;
                break;
            }
        }
    }

    public void InitPatterns() {
        patternIndex = 0;
        patterns = GetPattern();
        state = PatternStates.WORKING;
    }

    private bool MoveMyself(Vector3 target) {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        return transform.position.Equals(target);
    }

    private void ExecutePatterns() {
        bool hasArrived = MoveMyself(patterns[patternIndex]);
        if (hasArrived) {
            patternIndex++;
            hasArrived = false;
            if (patternIndex == patterns.Length) {
                state = PatternStates.FINISH;
            }
        }
    }

    public abstract Vector3[] GetPattern();
    public abstract void PatternFinished();
}
