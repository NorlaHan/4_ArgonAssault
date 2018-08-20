using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    private void Awake()
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        print("Number if music players in the scene : " + numMusicPlayer);
        if (numMusicPlayer>1)
        {
            Destroy(gameObject);
        }else
        {
        DontDestroyOnLoad(gameObject);
        }
    }

}
