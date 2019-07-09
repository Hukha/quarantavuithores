using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EntityController {
    public Enemy info;
    private Animator animator;
    private Vector3 lastPos;
    public int position;
    private Player player;

    void Awake () {
        animator = GetComponent<Animator> ();
        player = PlayerManager.player;
    }

    public void Init (Enemy _info) {
        info = _info;
        gameObject.name = info.id;
        transform.position = info.pattern.route[0].position;
        GoToTarget ();
        position = 0;
        lastPos = transform.localPosition;
        animator.SetBool("attackOrientation",_info.target.restPlace.orientation);
    }

    void FixedUpdate () {
        if (PositionHelper.GetPosition (transform.localPosition, lastPos) != position) {
            position = PositionHelper.GetPosition (transform.localPosition, lastPos);
            animator.SetInteger ("direction", position);
        }
        lastPos = transform.localPosition;
    }

    private void GoToTarget () {
        ChangeState (EnemyAction.ToTarget);
        InitPatterns ();
    }

    private void OnTouristStunned () {
        animator.SetTrigger ("EndAttack");
        ReturnToOrigin ();
    }

    IEnumerator Attack () {
        ChangeState (EnemyAction.OnTarget);
        animator.SetTrigger ("Attack");
        yield return new WaitForSeconds (1F);
        if (info.target.restPlace.tourist != null) {
            info.target.restPlace.tourist.OnHit ();
        }
        OnTouristStunned ();
    }

    private void ReturnToOrigin () {
        ChangeState (EnemyAction.ToDestiny);
        ChangeState (EnemyState.AfterHit);
        InitPatterns ();
    }

    void Die () {
       
        if (info.action.Equals (EnemyAction.ToTarget)) {
            InstanceReward ();
        }
        ChangeState (EnemyState.Dead);
        Destroy (gameObject);
    }

    private void Hit (int value) {
        Debug.Log ("Auch");
        info.TakeHealth (value);
        if (info.state.Equals (EnemyState.Dead)) {
            if (info.action.Equals (EnemyAction.ToTarget)) {
                InstanceReward ();
                 PlayerManager.player.points += 200;
            }else{
                PlayerManager.player.points += 100;
            }
            StopCoroutine ("Attack");
            Die();
        }
    }

    private void ChangeState (EnemyAction action) {
        Debug.Log ("ChangeEnemyAction " + action.ToString ());
        info.action = action;
        // animator.SetTrigger (action.ToString ());
    }
    private void ChangeState (EnemyState state) {
        Debug.Log ("ChangeEnemyState " + state.ToString ());
        info.state = state;
        // animator.SetTrigger (state.ToString ());
    }

    // EVENTS
    void OnMouseDown() {
        if (info.state.Equals(EnemyState.Alive)) {
            switch (player.selectedTool.action) {
                case ToolAction.Hit: {
                        animator.SetTrigger("Hitted");
                        Hit(1);
                        break;
                    }
            }
        }
    }

    void InstanceReward () {
        Debug.Log ("Rewaaard ayyyy");
        for (int i = 0; i < info.rewardBeforeStunt; i++) {
            Instantiate (Resources.Load ("Prefabs/Bottle") as GameObject, PositionHelper.RandomPositionCloseTo (transform.position), Quaternion.identity);
        }
    }

    public override Vector3[] GetPattern () {
        switch (info.state) {
            case EnemyState.AfterHit:
                return info.pattern.GetPatternVectorsReversed ().ToArray ();
            default:
                return info.pattern.GetPatternVectors ().ToArray ();
        }
    }

    public override void PatternFinished () {
        switch (info.action) {
            case EnemyAction.ToTarget:
                info.action = EnemyAction.OnTarget;
                StartCoroutine ("Attack");
                break;
            case EnemyAction.ToDestiny:
                info.target.enemyLeaves ();
                Destroy (gameObject);
                break;
        }
    }
}