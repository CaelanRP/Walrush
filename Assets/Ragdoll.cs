using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{

    

    void Start()
    {
        data.ragdoll = this;
        refs.rigs = GetComponentsInChildren<Rigidbody>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        data.FixedUpd();
    }


    public Ragdoll_Refs refs;
    [System.Serializable]
    public class Ragdoll_Refs
    {
        [Sirenix.OdinInspector.FoldoutGroup("Manual entry")]
        public Rigidbody head;
        [Sirenix.OdinInspector.FoldoutGroup("Manual entry")]
        public Rigidbody torso;
        [Sirenix.OdinInspector.FoldoutGroup("Manual entry")]
        public Rigidbody hip;

        public Rigidbody[] rigs;

    }

    public Ragdoll_Data data;
    [System.Serializable]
    public class Ragdoll_Data
    {
        public Ragdoll ragdoll;
        public float sinceGrounded;
        public bool isGrounded = false;
        internal float distanceToGround;

        internal void Collide(Collision col)
        {
            if (col.transform.root == ragdoll.transform)
                return;

            if (Vector3.Angle(Vector3.up, col.contacts[0].normal) > 60)
                return;

            isGrounded = true;
            wasGrounded = true;
            sinceGrounded = 0;
            distanceToGround = Mathf.Abs(col.contacts[0].point.y - ragdoll.refs.head.transform.position.y);

        }

        bool wasGrounded = false;
        internal Vector3 movementDirection;

        public void FixedUpd()
        {


            if(!wasGrounded)
            {
                isGrounded = false;
                sinceGrounded += Time.deltaTime;
            }
            else
            {
                sinceGrounded = 0;
            }

            wasGrounded = false;
        }
    }

}
