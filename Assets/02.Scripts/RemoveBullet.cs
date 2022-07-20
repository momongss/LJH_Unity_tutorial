using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision coll)
    {
        // if (coll.gameObject.tag == "BULLET") // GC ¹ß»ý. 

        if (coll.gameObject.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);
        }
    }
}
