using DaikonForge.Tween;

using UnityEngine;
using System.Collections.Generic;
using System;

using UnityEngine.UI;

public class ShapeeBase : MonoBehaviour
{
    public GameObject Body;
    public GameObject FaceFocused;
    public GameObject FaceHappy;
    public GameObject FaceDead;

    public Queue<IAction> ActionQueue { get; private set; }

    private GameObject _winCanvas;

    private EasingType _textEase = EasingType.Bounce;

    private TweenEasingCallback _easingFunc;

    private bool _isDead;
    public bool IsDead
    {
        get { return _isDead; }
        private set
        {
            _isDead = value;
            if (!IsDead) return;
            ActionQueue.Clear();
            if (OutOfActions != null)
            {
                OutOfActions(this);
            }
        }
    }


    public event Action<ShapeeBase> OutOfActions;

    private int _direction;
    public int Direction //  -1 for left, 1 for right
    {
        get { return _direction; }
        set
        {
            if (value != -1 && value != 1)
            {
                return;
            }
            _direction = value;
        }
    } 

    private Action<ShapeeBase> _actionCompleteCallback;

    public void Reset()
    {
        Debug.Log("Resetting Shapee");
        ActionQueue = new Queue<IAction>();
        IsDead = false;
        Direction = 1;

        SetFace(0);
    }

    public void PerformNextAction(Action<ShapeeBase> callback)
    {
        _actionCompleteCallback = callback;

        if (ActionQueue.Count > 0)
        {
            ActionQueue.Dequeue().Perform(ActionComplete);
            Debug.Log("Performinc action, " + ActionQueue.Count + " actions left");
        }
        else if (OutOfActions != null)
        {
            OutOfActions(this);
        }
    }

    private void Awake()
    {
        Reset();

        _winCanvas = Resources.Load<GameObject>("Prefabs/UI/WinCanvas");
        _easingFunc = TweenEasingFunctions.GetFunction(_textEase);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.layer)
        {
            case 10:        // obstacles
                if (!IsDead)
                {
                    // play a sound for death
                    AudioManager.PlaySound("FX/Character/Death", gameObject);
                    IsDead = true;
		    SetFace(1);		
                }
                break;
            case 11:        // exit
                Debug.Log("SUCCESS!");
                var canvas = Instantiate(_winCanvas) as GameObject;
                var text = canvas.GetComponentInChildren<Text>();
                text.TweenScaleTo(new Vector3(4, 4)).SetDuration(.75f).SetEasing(_easingFunc).Play();

                SetFace(2);
                break;
        }
    }

    private void ActionComplete()
    {
        _actionCompleteCallback(this);
    }

    private void SetFace(int faceIndex)
    {
        FaceFocused.SetActive(false);
        FaceHappy.SetActive(false);
        FaceDead.SetActive(false);

        switch (faceIndex)
        {
            case 0:
                FaceFocused.SetActive(true);
                break;
            case 1:
                FaceDead.SetActive(true);
                break;
            case 2:
                FaceHappy.SetActive(true);
                break;
        }
    }
}
