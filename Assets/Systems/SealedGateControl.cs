using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealedGateControl : MonoBehaviour
{
    public GameObject gate;
    public void Seal()
    {
        gate.SetActive(true);
    }
    public void Unseal()
    {
        gate.SetActive(false);
    }
}
