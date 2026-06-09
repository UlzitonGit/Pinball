using System;
using UnityEngine;
using Zenject;
    
public class GatesController: MonoBehaviour
{
    [SerializeField] private GatesDataSO gatesData;
    [SerializeField] HingeJoint hingeJointLeft;
    [SerializeField] HingeJoint hingeJointRight;
    [SerializeField] HingeJoint hingeJointSpawner;
    private JointSpring jointSpringReleased = new();
    private JointSpring jointSpringPressed = new();
    private bool leftFlipperPressed, rightFlipperPressed, spawnerFlipperPressed;
    private GatesInputHandler inputHandler;
    private JointSpring spring;

    [Inject]
    private void Construct(GatesInputHandler _inputHandler)
    {
        this.inputHandler = _inputHandler;
        inputHandler.Enable();
        
        jointSpringPressed.spring = jointSpringReleased.spring = gatesData.hitStrength;
        jointSpringPressed.damper = jointSpringReleased.damper = gatesData.dampening;
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
        if (spawnerFlipperPressed)
        {
            hingeJointSpawner.spring = jointSpringPressed;
        }
        else
        {
            hingeJointSpawner.spring = jointSpringReleased;
        }
        leftFlipperPressed = inputHandler.inputX > 0;
        rightFlipperPressed = inputHandler.inputZ > 0;
        spawnerFlipperPressed = inputHandler.inputSpace > 0;
    }
    
}
