using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       22-01-2023 19:59:13
================================================*/
[RequireComponent(typeof(AudioSource))]
public class Resource : MonoBehaviour {

    [field: SerializeField]
    public ResourceDataSO ResourceData { get; set; }

    AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PickupResource() {
        StartCoroutine(DestroyCoroutine());
    }

    IEnumerator DestroyCoroutine() {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject);
    }
}