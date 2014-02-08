namespace NBitcoin.Requests
{
    internal class BackupWalletRequest
    {
        private string _targetPath;

        public string TargetPath
        {
            get { return _targetPath; }
            set
            {
                _targetPath = value.Replace("\\", "/");
            }
        }
    }
}
