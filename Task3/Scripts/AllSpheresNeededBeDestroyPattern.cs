namespace Task3
{
    public class AllSpheresNeededBeDestroyPattern : IWinCondition
    {
        private SpheresList _spheresList;

        public AllSpheresNeededBeDestroyPattern(SpheresList spheresList)
        {
            _spheresList = spheresList;
        }
        public bool CheckWinResult()
        {
            return _spheresList.GetCountOfSpheres() == 0;
        }

    }
}

