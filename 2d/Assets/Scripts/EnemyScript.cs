using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 leftPos;
    public Vector2 rightPos;
    public float patrolDistance;
    public Transform enemyTransform;
    public Transform playerTransform;
    Animator anim;
    // Start is called before the first frame update

    public enum EnemyState { Walking, Attacking };
    public EnemyState currentState;
    public bool isAttacking = false;

    public Transform attackTransform;
    public float AttackRadius;
    public LayerMask playerMask;
    bool isPatroling = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        startPos = enemyTransform.position;
        leftPos = new Vector2(startPos.x + patrolDistance, startPos.y);
        rightPos = new Vector2(startPos.x - patrolDistance, startPos.y);
        StartCoroutine("MoveEnemy",leftPos);
    }
    //utility function
    void SetEnemyState(EnemyState state)
    {
        currentState = state;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveEnemy(Vector2 target)
    {
        isPatroling = true;
        while (Mathf.Abs((target.x - transform.position.x ))> 0.2f)
        {
            //ternary op
            Vector3 dir = target.x == rightPos.x ? Vector2.left : Vector2.right;

            /* Vector3 dir;
             if (target.x == rightPos.x)
             {
                 dir = Vector2.left;
             }
             else
             {
                 dir = Vector2.right;
             }*/


            enemyTransform.localPosition += dir * Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);

        Vector3 eScaleX = transform.localScale;

        Vector2 nextTarget;

        if (target.x == rightPos.x)
        {
            nextTarget = leftPos;
            eScaleX.x = -1;
        }
        else
        {
            nextTarget = rightPos;
            eScaleX.x = 1;
        }
        enemyTransform.localScale = eScaleX;
        StartCoroutine(MoveEnemy(nextTarget));
    }
}
