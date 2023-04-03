using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class h : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    private float currentHealth;

    [SerializeField]
    private float respawnTime;

    [SerializeField]
    private GameObject healthPanel;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private RectTransform healthBar;

    private float healthBarStartWidth;

    private MeshRenderer meshRenderer;
    
    private bool isDead;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        currentHealth = maxHealth;
        healthBarStartWidth = healthBar.sizeDelta.x;
        UpdateUI();
    }

    public void ApplyDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            meshRenderer.enabled = false;
            healthPanel.SetActive(false);

            StartCoroutine(RespawnAfterTime());
        }

        UpdateUI();
    }

    private IEnumerator RespawnAfterTime()
    {
        yield return new WaitForSeconds(respawnTime);
        ResetHealth();
    }

    private void ResetHealth()
    {
        currentHealth = maxHealth;
        isDead = false;
        meshRenderer.enabled = true;
        healthPanel.SetActive(true);
        UpdateUI();
    }

    private void UpdateUI()
    {
        float percentOutOf = (currentHealth / maxHealth) * 100;
        float newWidth = (percentOutOf / 100) * healthBarStartWidth;

        healthBar.sizeDelta = new Vector2(newWidth, healthBar.sizeDelta.y);
        healthText.text = currentHealth + "/" + maxHealth;
    }
}
