﻿using UnityEngine;
using System.Collections;

public class ObjCustomizationHats : MonoBehaviour
{
    public static bool CustomizationHats;
    public static SwipeControlCustomizationHats swipeCtrl;
    public Transform[] obj = new Transform[0];

    public static ObjCustomizationHats ObjCustomizationInstance;
    //public GameObject[] arrayOfObj;


    public float minXPos = 0f; //min x position of the camera
    public float maxXPos = 115f; //max x position of the camera
    private float xDist; //distance between camMinXPos and camMaxXPos
    private float xDistFactor; // = 1/camXDist
    public static int HatsNumber = 8;
    public static int ShirtsNumber = 8;
    public static int BackBacksNumber = 8;
    private float swipeSmoothFactor = 1.0f; // 1/swipeCtrl.maxValue
    public float xPosReal = -11f;

    private float rememberYPos;

    void Awake()
    {
        CustomizationHats = false;
        if (Application.loadedLevel != 1)
        {
            minXPos = minXPos - 94.2f;
            maxXPos = maxXPos - 94.2f;
            xPosReal = -33.5f;
        }
    }

    // Use this for initialization
    void Start()
    {
        ObjCustomizationInstance = this;

        xDist = maxXPos - minXPos;
        xDistFactor = 1.0f / xDist;

        if (!swipeCtrl) swipeCtrl = gameObject.AddComponent<SwipeControlCustomizationHats>();

        swipeCtrl.skipAutoSetup = true; //skip auto-setup, we'll call Setup() manually once we're done changing stuff
        swipeCtrl.clickEdgeToSwitch = false; //only swiping will be possible
        swipeCtrl.SetMouseRect(new Rect(0, 0, Screen.width / 2, Screen.height)); //entire screen
        swipeCtrl.maxValue = obj.Length - 1; //max value


        //Default
        //swipeCtrl.currentValue = swipeCtrl.maxValue; //current value set to max, so it starts from the end
        //swipeCtrl.startValue = Mathf.RoundToInt(swipeCtrl.maxValue * 0.5f); //when Setup() is called it will animate from the end to the middle

        swipeCtrl.currentValue = obj.Length - 1; //current value set to max, so it starts from the end
        swipeCtrl.startValue = obj.Length - 1; //when Setup() is called it will animate from the end to the middle


        //swipeCtrl.partWidth = Screen.width  / swipeCtrl.maxValue; //how many pixels do you have to swipe to change the value by one? in this case we make it dependent on the screen-width and the maxValue, so swiping from one edge of the screen to the other will scroll through all values.

        swipeCtrl.partWidth = Screen.width / swipeCtrl.maxValue;

        swipeCtrl.Setup();

        swipeSmoothFactor = 1.0f / swipeCtrl.maxValue; //divisions are expensive, so we'll only do this once in start

        rememberYPos = obj[0].position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (CustomizationHats)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                //			obj[i].position = new Vector3(obj[i].position.x,minXPos + i * (xDist * swipeSmoothFactor) - swipeCtrl.smoothValue*swipeSmoothFactor*xDist , obj[i].position.z);
                obj[i].position = new Vector3((xPosReal),
                    minXPos - i * (xDist * swipeSmoothFactor) - swipeCtrl.smoothValue * swipeSmoothFactor * xDist,
                    obj[i].position.z);

                if (ShopManagerFull.AktivanCustomizationTab == 1 && ShopManagerFull.AktivanItemSesir !=
                    (swipeCtrl.maxValue - swipeCtrl.currentValue))
                {
                    ShopManagerFull.AktivanItemSesir = swipeCtrl.maxValue - swipeCtrl.currentValue;
                    ShopManagerFull.ShopObject.PreviewItem();
//					Debug.Log(obj[ShopManagerFull.AktivanItemSesir].name);
//					obj[swipeCtrl.currentValue].Find("Text/Helmet").GetComponent<TextMesh>().text="radi";
                }

//				ShopManagerFull.ShopObject.PreviewItem();
//				Debug.Log("Glupost najveca!!!!!!!!!!");	
            }
        }
    }

//	public void PostaviImenaItemaShop
}