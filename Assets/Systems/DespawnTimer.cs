using UnityEngine;

public class DespawnTimer : MonoBehaviour
{
    public float timer;
    public float timerEnd;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timerEnd)
        {
            Destroy(gameObject);
        }
    }
}