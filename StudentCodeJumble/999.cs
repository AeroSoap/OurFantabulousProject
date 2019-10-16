

        void Awake()
        {
            controls[player_id] = this;
        }

        void OnDestroy()
        {
            controls.Remove(player_id);
        }

        void Update()
        {

            move = Vector2.zero;
            jump_hold = false;
            jump_press = false;
            action_hold = false;
            action_press = false;

            if (Input.GetKey(left_key))
                move += -Vector2.right;
            if (Input.GetKey(right_key))
                move += Vector2.right;
            if (Input.GetKey(up_key))
                move += Vector2.up;
            if (Input.GetKey(down_key))
                move += -Vector2.up;
            if (Input.GetKey(jump_key))
                jump_hold = true;
            if (Input.GetKeyDown(jump_key))
                jump_press = true;
            if (Input.GetKey(action_key))
                action_hold = true;
            if (Input.GetKeyDown(action_key))
                action_press = true;

            float move_length = Mathf.Min(move.magnitude, 1f);
            move = move.normalized * move_length;
        }


        //------ These functions should be called from the Update function, not FixedUpdate
        public Vector2 GetMove()
        {
            return move;
        }

        public bool GetJumpDown()
        {
            return jump_press;
        }

        public bool GetJumpHold()
        {
            return jump_hold;
        }

        public bool GetActionDown()
        {
            return action_press;
        }

        public bool GetActionHold()
        {
            return action_hold;
        }

        //-----------

        public static PlayerControls Get(int player_id)
        {
            foreach (PlayerControls control in GetAll())
            {
                if (control.player_id == player_id)
                {
                    return control;
                }
            }
            return null;
        }

        public static PlayerControls[] GetAll()
        {
            PlayerControls[] list = new PlayerControls[controls.Count];
            controls.Values.CopyTo(list, 0);
            return list;
        }

    }

