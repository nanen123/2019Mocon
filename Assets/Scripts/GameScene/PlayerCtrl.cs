using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum STATE
{
    idle,
    moving
}

public enum Plocation
{
    bottom,
    middle,
    left,
    right,
    top
}

public class PlayerCtrl : MonoBehaviour
{
    #region PlayerCtrl Variables

    public float maxX, minX;

    public Plocation loc;
    public GameObject mainCam;
    public bool Movable = false;
    private Vector3 dir;
    public Vector3 toVector;
    public STATE playerState = STATE.idle;
    public Vector2 Movedir;
    private Animator anim;

    #endregion

    #region PlayerCtrl Functions

    private void Awake()
    {
        anim = GetComponent<Animator>();
        SetMinMax();
    }

    private void FixedUpdate()
    {
        Move();

        if (Vector3.Distance(transform.position, toVector) < 0.05f)
            Movable = false;

    }

    void Update()
    {

        CheckInput();

        if (transform.position.x < minX || transform.position.x > maxX) return;

        switch (playerState)
        {
            case STATE.moving:
                transform.Translate(Movedir * Time.deltaTime * 2);
                break;
        }

        GameManager.instance.tempText.text = toVector + " " + transform.position;
    }

    public void Move()
    {
        if (Movable)
        {
            transform.Translate(dir * Time.deltaTime * 4);
        }

    }
    public void CheckInput()
    {
        if (EventSystem.current.IsPointerOverGameObject(0) || EventSystem.current.IsPointerOverGameObject(-1)) return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touchPos = Input.GetTouch(0);
            toVector = Camera.main.ScreenToWorldPoint(touchPos.position);
            if (toVector.x < minX) toVector.x = minX + 1;
            else if (toVector.x > maxX) toVector.x = maxX - 1;
            switch (loc)
            {
                case Plocation.bottom:
                    toVector.y = -6.5f;
                    break;

                case Plocation.middle:
                    toVector.y = 1.5f;
                    break;

                case Plocation.left:
                    toVector.y = 6.5f;
                    break;

                case Plocation.right:
                    toVector.y = 6.5f;
                    break;

                case Plocation.top:
                    toVector.y = 11.5f;
                    break;

            }
            toVector.z = transform.position.z;
            Movable = true;
        }
        toVector.y = transform.position.y;

        if (Input.GetMouseButtonDown(0))
        {
            toVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (toVector.x < minX) toVector.x = minX + 1;
            else if (toVector.x > maxX) toVector.x = maxX - 1;

            switch (loc)
            {
                case Plocation.bottom:
                    toVector.y = -6.5f;
                    break;

                case Plocation.middle:
                    toVector.y = 1.5f;
                    break;

                case Plocation.left:
                    toVector.y = 6.5f;
                    break;

                case Plocation.right:
                    toVector.y = 6.5f;
                    break;

                case Plocation.top:
                    toVector.y = 11.5f;
                    break;

            }
            toVector.z = transform.position.z;
            Movable = true;
        }
        dir = Vector3.Normalize(toVector - transform.position);
        #endregion

    }

    public void SetMinMax()
    {
        switch (loc)
        {
            case Plocation.bottom:
                minX = -7;
                maxX = 35;
                break;

            case Plocation.middle:
                break;

            case Plocation.left:
                break;

            case Plocation.right:
                break;

            case Plocation.top:
                break;

        }
    }
}