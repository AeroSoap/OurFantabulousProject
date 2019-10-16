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

    
}
