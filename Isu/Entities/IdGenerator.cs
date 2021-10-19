namespace Isu.Entities
{
    public class IdGenerator
    {
        private static int _id = 0;

        public static int NewId()
        {
            int id = (++_id) + 10000;
            return id;
        }
    }
}