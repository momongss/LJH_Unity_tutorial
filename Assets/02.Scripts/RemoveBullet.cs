using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    private void OnCollisionEnter(Collision coll)
    {
        // if (coll.gameObject.tag == "BULLET") // GC �߻�.
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
 * Quaternion. ���ʹϾ� (�����) : x, y, z, w
 * 
 * �� ���ʹϾ��� ���°�? 
 * 
 * ���Ϸ� ȸ��(Euler Rotation) x -> y -> z
 * ������. 2���� ���� �������� ���� ȸ���� �ȵǴ�, ������ �߻�.
 * 
 * ����Ƽ�� ���������� ��� ���ʹϾ��� ����Ѵ�.
 * 
 * 
 * Quaternion.Euler
 * Quaternion.LookRotation
 * Quaternion.identity
 */