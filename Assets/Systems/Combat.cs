using UnityEngine;
using TMPro;

public class Combat : MonoBehaviour
{
    public float currentHP;
    public float maxHP;

    public bool i_frames;
    public TMP_Text HP;


    public float shakeTime;
    public float shakeIntensity;
    // Start is called before the first frame update
    void Start()
    {
        HP.text = ("HP: " + currentHP);
    }

    public virtual void TakeDamage(float Damage)
    {
        if (i_frames == false)
        {
            CinemachineShake.Instance.ShakeCamera(shakeIntensity, shakeTime);
            currentHP -= Damage;
        }

        if (currentHP <= 0)
        {
            currentHP = 0;
            Death();
        }

        HP.text = ("HP: " + currentHP);

        //Item functionality
        FindObjectOfType<ARegularScrewdriver>().RemoveAllStacks();
    }

    public virtual void Death()
    {

    }

    public virtual void SetI_Frames(bool enableI_Frames)
    {
        i_frames = enableI_Frames;
    }


    public virtual void Heal(float healAmount)
    {
        currentHP += healAmount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }
}
