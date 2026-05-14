using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ARTargetManager : MonoBehaviour
{
    [Header("UI & Object Setup")]
    public GameObject targetPrefab;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI timerUI; 

    [Header("Audio Setup")]
    public AudioSource audioPlayer; 
    public AudioClip hitSound;      

    private int score = 0;
    private float gameTimer = 60f; // Exactly 60 seconds
    private float spawnTimer = 0f;

    void Start() 
    {
        if (scoreUI != null) scoreUI.text = "SCORE: 0";
    }

    void Update() 
    {
        // 1. Timer Logic
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
            
            // Mathf.Max ensures the timer never displays a negative number
            if (timerUI != null) 
                timerUI.text = "TIME: " + Mathf.Max(0, Mathf.CeilToInt(gameTimer)).ToString();
        }

        // Trigger Game Over exactly at 0
        if (gameTimer <= 0) 
        {
            // Save the score to the phone's memory before switching scenes
            PlayerPrefs.SetInt("FinalScore", score); 
            PlayerPrefs.Save();
            
            SceneManager.LoadScene("EndScene"); 
        }

        // 2. Spawning Logic
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= 1.3f && gameTimer > 0) 
        {
            SpawnTarget();
            spawnTimer = 0f;
        }

        // 3. Input Logic (Touch & Mouse)
        if (Input.GetMouseButtonDown(0)) 
        {
            CheckHit(Input.mousePosition);
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            CheckHit(Input.GetTouch(0).position);
        }
    }

    void CheckHit(Vector2 screenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hit)) 
        {
            if (hit.transform.name.Contains("ARTarget")) 
            {
                score++;
                if (scoreUI != null) scoreUI.text = "SCORE: " + score;
                
                if (audioPlayer != null && hitSound != null) 
                {
                    audioPlayer.PlayOneShot(hitSound);
                }

                Destroy(hit.transform.gameObject);
            }
        }
    }

    void SpawnTarget() 
    {
        Transform cam = Camera.main.transform;
        
        Vector3 spawnPos = cam.position + cam.forward * 2.5f;
        spawnPos += cam.right * Random.Range(-1.2f, 1.2f);
        spawnPos += cam.up * Random.Range(-0.8f, 0.8f);

        GameObject target = Instantiate(targetPrefab, spawnPos, Quaternion.identity);
        target.name = "ARTarget";
        
        if (target.GetComponent<Collider>() == null) 
        {
            target.AddComponent<SphereCollider>();
        }

        Destroy(target, 2.0f);
    }
}