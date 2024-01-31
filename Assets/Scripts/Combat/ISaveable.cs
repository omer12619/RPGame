namespace RPG.Combat
{
    internal interface ISaveable
    {
        public object CaptureState();
        public void RestoreState(object state);
    }
}