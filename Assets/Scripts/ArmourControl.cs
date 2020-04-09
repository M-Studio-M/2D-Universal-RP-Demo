using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class ArmourControl : MonoBehaviour
{
    [SerializeField]
    SpriteResolver bodyResolver, hairResolver;
    public GameObject item;
    public List<SpriteResolver> spriteResolver = new List<SpriteResolver>();
    [SerializeField]
    int index = 0;
    void Start()
    {
        foreach (var resolver in FindObjectsOfType<SpriteResolver>())
        {
            if (resolver.GetCategory() == "Body")
                bodyResolver = resolver;
            if (resolver.GetCategory() == "Hair")
            {
                hairResolver = resolver;
                continue;
            }
            spriteResolver.Add(resolver);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (index < 0)
            index = 0;
        if (index == spriteResolver.Count)
            index -= 1;

        if (Input.GetKeyDown(KeyCode.E) && index <= spriteResolver.Count)
        {
            spriteResolver[index].SetCategoryAndLabel(spriteResolver[index].GetCategory(), "armour");
            index++;
        }
        if (Input.GetKeyDown(KeyCode.Q) && index >= 0)
        {
            spriteResolver[index].SetCategoryAndLabel(spriteResolver[index].GetCategory(), "normal");
            index--;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (hairResolver.GetLabel() == "normal")
                hairResolver.SetCategoryAndLabel(hairResolver.GetCategory(), "armour");
            else if (hairResolver.GetLabel() == "armour")
                hairResolver.SetCategoryAndLabel(hairResolver.GetCategory(), "normal");
        }
        if (bodyResolver.GetLabel() == "armour")
        {
            item.SetActive(false);
        }
        else
        {
            item.SetActive(true);
        }
    }
}
