namespace VRTK.Examples
{
    using UnityEngine;

    public class Gun : VRTK_InteractableObject
    {
        private GameObject bullet;
        private float bulletSpeed = 2000f;
        private float bulletLife = 5f;
        private ReferenceManager _refs;
        private AudioSource _audioSrc;
        private ParticleSystem _ps;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            FireBullet();
        }

        protected void Start()
        {
            bullet = transform.Find("Bullet").gameObject;
            bullet.SetActive(false);
            _refs = FindObjectOfType<ReferenceManager>();
            _audioSrc = GetComponent<AudioSource>();
            _ps = GetComponentInChildren<ParticleSystem>();
        }

        private void FireBullet()
        {
            VRTK_ControllerHaptics.TriggerHapticPulse(_refs.RightController, _audioSrc.clip);
            _audioSrc.Play();
            _ps.Play();

            GameObject bulletClone = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation) as GameObject;
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(-bullet.transform.forward * bulletSpeed);
            Destroy(bulletClone, bulletLife);
        }
    }
}