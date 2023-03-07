using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShrinkTab : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [Header("Full Size")]
    [SerializeField] float _posX, _posY, _width, _height;
    [Header("Shrunk Size")]
    [SerializeField] float _posXsmall, _posYsmall, _widthsmall, _heightsmall;

    public void Shrink()
    {
        _rectTransform.localPosition = new Vector3(_posXsmall, _posYsmall);
        _rectTransform.sizeDelta = new Vector2(_widthsmall, _heightsmall);
    }

    public void Grow()
    {
        _rectTransform.localPosition = new Vector3(_posX, _posY);
        _rectTransform.sizeDelta = new Vector2(_width, _height);
    }

}
