namespace GAT.Core.Devices.Gen7
{
    internal class TransactionIdGenerator
    {
        private int _tid = 1;
        private object _tidLock = new object();
        public int GetTID()
        {
            //lock to ensure unique TID
            lock (_tidLock)
            {
                _tid++;

                if (_tid < 0)
                {
                    _tid = 1;
                }

                return _tid;
            }
        }
    }
}
