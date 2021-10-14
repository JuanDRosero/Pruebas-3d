using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour, IAction
{
    [SerializeField]
    private Color activateColor;
    [SerializeField]
    private Color inactivateColor;
    [SerializeField]
    private Material material;

    private bool activated;
    public void Activate()
    {
        activated = !activated;
        if (activated)
        {
            material.color = activateColor;
        }
        else
        {
            material.color = inactivateColor;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        material.color = inactivateColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
