using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContentFitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HorizontalLayoutGroup hrzGp = GetComponent<HorizontalLayoutGroup>();
        int childCount = transform.childCount - 1; //-1 beacuse spacing count
        float childWidth = transform.GetChild(0).GetComponent<RectTransform>().rect.width;//width
        float width = hrzGp.spacing * childCount + childCount * childWidth + hrzGp.padding.left;

        GetComponent<RectTransform>().sizeDelta = new Vector2(width, 130); //change value height based on Content

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
