using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [Tooltip("The Material to switch to when flashing")]
    [SerializeField] private Material flashMaterial;

    public float flashDuration;

    private SpriteRenderer spRend;
    private Material originalMaterial;
    private Coroutine flashRoutine; //Used to prevent bugs

    // Start is called before the first frame update
    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        originalMaterial = spRend.material;
    }

    //Call this to trigger the "flash"
    public void StartFlash()
    {
        //Make sure that only one instance of Flash is running
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine());
    }

    //Makes the entity "flash"
    private IEnumerator FlashRoutine()
    {
        spRend.material = flashMaterial;

        yield return new WaitForSeconds(flashDuration);

        spRend.material = originalMaterial;

        //Marks the flashing as complete
        flashRoutine = null;
    }
}
