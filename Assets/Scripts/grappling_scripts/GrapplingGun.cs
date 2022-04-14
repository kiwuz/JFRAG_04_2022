using UnityEngine;

public class GrapplingGun : MonoBehaviour
{

    private Vector3 grapplePoint;
    [SerializeField] private LayerMask whatIsGrappleable;
    public Transform cam, player, gunTip;
    [SerializeField] private AudioClip grapple_shoot;     
    private float maxDistance = 100f;
    private SpringJoint joint;
    private PauseMenu PM;


    void Start(){
        PM = FindObjectOfType<PauseMenu>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !PM.GameIsPaused)
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }

    }

    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, whatIsGrappleable))
        {
            AudioSource.PlayClipAtPoint(grapple_shoot,transform.position);
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.75f;
            joint.minDistance = distanceFromPoint * 0.25f;
            //spring behaviour
            joint.spring = 200.5f;
            joint.damper = 20f;
            joint.massScale = 4.5f;
        }
    }

    public void StopGrapple()
    {
        Destroy(joint);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}