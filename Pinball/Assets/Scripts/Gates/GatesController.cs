using System;
using UnityEngine;
using Zenject;
    
public class GatesController: MonoBehaviour
{
    [SerializeField] float hitStrength = 80000f;
    [SerializeField] float dampening = 250f;
    [SerializeField] HingeJoint hingeJointLeft;
    [SerializeField] HingeJoint hingeJointRight;
    private JointSpring jointSpringReleased = new();
    private JointSpring jointSpringPressed = new();
    private bool leftFlipperPressed, rightFlipperPressed;
    private GatesInputHandler inputHandler;
    private float flipperInput;
    private JointSpring spring;

    [Inject]
    private void Construct(GatesInputHandler _inputHandler)
    {
        this.inputHandler = _inputHandler;
        inputHandler.Enable();
        
        jointSpringPressed.spring = jointSpringReleased.spring = hitStrength;
        jointSpringPressed.damper = jointSpringReleased.damper = dampening;
        jointSpringPressed.targetPosition = hingeJointLeft.limits.max;
        jointSpringReleased.targetPosition = hingeJointLeft.limits.min;
    }
    private void OnDisable()
    {
        if(inputHandler != null)
            inputHandler.Disable();
    }

    void Update()
    {
        if (leftFlipperPressed)
        {
            hingeJointLeft.spring = jointSpringPressed;
        }
        else
        {
            hingeJointLeft.spring = jointSpringReleased;
        }
        if (rightFlipperPressed)
        {
            hingeJointRight.spring = jointSpringPressed;
        }
        else
        {
            hingeJointRight.spring = jointSpringReleased;
        }

        leftFlipperPressed = inputHandler.inputX > 0;
        rightFlipperPressed = inputHandler.inputZ > 0;
    }
    
}
