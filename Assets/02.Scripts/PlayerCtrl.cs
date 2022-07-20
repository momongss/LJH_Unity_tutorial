using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // Private 변수선언
    private float v;
    private float h;
    private float r;

    // Public 변수선언
    public float moveSpeed = 8.0f;
    public float turnSpeed = 50.0f;

    // 접근할 컴포넌트를 저장할 변수를 선언
    public Animation anim;

    /*
        프로퍼티(속성)
        - Car.speed = 200;
        - Car.color = yellow;
        - Car.capacity = 4;

        => 속성은 소문자.

        메소드(함수) - 명령(동사)
        - anim.Play(인자);

        => 메소드는 대문자.

        Camel Case (단봉 낙타)
        moveSpeed;
        변수, 속성

        Pascal Case 
        MoveSpeed;
        클래스, 구조체, 메소드.

        => 키워드가 바뀔 때마다 대문자.
        
    */

    // 변수의 초기화(게임의 초기화 로직), 1회 호출
    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();
        anim.Play("Idle");
    }

    void Update()
    {
        v = Input.GetAxis("Vertical");   // -1.0f ~ 0.0f ~ +1.0f
        h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        r = Input.GetAxis("Mouse X");

        // 벡터의 덧셈연산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        // 이동처리
        transform.Translate(moveDir.normalized * Time.deltaTime * moveSpeed);
        // 회전처리
        transform.Rotate(Vector3.up * Time.deltaTime * r * turnSpeed);

        PlayerAnimation();
    }

    void PlayerAnimation()
    {
        // 전진
        if (v >= 0.1f)
        {
            anim.CrossFade("RunF");
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB");
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("RunR");
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunL");
        }
        else
        {
            anim.CrossFade("Idle");
        }
    }

    /* 정규화 벡터(Normalized Vector)
        Vector3 -> 구조체(Structure)


        Vector3.forward = new Vector3(0, 0, 1)
        Vector3.up      = new Vector3(0, 1, 0)
        Vector3.right   = new Vector3(1, 0, 0)

        Vector3.one     = new Vector3(1, 1, 1)
        Vector3.zero    = new Vector3(0, 0, 0)
    */
}
