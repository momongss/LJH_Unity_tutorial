using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    private void OnCollisionEnter(Collision coll)
    {
        // if (coll.gameObject.tag == "BULLET") // GC 발생.
        // 
        string a = "ssdsd";

        if (coll.gameObject.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);

            ContactPoint cp = coll.GetContact(0);

            Vector3 _normal = -cp.normal;
            Vector3 _point = cp.point;

            Quaternion rot = Quaternion.Euler(_normal);
            var spark = Instantiate(sparkEffect, _point, rot);
            Destroy(spark, 0.9f);
        }
    }
}

/* 
 * Quaternion. 쿼터니언 (사원수) : x, y, z, w
 * 
 * 왜 쿼터니언을 쓰는가? 
 * 
 * 오일러 회전(Euler Rotation) x -> y -> z
 * 문제점. 2개의 축이 겹쳐지는 순간 회전이 안되는, 짐벌락 발생.
 * 
 * 유니티는 내부적으로 모두 쿼터니언을 사용한다.
 * 
 * 
 * Quaternion.Euler
 * Quaternion.LookRotation
 * Quaternion.identity
 */