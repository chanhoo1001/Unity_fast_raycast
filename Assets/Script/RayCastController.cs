using UnityEngine;

public class RayCastController : MonoBehaviour {

    const float RAYCART_INTERVAL = 1f;

    bool mHasPrevHit;
    RaycastHit mPrevHit;
    RaycastHit mHit;

    void Start () {
        mPrevHit = new RaycastHit();
    }
	
	void Update () {
        if (Input.GetMouseButton(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out mHit, Mathf.Infinity)) {
                if (mHasPrevHit) {
                    for (float i = 0.1f; i <= 1.0f; i += RAYCART_INTERVAL) {
                        Debug.Log(Vector2.Lerp(mPrevHit.point, mHit.point, i));
                    }
                    mPrevHit = mHit;
                } else {
                    mPrevHit = mHit;
                    mHasPrevHit = true;
                }
            }
        }
    }
}
