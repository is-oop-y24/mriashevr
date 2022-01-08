namespace BackupsExtra.Logging
{
    public interface ILogging
    {
        void LogCreatedRestorePoint();

        void LogCreatedBackupJob();

        void LogDeletedBackupJob();

        void LogMerge();

        void LogAlgorithm();
    }
}