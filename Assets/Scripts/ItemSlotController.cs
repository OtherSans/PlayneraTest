using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemSlotController : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //�������, ������� ���������, ��� ������ ��������� ������ � ������� ����� GameObject
        if (eventData.pointerDrag != null && eventData.pointerDrag.gameObject.CompareTag("GrabbingObject"))
        {
            //����� �������� ������ ������� ������� ��������
            eventData.pointerDrag.GetComponent<RectTransform>().position = new Vector3(eventData.pointerDrag.transform.position.x, GetComponent<RectTransform>().position.y, 10f);
        }
    }
}
