void Start()
    {
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        /*jumped = false;
        if(jumpDelay <= 0)
        {
            jumpDelay = 5;
        }*/
    }

    void Update()
    {
        if (knockBackCounter <= 0)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            moveDirection = new Vector3(moveHorizontal * moveSpeed, moveDirection.y);

            if (moveHorizontal > 0)
            {
                transform.eulerAngles = new Vector3(0, 90);
            }
            else if (moveHorizontal < 0)
            {
                transform.eulerAngles = new Vector3(0, -100);
            }

            if (controller.isGrounded)
            {
                moveDirection.y = -1f;
                if (Input.GetKey(KeyCode.KeypadPlus))
                {
                    moveDirection.y = jumpForce;
                    jumped = true;
                    //StartCoroutine(SpamBlockco());
                }
                else if(!Input.GetKey(KeyCode.KeypadPlus))
                {
                    jumped = false;
                }
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }