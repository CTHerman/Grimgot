using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{


    public TextMeshProUGUI text;
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
        text.color = selectColor;
    }


}