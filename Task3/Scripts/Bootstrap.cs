using UnityEngine;
using Zenject;

namespace Task3
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private SpheresList _spheresList;
        private Level _level;

        [Inject]
        private void Construct(Level level)
        {
            _level = level;
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _level.SetConditionToWin(new AllSpheresNeededBeDestroyPattern(_spheresList));
                Debug.Log("Победа только тогда, когда все сферы лопнуты");
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                _level.SetConditionToWin(new OnlyOneColorWinPattern(_spheresList, SphereType.RedSphere));
                Debug.Log("Победа только тогда, когда все красные сферы лопнуты");
            }

        }
    }
}

