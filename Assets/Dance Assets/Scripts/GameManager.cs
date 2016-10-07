using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : CustomMono {
    public static GameManager currentGameManager;
    
    public Spawmer spawner;
    public bool startSpawn;
    public Zombie testZombie;
    public ArrayList zombieList;
    public int zombieReady;
    AudioSource audio;
    public bool stopAudio = false;
    void Awake()
    {
        if(currentGameManager == null)
        {
            currentGameManager = this;
        }else if(currentGameManager != this)
        {
            Destroy(transform.gameObject);
        }
        zombieList = new ArrayList();
        audio = GetComponent<AudioSource>();
        startSpawn = false;
    }
	// Use this for initialization
	void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {
	    if(zombieReady != 0 && zombieReady == spawner.spawnPoints.Length)
        {
            zombieReady = 0;
            foreach (GameObject zombie in zombieList)
            {
                zombie.GetComponent<Zombie>().TriggerThriller1();
                
            }
            audio.Play();
        }
        if (startSpawn)
        {
            startSpawn = false;
            spawner.start = true;

        }
        if (stopAudio)
        {
            stopAudio = false;
            audio.Stop();
            Debug.Log(audio.timeSamples);
        }
	}
    public void TempStopAudio()
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }
    }
}
