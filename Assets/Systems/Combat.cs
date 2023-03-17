using UnityEngine;

public class Combat : MonoBehaviour
{
    public float currentHP;
    public float maxHP;

    public bool i_frames;

    


    // Start is called before the first frame update
    void Start()
    {

    }

    public virtual void TakeDamage(float Damage)
    {
        if (i_frames == false)
        {
            currentHP -= Damage;
        }

        if (currentHP <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Debug.Log("dead");
    }

    public virtual void SetI_Frames(bool enableI_Frames)
    {
        i_frames = enableI_Frames;

    }
}
