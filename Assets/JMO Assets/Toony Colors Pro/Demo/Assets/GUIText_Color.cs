using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GUIText_Color : MonoBehaviour
{
    public Color labelColor;

    private void Awake()
    {
        GetComponent<Text>().material.color = labelColor;
    }
}