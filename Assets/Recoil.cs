using UnityEngine;

public class Recoil : MonoBehaviour
{
    public Gun gun;
    public bool aim;

    //Rotation
    Vector3 currentRotation, targetRotation;

    //HipFire recoil
    [Header("HipFire recoil")]
    [SerializeField]
    float recoilX;
    [SerializeField] float recoilY;
    [SerializeField] float recoilZ;

    //ADS recoil
    [Header("ADS recoil")]
    [SerializeField]
    float adsRecoilX;
    [SerializeField] float adsRecoilY;
    [SerializeField] float adsRecoilZ;

    //Settings
    [SerializeField]
    float snappiness, returnSpeed;

    // Start is called before the first frame update
    private void Awake()
    {
        adsRecoilX = recoilX / 2;
        adsRecoilY = recoilY / 2;
        adsRecoilZ = recoilZ / 2;

    }



    // Update is called once per frame
    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.fixedDeltaTime);

        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void RecoilFire()
    {
        aim = gun.aiming;
        if (aim)
            targetRotation += new Vector3(adsRecoilX, Random.Range(-adsRecoilY, adsRecoilY), Random.Range(-adsRecoilZ, adsRecoilZ));
        else
            targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
    }
}
