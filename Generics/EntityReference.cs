using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

public class EntityReference : MonoBehaviour, IPointerClickHandler
{
    public EcsEntity entity;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{gameObject.name}.OnTriggerEnter");
        entity.Get<OnTriggerEnter>().other = other;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"{gameObject.name}.OnCollisionEnter");
        entity.Get<OnCollisionEnter>().collision = collision;
    }

    private void OnMouseDown()
    {
        //Debug.Log($"{gameObject.name}.OnMouseDown");
        entity.Get<OnMouseDown>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log($"{gameObject.name}.OnPointerClick");
        entity.Get<OnMouseDown>();
    }
}
