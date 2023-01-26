using System;
using UnityEngine;

namespace Player_Interactions
{
    public class AttachSocketToPlayer : MonoBehaviour
    {
        public GameObject centerEyeAnchor;
        private float rotationSpeed;
    
        private void Update()
        {
            //Put holster halfway between the body
            var position = centerEyeAnchor.transform.position;
            var holsterTransform = transform;
        
            holsterTransform.position = new Vector3(position.x,  position.y * 0.65f ,
                position.z);

            var eulerAngles = centerEyeAnchor.transform.eulerAngles;
        
            var rotationDifference = Math.Abs(eulerAngles.y - holsterTransform.eulerAngles.y);

            var finalRotationSpeed = rotationDifference switch
            {
                // Make rotation speed faster if holster rotation is further away from the central eye camera
                >= 60 => rotationDifference * 2,
                >= 40 and < 60 => rotationSpeed,
                >= 20 and < 40 => rotationSpeed / 2,
                >= 0 and < 20 => rotationSpeed / 4,
                _ => rotationSpeed
            };
            
            //the step size is equal to speed times frame time
            var step = finalRotationSpeed * Time.deltaTime;
            
            //rotate our transform a step closer to the target's
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                Quaternion.Euler(0, eulerAngles.y, 0), step);
        }
    }
}
