using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    public ParticleSystem pickUpEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if(controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Instantiate(pickUpEffect, transform.position, pickUpEffect.transform.rotation);
                Destroy(gameObject);

                controller.PlaySound(collectedClip);
            }
        }
    }
}
