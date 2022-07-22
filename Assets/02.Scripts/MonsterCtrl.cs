using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    public enum State
    {
        IDLE, TRACE, ATTACK, DIE
    }

    public State state;

    public float traceDist = 10.0f;
    public float attackDist = 2.0f;
    public bool isDie = false;

    private Transform monsterTr;
    private Transform playerTr;

    // Start is called before the first frame update
    void Start()
    {
        monsterTr = transform;
        playerTr = GameObject.FindGameObjectWithTag("PLAYER")?.transform;

        StartCoroutine(CheckMonsterState());
    }

    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            float dist = Vector3.Distance(monsterTr.position, playerTr.position);

            if (dist <= attackDist)
            {
                state = State.ATTACK;
            }
            else if (dist < traceDist)
            {
                state = State.TRACE;
            }
            else
            {
                state = State.IDLE;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
}
