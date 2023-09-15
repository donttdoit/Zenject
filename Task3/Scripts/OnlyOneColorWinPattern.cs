using System;
using System.Linq;

namespace Task3 
{
    public class OnlyOneColorWinPattern : IWinCondition
    {
        private SpheresList _spheresList;
        private SphereType _winSphereType;

        public OnlyOneColorWinPattern(SpheresList spheresList, SphereType winSphereType)
        {
            _spheresList = spheresList;
            _winSphereType = winSphereType;
        }



        public bool CheckWinResult()
        {
            bool IsOnlyOneColorWin = !_spheresList.Spheres.Any(sphere => sphere.SphereType == _winSphereType);

            return IsOnlyOneColorWin;
        }
    }
}

