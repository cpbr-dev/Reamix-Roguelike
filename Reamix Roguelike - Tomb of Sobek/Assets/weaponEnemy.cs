using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponEnemy : MonoBehaviour
{
    [SerializeField]
    private new ParticleSystem particleSystem;

    [SerializeField]
    private float damage;

    [SerializeField]
    private float fireRate;

    private List<ParticleCollisionEvent> collisionEvents;

    private string enemyTag;

    private bool fireCooldown;

    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleSystem, other, collisionEvents);

        for (int i = 0; i < collisionEvents.Count; i++)
        {
            var collider = collisionEvents[i].colliderComponent;
            if (collider.CompareTag(enemyTag))
            {
                var health = collider.GetComponent<PlayerHealth>();
                health.TakeDamage(damage);
            }
        }
    }

    public void Fire()
    {
        if (fireCooldown) return;
        fireCooldown = true;
        particleSystem.Emit(1);
        StartCoroutine(StopCooldownAfterTime());
    }

    private IEnumerator StopCooldownAfterTime()
    {
        yield return new WaitForSeconds(fireRate);
        fireCooldown = false;
    }

    public void SetEnemyTag(string enemyTag)
    {
        this.enemyTag = enemyTag;
    }
}
