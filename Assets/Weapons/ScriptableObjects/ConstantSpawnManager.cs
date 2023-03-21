using UnityEngine;

public class ConstantSpawnManager : MonoBehaviour
{
    [Header("Minimum and Maximum spawn area is set here")]
    // floats used to coordinate the spawn position for the prefabs in game.
    // Set the first and second variables to the same number in order to disable the randomness in the spawns
    public float spawnPosX;
    public float spawnPosX1;

    public float spawnPosY;
    public float spawnPosY1;

    public float spawnPosZ;
    public float spawnPosZ1;

    [Header("Game Object array")]
    //the array is made using the game objects put inside, and becomes bigger the more parts are put in
    public GameObject[] obj;

    [Header("Misc Settings")]
    //time control so that thre is a set amount of time between each prefab spawning as well as using the sustem to 
    public float timer;

    public float spawnSpeed;

    public float durationOfSpawning;

    public float spawnTimer;

    public bool HasLimitedTime = false;

    // Update is called once per frame
    void Update()
    {
        //assigns the object spawn timer to actual time, as well as the spawn manager's lifetime
        timer += Time.deltaTime;
        if(HasLimitedTime == true)
        {
            durationOfSpawning += Time.deltaTime;
        }

        //spawns prefabs at a set interval
        if (timer >= spawnSpeed)
        {
            timer = 0;
            Spawning();
        }

        //destroys the spawn manager after a set amount of time if it has limited time and the required time has passed
        if (durationOfSpawning >= spawnTimer && HasLimitedTime == true)
        {
            Destroy(gameObject);
        }

    }
    void Spawning()
    {
        //spawns the prefab at a randomized location between 2 variables that are assigned manually before running the game
        Vector3 spawnPos = new Vector3(Random.Range(spawnPosX, spawnPosX1), Random.Range(spawnPosY, spawnPosY1), Random.Range(spawnPosZ, spawnPosZ1));

        //initializes the Game object array so that its contents are randomly spawned in
        int objectIndex = Random.Range(0, obj.Length);

        //physically spawns the object at the randomized location
        Instantiate(obj[objectIndex], spawnPos, obj[objectIndex].transform.rotation);

    }
}
