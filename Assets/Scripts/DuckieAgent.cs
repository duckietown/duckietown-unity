﻿using MLAgents;
using UnityEngine;

public class DuckieAgent : Agent {
    Rigidbody rigidBody;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }

    public override void AgentReset() {
        if (transform.position.y < -.5) { // Falling
            transform.position = new Vector3(2.25f, 0.1f, 1.25f); // FIXME
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }
    }

    public override void CollectObservations()
    {
        // Calculate relative position
        //Vector3 relativePosition = Target.position - this.transform.position;

        // Relative position
        AddVectorObs(transform.position.x);
        AddVectorObs(transform.position.z);

        // Distance to edges of platform
        //AddVectorObs((this.transform.position.x + 5)/5);
        //AddVectorObs((this.transform.position.x - 5)/5);
        //AddVectorObs((this.transform.position.z + 5)/5);
        //AddVectorObs((this.transform.position.z - 5)/5);

        // Agent velocity
        //AddVectorObs(rigidBody.velocity.x/5);
        //AddVectorObs(rigidBody.velocity.z/5);
    }

    //public float speed = 10;
    //private float previousDistance = float.MaxValue;
    public override void AgentAction(float[] vectorAction, string textAction)
    {
        // Rewards
        /*float distanceToTarget = Vector3.Distance(this.transform.position,
          Target.position);*/

        // Reached target
        /*if (distanceToTarget < 1.42f)
          {
          Done();
          AddReward(1.0f);
          }*/

        // Getting closer
        /*if (distanceToTarget < previousDistance)
          {
          AddReward(0.1f);
          }*/

        // Time penalty
        //AddReward(-0.05f);

        // Fell off platform
        if (transform.position.y < -0.5) {
            AddReward(-1.0f);
            Done();
        }

        //previousDistance = distanceToTarget;

        // Actions, size = 2
        /*Vector3 controlSignal = Vector3.zero;
          controlSignal.x = Mathf.Clamp(vectorAction[0], -1, 1);
          controlSignal.z = Mathf.Clamp(vectorAction[1], -1, 1);
          Debug.Log(controlSignal);
          rigidBody.AddForce(controlSignal * speed);*/

        // FIXME Rewarding system needs to be completed
        //For locomotion tasks, a small positive reward (+0.1) for forward velocity is typically used.


        // FIXME They added Axis to settings for agents...
        //motor = maxMotorTorque * Input.GetAxis("Vertical"); // FIXME TEST
        //steering = maxSteeringAngle * Input.GetAxis("Horizontal"); // FIXME TEST
        //Debug.Log(vectorAction[0]);

        float motor = maxMotorTorque * vectorAction[0];
        float steering = maxSteeringAngle * vectorAction[1];

        WheelCollider[] colliders = GetComponentsInChildren<WheelCollider>();
        colliders[1].motorTorque = colliders[2].motorTorque = motor;
        colliders[1].steerAngle = colliders[2].steerAngle = steering;
        /*Debug.Log(colliders[0].mass);
          Debug.Log(colliders[1].mass);
          Debug.Log(colliders[2].mass);*/
        /*colliders[0].motorTorque = */
        /*colliders[0].steerAngle = */

        // FIXME Visuals for wheels (rotation for movement and steering angles)
        //Vector3 position;
        //Quaternion rotation;
        //colliders[0].GetWorldPose(out position, out rotation); // XXX
        //colliders[0].transform.GetChild(0).transform.position = position;
        //colliders[0].transform.GetChild(0).transform.rotation = rotation;
        //Debug.Log(position);
        //Debug.Log(rotation);
        //colliders[0].GetComponentInParent<MeshFilter>().transform.rotation = rotation;
        //colliders[0].GetComponentInParent<MeshFilter>().transform.position = position;
        //colliders[0].GetComponentInParent<MeshFilter>().transform.rotation = rotation;
        //colliders[1].GetWorldPose(out position, out rotation); // XXX
        //colliders[1].transform.GetChild(0).transform.rotation = rotation;
        //colliders[1].GetComponentInParent<MeshFilter>().transform.rotation = rotation;
        /*colliders[1].GetComponentInParent<MeshFilter>().transform.position = position;
          colliders[1].GetComponentInParent<MeshFilter>().transform.rotation = rotation;*/
    }
}
