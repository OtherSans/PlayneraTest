using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackgroundController : MonoBehaviour, IDropHandler
{
    //���� ������ ������� ��� ���� ������
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Rigidbody2D>() != null)
        {
            //����� ��� Rigidbody, ��������� ������� ����������
            eventData.pointerDrag.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
