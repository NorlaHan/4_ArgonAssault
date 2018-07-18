using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField] int startCount = 5;
    public GameObject musicPlayerPrefab;

    MusicPlayer musicPlayer;


    // Use this for initialization
    void Start()
    {
        // If MusicPlayer doesn't exist in any cases. Instantiate from the prefab.
        if (!GameObject.FindObjectOfType<MusicPlayer>())
        {
            musicPlayer = Instantiate(musicPlayerPrefab).GetComponent<MusicPlayer>();
        }
        else {
            musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
        }

        // Only works on splash screen
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Invoke("OnLoadLevel01", startCount);
            InvokeRepeating("CountSeconds", 1, 1);
        }        
    }

    private void OnLoadLevel01()
    {
        SceneManager.LoadScene(1);
    }

    void CountSeconds() {
        startCount--;
        if (startCount == 0)
        {
            print("Game START!");
        }
        else {
            print(startCount);
        }        
    }
}
