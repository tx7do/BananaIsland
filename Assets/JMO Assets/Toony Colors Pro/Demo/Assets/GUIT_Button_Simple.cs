using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GUIT_Button_Simple : MonoBehaviour
{
    public Color labelColor;
    public Texture text;
    [FormerlySerializedAs("text_over")] public Texture textOver;

    public GameObject callbackObject;
    public string callback;

    private bool _over = false;

    private void Awake()
    {
        this.GetComponentInChildren<Text>().material.color = labelColor;
        UpdateImage();
    }

    private void Update()
    {
        if (GetComponent<Image>().rectTransform.rect.Contains(Input.mousePosition))
        {
            if (!_over)
            {
                OnOver();
            }

            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
            }
        }
        else if (_over)
        {
            OnOut();
        }
    }

    private void OnClick()
    {
        callbackObject.SendMessage(callback);
    }

    private void OnOver()
    {
        _over = true;
        UpdateImage();
    }

    private void OnOut()
    {
        _over = false;
        UpdateImage();
    }

    private void UpdateImage()
    {
        if (_over)
            GetComponent<Image>().material.mainTexture = textOver;
        else
            GetComponent<Image>().material.mainTexture = text;
    }
}