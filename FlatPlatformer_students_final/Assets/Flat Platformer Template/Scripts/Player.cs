/* By: Bulat Sultanov, edited by Ryan Schepppler
 * Last Edited: 10/9/19
 * Description: Script that is input for the player, has many useful features including checking below the player for ground(Default layer), 
 * and handles sword movement and some mirroring in addition to normal platforming
 */
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

    public float WalkSpeed;
    public float JumpForce;
    public AnimationClip _walk, _jump;
    public Animation _Legs;
    public Transform _Blade, _GroundCast;
    public Camera cam;
    public bool mirror;
    public AudioClip sfxJump;
    public AudioClip sfxWalk;


    private bool _canJump, _canWalk;
    private bool _isWalk, _isJump;
    private float rot, _startScale;
    private Rigidbody2D rig;
    private Vector2 _inputAxis;
    private RaycastHit2D _hit;
    private LayerMask _layerMask;
    private AudioSource audioSource;

    public bool Active = true;



    public void DisablePlayer()
    {
        Active = false;
    }
    public void EnablePlayer()
    {
        Active = true;
    }

    void Start()
    {
        _layerMask = LayerMask.GetMask("Default");
        rig = gameObject.GetComponent<Rigidbody2D>();
        _startScale = transform.localScale.x;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Active)
        {
            if (_hit = Physics2D.Linecast(new Vector2(_GroundCast.position.x, _GroundCast.position.y + 0.2f), _GroundCast.position, _layerMask))
            {
                if (!_hit.transform.CompareTag("Player"))
                {
                    _canJump = true;
                    _canWalk = true;
                }
            }
            else _canJump = false;

            _inputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (_inputAxis.y > 0 && _canJump)
            {
                _canWalk = false;
                _isJump = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (Active)
        {
            Vector3 dir = cam.ScreenToWorldPoint(Input.mousePosition) - _Blade.transform.position;
            dir.Normalize();

            if (cam.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x + 0.2f)
                mirror = false;
            if (cam.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x - 0.2f)
                mirror = true;

            if (!mirror)
            {
                rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.localScale = new Vector3(_startScale, _startScale, 1);
                _Blade.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);

            }
            if (mirror)
            {
                rot = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
                transform.localScale = new Vector3(-_startScale, _startScale, 1);
                _Blade.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);

            }

            if (_inputAxis.x != 0)
            {
                rig.velocity = new Vector2(_inputAxis.x * WalkSpeed * Time.deltaTime, rig.velocity.y);

                if (_canWalk)
                {
                    _Legs.clip = _walk;
                    _Legs.Play();
                    audioSource.clip = sfxWalk;
                    audioSource.Play();
                }
            }

            else
            {
                rig.velocity = new Vector2(0, rig.velocity.y);
            }

            if (_isJump)
            {
                rig.AddForce(new Vector2(0, JumpForce));
                _Legs.clip = _jump;
                _Legs.Play();
                audioSource.clip = sfxJump;
                audioSource.Play();
                _canJump = false;
                _isJump = false;
            }
        }
    }

    public bool IsMirror()
    {
        return mirror;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, _GroundCast.position);
    }



}
