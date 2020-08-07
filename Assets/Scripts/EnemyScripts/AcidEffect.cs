using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * 3 * Vector3.right);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();

            if (hit != null)
            {
                hit.Damage();
                Destroy(other.gameObject);
            }
        }
    }
}
