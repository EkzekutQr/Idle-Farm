using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public RectTransform center;
    public RectTransform knob;
    public float range;
    public bool fixedJoystick;

    public Vector2 direction;

    private Vector2 _start;
    private bool _isOverPanel;
    private bool _isShow;

    [SerializeField]
    AnimatorManager animatorManager;

    private int movingTouchIndex = 0;
    private Touch touch;

    [SerializeField]
    private bool canMove = false;

    public bool IsShow { get => _isShow; }

    [SerializeField]
    List<Touch> touches = new List<Touch>();

    private void Start()
    {
        ShowHide(false, Vector2.zero);
        touch = new Touch();
    }

    private void Update()
    {
        touches.Clear();
        touches.AddRange(Input.touches);
        
        if(Input.touchCount != 0)
        {
            //Debug.Log(Input.GetTouch(movingTouchIndex).phase);
            //Debug.Log(Input.GetTouch(movingTouchIndex));
            //Debug.Log(Input.touchCount - 1);
            //Debug.Log(Input.touches[Input.touchCount - 1].position);
        }
        //movingTouchIndex = touches[touches.Count - 1].
        Move();
        //Debug.Log("Touch position" + touch.position);
        //Debug.Log("joystick position" + knob.position);
        //Debug.Log(Input.touches[Input.touchCount - 1].position);
    }

    private void Move()
    {
        if (Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                if(Input.touches[i].position.x < 500)
                {
                    touch = Input.touches[i];
                }
            }

            Vector2 pos;

            pos = touch.position;

            if (touch.phase == TouchPhase.Began/*(TouchPhase.Moved | TouchPhase.Stationary)*//* && _isOverPanel*/)
            {
                ShowHide(true, pos);
            }
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary /*&& IsShow*/)
            {
                knob.position = pos;
                knob.position = center.position + Vector3.ClampMagnitude(knob.position - center.position, center.sizeDelta.x * range);

                if (knob.position != (Vector3)touch.position && !fixedJoystick)
                {
                    Vector3 outsideBoundsVector = (Vector3)touch.position - knob.position;
                    center.position += outsideBoundsVector;
                }

                direction = (knob.position - center.position).normalized;
            }
            if (touch.phase == (TouchPhase.Ended)/* && IsShow*/)
            {
                ShowHide(false, Vector2.zero);
                direction = Vector2.zero;
            }
        }
    }

    private void ShowHide(bool state, Vector2 pos)
    {
        center.gameObject.SetActive(state);
        knob.gameObject.SetActive(state);
        _isShow = state;


        _start = pos;

        knob.position = pos;
        center.position = pos;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //movingTouchIndex = Input.touches.Length - 1;
        _isOverPanel = true;
        canMove = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canMove = false;
        _isOverPanel = false;
    }
}
