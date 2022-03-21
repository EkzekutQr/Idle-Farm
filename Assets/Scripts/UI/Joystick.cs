using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{

    public RectTransform center;
    public RectTransform knob;
    public float range;
    public bool fixedJoystick;

    public Vector2 direction;

    private bool _isShow;


    private Touch touch;


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
        
        Move();
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

        knob.position = pos;
        center.position = pos;
    }
}
