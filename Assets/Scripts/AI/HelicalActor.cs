using System.Collections;
using UnityEngine;

namespace AI
{

    public class HelicalActor : LinearActor
    {
        [SerializeField] protected float _angularSpeed = default;
        [SerializeField] protected Transform _centerOfMass = null;

        protected override void SetSpeed()
        {
            base.SetSpeed();

            //_rigidBody.a

            //_rigidBody.centerOfMass = _centerOfMass.position;
            //_rigidBody.angularVelocity = new Vector3(0.0f, 0.0f, _angularSpeed);

            transform.RotateAround(_centerOfMass.position, Vector3.right, _angularSpeed * Time.deltaTime);
            _angularSpeed += 10.0f;

        }

        private void Update()
        {
            //_centerOfMass.position = new Vector3(_centerOfMass.position.x, _centerOfMass.position.y, transform.position.z); 
        }



    }


}