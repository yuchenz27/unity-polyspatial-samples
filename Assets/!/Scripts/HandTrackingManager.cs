using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Hands;

public class HandTrackingManager : MonoBehaviour
{
    [SerializeField] private Hand m_LeftHand;

    [SerializeField] private Hand m_RightHand;

    private XRHandSubsystem m_HandSubsystem;

    private static List<XRHandSubsystem> s_SubsystemsReuse = new();

    private void Start()
    {
        m_LeftHand.gameObject.SetActive(false);
        m_RightHand.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (m_HandSubsystem != null && !m_HandSubsystem.running)
        {
            UnsubscribeHandSubsystem();
            return;
        }

        if (m_HandSubsystem == null)
        {
            SubsystemManager.GetSubsystems(s_SubsystemsReuse);
            foreach (var subsystem in s_SubsystemsReuse)
            {
                if (subsystem.running)
                {
                    m_HandSubsystem = subsystem;
                    break;
                }
            }

            if (m_HandSubsystem != null)
            {
                // Setup
                SubscribeHandSubsystem();
            }
        }
    }

    private void SubscribeHandSubsystem()
    {
        if (m_HandSubsystem == null)
            return;

        m_HandSubsystem.trackingAcquired += OnTrackingAcquired;
        m_HandSubsystem.trackingLost += OnTrackingLost;
        m_HandSubsystem.updatedHands += OnUpdatedHands;
    }

    private void UnsubscribeHandSubsystem()
    {
        if (m_HandSubsystem == null)
            return;

        m_HandSubsystem.trackingAcquired -= OnTrackingAcquired;
        m_HandSubsystem.trackingLost -= OnTrackingLost;
        m_HandSubsystem.updatedHands -= OnUpdatedHands;
    }

    private void OnTrackingAcquired(XRHand hand)
    {
        Debug.Log($"[HandTrackingManager] OnTrackingAcquired {hand.handedness}");

        if (hand.handedness == UnityEngine.XR.Hands.Handedness.Left)
            m_LeftHand.gameObject.SetActive(true);
        else if (hand.handedness == UnityEngine.XR.Hands.Handedness.Right)
            m_RightHand.gameObject.SetActive(true);
    }

    private void OnTrackingLost(XRHand hand)
    {
        Debug.Log($"[HandTrackingManager] OnTrackingLost {hand.handedness}");

        if (hand.handedness == UnityEngine.XR.Hands.Handedness.Left)
            m_LeftHand.gameObject.SetActive(false);
        else if (hand.handedness == UnityEngine.XR.Hands.Handedness.Right)
            m_RightHand.gameObject.SetActive(false);
    }

    private void OnUpdatedHands(XRHandSubsystem subsystem, XRHandSubsystem.UpdateSuccessFlags updateSuccessFlags, XRHandSubsystem.UpdateType updateType)
    {
        if ((updateSuccessFlags & XRHandSubsystem.UpdateSuccessFlags.LeftHandJoints) != 0)
        {
            for (int i = (int)XRHandJointID.Wrist; i < (int)XRHandJointID.EndMarker; i++)
            {
                XRHandJointID handJointID = (XRHandJointID)i;
                XRHandJoint handJoint = subsystem.leftHand.GetJoint(handJointID);
                if (handJoint.TryGetPose(out var handJointPose))
                {
                    m_LeftHand.SetHandJointPose(handJointID, handJointPose);
                }
            }
        }

        if ((updateSuccessFlags & XRHandSubsystem.UpdateSuccessFlags.RightHandJoints) != 0)
        {
            for (int i = (int)XRHandJointID.Wrist; i < (int)XRHandJointID.EndMarker; i++)
            {
                XRHandJointID handJointID = (XRHandJointID)i;
                XRHandJoint handJoint = subsystem.rightHand.GetJoint(handJointID);
                if (handJoint.TryGetPose(out var handJointPose))
                {
                    m_RightHand.SetHandJointPose(handJointID, handJointPose);
                }
            }
        }
    }
}
