using UnityEngine;
using System.Collections;

public class RobeBridgeCreator : MonoBehaviour {

    public GameObject rightAnchor, linkPrefab;
    public int numLinks;

	void Start () {
        // Anchors
        ////////////////////////////
        GetComponent<HingeJoint2D>().connectedAnchor = transform.position;
        rightAnchor.GetComponent<HingeJoint2D>().connectedAnchor = rightAnchor.transform.position;


        // Joints
        ///////////////////////////
        float gapDist = (transform.position - rightAnchor.transform.position).magnitude;
        float linkSize = linkPrefab.GetComponent<BoxCollider2D>().size.y;

        float linkDist = (gapDist - numLinks * linkSize) / (numLinks + 1);

        GameObject lastJoint = gameObject;
        for (int i = 0; i < numLinks; ++i) {
            Vector3 pos = new Vector3((linkDist + linkSize / 2) * (i + 1), transform.position.y, transform.position.z);
            GameObject link = Instantiate(linkPrefab, pos, Quaternion.identity) as GameObject;

            DistanceJoint2D joint = link.GetComponent<DistanceJoint2D>();
            joint.connectedBody = lastJoint.rigidbody2D;

            joint.anchor = new Vector2(-linkSize / 2, 0);
            joint.connectedAnchor = new Vector2(i == 0 ? 0 : linkSize / 2, 0);

            joint.distance = linkDist;

            lastJoint = link;
        }

        DistanceJoint2D rightDistJoint = rightAnchor.AddComponent<DistanceJoint2D>();
        rightDistJoint.connectedBody = lastJoint.rigidbody2D;
        rightDistJoint.anchor = new Vector2(0, 0);
        rightDistJoint.connectedAnchor = new Vector2(linkSize / 2, 0);
        rightDistJoint.distance = linkDist;
	}

}
