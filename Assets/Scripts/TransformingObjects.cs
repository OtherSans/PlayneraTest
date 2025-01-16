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
        //�������� ������� ����� ����, ��� ������ ������������� ������
        //����������� ������, ����� �������� ��� �� ��� �����
        rectTrans.localScale = scaleObjectParams;
        //������ ������ ������� � ��������, ����� �� ��� ������ ������ ���������������� ��������
        gameObject.transform.SetAsLastSibling();
        //������ Static body type, ������� ���������� � ���� Raycast'�
        rb.bodyType = RigidbodyType2D.Static;
        canvasGroup.blocksRaycasts = false;  
    }
    public void OnDrag(PointerEventData eventData)
    {
        //�������, ������������ �� ����� ����, ��� ������������� ������
        //����������� pivot ������� � ������� ��� ����� �������
        rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //�������, ������������, ����� ��������� ������
        //���������� �������������� ������ ������� � ��������� Raycast
        rectTrans.localScale = Vector3.one;
        canvasGroup.blocksRaycasts = true;
    }
}
