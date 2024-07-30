using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Type _type;
    [SerializeField] public Kalimat _kalimat;
    
    public enum Type
    {
        Question,
        Answer,
    }
    
    public enum Kalimat
    {
        Subjek,
        Predikat,
        Objek,
        Keterangan
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
