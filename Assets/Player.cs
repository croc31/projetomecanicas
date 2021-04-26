using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public HealthBar healthBar;

    public int maxHealth = 100;
    public int currentHealth;
    public int currentScene;

    bool isDead = false;
    private static bool loaded = false;

    private GameManager gameManager;
    private TintColor tintColor;
    private CinemachineVirtualCamera cam;

    public IEnumerator Save()
    {
        while(true)
        {
            yield return new WaitForSeconds(5);
            Debug.Log("saving player data...");
            SaveState.SavePlayer(this);
        }
    }

    public void Load()
    {
        PlayerData data = SaveState.LoadPlayer();
        if(data != null)
        {
            Debug.Log("loading player data...");
            
            maxHealth = data.maxHealth;
            currentHealth = data.currentHealth;
            if(healthBar != null)
            {
                healthBar.SetMaxHealth(maxHealth);
                healthBar.SetHealth(currentHealth);
            }
            
            currentScene = data.level;

            LoadLevel.LoadScene(data.level);

            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.parent.position = position;

            loaded = true;
        }
    }

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        currentHealth = maxHealth;
        if(healthBar != null)
            healthBar.SetMaxHealth(maxHealth);
        
        tintColor = GetComponent<TintColor>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(!loaded)
            Load();
        StartCoroutine(Save()); //start autosave routine
    }

    void Update()
    {
        if(cam == null)
        {
            Debug.Log("Setting camera");
            cam = GameObject.Find("PlayerCamera").GetComponent<CinemachineVirtualCamera>();
            cam.m_Follow = gameObject.transform;
        }
    }

    public void DoDamage()
    {
        TakeDamage(1);
    }
   
    public void TakeDamage(int damage)
    {
        tintColor.SetTintColor(new Color(255, 0, 0, 255));
        currentHealth -= damage;

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        if(currentHealth <= 0 && !isDead)
        {
            Die();
            Debug.Log("the player has been slayed");
        }
    }

    void Die()
    {
        isDead = true;
        gameObject.GetComponentInParent<Destroy>().doDestroy();
        gameManager.Respawn();
    }

    private void OnLevelWasLoaded(int level)
    {
        if(currentScene == level)
            return;

        currentScene = level;

        Debug.Log("Setting player position in scene begin");
        transform.parent.position = GameObject.FindWithTag("StartPos").transform.position;
    }

}
