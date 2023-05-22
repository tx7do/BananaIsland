using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GUIT_Button : MonoBehaviour
{
    public Color labelColor;
    [FormerlySerializedAs("t_on")] public Texture _t_on;
    [FormerlySerializedAs("t_off")] public Texture _t_off;
    [FormerlySerializedAs("t_on_over")] public Texture _t_on_over;
    [FormerlySerializedAs("t_off_over")] public Texture _t_off_over;

    public GameObject callbackObject;
    public string callback;

    private bool _over = false;
    public bool on;

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
        on = !on;
        callbackObject.SendMessage(callback);
        UpdateImage();
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
            this.GetComponent<Image>().material.mainTexture = on ? _t_on_over : _t_off_over;
        else
            this.GetComponent<Image>().material.mainTexture = on ? _t_on : _t_off;
    }

    public void UpdateState(bool b)
    {
        on = b;
        UpdateImage();
    }
}