using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boton : MonoBehaviour, IAction
{
    [SerializeField]
    private Color activateColor;
    [SerializeField]
    private Color inactivateColor;
    [SerializeField]
    private Material material;
    public GameObject ui;
    public Text tit;
    public Text desc;
    public string titulo;
    public string texto;

    private bool activated;
    public void Activate()
    {
        activated = !activated;
        if (activated)
        {
            material.color = activateColor;
            ui.SetActive(true);
            tit.text = titulo;
            desc.text = texto;
           
        }
        else
        {
            material.color = inactivateColor;
           ui.SetActive(false);
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
