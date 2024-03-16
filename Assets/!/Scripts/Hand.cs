using UnityEngine;
using UnityEngine.XR.Hands;

public enum Handedness
{
    Left = 0,
    Right = 1
}

public class Hand : MonoBehaviour
{
    [SerializeField] private Handedness m_Handedness;

    [SerializeField] private Transform[] m_HandJoints;

    public Handedness Handedness => m_Handedness;

    public void SetHandJointPose(XRHandJointID handJointID, Pose pose)
    {
        int handJointIndex = handJointID == XRHandJointID.Wrist ? 0 : ((int)handJointID - 1);
        m_HandJoints[handJointIndex].SetPositionAndRotation(pose.position, pose.rotation);
    }
}
