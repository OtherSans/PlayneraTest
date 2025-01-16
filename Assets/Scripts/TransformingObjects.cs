using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;

public class TransformingObjects : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;
    [SerializeField] private Vector3 scaleObjectParams;
    private RectTransform rectTrans;
    private Rigidbody2D rb;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //вызываем событие после того, как начали перетаскивать объект
        //увеличиваем объект, чтобы показать что мы его взяли
        rectTrans.localScale = scaleObjectParams;
        //задаем первую позицию в иерархии, чтобы он был поверх других перетаскеиваемых объектов
        gameObject.transform.SetAsLastSibling();
        //задаем Static body type, убираем гравитацию и блок Raycast'а
        rb.bodyType = RigidbodyType2D.Static;
        canvasGroup.blocksRaycasts = false;  
    }
    public void OnDrag(PointerEventData eventData)
    {
        //событие, происходящее во время того, как перетаскиваем объект
        //привязываем pivot объекта к курсору или месту нажатия
        rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //событие, происходящее, когда отпустили объект
        //возвращаем первоначальный размер объекта и блокируем Raycast
        rectTrans.localScale = Vector3.one;
        canvasGroup.blocksRaycasts = true;
    }
}
