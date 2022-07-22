using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0108, IDE0051

public class BarrelCtrl : MonoBehaviour
{
    private MeshRenderer renderer;
    public Texture[] textures;

    private int hitCount = 0;

    public GameObject expEffect;

    private AudioSource audioSource;
    public AudioClip expSfx;

    void Start()
    {
        renderer = GetComponentInChildren<MeshRenderer>();

        int idx = Random.Range(0, textures.Length);

        renderer.material.mainTexture = textures[idx];

        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 3)
            {
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        var rb = this.gameObject.AddComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 1500f);

        var effect = Instantiate(expEffect, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(expSfx, 1.2f);

        Destroy(effect, 6.0f);
        Destroy(this.gameObject, 3.5f);
    }
}
