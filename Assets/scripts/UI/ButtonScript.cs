using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{


    public Text text;
    public Color defaultColor;
    public Color hoverColor;
    public Color selectColor;

    public void ChangeColorHoverOver()
    {
        text.color = hoverColor;
    }

    public void ChangeColorDefault()
    {
        text.color = defaultColor;
    }

    public void ChangeColorSelected()
    {
        //text.color = selectColor;
    }


}