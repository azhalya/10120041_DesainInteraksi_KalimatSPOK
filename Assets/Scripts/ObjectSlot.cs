using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Type _type;
    
    public enum Type
    {
        Question,
        Answer,
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableObject draggableObject = dropped.GetComponent<DraggableObject>();
            if (draggableObject.type.ToString() != _type.ToString())
            {
                draggableObject.parentAfterDrag = transform;
            }
        }
    }
}
