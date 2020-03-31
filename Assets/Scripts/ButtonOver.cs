
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Sprite _startPatoune;
    public Sprite _startOrigin;

    public Image _start;



    public void OnPointerEnter(PointerEventData eventData)
    {
        _start.sprite = _startPatoune;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _start.sprite = _startOrigin;
    }

}

