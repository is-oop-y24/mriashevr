namespace Backups.Entities
{
    public static class IdGenerator
    {
        private static int _id;

        public static int NewId()
        {
            return ++_id;
        }
    }
}