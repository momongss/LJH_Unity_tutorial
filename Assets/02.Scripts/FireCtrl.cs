using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0108, IDE0051

public class FireCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;

    private AudioSource audioSource;
    public AudioClip fireSfx;

    public MeshRenderer muzzleFlash;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        muzzleFlash.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ToggleMouseLock();
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        audioSource.PlayOneShot(fireSfx, 0.7f);

        StartCoroutine(ShowMuzzleFlash());
    }

    IEnumerator ShowMuzzleFlash()
    {
        Vector3 offset = new Vector2(Random.Range(0, 2) * 0.5f, Random.Range(0, 2) * 0.5f);
        muzzleFlash.material.mainTextureOffset = offset;

        float angle = Random.Range(0, 360);
        muzzleFlash.transform.localRotation = Quaternion.Euler(0, 0, angle);

        float scale = Random.Range(1.0f, 2.5f);
        muzzleFlash.transform.localScale = Vector3.one * scale;

        muzzleFlash.enabled = true;

        yield return new WaitForSeconds(0.3f); // yield 양보하다.
        muzzleFlash.enabled = false;
    }

    void ToggleMouseLock()
    {
        switch (Cursor.lockState)
        {
            case CursorLockMode.None:
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case CursorLockMode.Locked:
                Cursor.lockState = CursorLockMode.None;
                break;
        }
    }
}
