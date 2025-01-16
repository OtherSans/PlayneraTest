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
        //событие, которое наступает, как только отпустили объект в области этого GameObject
        if (eventData.pointerDrag != null && eventData.pointerDrag.gameObject.CompareTag("GrabbingObject"))
        {
            //после проверки задаем текущую позицию предмета
            eventData.pointerDrag.GetComponent<RectTransform>().position = new Vector3(eventData.pointerDrag.transform.position.x, GetComponent<RectTransform>().position.y, 10f);
        }
    }
}
