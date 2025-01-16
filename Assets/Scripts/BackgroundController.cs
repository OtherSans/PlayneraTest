using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackgroundController : MonoBehaviour, IDropHandler
{
    //если объект отпущен вне зоны слотов
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Rigidbody2D>() != null)
        {
            //мен€€ тип Rigidbody, добавл€ем объекту гравитацию
            eventData.pointerDrag.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
