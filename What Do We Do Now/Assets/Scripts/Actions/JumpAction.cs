using DaikonForge.Tween;

using UnityEngine;
using System;

public class JumpAction : MonoBehaviour, IAction
{
    private Action _callback;
    private bool _isMoving = false;
    private int _direction = 1;

    [SerializeField] private bool _jump; //used to trigger this behaviour in the editor
    private float _height;
    private float _distance;

    private ShapeeBase _shappie;


    public void Perform(Action callback)
    {
        _callback = callback;
        Debug.Log("Performing Jump Action");

        var trans = _shappie.Body.transform;
        var origSize = trans.localScale;

        var scaleIn = trans.TweenScaleTo(new Vector3(trans.localScale.x, trans.localScale.y * 0.5f)).SetDuration(0.1f).OnCompleted((sender) => JumpSound());
        var scaleOut = trans.TweenScaleTo(origSize).SetDuration(0.15f).OnStarted((sender) => Jump());

        var tweenGroup = new TweenGroup().SetMode(TweenGroupMode.Sequential).AppendTween(scaleIn).AppendTween(scaleOut);

        tweenGroup.Play();

        //trans.TweenScale()
        //    .SetStartValue(trans.localScale)
        //    .SetEndValue(new Vector3(trans.localScale.x, trans.localScale.y * 0.5f))
        //    .SetDuration(.1f)
        //    .Chain(
        //        trans.TweenScale()
        //        .SetEndValue(origSize).SetDuration(0.15f)).OnCompleted(sender => Jump()).Play();

		
    }

    private void Awake()
    {
        _height = 6.5f;
        _distance = 2.5f;

        _shappie = transform.GetComponent<ShapeeBase>();
    }

    private void JumpSound()
    {
        // play a sound
        Debug.Log("Play a jump sound");
        AudioManager.PlaySound("FX/Character/Jump", gameObject);
    }

    private void Jump()
    {
        _direction = gameObject.GetComponent<ShapeeBase>().Direction;
        var jumpVector = new Vector2(_distance * _direction, _height);
        rigidbody2D.AddForce(jumpVector, ForceMode2D.Impulse);
        rigidbody2D.AddTorque(UnityEngine.Random.Range(-2f, 2f));
        _isMoving = true;
    }

    private void Update()
    {
        if (_jump)
        {
            Perform(null);
            _jump = false;
        }

        if (_isMoving && rigidbody2D.velocity.sqrMagnitude <= 0.1f && (Mathf.Abs(rigidbody2D.angularVelocity) <= 0.01f))
        {
            Debug.Log("Done jumping");
            _isMoving = false;
            if (_callback != null)
            {
                _callback();
            }
        }
    }
}
