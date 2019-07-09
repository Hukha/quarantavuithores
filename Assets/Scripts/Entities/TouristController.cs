using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class TouristController : EntityController {

    public Tourist info;
    public int asginedLoungerId;
    private Animator animator,stunt;

    private Vector3 lastPos;
    private Player player;
    public int position;


    void Awake() {
        animator = GetComponent<Animator>();
        stunt = transform.Find("Stunt").GetComponent<Animator>();
        lastPos = transform.localPosition;
        player = PlayerManager.player;
        position = 0;
    }

    void FixedUpdate() {
        if (PositionHelper.GetPosition(transform.localPosition, lastPos) != position) {
            position = PositionHelper.GetPosition(transform.localPosition, lastPos);
            animator.SetInteger("position", position);
        }
        lastPos = transform.localPosition;
    }

    public void OnHit() {
        info.stunned = true;
        animator.SetBool("stunned", true);
        stunt.SetTrigger("Show");
    }

    public void Init(Tourist initialInfo) {
        info = initialInfo;
        gameObject.name = info.id;
        transform.position = info.pattern.route[0].position;
        GoToLounger();
    }

    // ROUTE CHANGES
    private void GoToLounger () {
        ChangeState (TouristRouteState.ToLounger);
        InitPatterns ();
    }
    private void SitOnLounger () {
        ChangeState (TouristRouteState.OnLounger);
        StartStateChange ();
    }
    IEnumerator ExitLoungerGood () {
        ChangeState (TouristRouteState.OutGood);
        yield return new WaitForSeconds (1F);
        if (info.state.Equals (TouristState.Bronceado)) {
            InstanceReward ();
            PlayerManager.player.points += 300;
        } else {
            PlayerManager.player.points += 100;
        }
        ReturnToOrigin();
    }
    IEnumerator ExitLoungerBad() {
        ChangeState(TouristRouteState.OutBad);
        yield return new WaitForSeconds(1F);
        ReturnToOrigin();
    }

    private void StartStateChange() {
        ChangeState(TouristState.Normal);
        StartCoroutine("IntervalChangeState");
    }

    IEnumerator IntervalChangeState() {
        Debug.Log("IntervalChangeState");
        TouristState[] state = { TouristState.Gamba, TouristState.Bronceado, TouristState.Quemado, TouristState.Dep };
        for (int i = 0; i < state.Length; i++) {
            yield return new WaitForSeconds(info.speed);
            ChangeState(state[i]);
        }
        yield return new WaitForSeconds(0.3F);
        info.restPlace.touristLeaves();
        Destroy(gameObject);
    }

    // STATE CHANGES AND ANIMATIONS CHANGE
    private void ChangeState(TouristRouteState state) {
        Debug.Log("ChangeState " + state.ToString());
        info.routeState = state;
        animator.SetTrigger(state.ToString());
    }

    private void ChangeState(TouristState state) {
        Debug.Log("ChangeState " + state.ToString());
        info.state = state;
        if (state.Equals(TouristState.Dep)) {
            ExitLoungerBad();
        }
        animator.SetTrigger(state.ToString());
    }

    private void ReturnToOrigin() {
        InitPatterns();
    }

    // ENTITY OVERRIDES
    public override Vector3[] GetPattern() {
        switch (info.routeState) {
            case TouristRouteState.OutBad:
            case TouristRouteState.OutGood:
                return info.pattern.GetPatternVectorsReversed().ToArray();
            default:
                return info.pattern.GetPatternVectors().ToArray();
        }
    }

    public override void PatternFinished() {
        switch (info.routeState) {
            case TouristRouteState.ToLounger:
                info.restPlace.touristArrived();
                SitOnLounger();
                break;
            case TouristRouteState.OutBad:
            case TouristRouteState.OutGood:
                info.restPlace.touristLeaves();
                Destroy(gameObject);
                break;
        }
    }

    void InstanceReward() {
        for (int i = 0; i < info.perfectReward; i++) {
            Instantiate(Resources.Load("Prefabs/Quely") as GameObject, PositionHelper.RandomPositionCloseTo(transform.position), Quaternion.identity);
        }
    }

    // EVENTS
    void OnMouseDown() {
        if (!info.stunned && TouristRouteState.OnLounger == info.routeState) {
            switch (player.selectedTool.action) {
                case ToolAction.Save: {
                        break;
                    }
                default: {
                        return;
                    }
            }
            switch (info.state) {
                case TouristState.Gamba:
                case TouristState.Bronceado:
                    StopCoroutine("IntervalChangeState");
                    StartCoroutine("ExitLoungerGood");
                    break;
                case TouristState.Quemado:
                    StopCoroutine("IntervalChangeState");
                    StartCoroutine("ExitLoungerBad");
                    break;
                default:
                    Debug.Log("Don't click ass licker!");
                    break;
            }

        }
    }
}