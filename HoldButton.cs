using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] protected float timeHold;
    public float HoldPercentage
       => Mathf.Clamp(time / timeHold, 0, 1);

    float time;
    protected Button button;
    protected bool isHolding;

    void Awake()
        => button = GetComponent<Button>();


    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        time = 0;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        time = 0;
    }

    void Update()
    {
        if (!isHolding)
            return;

        time += Time.deltaTime;

        if (time >= timeHold)
        {
            isHolding = false;
            time = 0;
            OnHold();
        }
    }

    protected virtual void OnHold() { }
}