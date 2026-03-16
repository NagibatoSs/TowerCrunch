using UnityEngine;
using UnityEngine.UI;


public class SpriteToggle : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Sprite spriteOn;
    [SerializeField] Sprite spriteOff;
    bool isOn = true;

    public void ToggleSprite()
    {
        if (image==null || spriteOn == null || spriteOff == null) return;
        if (isOn)
            image.sprite = spriteOff;
        else
            image.sprite = spriteOn;
        isOn = !isOn;
    }

}
